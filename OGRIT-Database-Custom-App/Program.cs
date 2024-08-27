using OGRIT_Database_Custom_App.Controller;

namespace OGRIT_Database_Custom_App
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main method that initializes and runs the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var controller = new MainController();
            controller.Run();
        }
    }
}