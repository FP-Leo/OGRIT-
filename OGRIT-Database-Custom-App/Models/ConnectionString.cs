using DataJuggler.Core.Cryptography;
using OGRIT_Database_Custom_App.Generics;
using System.Configuration;
using static OGRIT_Database_Custom_App.Generics.ScreenEnums;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OGRIT_Database_Custom_App.Models
{
    /// <summary>
    /// Represents a connection string used to connect to a database.
    /// </summary>
    public class ConnectionString
    {
        // Fields
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
        /// <param name="AlreadyEncrypted">A flag indicating whether <paramref name="password"/> is <c>already encrypted</c>.</param>
        public ConnectionString(string serverNameIP, int Port, string InstanceName, bool SQLAuth, string? username, string? password, bool AlreadyEncrypted)
        {
            _serverNameIP = serverNameIP;
            _Port = Port;
            _InstanceName = InstanceName;
            _SQLAuth = SQLAuth;
            if (SQLAuth)
            {
                // The way the code is written it should never be null nor empty (we do the validation on the input form), but you never know.
                if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password)) {
                    StaticMethodHolder.WriteToLog(LogType.Warning, "Failed to create Connection String. SQL Auth selected but no credentials specified.");
                    return;
                }

                _username = username;

                // The password is encrypted if provided and SQL authentication is used.
                _password = password;

                // Upon getting an unencrypted password, encrypt it.
                if (!AlreadyEncrypted)
                {
                    _password = CryptographyHelper.EncryptString(password, ConfigurationManager.AppSettings["encryptionKey"]);
                }
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
