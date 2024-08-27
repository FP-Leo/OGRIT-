using OGRIT_Database_Custom_App.Model;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace OGRIT_Database_Custom_App.Models
{
    public class MainDatabaseConnetion : DatabaseConnection
    {
        private readonly List<RemoteDatabaseConnection> establishedConnections = [];
        // Configuration 
        private readonly string _ConnectionTable;
        private readonly string _ConnectionTableSchema;
        //private readonly string _ProcedureTable;
        //private readonly string _ProcedureTableSchema;
        private readonly string _FilterColumn;

        public MainDatabaseConnetion(string ConnectionTable, string ConnectionTableSchema, string FilterColumn)
        {
            _ConnectionTable = ConnectionTable;
            _ConnectionTableSchema = ConnectionTableSchema;
            // _ProcedureTable = ProcedureTable;
            // _ProcedureTableSchema = ProcedureTableSchema;
            _FilterColumn = FilterColumn;
        }
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

            ExecuteCommand(command);
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
        public void ExecuteSPsRemote(List<string> SPList, List<int> connectionIDList)
        {
            if (Connection == null)
                return;

            string FailedQuery = "( Note:: Please check how the format of SPs should be )\n\rFailed Retriveal of Queries from the following SPs:\n\r";
            string FailedFetching = "Failed to retrieve to the following Database Connection String(Report to administrator):\n\r";
            string FailedConnection = "Failed to establish connection to the following Databases:\n\r";
            string OtherErrors = "Other Errors:\n\r";
            bool failed = false;
            foreach (var SP in SPList) {
                string? SPsInnerQuery = GetSPQuery(SP);
                if (SPsInnerQuery == null){
                    FailedQuery += SP + "\n\r";
                    failed = true;
                    continue;
                }
                foreach (var connectionID in connectionIDList) { 
                    int? eci = EstablishedConnectionIndex(connectionID);

                    if (eci == null) { 
                        string selectQuery = $"SELECT * FROM [{_ConnectionTableSchema}].[{_ConnectionTable}] WHERE {_FilterColumn}={connectionID}";
                        DataTable? dataTable = ExecuteSelectQueryAndGetResult(selectQuery);
                        if(dataTable == null)
                        {
                            FailedFetching += "Database Id: " + connectionID + "\n\r";
                            continue;
                        }

                        if(dataTable.Rows.Count > 1)
                        {
                            OtherErrors += $"More than one connection string returned for database id {connectionID}. Please use a Unique column for filtering";
                            continue;
                        }

                        ConnectionString tempCS = new(
                                Convert.ToString(dataTable.Rows[0]["ServerIPorName"]),
                                Convert.ToInt32(dataTable.Rows[0]["Port"]),
                                Convert.ToString(dataTable.Rows[0]["InstanceName"]),
                                Convert.ToBoolean(dataTable.Rows[0]["SQLAuth"]),
                                Convert.ToString(dataTable.Rows[0]["UserName"]),
                                Convert.ToString(dataTable.Rows[0]["Password"]),
                                true
                            );

                        RemoteDatabaseConnection databaseConnection = new(tempCS, connectionID);

                        if (!databaseConnection.OpenConnection())
                        {
                            FailedConnection += "Database Id: " + connectionID + "\n\r";
                            continue;
                        }

                        establishedConnections.Add(databaseConnection);

                        eci = establishedConnections.Count - 1;
                    }

                    establishedConnections[(int)eci].ExecuteQuery(SPsInnerQuery);
                }
            }
            if (failed)
                MessageBox.Show(FailedQuery);
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
