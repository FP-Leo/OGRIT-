using System.Data.SqlClient;
using System.Data;
using OGRIT_Database_Custom_App.Models;
using DataJuggler.Core.Cryptography;
using System.Configuration;
using OGRIT_Database_Custom_App.Generics;
using static OGRIT_Database_Custom_App.Generics.ScreenEnums;

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
        /// Deconstructor - upon going out of scope it terminates the database connection if it was established.
        /// </summary>
        ~DatabaseConnection() {
            CloseConnection();
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
                StaticMethodHolder.WriteToLog(LogType.Information, "Connection established with a database.");

                return true;
            }
            catch (SqlException ex)
            {
                // When a wrong CS is provided the connection needs to be reset so that it can use the new one that's going to be provided.
                Connection = null;
                MessageBox.Show("Failed establishing connection to the database.");
                StaticMethodHolder.WriteToLog(LogType.Error, $"Failed establishing connection to the database. Full error {ex}");
            }// Connection.Open() throws 3 different exceptions, since I'm not familiar with each of them, I'll handle them in a single catch statement. Subjected to change in newer releases.
            catch (Exception generalEx)
            {
                MessageBox.Show("Failed establishing connection to the database.");
                StaticMethodHolder.WriteToLog(LogType.Error, $"Failed establishing connection to the database [ .Open() issue]. Full error {generalEx}");
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
                try
                {
                    Connection.Close();
                    StaticMethodHolder.WriteToLog(LogType.Information, $"Closed connection to a database.");
                }
                catch (SqlException ex) {
                    MessageBox.Show($"Failed closing connection of {cs?.GetServerNameIP()}");
                    StaticMethodHolder.WriteToLog(LogType.Error, $"Failed closing a connection of the database. Full error {ex}");
                }
            }
        }

        /// <summary>
        /// Executes a SQL query that does not return results (e.g., INSERT, UPDATE, DELETE).
        /// </summary>
        /// <param name="query">The <see cref="string"/> string representing the SQL query to execute.</param>
        public void ExecuteQuery(string query)
        {
            using var command = new SqlCommand(query, Connection);
            ExecuteCommandNonQuery(command);
        }
        /// <summary>
        /// Executes a SQL command that does not return results.
        /// </summary>
        /// <param name="command">Represents the SQL command to execute.</param>
        public static bool ExecuteCommandNonQuery(SqlCommand command)
        {
            try
            {
                command.ExecuteNonQuery();
                StaticMethodHolder.WriteToLog(LogType.Information, $"Non query command executed successfully.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing non query command, most likely caused by an Insert command. Check logs for full error. ");
                StaticMethodHolder.WriteToLog(LogType.Error, $"Error executing non query command. Full error: {ex}");
                return false;
            }
        }
        /// <summary>
        /// Executes a SQL query that returns results inform of SqlDataReader
        /// </summary>
        /// <param name="query">The <see cref="string"/> string representing the SQL query to execute.</param>
        public SqlDataReader? ExecuteQueryDbDataReader(string query)
        {
            using var command = new SqlCommand(query, Connection);
            return ExecuteDbDataReaderCommand(command);
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
                StaticMethodHolder.WriteToLog(LogType.Information, $"Data reader command executed successfully.");
                return result;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error executing data reader command, most likely caused by an OnReturnExecute stored procedure. Check logs for full error. ");
                StaticMethodHolder.WriteToLog(LogType.Error, $"Error executing data reader command. Full error: {ex}");
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
            {
                StaticMethodHolder.WriteToLog(LogType.Warning, "Failed converting Connection String object to string. Object not provided (null)");
                return null;
            }
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = $"{cs.GetServerNameIP()},{cs.GetPort()}",
                InitialCatalog = cs.GetInstanceName()
            };
            if (cs.IsSQLAuth())
            {
                builder.UserID = cs.GetUsername();
                if (!StaticMethodHolder.ValidConfigKey("encryptionKey"))
                {
                    MessageBox.Show("Error: No encryption key found in the config file.");
                    StaticMethodHolder.WriteToLog(LogType.Error, "Failed converting ConnectionString object to string. Encryption Key most likely deleted after loging in.");
                    return null;
                }
                var decryptedPassword = CryptographyHelper.DecryptString(cs.GetPassword(), ConfigurationManager.AppSettings["encryptionKey"]);
                builder.Password = decryptedPassword;
            }
            else
            {
                builder.IntegratedSecurity = true;
            }
            return builder.ConnectionString;
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
