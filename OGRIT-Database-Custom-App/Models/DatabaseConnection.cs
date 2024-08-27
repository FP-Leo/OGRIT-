using System.Data.SqlClient;
using System.Data;
using OGRIT_Database_Custom_App.Models;
using DataJuggler.Core.Cryptography;
using System.Configuration;


namespace OGRIT_Database_Custom_App.Model
{
    public class DatabaseConnection
    {
        private ConnectionString? cs;
        protected SqlConnection? Connection;

        public DatabaseConnection(){}
        public DatabaseConnection(ConnectionString connectionString) {
            cs = connectionString;
        }
        public bool OpenConnection()
        {
            try
            {
                if( cs == null)
                    return false;

                Connection ??= new SqlConnection(FormatConnectionString());

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

        public static void ExecuteCommand(SqlCommand command)
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
        private string? FormatConnectionString()
        {
            if (cs == null)
                return null;
            string connectionString = $"Data Source={cs.GetServerNameIP()},{cs.GetPort()};Initial Catalog={cs.GetInstanceName()};";
            if (cs.IsSQLAuth())
            {
                /*
                var encryptionKey = ConfigurationManager.AppSettings["encryptionKey"];
                if (string.IsNullOrEmpty(encryptionKey))
                {
                    MessageBox.Show("Encryption key is missing or empty.");
                    return null;
                }

                MessageBox.Show(encryptionKey);

                var encryptedPassword = cs.GetPassword();
                if (string.IsNullOrEmpty(encryptedPassword))
                {
                    MessageBox.Show("Encrypted password is missing or empty.");
                    return null;
                }

                MessageBox.Show(encryptedPassword);
                */

                var decryptedPassword = CryptographyHelper.DecryptString(cs.GetPassword(), ConfigurationManager.AppSettings["encryptionKey"]);
                connectionString += $"User ID={cs.GetUsername()};Password={decryptedPassword};";
                //MessageBox.Show("Connection String: " + connectionString);
            }
            else
            {
                connectionString += "Integrated Security=True;";
            }
            return connectionString;
        }
        public void SetConnectionString(ConnectionString connectionString)
        {
            cs = connectionString;
        }
    }
}
