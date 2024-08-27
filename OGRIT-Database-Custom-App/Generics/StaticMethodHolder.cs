using System.Configuration;

namespace OGRIT_Database_Custom_App.Generics
{
    /// <summary>
    /// A static class that holds various utility methods related to configuration settings.
    /// </summary>
    public static class StaticMethodHolder
    {
        /// <summary>
        /// Validates if the specified configuration key exists in the application's configuration file.
        /// </summary>
        /// <param name="key">The configuration key to validate.</param>
        /// <returns>Returns <c>true</c> if the key exists; otherwise, <c>false</c>.</returns>
        public static bool ValidConfigKey(string key)
        {
            if (ConfigurationManager.AppSettings[key] == null)
                return false;
            return true;
        }

        /// <summary>
        /// Retrieves the value associated with the specified configuration key.
        /// </summary>
        /// <param name="key">The configuration key to retrieve the value for.</param>
        /// <returns>The value associated with the specified key.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the key is not set or its value is null or empty.</exception>
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
