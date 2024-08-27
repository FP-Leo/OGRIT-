using DataJuggler.Core.Cryptography;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OGRIT_Database_Custom_App.Models
{
    /// <summary>
    /// Represents a connection string used to connect to a database.
    /// </summary>
    public class ConnectionString
    {
        private readonly string _serverNameIP;
        private readonly int _Port;
        private readonly string _InstanceName;
        private readonly bool _SQLAuth;
        private readonly string? _username;
        private readonly string? _password;
        private readonly bool encrypted = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionString"/> class with the specified parameters.
        /// </summary>
        /// <param name="serverNameIP">The server name or IP address.</param>
        /// <param name="Port">The port number for the connection.</param>
        /// <param name="InstanceName">The instance name of the SQL Server.</param>
        /// <param name="SQLAuth">A flag indicating whether SQL authentication is used.</param>
        /// <param name="username">The username for SQL authentication. This parameter is ignored if <paramref name="SQLAuth"/> is <c>false</c>.</param>
        /// <param name="password">The password for SQL authentication. This parameter is ignored if <paramref name="SQLAuth"/> is <c>false</c>.</param>
        public ConnectionString(string serverNameIP, int Port, string InstanceName, bool SQLAuth, string? username, string? password)
        {
            _serverNameIP = serverNameIP;
            _Port = Port;
            _InstanceName = InstanceName;
            _SQLAuth = SQLAuth;
            if (SQLAuth)
            {
                _username = username;
                // The password is encrypted if provided and SQL authentication is used.
                if (String.IsNullOrEmpty(password))
                    return;
                // Encrypt the password using the encryption key from configuration.
                _password = CryptographyHelper.EncryptString(password, ConfigurationManager.AppSettings["encryptionKey"]);
                encrypted = true;
            }
        }

        /// <summary>
        /// Gets the server name or IP address.
        /// </summary>
        /// <returns>The server name or IP address.</returns>
        public string GetServerNameIP()
        {
            return _serverNameIP;
        }

        /// <summary>
        /// Gets the port number for the connection.
        /// </summary>
        /// <returns>The port number.</returns>
        public int GetPort()
        {
            return _Port;
        }

        /// <summary>
        /// Gets the instance name of the SQL Server.
        /// </summary>
        /// <returns>The instance name.</returns>
        public string GetInstanceName()
        {
            return _InstanceName;
        }

        /// <summary>
        /// Gets a value indicating whether SQL authentication is used.
        /// </summary>
        /// <returns><c>true</c> if SQL authentication is used; otherwise, <c>false</c>.</returns>
        public bool IsSQLAuth()
        {
            return _SQLAuth;
        }

        /// <summary>
        /// Gets the username for SQL authentication.
        /// </summary>
        /// <returns>The username, or <c>null</c> if SQL authentication is not used.</returns>
        public string? GetUsername()
        {
            return _username;
        }

        /// <summary>
        /// Gets the encrypted password for SQL authentication.
        /// </summary>
        /// <returns>The encrypted password if SQL authentication is used; otherwise, <c>null</c>.</returns>
        public string? GetPassword()
        {
            if (encrypted)
                return _password;
            return null;
        }
    }
}
