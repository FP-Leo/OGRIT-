using OGRIT_Database_Custom_App.Model;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using OGRIT_Database_Custom_App.Generics;
using static OGRIT_Database_Custom_App.Generics.ScreenEnums;

namespace OGRIT_Database_Custom_App.Models
{
    /// <summary>
    /// Represents a database connection with additional functionalities designed for the Main Database which will hold the Connection and Procedure Table.
    /// </summary>
    public class MainDatabaseConnection(string ConnectionFilter, string ProcedureFilter, string DataRetrivealColumn) : DatabaseConnection
    {
        private readonly List<RemoteDatabaseConnection> establishedConnections = [];

        private readonly string ConnectionFilter = ConnectionFilter;

        private readonly string ProcedureFilter = ProcedureFilter;

        private readonly string DataRetrivealColumn = DataRetrivealColumn;

        /// <summary>
        /// Executes a SELECT SQL query and retrieves the results as a <see cref="DataTable"/>.
        /// </summary>
        /// <param name="query">The SQL SELECT query to execute.</param>
        /// <returns>A <see cref="DataTable"/> containing the query results, or <c>null</c> if the query does not start with "SELECT" or an error occurs.</returns>
        public DataTable? ExecuteSelectQueryAndGetResult(string query)
        {
            if (Connection == null){
                StaticMethodHolder.WriteToLog(LogType.Warning, "Trying to execute a Select query on a MainDatabaseConnection Object without the connection being established.");
                return null;
            }

            if (!query.StartsWith("SELECT"))
            {
                StaticMethodHolder.WriteToLog(LogType.Warning, "Trying to execute a non select query on a MainDatabaseConnection Object using select query's function.");
                return null;
            }

            try
            {
                SqlDataAdapter dataAdapter = new(query, Connection);
                DataTable dataTable = new();
                dataAdapter.Fill(dataTable);
                StaticMethodHolder.WriteToLog(LogType.Information, $"Select query executed successfully on the main database.");
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to fetch data from the Main Database. Review logs.");
                StaticMethodHolder.WriteToLog(LogType.Error, $"Failed executing Select statement on a MainDatabaseConnection object. Full error {ex}");
                return null;
            }
        }

        /// <summary>
        /// Adds parameters to the SQL command and executes it using the provided connection string.
        /// Used for inserting/updating into Connection Table. Needs refactoring becuase of all the 'hard coding'.
        /// </summary>
        /// <param name="query">The SQL query to execute with parameters.</param>
        /// <param name="connectionString">The <see cref="ConnectionString"/> object containing the parameters to add.</param>
        public void AddParamAndExecuteCommand(string query, ConnectionString connectionString)
        {
            if (Connection == null)
            {
                StaticMethodHolder.WriteToLog(LogType.Warning, "Trying to execute an Insert query on a MainDatabaseConnection Object without the connection being established.");
                return;
            }

            SqlCommand command = new(query, Connection);

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

            ExecuteCommandNonQuery(command);
        }
        
        /// <summary>
        /// Gets the query that needs to be executed on the remote server from the selected procedure.
        /// </summary>
        /// <param name="SPName">The name of the selected Stored Procedure</param>
        public string? GetSPQuery(string SPName)
        {
            if (Connection == null)
            {
                StaticMethodHolder.WriteToLog(LogType.Warning, "Trying to get query from a Stored Procedure on a MainDatabaseConnection Object without the connection being established.");
                return null;
            }

            SqlCommand command = new(SPName, Connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                string? result = command.ExecuteScalar().ToString();
                StaticMethodHolder.WriteToLog(LogType.Information, $"Got query from SP  on the main database successfully.");
                return result;
            }
            catch (Exception ex) 
            {
                StaticMethodHolder.WriteToLog(LogType.Error, $"Failed to get query from SP. Details: {ex}");
                return null;
            }
        }
        
