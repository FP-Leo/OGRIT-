using OGRIT_Database_Custom_App.Model;
using System.Data.SqlClient;
using System.Data;

namespace OGRIT_Database_Custom_App.Models
{
    public class MainDatabaseConnetion : DatabaseConnection
    {
        //private List<DatabaseConnection>? estabileshedConnections;
        public DataTable? ExecuteSelectQueryAndGetResult(string query)
        {
            if (!query.StartsWith("SELECT"))
            {
                return null;
            }

            try
            {
                SqlDataAdapter dataAdapter = new(query, Connection);
                DataTable dataTable = new();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                return null;
            }
        }

        public void InsertConnection(ConnectionString connectionString) {
            string query = $"INSERT INTO [dbo].[ServerConfig] VALUES ( @var1, @var2, @var3, @var4, @var5, @var6 )";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@var1", connectionString.GetServerNameIP());
            command.Parameters.AddWithValue("@var2", connectionString.GetPort());
            command.Parameters.AddWithValue("@var3", connectionString.GetInstanceName());

            if (connectionString.IsSQLAuth())
            {
                command.Parameters.AddWithValue("@var4", 1);
                command.Parameters.AddWithValue("@var5", connectionString.GetUsername());
                command.Parameters.AddWithValue("@var6", connectionString.GetPassword());
            }
            else
            {
                command.Parameters.AddWithValue("@var4", 0);
                command.Parameters.AddWithValue("@var5", DBNull.Value);
                command.Parameters.AddWithValue("@var6", DBNull.Value);
            }

            ExecuteCommand(command);
        }

    }
}
