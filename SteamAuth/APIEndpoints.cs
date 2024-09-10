namespace SteamAuth
{
    public static class APIEndpoints
    {
        public static string STEAMAPI_BASE = "https://api.steampowered.com";
        public static string COMMUNITY_BASE = "https://steamcommunity.com";
        public static string MOBILEAUTH_BASE => STEAMAPI_BASE + "/IMobileAuthService/%s/v0001";
        public static string MOBILEAUTH_GETWGTOKEN => MOBILEAUTH_BASE.Replace("%s", "GetWGToken");
        public static string TWO_FACTOR_BASE => STEAMAPI_BASE + "/ITwoFactorService/%s/v0001";
        public static string TWO_FACTOR_TIME_QUERY => TWO_FACTOR_BASE.Replace("%s", "QueryTime");

        public static void SetEndpoints(string webApi, string community)
        {
            STEAMAPI_BASE = webApi;
            COMMUNITY_BASE = community;
        }
    }
}