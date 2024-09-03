using System.Configuration;
using System.Diagnostics;
using static OGRIT_Database_Custom_App.Generics.ScreenEnums;

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
            if (String.IsNullOrEmpty(ConfigurationManager.AppSettings[key]))
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
                WriteToLog(LogType.Error, $"Configuration Error: {key} not set.");
                System.Environment.Exit(1);
            }

            return result;
        }
        /// <summary>
        /// Function to change values of keys in App.config
        /// </summary>
        /// <param name="key">The key that is going to be changed</param>
        /// <param name="newValue">The new value that is going to be assigned to the key</param>
        public static void UpdateAppConfig(string key, string newValue)
        {
            // Open the configuration file for the current application
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Check if the key exists, then update its value
            if (config.AppSettings.Settings[key] == null)
            {
                WriteToLog(LogType.Error, $"Key '{key}' doesn't exist in app.config.");
                return;
            }

            // Update the value
            config.AppSettings.Settings[key].Value = newValue;

            // Save the configuration file
            config.Save(ConfigurationSaveMode.Modified);

            // Refresh the section so that the changes are reflected in the runtime
            ConfigurationManager.RefreshSection("appSettings");

            WriteToLog(LogType.Information, $"Updated '{key}' in app.config.");
        }
        /// <summary>
        /// Function to create the log file and the listener of it.
        /// </summary>
        public static void SetUpLogging()
        {
            var fileListener = new TextWriterTraceListener("output.log", "fileListener");
            Trace.Listeners.Add(fileListener);
            Trace.AutoFlush = true;
        }
        /// <summary>
        /// Function to log operations to the log file initialized in MainController's constructor.
        /// </summary>
        /// <param name="logType">Declares what type of log is about to be written.</param>
        /// <param name="message">Log's message that needs to be written.</param>
        public static void WriteToLog(LogType logType, string message)
        {
            Trace.WriteLine($"{DateTime.Now} - {logType} - {message}");
        }
    }
}
