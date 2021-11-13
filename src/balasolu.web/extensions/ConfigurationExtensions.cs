using balasolu.web.options;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace balasolu.web.extensions
{
    static class ConfigurationExtensions
    {
        public static Task<string> BuildSqlConnectionStringAsync(this IConfiguration configuration)
        {
            var options = new SqlClientOptions();
            configuration.GetSection("APPLICATION:SQLCLIENTOPTIONS").Bind(options);
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Server={options.Server};");
            stringBuilder.Append($"User Id={options.Username};");
            stringBuilder.Append($"Password={options.Password};");
            stringBuilder.Append($"Database={options.Database};");
            return Task.FromResult(stringBuilder.ToString());
        }

        public static Task<DiscordOptions> BuildDiscordOptionsAsync(this IConfiguration configuration)
        {
            var options = new DiscordOptions();
            configuration.GetSection("APPLICATION:DISCORDOPTIONS").Bind(options);
            return Task.FromResult(options);
        }
    }
}
