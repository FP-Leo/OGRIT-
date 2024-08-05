using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OGRIT_Database_Custom_App
{
    public partial class LogInScreen : UserControl
    {
        private MainWindow _parent;
        public LogInScreen()
        {
            InitializeComponent();
        }
        public LogInScreen(MainWindow parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if( _parent == null)
            {
                return;
            }
            string serverIP = serverTB.Text;
            string dbi = dbTB.Text;
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

            if (!validState)
            {
                MessageBox.Show(errorMessage);
                return;
            }

            string connectionString = $"Data Source={serverIP};Initial Catalog={dbi};User ID={username};Password={password};";
            try
            {
                var connection = new SqlConnection(connectionString);
                string query = "SELECT * FROM [dbo].[dbInfo]";
                try
                {
                    SqlDataAdapter dataAdapter = new(query, connection);
                    DataTable dataTable = new();
                    dataAdapter.Fill(dataTable);
                    //dataGridView1.DataSource = dataTable;
                    _parent.logInScreen.Hide();
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
    }
}
