using OGRIT_Database_Custom_App.Model;

/// <summary>
/// Represents a remote database connection with Database's Connection String Id field to differenciate it from other remote db connections.
/// </summary>
namespace OGRIT_Database_Custom_App.Models
{
    public class RemoteDatabaseConnection : DatabaseConnection
    {
        private readonly int _connectionStringsId;

        public RemoteDatabaseConnection(ConnectionString cs, int connectionStringsId) : base(cs)
        {
            _connectionStringsId = connectionStringsId;
        }
        /// <summary>
        /// Gets the Database's Connection String Id.
        /// </summary>
        /// <returns>The server name or IP address.</returns>
        public int GetDatabasesConnectionStringId()
        {
            return _connectionStringsId;
        }
    }
}
