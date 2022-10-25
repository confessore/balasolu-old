using balasolu.models.options;
using System.Text;

namespace balasolu.extensions
{
    public static class ConfigurationExtensions
    {
        public static Task<string> BuildDefaultConnectionStringAsync(this IConfiguration configuration)
        {
            var options = new SqlClientOptions();
            configuration.GetSection("APPLICATION:SQLCLIENTOPTIONS").Bind(options);
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Server={options.Server!.Trim()};");
            stringBuilder.Append($"User Id={options.Username!.Trim()};");
            stringBuilder.Append($"Password={options.Password!.Trim()};");
            stringBuilder.Append($"Database={options.Database!.Trim()}.default;");
            return Task.FromResult(stringBuilder.ToString());
        }

        public static Task<string> BuildKeyConnectionStringAsync(this IConfiguration configuration)
        {
            var options = new SqlClientOptions();
            configuration.GetSection("APPLICATION:SQLCLIENTOPTIONS").Bind(options);
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Server={options.Server!.Trim()};");
            stringBuilder.Append($"User Id={options.Username!.Trim()};");
            stringBuilder.Append($"Password={options.Password!.Trim()};");
            stringBuilder.Append($"Database={options.Database!.Trim()}.key;");
            return Task.FromResult(stringBuilder.ToString());
        }

        public static Task<string> BuildCryptoConnectionStringAsync(this IConfiguration configuration)
        {
            var options = new SqlClientOptions();
            configuration.GetSection("APPLICATION:SQLCLIENTOPTIONS").Bind(options);
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Server={options.Server!.Trim()};");
            stringBuilder.Append($"User Id={options.Username!.Trim()};");
            stringBuilder.Append($"Password={options.Password!.Trim()};");
            stringBuilder.Append($"Database={options.Database!.Trim()}.crypto;");
            return Task.FromResult(stringBuilder.ToString());
        }

        public static Task<DiscordOptions> BuildDiscordOptionsAsync(this IConfiguration configuration)
        {
            var options = new DiscordOptions();
            configuration.GetSection("APPLICATION:DISCORDOPTIONS").Bind(options);
            return Task.FromResult(options);
        }

        public static Task<TwitterOptions> BuildTwitterOptionsAsync(this IConfiguration configuration)
        {
            var options = new TwitterOptions();
            configuration.GetSection("APPLICATION:TWITTEROPTIONS").Bind(options);
            return Task.FromResult(options);
        }

        public static Task<PaypalOptions> BuildPaypalOptionsAsync(this IConfiguration configuration)
        {
            var options = new PaypalOptions();
            configuration.GetSection("APPLICATION:PAYPALOPTIONS").Bind(options);
            return Task.FromResult(options);
        }
    }
}
