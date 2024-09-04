using OGRIT_Database_Custom_App.Models;
using static OGRIT_Database_Custom_App.Generics.ScreenEnums;

namespace OGRIT_Database_Custom_App.Generics
{
    /// <summary>
    /// Contains delegate definitions used throughout the application for screen changes, 
    /// menu actions, login operations, and other functionalities.
    /// </summary>
    public class DelegateContainer
    {
        /// <summary>
        /// Delegate for changing screens.
        /// </summary>
        public delegate void ScreenChanger();

        /// <summary>
        /// Delegate for changing the menu screen to a selected sub-screen and vise versa.
        /// </summary>
        /// <param name="selected">The selected sub-screen to switch to or to switch from.</param>
        public delegate void MenuScreenChanger(SubScreens selected);

        /// <summary>
        /// Delegate for handling login screen operations with a given connection string.
        /// </summary>
        /// <param name="connection">The connection string used for logging in.</param>
        public delegate void LogInScreenChanger(ConnectionString connection);

        /// <summary>
        /// Delegate for handling connection screen operations based on the selected menu option.
        /// </summary>
        /// <param name="selected">The selected connection menu option.</param>
        public delegate void ConnectionScreenMenuSignal(ConnectionMenuOptions selected);

        /// <summary>
        /// Delegate for signaling that a data grid or similar UI element needs to be filled.
        /// </summary>
        public delegate void FillSignal();

        /// <summary>
        /// Delegate for refreshing a UI component.
        /// </summary>
        public delegate void Refresher();

        /// <summary>
        /// Delegate for setting updates in a UI or model component.
        /// </summary>
        public delegate void UpdateFormSignal();
        
        /// <summary>
        /// Delegate for sending a signal to execute an action.
        /// </summary>
        public delegate void ExecuteSignal();
        
        /// <summary>
        /// Delegate for sending a signal to log out of the main database.
        /// </summary>
        public delegate void LogOutSignal();

        /// <summary>
        /// Delegate for sending a signal that the form is closing.
        /// </summary>
        public delegate void FormClosingSignal();
    }
}
