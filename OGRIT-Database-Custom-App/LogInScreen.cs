using System.Data;
using System.Data.SqlClient;
using static OGRIT_Database_Custom_App.MainWindow;

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
            string? connectionString = LISinputForm.GetConnectionString();

            if (connectionString == null)
            {
                return;
            }

            try
            {
                var connection = new SqlConnection(connectionString);
                // Ensure that you're connected to the DB by using try and catch, if so pass the connection
                // To do: Ensure that ServiceTable exists on that DB.
                _changer?.Invoke(connection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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