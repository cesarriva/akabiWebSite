using System.Configuration;

namespace AkaBIWebSite.Infrastructure
{
    public static class ConfigSettingsHandler
    {
        public static string ReadSetting(string key)
        {
            var result = ConfigurationManager.AppSettings[key] ?? null;
            return result;
        }
    }
}
