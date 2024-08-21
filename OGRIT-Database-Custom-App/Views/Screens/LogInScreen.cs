using OGRIT_Database_Custom_App.Models;
using static OGRIT_Database_Custom_App.Generics.DelegateContainer;


namespace OGRIT_Database_Custom_App
{
    public partial class LogInScreen : UserControl
    {
        private LogInScreenChanger? _changer;
        public LogInScreen()
        {
            InitializeComponent();
        }

        //
        // Events
        //
        
        // Event to validate DB connection.
        private void LoginButton_Click(object sender, EventArgs e)
        {
            ConnectionString? connectionString = LISinputForm.ValidateInput();

            if (connectionString == null)
            {
                return;
            }

            _changer?.Invoke(connectionString);
        }
        //
        // Set Screen Changer
        //
        public void SetChanger(LogInScreenChanger changer)
        {
            _changer = changer;
        }

        private void LogInScreen_Resize(object sender, EventArgs e)
        {
            int newWidth = Math.Min(450, this.Width - 800);
            int newHeight = Math.Min(600, this.Height - 200);
            lsTablePanel.Size = new Size(newWidth, newHeight);

            lsTablePanel.Location = new Point(
                (lsOuterPanel.Width - lsTablePanel.Width) / 2,
                (lsOuterPanel.Height - lsTablePanel.Height) / 2);
        }
    }
}