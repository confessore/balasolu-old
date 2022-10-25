using balasolu.handlers;
using balasolu.models.options;
using Microsoft.AspNetCore.Authentication;

namespace balasolu.extensions
{
    public static class AuthenticationBuilderExtensions
    {
        public static AuthenticationBuilder AddDiscord(this AuthenticationBuilder builder)
            => builder.AddDiscord(DiscordOptions.DiscordDefaults.AuthenticationScheme, _ => { });

        public static AuthenticationBuilder AddDiscord(this AuthenticationBuilder builder, Action<DiscordOptions> configureOptions)
            => builder.AddDiscord(DiscordOptions.DiscordDefaults.AuthenticationScheme, configureOptions);

        public static AuthenticationBuilder AddDiscord(this AuthenticationBuilder builder, string authenticationScheme, Action<DiscordOptions> configureOptions)
            => builder.AddDiscord(authenticationScheme, DiscordOptions.DiscordDefaults.DisplayName, configureOptions);

        public static AuthenticationBuilder AddDiscord(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<DiscordOptions> configureOptions)
            => builder.AddOAuth<DiscordOptions, DiscordHandler>(authenticationScheme, displayName, configureOptions);
    }
}
