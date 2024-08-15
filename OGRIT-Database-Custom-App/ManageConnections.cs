using System.Data.SqlClient;
using System.Data;

namespace OGRIT_Database_Custom_App
{
    public partial class ManageConnections : UserControl
    {
        private SqlConnection? _connection;
        public ManageConnections()
        {
            InitializeComponent();
        }

        private void ManageConnections_Load(object sender, EventArgs e)
        {
            // Based on the written code, it should never get triggered, but just to be safe.
            if (_connection == null)
            {
                MessageBox.Show("Failed to connect to the db");
            }

            // Get all the Available Connections on Load.
            string query = "SELECT * FROM [dbo].[ServerConfig]";
            try
            {
                SqlDataAdapter dataAdapter = new(query, _connection);
                DataTable dataTable = new();
                dataAdapter.Fill(dataTable);
                mcDataGrid.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        // To get the main DB connection from MainWindow
        public void SetConnection(SqlConnection? connection) { 
            _connection = connection;
        }
    }
}
