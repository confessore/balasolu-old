using System.Reflection;

namespace balasolu.statics
{
    /// <summary>
    /// a static class for commonly used strings
    /// </summary>
    public static class Strings
    {
        /// <summary>
        /// the name of the assembly that calls this property
        /// </summary>
        public static string? CallingAssemblyName =>
            Assembly.GetCallingAssembly().GetName().Name;

        /// <summary>
        /// the name of the assembly that executes this property
        /// </summary>
        public static string? ExecutingAssemblyName =>
            Assembly.GetExecutingAssembly().GetName().Name;

        public static string DiscordOAuthAuthenticationScheme =>
            "Discord";
        public static string DiscordOAuthDisplayName =>
            "Discord";

        public static string DiscordAuthorizationEndpoint =>
            "https://discordapp.com/api/oauth2/authorize";

        public static string DiscordTokenEndpoint =>
            "https://discordapp.com/api/oauth2/token";

        public static string DiscordUserInformationEndpoint =>
            "https://discordapp.com/api/users/@me";
    }
}
