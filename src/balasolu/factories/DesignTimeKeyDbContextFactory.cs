using balasolu.contexts;
using balasolu.extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections;
using System.Reflection;

namespace balasolu.factories
{
    sealed class DesignTimeKeyDbContextFactory : IDesignTimeDbContextFactory<KeyDbContext>
    {
        public KeyDbContext CreateDbContext(string[] args)
        {
            return Task.Run(async () =>
            {
                foreach (DictionaryEntry environmentVariable in Environment.GetEnvironmentVariables())
                {
                    if (environmentVariable.Key.ToString()!.Contains("APPLICATION") && environmentVariable.Value!.ToString()!.StartsWith('/'))
                        Environment.SetEnvironmentVariable(environmentVariable.Key.ToString()!, await File.ReadAllTextAsync(environmentVariable.Value.ToString()!));
                }

                var configuration = new ConfigurationBuilder()
                    .AddEnvironmentVariables()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                    .Build();

                var connection = await configuration.BuildKeyConnectionStringAsync();
                var optionsBuilder = new DbContextOptionsBuilder<KeyDbContext>()
                    .UseMySql(connection, ServerVersion.AutoDetect(connection), x =>
                    {
                        x.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                    });
                return new KeyDbContext(optionsBuilder.Options);
            }).Result;
        }
    }
}
