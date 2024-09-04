using static OGRIT_Database_Custom_App.Generics.DelegateContainer;
using static OGRIT_Database_Custom_App.Generics.ScreenEnums;

namespace OGRIT_Database_Custom_App
{
    /// <summary>
    /// Represents the menu screen that provides navigation to different application screens and functionalities.
    /// </summary>
    public partial class MenuScreen : UserControl
    {
        /// <summary>
        /// Delegate to change the screen based on user actions.
        /// </summary>
        private MenuScreenChanger? _changer;

        private LogOutSignal? _logOutSignal;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuScreen"/> class.
        /// </summary>
        public MenuScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the delegate for changing the screen.
        /// </summary>
        /// <param name="changer">The delegate to change the screen.</param>
        public void SetChanger(MenuScreenChanger changer)
        {
            _changer = changer;
        }

        /// <summary>
        /// Sets the delegate for logging out.
        /// </summary>
        /// <param name="logOutSignal">The delegate to log out.</param>
        public void SetLogOutSignal(LogOutSignal logOutSignal)
        {
            _logOutSignal = logOutSignal;
        }

        /// <summary>
        /// Handles the resize event of the menu screen, adjusting the size and location of the menu table panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void MenuScreen_Resize(object sender, EventArgs e)
        {
            int newWidth = Math.Min(500, this.Width - 800);
            int newHeight = Math.Min(500, this.Height - 400);
            Console.WriteLine("New Height: " + newHeight);
            menuTablePanel.Size = new Size(newWidth, newHeight);

            menuTablePanel.Location = new Point(
                (menuPanel.Width - menuTablePanel.Width) / 2,
                (menuPanel.Height - menuTablePanel.Height) / 2);
        }

        /// <summary>
        /// Handles the click event for the "Manage Connection" button, navigating to the manage connections screen.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ManageConnectionButton_Click(object sender, EventArgs e)
        {
            _changer?.Invoke(SubScreens.ManageConnectionsScreen);
        }

        /// <summary>
        /// Handles the click event for the "View Procedure" button, navigating to the view procedures screen.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ViewProcedureButton_Click(object sender, EventArgs e)
        {
            _changer?.Invoke(SubScreens.ViewProceduresScreen);
        }

        /// <summary>
        /// Handles the click event for the "Execute Procedure" button, navigating to the execute procedures screen.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ExecuteProcedureButton_Click(object sender, EventArgs e)
        {
            _changer?.Invoke(SubScreens.ExecuteProceduresScreen);
        }

        /// <summary>
        /// Handles the click event for the "Quit" button, closing the application.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void QuitButton_Click(object sender, EventArgs e)
        {
            _logOutSignal?.Invoke();
        }
    }
}
