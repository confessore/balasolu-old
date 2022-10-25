using balasolu.contexts;
using balasolu.extensions;
using balasolu.handlers;
using balasolu.models.abstractions;
using balasolu.models.options;
using balasolu.providers;
using balasolu.services;
using balasolu.services.interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using System.Collections;
using System.Diagnostics;
using System.Reflection;

var executingAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
var loggerConfig = new LoggerConfiguration()
    .MinimumLevel.Verbose()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Logger(config =>
    {
        config
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File(string.Concat(executingAssemblyName, ".log"));
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
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
    .AddEnvironmentVariables()
    .Build();
Log.Information("configuration built!");

var defaultConnection = await configuration.BuildDefaultConnectionStringAsync();
var keyConnection = await configuration.BuildKeyConnectionStringAsync();
var cryptoConnection = await configuration.BuildCryptoConnectionStringAsync();
var twitterOptions = await configuration.BuildTwitterOptionsAsync();
var discordOptions = await configuration.BuildDiscordOptionsAsync();
var paypalOptions = await configuration.BuildPaypalOptionsAsync();
var options = new WebApplicationOptions()
{
    ApplicationName = executingAssemblyName,
    Args = args,
    WebRootPath = "wwwroot"
};
var builder = WebApplication.CreateBuilder(options);
builder.Host
    .UseSerilog();
builder.WebHost
    .ConfigureAppConfiguration(x =>
    {
        x.AddConfiguration(configuration);
    })
    .ConfigureServices(async x =>
    {
        x.AddDbContextPool<DefaultDbContext>(x =>
        {
            x.UseMySql(defaultConnection, ServerVersion.AutoDetect(defaultConnection), x =>
            {
                x.MigrationsAssembly(executingAssemblyName);
            });
            x.EnableSensitiveDataLogging();
            x.EnableDetailedErrors();
        });
        x.AddDbContextPool<KeyDbContext>(x =>
        {
            x.UseMySql(keyConnection, ServerVersion.AutoDetect(keyConnection), x =>
            {
                x.MigrationsAssembly(executingAssemblyName);
            });
            x.EnableSensitiveDataLogging();
            x.EnableDetailedErrors();
        });
        x.AddDbContextPool<CryptoDbContext>(x =>
        {
            x.UseMySql(cryptoConnection, ServerVersion.AutoDetect(cryptoConnection), x =>
            {
                x.MigrationsAssembly(executingAssemblyName);
            });
            x.EnableSensitiveDataLogging();
            x.EnableDetailedErrors();
        });
        x.AddDbContextFactory<DefaultDbContext>(x =>
        {
            x.UseMySql(defaultConnection, ServerVersion.AutoDetect(defaultConnection), x =>
            {
                x.MigrationsAssembly(executingAssemblyName);
            });
            x.EnableSensitiveDataLogging();
            x.EnableDetailedErrors();
        });
        x.AddDbContextFactory<KeyDbContext>(x =>
        {
            x.UseMySql(keyConnection, ServerVersion.AutoDetect(keyConnection), x =>
            {
                x.MigrationsAssembly(executingAssemblyName);
            });
            x.EnableSensitiveDataLogging();
            x.EnableDetailedErrors();
        });
        x.AddDbContextFactory<CryptoDbContext>(x =>
        {
            x.UseMySql(cryptoConnection, ServerVersion.AutoDetect(cryptoConnection), x =>
            {
                x.MigrationsAssembly(executingAssemblyName);
            });
            x.EnableSensitiveDataLogging();
            x.EnableDetailedErrors();
        });
        x.AddDataProtection()
            .PersistKeysToDbContext<KeyDbContext>();
        x.AddIdentity<User, Role>(x =>
        {
            x.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<DefaultDbContext>()
        .AddDefaultTokenProviders();
        x.ConfigureSameSiteNone();
        x.AddAuthentication(x =>
        {
            x.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            x.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = DiscordOptions.DiscordDefaults.AuthenticationScheme;
        })
        .AddCookie()
        .AddDiscord(x =>
        {
            x.ClientId = discordOptions.ClientId.Trim();
            x.ClientSecret = discordOptions.ClientSecret.Trim();
            x.SaveTokens = true;
        });
        x.AddRazorPages(x =>
        {
            x.RootDirectory = "/ui/pages";
            x.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
        });
        x.AddServerSideBlazor();
        x.AddControllers();
        x.AddHttpContextAccessor();
        //x.AddHttpClient(executingAssemblyName, client => client.BaseAddress = new Uri("http://localhost:5000"));
        //x.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient(executingAssemblyName));
        x.AddScoped<IAuthService, AuthService>();
        x.AddScoped<ILocalStorageService, LocalStorageService>();
        x.AddScoped<IMarketService, MarketService>();
        x.AddScoped<IAtomService, AtomService>();
        x.AddScoped<IEmailService, EmailService>();
        x.AddTwitterClient(twitterOptions);
        x.AddPaypalClient(paypalOptions);
        //x.AddScoped<IUserService, UserService>();
        x.AddScoped<AuthenticationStateProvider, DefaultRevalidatingServerAuthenticationStateProvider>();
        x.AddScoped<IHostEnvironmentAuthenticationStateProvider>(x =>
        {
            // this is safe because
            //     the `RevalidatingServerAuthenticationStateProvider` extends the `ServerAuthenticationStateProvider`
            var provider = (ServerAuthenticationStateProvider)x.GetRequiredService<AuthenticationStateProvider>();
            return provider;
        });
        x.AddScoped<CircuitHandler, DefaultCircuitHandler>();
        await x.AddQuartzAsync();
    });
try
{
    var application = builder.Build();

    await application.MigrateDefaultDbContextAsync();
    await application.MigrateKeyDbContextAsync();
    await application.MigrateCryptoDbContextAsync();

    await application.InitializeAsync();

    // Configure the HTTP request pipeline.
    if (!application.Environment.IsDevelopment())
    {
        application.UseExceptionHandler("/Error");
    }
    application.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    });
    application.UseCookiePolicy(new CookiePolicyOptions
    {
        MinimumSameSitePolicy = SameSiteMode.Lax
    });
    application.UseStaticFiles();
    application.UseRouting();
    application.UseAuthentication();
    application.UseAuthorization();
    application.UseEndpoints(x =>
    {
        x.MapDefaultControllerRoute();
        x.MapControllers();
        x.MapBlazorHub();
        x.MapFallbackToPage("/_Host");
    });
    await application.RunAsync("http://*:5000");
}
catch (Exception e)
{
    if (e.GetType().Name.Equals("StopTheHostException", StringComparison.Ordinal))
        throw;

    Log.Fatal(e, "host terminated unexpectedly...");
    if (Debugger.IsAttached && Environment.UserInteractive)
    {
        Console.WriteLine(string.Concat(Environment.NewLine, "press any key to exit..."));
        Console.Read();
    }
}
finally
{
    Log.CloseAndFlush();
}
