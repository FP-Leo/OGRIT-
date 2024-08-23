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
    }
}
