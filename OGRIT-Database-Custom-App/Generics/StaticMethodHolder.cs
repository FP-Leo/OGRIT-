using System.Configuration;

namespace OGRIT_Database_Custom_App.Generics
{
    public static class StaticMethodHolder
    {
        public static bool ValidConfigKey(string key)
        {
            if (ConfigurationManager.AppSettings[key] == null)
                return false;
            return true;
        }
        public static string GetConfigKey(string key)
        {
            string? result = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show($"Configuration Error: {key} not set!");
                System.Environment.Exit(1);
            }

            return result;
        }
    }
}
