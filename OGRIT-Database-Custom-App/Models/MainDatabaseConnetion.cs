using OGRIT_Database_Custom_App.Model;
using System.Data.SqlClient;
using System.Data;

namespace OGRIT_Database_Custom_App.Models
{
    /// <summary>
    /// Represents a database connection with additional functionalities for executing queries and commands.
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
            if (Connection == null)
                return null;

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
            if (Connection == null)
                return;

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
                return null;

            SqlCommand command = new(SPName, Connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            try
            {
                string? result = command.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
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
            string FailedQuery = "( Note:: Please check how the format of SPs should be )\n\rFailed Retriveal of Queries from the following SPs:\n\r";
            string FailedConnection = "Failed to establish connection to the following Databases:\n\r";
            string FailedConversion = "Failed to convert data to a connection string:\n\r";
            bool queryFailed = false;
            bool connectionFailed = false;
            bool conversionFailed = false;

            // Get every selected Store Procedure
            foreach (var SP in SPList) {
                string? procedureName = SP[ProcedureFilter] as string;

                if(procedureName == null) continue;

                // Get every SPs inner query
                string? SPsInnerQuery = GetSPQuery(procedureName);
                if (SPsInnerQuery == null){
                    FailedQuery += $"{procedureName}\n\r";
                    queryFailed = true;
                    continue;
                }

                foreach (var connection in connectionList) {
                    // Get every selected connection
                    int? connectionId = connection[ConnectionFilter] as int?;

                    if (connectionId == null) continue;

                    // Check if there's an established connection, if not try to establish it.
                    int? eci = EstablishedConnectionIndex((int)connectionId);

                    if (eci == null) {
                        ConnectionString? tempCS = RowToConnectionStringMapper(connection);

                        if (tempCS == null) {
                            FailedConversion += $"Database {ConnectionFilter}: {connection}\n\r";
                            conversionFailed = true;
                            continue;
                        }

                        RemoteDatabaseConnection databaseConnection = new(tempCS, (int)connectionId);

                        if (!databaseConnection.OpenConnection())
                        {
                            FailedConnection += $"Database {ConnectionFilter}: {connection}\n\r";
                            connectionFailed = true;
                            continue;
                        }

                        // Add the newly established connection to the list
                        establishedConnections.Add(databaseConnection);

                        eci = establishedConnections.Count - 1;
                    }
                    // Store the results in a reader so that you can pass them to the main database if needed.
                    SqlDataReader? result = establishedConnections[(int)eci].ExecuteQueryDbDataReader(SPsInnerQuery);

                    MessageBox.Show("SP executed succesfully");

                    if (result == null)
                        continue;

                    // Check to see if data retrieval is necessary
                    string? toBeExecuted = SP[DataRetrivealColumn] as string;

                    if (toBeExecuted == null)
                        continue;

                    MessageBox.Show("Starting data retrieval Operation.");
                    InsertResult(toBeExecuted, result);
                }
            }

            // Show all the errors
            if (queryFailed) MessageBox.Show(FailedQuery);
            if (conversionFailed) MessageBox.Show(FailedConversion);
            if (connectionFailed) MessageBox.Show(FailedConnection);
        }
        /// <summary>
        /// Maps a <see cref="DataRowView"/> representing a database connection to a <see cref="ConnectionString"/> object.
        /// This method extracts connection details such as server IP, port, instance name, authentication type, 
        /// username, and password from the given DataRowView. 
        /// If any of the required fields are missing or invalid, the method returns null.
        /// </summary>
        /// <param name="connection">A DataRowView containing the connection details.</param>
        /// <returns>A <see cref="ConnectionString"/> object if mapping is successful; otherwise, null.</returns>

        private static ConnectionString? RowToConnectionStringMapper(DataRowView? connection)
        {
            if(connection == null) return null;

            string? serverIP = connection["ServerIPorName"] as string;
            int? port = connection["Port"] as int?;
            string? instanceName = connection["InstanceName"] as string;
            bool? SQLAuth = connection["SQLAuth"] as Boolean?;
            string? username = connection["UserName"] as string;
            string? password = connection["Password"] as string;

            if (serverIP == null || port == null || instanceName == null || SQLAuth == null)
                return null;

            if (SQLAuth == true && (username == null || password == null))
                return null;

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

                ExecuteCommandNonQuery(command);
            }
            MessageBox.Show("Data retrieved.");

            reader.Close();
        }
        /// <summary>
        /// Finds the index of an established database connection based on the given connection ID.
        /// This method iterates through the list of established connections and returns the index of the connection 
        /// that matches the provided connection ID. If no match is found, it returns <c>null</c>.
        /// </summary>
        /// <param name="connectionID">The ID of the connection to find.</param>
        /// <returns>The index of the matching connection in the <see cref="establishedConnections"/> list, or <c>null</c> if not found.</returns>
        private int? EstablishedConnectionIndex(int connectionID)
        {
            for(int i = 0; i < establishedConnections.Count; i++)
            {
                if (establishedConnections[i].getDatabaseId() == connectionID)
                    return i;
            }
            return null;
        }
    }
}
