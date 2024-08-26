using System.Data.SqlClient;
using System.Data;
using OGRIT_Database_Custom_App.Models;
using System.Data.Common;
using DataJuggler.Core.Cryptography;
using System.Configuration;


namespace OGRIT_Database_Custom_App.Model
{
    public class DatabaseConnection
    {
        private ConnectionString? cs;
        protected SqlConnection? Connection;

        public DatabaseConnection()
        {}
        public bool OpenConnection()
        {
            try
            {
                if (Connection == null)
                    Connection = new SqlConnection(FormatConnectionString());
                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        public void CloseConnection()
        {
            if (Connection == null)
                return;

            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }

        public void ExecuteCommand(SqlCommand command)
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

        public void ExecuteQuery(string query)
        {
            var command = new SqlCommand(query, Connection);
            ExecuteCommand(command);
        }
        private string FormatConnectionString()
        {
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
        public void setConnectionString(ConnectionString connectionString)
        {
            cs = connectionString;
        }
    }
}
