using OGRIT_Database_Custom_App.Models;
using static OGRIT_Database_Custom_App.Generics.DelegateContainer;

namespace OGRIT_Database_Custom_App
{
    /// <summary>
    /// Represents the login screen for the application.
    /// </summary>
    public partial class LogInScreen : UserControl
    {
        /// <summary>
        /// Delegate to change the screen after successful login.
        /// </summary>
        private LogInScreenChanger? _changer;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogInScreen"/> class.
        /// </summary>
        public LogInScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event for the login button, validating the database connection.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            ConnectionString? connectionString = LISinputForm.ValidateInput();

            if (connectionString == null)
            {
                return;
            }

            _changer?.Invoke(connectionString);
        }

        /// <summary>
        /// Sets the delegate to change the screen after successful login.
        /// </summary>
        /// <param name="changer">The delegate that changes the screen.</param>
        public void SetChanger(LogInScreenChanger changer)
        {
            _changer = changer;
        }

        /// <summary>
        /// Handles the resize event of the login screen, adjusting the size and position of the table panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void LogInScreen_Resize(object sender, EventArgs e)
        {
            int newWidth = Math.Min(450, this.Width - 800);
            int newHeight = Math.Min(600, this.Height - 200);
            lsTablePanel.Size = new Size(newWidth, newHeight);

            lsTablePanel.Location = new Point(
                (lsOuterPanel.Width - lsTablePanel.Width) / 2,
                (lsOuterPanel.Height - lsTablePanel.Height) / 2);
        }

        /// <summary>
        /// Gets the current value of the rememberMeCheckBox.
        /// </summary>
        public bool RememberMeIsChecked() { 
            return rememberMeCheckBox.Checked;
        }

        /// <summary>
        /// Sets the last used value of the rememberMeCheckBox.
        /// </summary>
        /// <param name="rememberMe">The new value of rememberMeCheckBox.</param>
        public void SetRememberMe(bool rememberMe) { 
            rememberMeCheckBox.Checked = rememberMe;
        }
    }
}
