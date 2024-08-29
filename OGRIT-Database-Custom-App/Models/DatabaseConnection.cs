using System.Data.SqlClient;
using System.Data;
using OGRIT_Database_Custom_App.Models;
using DataJuggler.Core.Cryptography;
using System.Configuration;

namespace OGRIT_Database_Custom_App.Model
{
    /// <summary>
    /// Provides methods for connecting to a SQL database and executing commands.
    /// </summary>
    public class DatabaseConnection
    {
        private ConnectionString? cs;
        protected SqlConnection? Connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseConnection"/> class.
        /// </summary>
        public DatabaseConnection() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseConnection"/> class with a specified connection string.
        /// </summary>
        /// <param name="connectionString">The connection string to use for connecting to the database.</param>
        public DatabaseConnection(ConnectionString connectionString)
        {
            cs = connectionString;
        }

        /// <summary>
        /// Opens a connection to the database using the specified connection string.
        /// </summary>
        /// <returns><c>true</c> if the connection was successfully opened; otherwise, <c>false</c>.</returns>
        public bool OpenConnection()
        {
            try
            {
                if (cs == null)
                    return false;


                /*
                 * if (Connection == null)
                    Connection = new SqlConnection(FormatConnectionString());
                */
                // The compound assignment is the same as the above.
                Connection ??= new SqlConnection(FormatConnectionString());

                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();

                return true;
            }
            catch (Exception ex)
            {
                Connection = null;
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Closes the connection to the database if it is open.
        /// </summary>
        public void CloseConnection()
        {
            if (Connection == null)
                return;

            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }

        /// <summary>
        /// Executes a SQL query that does not return results (e.g., INSERT, UPDATE, DELETE).
        /// </summary>
        /// <param name="query">The <see cref="string"/> string representing the SQL query to execute.</param>
        public void ExecuteQuery(string query)
        {
            using (var command = new SqlCommand(query, Connection))
            {
                ExecuteCommandNonQuery(command);
            }
        }
        /// <summary>
        /// Executes a SQL command that does not return results.
        /// </summary>
        /// <param name="command">Represents the SQL command to execute.</param>
        public static void ExecuteCommandNonQuery(SqlCommand command)
        {
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        /// <summary>
        /// Executes a SQL query that returns results inform of SqlDataReader
        /// </summary>
        /// <param name="query">The <see cref="string"/> string representing the SQL query to execute.</param>
        public SqlDataReader? ExecuteQueryDbDataReader(string query)
        {
            using (var command = new SqlCommand(query, Connection))
            {
                return ExecuteDbDataReaderCommand(command);
            }
        }
        /// <summary>
        /// Executes a SQL command that returns results inform of SqlDataReader
        /// </summary>
        /// <param name="command">Represents the SQL query to execute.</param>
        public static SqlDataReader? ExecuteDbDataReaderCommand(SqlCommand command)
        {
            try
            {
                SqlDataReader? result = command.ExecuteReader();

                return result;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            return null;
        }

        /// <summary>
        /// Formats the connection string based on the stored connection settings.
        /// </summary>
        /// <returns>The formatted connection string, or <c>null</c> if no connection settings are provided.</returns>
        private string? FormatConnectionString()
        {
            if (cs == null)
                return null;

            string connectionString = $"Data Source={cs.GetServerNameIP()},{cs.GetPort()};Initial Catalog={cs.GetInstanceName()};";
            if (cs.IsSQLAuth())
            {
                var decryptedPassword = CryptographyHelper.DecryptString(cs.GetPassword(), ConfigurationManager.AppSettings["encryptionKey"]);
                connectionString += $"User ID={cs.GetUsername()};Password={decryptedPassword};";
            }
            else
            {
                connectionString += "Integrated Security=True;";
            }
            return connectionString;
        }

        /// <summary>
        /// Sets the connection string to be used for database operations.
        /// </summary>
        /// <param name="connectionString">The <see cref="ConnectionString"/> object representing the connection settings.</param>
        public void SetConnectionString(ConnectionString connectionString)
        {
            cs = connectionString;
        }
    }
}
