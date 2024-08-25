using DataJuggler.Core.Cryptography;
using System.Configuration;
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
        private bool encrypted = false;

        public ConnectionString(string serverNameIP, int Port, string InstanceName, bool SQLAuth, string? username, string? password)
        {
            _serverNameIP = serverNameIP;
            _Port = Port;
            _InstanceName = InstanceName;
            _SQLAuth = SQLAuth;
            if (SQLAuth)
            {
                _username = username;
                // The way the code is written it should never be null nor empty (we do the validation on the input form), but you never know.
                if (String.IsNullOrEmpty(password))
                    return;
                // Upon getting the password, encrypt it.
                _password = CryptographyHelper.EncryptString(password, ConfigurationManager.AppSettings["encryptionKey"]);
                encrypted = true;
            }
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
            if(encrypted) 
                return _password;
            return null;
        }
    }
}
