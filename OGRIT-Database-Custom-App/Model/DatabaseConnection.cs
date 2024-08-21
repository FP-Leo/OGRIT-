using System.Data.SqlClient;
using System.Data;


namespace OGRIT_Database_Custom_App.Model
{
    public class DatabaseConnection
    {
        public SqlConnection Connection { get; private set; }

        public DatabaseConnection(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }
        public void OpenConnection()
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
        }
        public void CloseConnection()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }
}
