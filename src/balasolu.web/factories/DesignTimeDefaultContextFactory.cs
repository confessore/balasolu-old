using balasolu.web.contexts;
using balasolu.web.extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;

namespace balasolu.web.factories
{
    sealed class DesignTimeDefaultContextFactory : IDesignTimeDbContextFactory<DefaultContext>
    {
        public DefaultContext CreateDbContext(string[] args)
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

                var connection = await configuration.BuildSqlConnectionStringAsync();
                var optionsBuilder = new DbContextOptionsBuilder<DefaultContext>()
                    .UseMySql(connection, ServerVersion.AutoDetect(connection));
                return new DefaultContext(optionsBuilder.Options);
            }).Result;
        }
    }
}
