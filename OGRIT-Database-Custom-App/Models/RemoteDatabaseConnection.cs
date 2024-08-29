using OGRIT_Database_Custom_App.Model;

namespace OGRIT_Database_Custom_App.Models
{
    public class RemoteDatabaseConnection : DatabaseConnection
    {
        private readonly int _databaseId;

        public RemoteDatabaseConnection(ConnectionString cs, int databaseId) : base(cs)
        {
            _databaseId = databaseId;
        }

        public int getDatabaseId()
        {
            return _databaseId;
        }
    }
}
