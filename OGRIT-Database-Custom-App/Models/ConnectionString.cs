using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OGRIT_Database_Custom_App.Models
{
    public class ConnectionString
    {
        private string _serverNameIP;
        private int _Port;
        private string _InstanceName;
        private bool _SQLAuth;
        private string? _username;
        private string? _password;

        public ConnectionString(string serverNameIP, int Port, string InstanceName, bool SQLAuth, string username, string password)
        {
            _serverNameIP = serverNameIP;
            _Port = Port;
            _InstanceName = InstanceName;
            _SQLAuth = SQLAuth;
            _username = username;
            _password = password;
        }

        public override string ToString() {
            string connectionString = $"Data Source={_serverNameIP},{_Port};Initial Catalog={_InstanceName};";
            if (_SQLAuth)
            {
                connectionString += $"User ID={_username};Password={_password};";
            }
            else
            {
                connectionString += "Integrated Security=True;";
            }
            return connectionString;
        }

        public string GetServerNameIP()
        {
            return _serverNameIP ;
        }

        public int GetPort()
        {
            return _Port ;
        }
        public string GetInstanceName() { 
            return _InstanceName ;
        }

        public bool IsSQLAuth() { 
            return _SQLAuth;
        }

        public string? GetUsername() {
            return _username;
        }

        public string? GetPassword() {
            return _password;
        }
    }
}
