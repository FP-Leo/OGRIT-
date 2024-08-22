using System.Data.SqlClient;
using System.Data;
using OGRIT_Database_Custom_App.Models;
using System.Data.Common;


namespace OGRIT_Database_Custom_App.Model
{
    public class DatabaseConnection
    {
        protected SqlConnection? Connection;

        public DatabaseConnection(){}
        public void OpenConnection()
        {
            if (Connection == null) return;

            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
        }
        public void CloseConnection()
        {
            if (Connection == null) return;

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
    }
}
