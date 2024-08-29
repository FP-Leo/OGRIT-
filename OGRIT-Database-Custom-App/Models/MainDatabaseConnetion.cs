using OGRIT_Database_Custom_App.Model;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace OGRIT_Database_Custom_App.Models
{
    /// <summary>
    /// Represents a database connection with additional functionalities for executing queries and commands.
    /// </summary>
    public class MainDatabaseConnection : DatabaseConnection
    {
        private readonly List<RemoteDatabaseConnection> establishedConnections = [];
        //private List<DatabaseConnection>? estabileshedConnections;

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
        public void ExecuteSPsRemote(List<DataRowView> SPList, List<DataRowView> connectionIDList)
        {
            if (Connection == null)
                return;

            string FailedQuery = "( Note:: Please check how the format of SPs should be )\n\rFailed Retriveal of Queries from the following SPs:\n\r";
            //string FailedFetching = "Failed to retrieve to the following Database Connection String(Report to administrator):\n\r";
            string FailedConnection = "Failed to establish connection to the following Databases:\n\r";
            //string OtherErrors = "Other Errors:\n\r";
            bool failed = false;
            foreach (var SP in SPList) {
                string? procedureName = SP["ProcedureName"] as string;

                if(procedureName == null) continue;

                string? SPsInnerQuery = GetSPQuery(procedureName);
                if (SPsInnerQuery == null){
                    FailedQuery += SP + "\n\r";
                    failed = true;
                    continue;
                }

                foreach (var connection in connectionIDList) {
                    int? connectionId = connection["ID"] as int?;

                    if (connectionId == null) continue;

                    int? eci = EstablishedConnectionIndex((int)connectionId);

                    if (eci == null) {

                        string? serverIP = connection["ServerIPorName"] as string;
                        int? port = connection["Port"] as int?;
                        string? instanceName = connection["InstanceName"] as string;
                        bool? SQLAuth = connection["SQLAuth"] as Boolean?;
                        string? username = connection["UserName"] as string;
                        string? password = connection["Password"] as string;

                        if (serverIP == null || port == null || instanceName == null || SQLAuth == null)
                            continue;

                        if (SQLAuth == true && (username == null || password == null))
                            continue;

                        ConnectionString tempCS = new(
                                serverIP,
                                (int)port, 
                                instanceName, 
                                (bool)SQLAuth,
                                username,
                                password,
                                true
                         );

                        RemoteDatabaseConnection databaseConnection = new(tempCS, (int)connectionId);

                        if (!databaseConnection.OpenConnection())
                        {
                            FailedConnection += "Database Id: " + connection + "\n\r";
                            failed = true;
                            continue;
                        }

                        establishedConnections.Add(databaseConnection);

                        eci = establishedConnections.Count - 1;
                    }

                    SqlDataReader? result = establishedConnections[(int)eci].ExecuteQueryDbDataReader(SPsInnerQuery);

                    if (result == null)
                        continue;

                    string? toBeExecuted = SP["OnReturnExecute"] as string;

                    if(toBeExecuted == null)
                        continue;

                    InsertResult(toBeExecuted, result);
                }
            }
            if (failed)
                MessageBox.Show(FailedQuery + FailedConnection);
        }

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
            reader.Close();
        }

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
