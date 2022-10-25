using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Security.Claims;

namespace balasolu.models.options
{
    public sealed class DiscordOptions : OAuthOptions
    {
        public DiscordOptions()
        {
            CallbackPath = new PathString("/signin-discord");
            AuthorizationEndpoint = DiscordDefaults.AuthorizationEndpoint;
            TokenEndpoint = DiscordDefaults.TokenEndpoint;
            UserInformationEndpoint = DiscordDefaults.UserInformationEndpoint;
            Scope.Add("identify");

            ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id", ClaimValueTypes.UInteger64);
            ClaimActions.MapJsonKey(ClaimTypes.Name, "username", ClaimValueTypes.String);
            ClaimActions.MapJsonKey(ClaimTypes.Email, "email", ClaimValueTypes.Email);
            ClaimActions.MapJsonKey("urn:discord:discriminator", "discriminator", ClaimValueTypes.UInteger32);
            ClaimActions.MapJsonKey("urn:discord:avatar", "avatar", ClaimValueTypes.String);
            ClaimActions.MapJsonKey("urn:discord:verified", "verified", ClaimValueTypes.Boolean);
        }

        public class DiscordDefaults
        {
            public const string AuthenticationScheme = "Discord";
            public const string DisplayName = "Discord";
            public static readonly string AuthorizationEndpoint = "https://discordapp.com/api/oauth2/authorize";
            public static readonly string TokenEndpoint = "https://discordapp.com/api/oauth2/token";
            public static readonly string UserInformationEndpoint = "https://discordapp.com/api/users/@me";
        }
    }
}
