using balasolu.statics;
using balasolu.web.extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace balasolu.web
{
    sealed class Program
    {
        public static int Main(string[] args) =>
            MainAsync(args).GetAwaiter().GetResult();

        static async Task<int> MainAsync(string[] args)
        {
            var loggerConfig = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Logger(config =>
                {
                    config
                    .MinimumLevel.Information()
                    .WriteTo.Console()
                    .WriteTo.File(Logs.CallingAssembly);
                });

            Log.Logger = loggerConfig.CreateLogger();

            Log.Information("updating environment variables...");
            foreach (DictionaryEntry environmentVariable in Environment.GetEnvironmentVariables())
            {
                if (environmentVariable.Key.ToString()!.Contains("APPLICATION") && environmentVariable.Value!.ToString()!.StartsWith('/'))
                    Environment.SetEnvironmentVariable(environmentVariable.Key.ToString()!, await File.ReadAllTextAsync(environmentVariable.Value.ToString()!));
            }
            Log.Information("environment variables updated!");

            Log.Information("building configuration...");
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables();

            var configuration = configurationBuilder.Build();
            Log.Information("configuration built!");

            var host = CreateHostBuilder(args, configuration).Build();

            try
            {
                await host.MigrateAsync();
                await host.RunAsync();
                return 0;
            }
            catch (Exception e)
            {
                Log.Fatal(e, "host terminated unexpectedly.");
                if (Debugger.IsAttached && Environment.UserInteractive)
                {
                    Console.WriteLine(Environment.NewLine + "press any key to exit...");
                    Console.Read();
                }
                return e.HResult;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args, IConfiguration configuration) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(x =>
            {
                x.AddConfiguration(configuration);
            })
            .ConfigureWebHostDefaults(x =>
            {
                x.UseSerilog();
                x.UseUrls("http://*:5000");
                x.UseStartup<Startup>();
            });
    }
}
