using System.Data.SqlClient;

namespace OGRIT_Database_Custom_App
{
    /// <summary>
    /// Represents the main window of the application.
    /// This form handles the display and management of different screens within the application.
    /// </summary>
    public partial class MainWindow : System.Windows.Forms.Form
    {
        /// <summary>
        /// The currently active user control (screen) displayed in the main window.
        /// </summary>
        private UserControl? _screen;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the specified screen to be displayed in the main window.
        /// </summary>
        /// <param name="screen">The user control representing the screen to be displayed.</param>
        public void SetScreen(UserControl screen)
        {
            ResetScreen();
            _screen = screen;
            ShowScreen();
        }

        /// <summary>
        /// Displays the currently set screen in the main window.
        /// </summary>
        private void ShowScreen()
        {
            if (_screen != null)
            {
                Controls.Add(_screen);
            }
        }

        /// <summary>
        /// Resets the currently displayed screen by removing it from the main window.
        /// </summary>
        private void ResetScreen()
        {
            if (_screen != null)
            {
                Controls.Remove(_screen);
                _screen = null;
            }
        }
    }
}
