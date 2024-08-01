using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OGRIT_Database_Custom_App
{
    public partial class Form1 : Form
    {
        private ScreenEnum currentScreen = ScreenEnum.StartingScreen;
        public Form1()
        {
            InitializeComponent();
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            currentScreen = ScreenEnum.Login;
            LoadScreen();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            switch (currentScreen)
            {
                case ScreenEnum.StartingScreen:
                    break;
                case ScreenEnum.Login:
                    currentScreen = ScreenEnum.StartingScreen;
                    break;
            }
            LoadScreen();
        }

        private void LoadScreen()
        {
            switch (currentScreen)
            {
                case ScreenEnum.StartingScreen:
                    ChangeStartingScreenVisibility(true);
                    ChangeLogInScreenVisibility(false);
                    break;
                case ScreenEnum.Login:
                    ChangeStartingScreenVisibility(false);
                    ChangeLogInScreenVisibility(true);
                    break;
            }
        }

        private void ChangeStartingScreenVisibility(bool visible)
        {
            companyNameLabel.Visible = visible;
            AppDescriptionLabel.Visible = visible;
            ContinueButton.Visible = visible;
        }

        private void ChangeLogInScreenVisibility(bool visible)
        {
            backButton.Visible = visible;
            serverIPLabel.Visible = visible;
            serverIPTB.Visible = visible;
            dbInstanceLabel.Visible = visible;
            dbInstanceTB.Visible = visible;
            usernameLabel.Visible = visible;
            usernameTB.Visible = visible;
            passwordLabel.Visible = visible;
            passwordTB.Visible = visible;
            loginButton.Visible = visible;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string serverIP = serverIPTB.Text;
            string dbi = dbInstanceTB.Text;
            string username = usernameTB.Text;
            string password = passwordTB.Text;

            string errorMessage = "Error List:";
            bool validState = true;

            if (string.IsNullOrEmpty(serverIP))
            {
                errorMessage += "Server IP missing\n\r";
                validState = false;
            }

            if (string.IsNullOrEmpty(dbi))
            {
                errorMessage += "Database Instance missing\n\r";
                validState = false;
            }

            if (string.IsNullOrEmpty(username))
            {
                errorMessage += "Username missing\n\r";
                validState = false;
            }

            if (string.IsNullOrEmpty(password))
            {
                errorMessage += "Password missing\n\r";
                validState = false;
            }

            if (!validState) {
                MessageBox.Show(errorMessage);
                return;
            }

            string connectionString = $"Data Source={serverIP};Initial Catalog={dbi};User ID={username};Password={password};";
            try
            {
                var connection = new SqlConnection(connectionString);
                string query = "SELECT * FROM [OGRIT-DB].[dbo].[dbInfo]";
                try
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                    //MessageBox.Show("Executed sucessfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        enum ScreenEnum
        {
            StartingScreen,
            Login,
        }
    }
}
