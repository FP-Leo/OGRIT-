using OGRIT_Database_Custom_App.Model;
using System.Data.SqlClient;
using System.Data;

namespace OGRIT_Database_Custom_App.Models
{
    /// <summary>
    /// Represents a database connection with additional functionalities for executing queries and commands.
    /// </summary>
    public class MainDatabaseConnection : DatabaseConnection
    {
        //private List<DatabaseConnection>? estabileshedConnections;

        /// <summary>
        /// Executes a SELECT SQL query and retrieves the results as a <see cref="DataTable"/>.
        /// </summary>
        /// <param name="query">The SQL SELECT query to execute.</param>
        /// <returns>A <see cref="DataTable"/> containing the query results, or <c>null</c> if the query does not start with "SELECT" or an error occurs.</returns>
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

        /// <summary>
        /// Adds parameters to the SQL command and executes it using the provided connection string.
        /// </summary>
        /// <param name="query">The SQL query to execute with parameters.</param>
        /// <param name="connectionString">The <see cref="ConnectionString"/> object containing the parameters to add.</param>
        public void AddParamAndExecuteCommand(string query, ConnectionString connectionString)
        {
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