        /// <summary>
        /// Executes the selected queries on the selected remote databases. 
        /// The method retrieves the inner query from each specified Stored Procedure (SP) 
        /// and attempts to execute it on each selected remote database connection. 
        /// If a connection is not already established, it attempts to establish a new connection. 
        /// If successful, the results are processed, and any necessary data retrieval is performed. 
        /// The method also handles errors related to query retrieval, connection establishment, 
        /// and connection string conversion, reporting them at the end of the execution.
        /// </summary>
        /// <param name="SPList">List of selected Stored Procedures.</param>
        /// <param name="connectionList">List of selected remote database connections.</param>
        public void ExecuteSPsRemote(List<DataRowView> SPList, List<DataRowView> connectionList)
        {
            if (Connection == null)
                return;

            // For error Reporting
            var failedQueryBuilder = new StringBuilder("( Note:: Please check how the format of SPs should be )\n\rFailed Retriveal of Queries from the following SPs:\n\r"); 
            var FailedConnectionBuilder = new StringBuilder("Failed to establish connection to the following Databases:\n\r");
            var FailedConversionBuilder = new StringBuilder("Failed to convert data to a connection string:\n\r");
            bool queryFailed = false;
            bool connectionFailed = false;
            bool conversionFailed = false;

            // Get every selected Store Procedure
            foreach (var SP in SPList) {
                if (SP[ProcedureFilter] is not string procedureName)
                {
                    StaticMethodHolder.WriteToLog(LogType.Error, $"(EXECUTION OPERATION) Failed getting Procedure name using {ProcedureFilter} as column for it.");
                    continue;
                }

                // Get every SPs inner query
                string? SPsInnerQuery = GetSPQuery(procedureName);
                if (SPsInnerQuery == null){
                    failedQueryBuilder.Append($"{procedureName}\n\r");
                    queryFailed = true;
                    continue;
                }

                foreach (var connection in connectionList) {
                    // Get every selected connection
                    int? connectionId = connection[ConnectionFilter] as int?;

                    if (connectionId == null)
                    {
                        StaticMethodHolder.WriteToLog(LogType.Error, $"(EXECUTION OPERATION) Failed getting Connection Id using {ConnectionFilter} as column for it.");
                        continue;
                    }

                    // Check if there's an established connection, if not try to establish it.
                    int eci = establishedConnections.FindIndex(c => c.GetDatabasesConnectionStringId() == connectionId);

                    if (eci == -1) {
                        ConnectionString? tempCS = MapRowToConnectionString(connection);

                        if (tempCS == null) {
                            FailedConversionBuilder.Append($"Database {ConnectionFilter}: {connection}\n\r");
                            conversionFailed = true;
                            continue;
                        }

                        RemoteDatabaseConnection databaseConnection = new(tempCS, (int)connectionId);

                        if (!databaseConnection.OpenConnection())
                        {
                            FailedConnectionBuilder.Append($"Database {ConnectionFilter}: {connection}\n\r");
                            connectionFailed = true;
                            continue;
                        }

                        // Add the newly established connection to the list
                        establishedConnections.Add(databaseConnection);
                        StaticMethodHolder.WriteToLog(LogType.Error, $"(EXECUTION OPERATION) Established and added Connection (w ID={connectionId}) to Connection List ");


                        eci = establishedConnections.Count - 1;
                    }
                    // Store the results in a reader so that you can pass them to the main database if needed.
                    SqlDataReader? result = establishedConnections[(int)eci].ExecuteQueryDbDataReader(SPsInnerQuery);
                    MessageBox.Show("SP executed succesfully");

                    if (result == null)
                        continue;

                    // Check to see if data retrieval is necessary

                    if (SP[DataRetrivealColumn] is not string toBeExecuted)
                        continue;

                    MessageBox.Show("Starting data retrieval Operation.");
                    StaticMethodHolder.WriteToLog(LogType.Information, "Starting Execution of OnReturnExecute SP.");
                    InsertResult(toBeExecuted, result);
                }
            }

            // Show all the errors
            if (queryFailed) MessageBox.Show(failedQueryBuilder.ToString());
            if (conversionFailed) MessageBox.Show(FailedConversionBuilder.ToString());
            if (connectionFailed) MessageBox.Show(FailedConnectionBuilder.ToString());
        }
        
        /// <summary>
        /// Maps a <see cref="DataRowView"/> representing a database connection to a <see cref="ConnectionString"/> object.
        /// This method extracts connection details such as server IP, port, instance name, authentication type, 
        /// username, and password from the given DataRowView. 
        /// If any of the required fields are missing or invalid, the method returns null.
        /// </summary>
        /// <param name="connection">A DataRowView containing the connection details.</param>
        /// <returns>A <see cref="ConnectionString"/> object if mapping is successful; otherwise, null.</returns>
        private static ConnectionString? MapRowToConnectionString(DataRowView? connection)
        {
            if (connection == null) {
                StaticMethodHolder.WriteToLog(LogType.Warning, "Trying to map a null row to a Connection String.");
                return null; 
            }

            int? port = connection["Port"] as int?;
            bool? SQLAuth = connection["SQLAuth"] as Boolean?;
            string? username = connection["UserName"] as string;
            string? password = connection["Password"] as string;

            if (connection["ServerIPorName"] is not string serverIP || connection["InstanceName"] is not string instanceName || port == null || SQLAuth == null || (SQLAuth == true && (username == null || password == null)))
            {
                StaticMethodHolder.WriteToLog(LogType.Error, "Mapping a row to a Connection String failed. Possible null values given.");
                return null;
            }

            StaticMethodHolder.WriteToLog(LogType.Information, "Succesfully mapped a row to a Connection String.");

            return new(
                    serverIP,
                    (int)port,
                    instanceName,
                    (bool)SQLAuth,
                    username,
                    password,
                    true
             );
        }
        
        /// <summary>
        /// Inserts the results from a <see cref="SqlDataReader"/> into the database by executing a stored procedure with the retrieved data as parameters.
        /// This method loops through each row in the reader, extracts the field names and values, and adds them as parameters to the specified stored procedure. 
        /// The stored procedure is then executed for each row in the reader.
        /// The parameter number and parameters names should be the same as the columns of the retrieved data. 
        /// </summary>
        /// <param name="procedureName">The name of the stored procedure to execute.</param>
        /// <param name="reader">A <see cref="SqlDataReader"/> containing the data to be inserted.</param>
        private void InsertResult(string procedureName, SqlDataReader reader)
        {

            while (reader.Read())
            {
                var command = new SqlCommand(procedureName, Connection) { CommandType = CommandType.StoredProcedure };
                // Loop through each field in the row
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    // Get the field value
                    object fieldValue = reader.GetValue(i);

                    // Get the field name (this assumes that your stored procedure uses the same names as the database columns)
                    string parameterName = reader.GetName(i);

                    command.Parameters.AddWithValue(parameterName, fieldValue);
                }

                bool result = ExecuteCommandNonQuery(command);

                if (!result)
                {
                    StaticMethodHolder.WriteToLog(LogType.Error, "Retrieving data failed for one row. Aborting operation.");
                    break;
                }
            }
            MessageBox.Show("Data retrieved.");
            StaticMethodHolder.WriteToLog(LogType.Information, "OnReturnExecute SP executed successfully. Data retrieved.");

            reader.Close();
        }
    }
}
