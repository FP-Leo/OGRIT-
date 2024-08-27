namespace OGRIT_Database_Custom_App.Generics
{
    /// <summary>
    /// Contains enumerations for different screens, subscreens, and menu options 
    /// used within the OGRIT Database Custom Application.
    /// </summary>
    public static class ScreenEnums
    {
        /// <summary>
        /// Enumerates the primary screens available in the application.
        /// </summary>
        public enum Screens
        {
            /// <summary>
            /// The initial screen displayed when the application starts.
            /// </summary>
            StartingScreen,

            /// <summary>
            /// The login screen for user authentication.
            /// </summary>
            LogInScreen,

            /// <summary>
            /// The main menu screen of the application.
            /// </summary>
            MenuScreen
        }

        /// <summary>
        /// Enumerates the subscreens available under specific main screens.
        /// </summary>
        public enum SubScreens
        {
            /// <summary>
            /// The screen for managing database connections.
            /// </summary>
            ManageConnectionsScreen,

            /// <summary>
            /// The screen for viewing a list of stored procedures.
            /// </summary>
            ViewProceduresScreen,

            /// <summary>
            /// The screen for executing selected stored procedures.
            /// </summary>
            ExecuteProceduresScreen
        }

        /// <summary>
        /// Enumerates the options available in the connection management menu.
        /// </summary>
        public enum ConnectionMenuOptions
        {
            /// <summary>
            /// Option to display all available database connections.
            /// </summary>
            ShowConnections,

            /// <summary>
            /// Option to insert a new database connection.
            /// </summary>
            Insert,

            /// <summary>
            /// Option to update an existing database connection.
            /// </summary>
            Update,

            /// <summary>
            /// Option to delete an existing database connection.
            /// </summary>
            Delete
        }
    }
}
