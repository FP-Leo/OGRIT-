using OGRIT_Database_Custom_App.Generics;
using OGRIT_Database_Custom_App.Models;
using OGRIT_Database_Custom_App.Views.Screens;
using System.Data;
using System.Security.Cryptography;
using static OGRIT_Database_Custom_App.Generics.ScreenEnums;

namespace OGRIT_Database_Custom_App.Controller
{
    /// <summary>
    /// MainController class is responsible for handling the main logic of the application, including 
    /// initializing screens, managing screen transitions, and interacting with the database.
    /// </summary>
    public class MainController
    {
        // Views
        /// <summary>
        /// The main window of the application.
        /// </summary>
        private readonly MainWindow mainWindow;

        /// <summary>
        /// The starting screen of the application.
        /// </summary>
        private StartingScreen? _startingScreen;

        /// <summary>
        /// The login screen of the application.
        /// </summary>
        private LogInScreen? _logInScreen;

        /// <summary>
        /// The menu screen of the application.
        /// </summary>
        private MenuScreen? _menuScreen;

        //// SubScreens
        /// <summary>
        /// The manage connections screen, used for handling database connections.
        /// </summary>
        private ManageConnectionsScreen? _connectionsScreen;

        /// <summary>
        /// The procedure list screen, used for viewing stored procedures.
        /// </summary>
        private ProcedureListScreen? _showProceduresScreen;

        /// <summary>
        /// The execute procedures screen, used for executing stored procedures.
        /// </summary>
        private ExecuteProceduresScreen? _executeProceduresScreen;

        // Models
        /// <summary>
        /// The main database connection instance.
        /// </summary>
        private readonly MainDatabaseConnection mainDBConnection;

        // Configuration 

        /// <summary>
        /// Indicates if the encryption key has been generated.
        /// </summary>
        private readonly string keyGenerated;

        /// <summary>
        /// The name of the table containing connection information.
        /// </summary>
        private readonly string ConnectionTable;

        /// <summary>
        /// The schema of the connection table.
        /// </summary>
        private readonly string ConnectionTableSchema;

        /// <summary>
        /// The name of the table containing stored procedures.
        /// </summary>
        private readonly string ProcedureTable;

        /// <summary>
        /// The schema of the procedure table.
        /// </summary>
        private readonly string ProcedureTableSchema;

        /// <summary>
        /// Name of the column that's used to retrieve data from Connection Table.
        /// </summary>
        private readonly string ConnectionFilterColumn;

        /// <summary>
        /// Name of the column that's used to retrieve data from Procedure Table.
        /// </summary>
        private readonly string ProcedureFilterColumn;

        /// <summary>
        /// Name of the column that's holds the stored procedure to retrieve data from already executed queries.
        /// </summary>
        private readonly string DataRetrivealColumn;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainController"/> class.
        /// Declares the log file, configures its settings.
        /// Validates configuration settings and sets up the main database connection.
        /// </summary>
        public MainController()
        {
            StaticMethodHolder.SetUpLogging();

            StaticMethodHolder.WriteToLog(LogType.Information, "Validating configuration.");
            // Validate Config
            keyGenerated = StaticMethodHolder.GetConfigKey("keyGenerated");

            ConnectionTable = StaticMethodHolder.GetConfigKey("ConnectionTable");
            ConnectionTableSchema = StaticMethodHolder.GetConfigKey("ConnectionTableSchema");
            ProcedureTable = StaticMethodHolder.GetConfigKey("ProcedureTable");
            ProcedureTableSchema = StaticMethodHolder.GetConfigKey("ProcedureTableSchema");
            ConnectionFilterColumn = StaticMethodHolder.GetConfigKey("ConnectionFilterColumn");
            ProcedureFilterColumn = StaticMethodHolder.GetConfigKey("ProcedureFilterColumn");
            DataRetrivealColumn = StaticMethodHolder.GetConfigKey("DataRetrivealColumn");

            CheckEncrypitonKey();
            StaticMethodHolder.WriteToLog(LogType.Information, "Configuration validated.");

            StaticMethodHolder.WriteToLog(LogType.Information, "Initilizing Main Window.");
            mainDBConnection = new MainDatabaseConnection(ConnectionFilterColumn, ProcedureFilterColumn, DataRetrivealColumn);
            mainWindow = new MainWindow();
            StaticMethodHolder.WriteToLog(LogType.Information, "Main Window initialized.");
        }
        /// <summary>
        /// Checks if the Encryption Key has already been generated, if not it generates it.
        /// </summary>
        private void CheckEncrypitonKey()
        {
            bool success = bool.TryParse(keyGenerated, out bool result);

            if (!success)
            {
                StaticMethodHolder.WriteToLog(LogType.Error, "Failed to convert keyGenerated value from App.config to a boolean value.");
                MessageBox.Show("Error: Invalid value on keyGenerated.");
                System.Environment.Exit(1);
            }

            if (!result)
            {
                using (Aes aes = Aes.Create())
                {
                    // Generate a new key and IV
                    aes.GenerateIV();
                    aes.GenerateKey();

                    // Retrieve the generated key
                    byte[] key = aes.Key;

                    // Optionally, convert the key to a Base64 string
                    string base64Key = Convert.ToBase64String(key);

                    // Change the value in config
                    StaticMethodHolder.UpdateAppConfig("encryptionKey", base64Key);

                    // Log the change
                    StaticMethodHolder.WriteToLog(LogType.Information, "Encryption Key Generated.");

                    // Change the indicator value in config
                    StaticMethodHolder.UpdateAppConfig("keyGenerated", "true");
                }
            }            
        }

        /// <summary>
        /// Starts the application by displaying the starting screen and running the main window.
        /// </summary>
        public void Run()
        {
            ChangeScreen(null, Screens.StartingScreen);
            Application.Run(mainWindow);
            StaticMethodHolder.WriteToLog(LogType.Information, "Program Running.");
        }
      
        // Screen Switcher
        /// <summary>
        /// Changes the current screen to a new screen.
        /// </summary>
        /// <param name="toBeDestroyed">The screen to be destroyed before switching.</param>
        /// <param name="toBeSet">The screen to be set after destruction.</param>
        private void ChangeScreen(Screens? toBeDestroyed, Screens toBeSet)
        {
            if (toBeDestroyed != null) {
                DestroyScreen((Screens)toBeDestroyed);
            }
            SetScreen(toBeSet);
        }

        /// <summary>
        /// Changes the current sub-screen to a new screen. It will always change back to the Menu Screen.
        /// </summary>
        /// <param name="toBeDestroyed">The sub-screen to be destroyed before switching.</param>
        private void ChangeScreen(SubScreens toBeDestroyed)
        {
            DestroyScreen(toBeDestroyed);
            SetScreen(Screens.MenuScreen);
        }

        /// <summary>
        /// Sets the specified screen as the active screen.
        /// </summary>
        /// <param name="toBeSet">The screen to be set.</param>
        private void SetScreen(Screens toBeSet) {
            switch (toBeSet) {
                case Screens.StartingScreen:
                    _startingScreen = ScreenInitializer.InitializeStartingScreen();
                    SetStartingScreenChanger();
                    mainWindow.SetScreen(_startingScreen);
                    break;
                case Screens.LogInScreen:
                    _logInScreen = ScreenInitializer.InitializeLogInScreen();
                    SetLogInScreenChanger();
                    mainWindow.SetScreen(_logInScreen);
                    break;
                case Screens.MenuScreen:
                    if(_menuScreen == null)
                    {
                        _menuScreen = ScreenInitializer.InitializeMenuScreen();
                        SetMenuScreenChanger();
                    }
                    mainWindow.SetScreen(_menuScreen);
                    break;
            }
            StaticMethodHolder.WriteToLog(LogType.Information, $"{toBeSet} loaded.");
        }

        /// <summary>
        /// Sets the specified sub-screen as the active sub-screen.
        /// </summary>
        /// <param name="screen">The sub-screen to be set.</param>
        private void SetScreen(SubScreens screen) {
            switch (screen) {
                case SubScreens.ManageConnectionsScreen:
                    _connectionsScreen = ScreenInitializer.InitializeConnectionsScreen();
                    SetConnectionsScreenChanger();
                    mainWindow.SetScreen(_connectionsScreen);
                    break;
                case SubScreens.ViewProceduresScreen:
                    _showProceduresScreen = ScreenInitializer.InitializeProcedureList();
                    SetProcedureListScreenChanger();
                    mainWindow.SetScreen(_showProceduresScreen);
                    break;
                case SubScreens.ExecuteProceduresScreen:
                    _executeProceduresScreen = ScreenInitializer.InitializeExecutionScreen();
                    SetExecutionScreenChanger();
                    mainWindow.SetScreen(_executeProceduresScreen);
                    break;
            }
            StaticMethodHolder.WriteToLog(LogType.Information, $"{screen} loaded.");
        }

        /// <summary>
        /// Destroys the specified screen.
        /// </summary>
        /// <param name="toBeDestroyed">The screen to be destroyed.</param>
        public void DestroyScreen(Screens toBeDestroyed)
        {
            switch (toBeDestroyed)
            {
                case Screens.StartingScreen:
                    ScreenDestroyer.DestroyScreen(ref _startingScreen);
                    break;
                case Screens.LogInScreen:
                    ScreenDestroyer.DestroyScreen(ref _logInScreen);
                    break;
                case Screens.MenuScreen:
                    ScreenDestroyer.DestroyScreen(ref _menuScreen);
                    break;
            }
            StaticMethodHolder.WriteToLog(LogType.Information, $"{toBeDestroyed} destroyed.");
        }

        /// <summary>
        /// Destroys the specified sub-screen.
        /// </summary>
        /// <param name="toBeDestroyed">The sub-screen to be destroyed.</param>
        public void DestroyScreen(SubScreens toBeDestroyed)
        {
            switch (toBeDestroyed)
            {
                case SubScreens.ManageConnectionsScreen:
                    ScreenDestroyer.DestroyScreen(ref _connectionsScreen);
                    break;
                case SubScreens.ViewProceduresScreen:
                    ScreenDestroyer.DestroyScreen(ref _showProceduresScreen);
                    break;
                case SubScreens.ExecuteProceduresScreen:
                    ScreenDestroyer.DestroyScreen(ref _executeProceduresScreen);
                    break;
            }
            StaticMethodHolder.WriteToLog(LogType.Information, $"{toBeDestroyed} destroyed.");
        }

        // User Control Delegate Screen Changers.
        /// <summary>
        /// Sets the screen changer for the starting screen.
        /// </summary>
        private void SetStartingScreenChanger()
        {
            if (_startingScreen == null)
                return;

            _startingScreen.SetChanger(() =>
            {
                if (!StaticMethodHolder.ValidConfigKey("encryptionKey"))
                {
                    MessageBox.Show("Error: No encryption key found in the config file.\n\rCannot proceed to the Log In screen.");
                    StaticMethodHolder.WriteToLog(LogType.Error, "Encryption Key generated but not found.");
                    return;
                }
                ChangeScreen(Screens.StartingScreen, Screens.LogInScreen);
            });
        }

        /// <summary>
        /// Sets the screen changer for the login screen.
        /// </summary>
        private void SetLogInScreenChanger()
        {
            if (_logInScreen == null)
                return;

            _logInScreen.SetChanger((ConnectionString connection) =>
            {
                mainDBConnection.SetConnectionString(connection);
                
                if(mainDBConnection.OpenConnection())
                {
                    StaticMethodHolder.WriteToLog(LogType.Information, "Logged in to the main database");
                    ChangeScreen(Screens.LogInScreen, Screens.MenuScreen);
                }
            });
        }

        /// <summary>
        /// Sets the screen changer for the menu screen.
        /// </summary>
        private void SetMenuScreenChanger()
        {
            if (_menuScreen == null)
                return;
            _menuScreen.SetChanger(SetScreen);
        }

        /// <summary>
        /// Sets the screen changer for the manage connections screen.
        /// </summary>
        private void SetConnectionsScreenChanger()
        {
            if(_connectionsScreen == null) return;

            // On Execution perform the necessary action based on options.
            _connectionsScreen.SetConnectionScreenMenuSignal((ConnectionMenuOptions option) =>
            {
                switch (option)
                {
                    case ConnectionMenuOptions.Insert:
                        // Get submited data from the Insert Form.
                        ConnectionString? submittedCS = _connectionsScreen.GetInputedConnectionString();
                        
                        if(submittedCS == null) {
                            StaticMethodHolder.WriteToLog(LogType.Error, "(INSERT OPERATION) Failed conversion from user input to Connection String");
                            MessageBox.Show("Failed to convert data to a Database Connection String");
                            return; 
                        }

                        // Set the query
                        string insertQuery = $"INSERT INTO [{ConnectionTableSchema}].[{ConnectionTable}] VALUES ( @var1, @var2, @var3, @var4, @var5, @var6 )";

                        // Perform the insert
                        mainDBConnection.AddParamAndExecuteCommand(insertQuery, submittedCS);

                        // Refresh the data.
                        _connectionsScreen.RefreshTable();
                        break;
                    case ConnectionMenuOptions.Update:
                        // Get the ID of the connection that's going to get updated
                        int? id = _connectionsScreen.GetUpdateIndex();

                        if (id == null) {
                            StaticMethodHolder.WriteToLog(LogType.Error, "Failed retrieving selected Database Id");
                            MessageBox.Show("Failed retrieving selected Database Id");
                            return;
                        }

                        // Get the new data
                        var updatedCS = _connectionsScreen.GetInputedConnectionString();

                        if (updatedCS == null) {
                            StaticMethodHolder.WriteToLog(LogType.Error, "(UPDATE OPERATION) Failed conversion from table row to Connection String");
                            MessageBox.Show("Failed to convert data to a Database Connection String");
                            return; 
                        }

                        // Set up the update query
                        string updateQuery = $"UPDATE [{ConnectionTableSchema}].[{ConnectionTable}]  SET ServerIPorName=@var1, Port=@var2, InstanceName=@var3, SQLAuth=@var4, UserName=@var5, Password=@var6 WHERE ID={id}";

                        // Execute the update query
                        mainDBConnection.AddParamAndExecuteCommand(updateQuery, updatedCS);

                        // Refresh Data Grid.
                        _connectionsScreen.ResetUpdateIndex();
                        _connectionsScreen.RefreshTable();
                        break;
                    case ConnectionMenuOptions.Delete:
                        // Allow multiple deletions at the same time, loop through the selected.
                        foreach (DataGridViewRow row in _connectionsScreen.GetSelectedRows())
                        {
                            try
                            {
                                // Get the value that uniquely identifies the row.
                                var colValue = row.Cells[ConnectionFilterColumn].Value;
                                string? colText = Convert.ToString(colValue);
                                if (string.IsNullOrEmpty(colText)) {
                                    MessageBox.Show("Failed to convert ConnectionFilterColumn's value to string");
                                    StaticMethodHolder.WriteToLog(LogType.Error, "(DELETE OPERATION) Failed to convert ConnectionFilterColumn's value to string");
                                    return;
                                }
                                // Set the delete query and execute it.
                                string deleteQuery = $"DELETE FROM [{ConnectionTableSchema}].[{ConnectionTable}] WHERE {ConnectionFilterColumn}={colText}";
                                mainDBConnection.ExecuteQuery(deleteQuery);
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show("Configuration Error: Invalid Filter Column. Please check the Connections Table for a valid Column.");
                                StaticMethodHolder.WriteToLog(LogType.Error, $"(DELETE OPERATION) {ex}");
                                return;
                            }
                        }
                        // Refresh the Data Grid
                        _connectionsScreen.RefreshTable();
                        break;
                }
            });

            // On execution destroy the ManageConnectionScreen, switch to Menu Screen.
            _connectionsScreen.SetGoToMenuSignal(ChangeScreen);

            _connectionsScreen.SetRefresher(() =>
            {
                // Get all the Available Connections on Load/Refresh.
                string selectQuery = $"SELECT * FROM [{ConnectionTableSchema}].[{ConnectionTable}]";
                DataTable? dataTable = mainDBConnection.ExecuteSelectQueryAndGetResult(selectQuery);
                if (dataTable == null) {
                    StaticMethodHolder.WriteToLog(LogType.Warning, "(FETCH OPERATION) Failed fetching Connection Table data.");
                    return; 
                }
                // Pass the fetched data to the screen.
                _connectionsScreen.FillDataGrid(dataTable);
            });

            // Executed when Update Button is clicked. Get data of selected row to put it on the Update Form.
            _connectionsScreen.SetUpdater(() => {
                // Already forced it to only be one row in ManageConnectionsScreen.
                DataGridViewRow row = _connectionsScreen.GetSelectedRows()[0];

                try
                {
                    var ID = Convert.ToInt32(row.Cells["ID"].Value);
                    var serverNameIP = Convert.ToString(row.Cells["ServerIPorName"].Value);
                    var Port = Convert.ToInt32(row.Cells["Port"].Value);
                    var InstanceName = Convert.ToString(row.Cells["InstanceName"].Value);
                    var SQLAuth = Convert.ToBoolean(row.Cells["SQLAuth"].Value);
                    var username = Convert.ToString(row.Cells["Username"].Value);

                    if (string.IsNullOrEmpty(serverNameIP))
                    {
                        MessageBox.Show("Error: Failed to get selected Server Name/IP");
                        StaticMethodHolder.WriteToLog(LogType.Error, "(UPDATE OPERATION) Failed converting Server Name/IP from the selected row.");
                        return;
                    }

                    if (string.IsNullOrEmpty(InstanceName)) {
                        MessageBox.Show("Error: Failed to get selected Instance Name");
                        StaticMethodHolder.WriteToLog(LogType.Error, "(UPDATE OPERATION) Failed converting Instance Name from the selected row.");
                        return;
                    }

                    var cs = new ConnectionString(serverNameIP, Port, InstanceName, SQLAuth, username, null, false);

                    // Pass the data to the Update Form
                    _connectionsScreen.SetUpUpdateForm(cs, ID);
                }
                catch(Exception ex) 
                {
                    MessageBox.Show("Error: " + ex.ToString());
                    StaticMethodHolder.WriteToLog(LogType.Error, $"(UPDATE OPERATION) Failed converting some selected fields. Details: {ex}");
                }
            });
        }

        /// <summary>
        /// Sets the screen changer for the procedure list screen.
        /// </summary>
        private void SetProcedureListScreenChanger()
        {
            if (_showProceduresScreen == null) return;

            // On execution destroy the ProcedureListScreen, switch to Menu Screen.
            _showProceduresScreen.SetGoToMenuOption(ChangeScreen);

            // On execution fill the Data Grid with Procedure List.
            _showProceduresScreen.SetRefresher(() =>
            {
                string selectQuery = $"SELECT * FROM [{ProcedureTableSchema}].[{ProcedureTable}]";
                DataTable? dataTable = mainDBConnection.ExecuteSelectQueryAndGetResult(selectQuery);
                if (dataTable == null)
                {
                    StaticMethodHolder.WriteToLog(LogType.Warning, "(FETCH OPERATION) Failed fetching Procedure Table data.");
                    return;
                }
                _showProceduresScreen.FillDataGrid(dataTable);
            });
        }

        /// <summary>
        /// Sets the screen changer for the execution screen.
        /// </summary>
        private void SetExecutionScreenChanger()
        {
            if (_executeProceduresScreen == null) return;
            // On execution destroy the ExecuteProcedureScreen, switch to Menu Screen.
            _executeProceduresScreen.SetGoToMenuSignal(ChangeScreen);

            // On Load Fill the ListBoxes' With data
            _executeProceduresScreen.SetFillSignal(() =>
            {
                string selectQuery = $"SELECT * FROM [{ConnectionTableSchema}].[{ConnectionTable}]";
                DataTable? dataTable = mainDBConnection.ExecuteSelectQueryAndGetResult(selectQuery);
                if (dataTable == null)
                {
                    StaticMethodHolder.WriteToLog(LogType.Warning, "(FETCH OPERATION - EXECUTE SCREEN) Failed fetching Connection Table data.");
                    return;
                }
                _executeProceduresScreen.SetCSsSource(dataTable);

                selectQuery = $"SELECT * FROM [{ProcedureTableSchema}].[{ProcedureTable}]";
                dataTable = mainDBConnection.ExecuteSelectQueryAndGetResult(selectQuery);
                if (dataTable == null)
                {
                    StaticMethodHolder.WriteToLog(LogType.Warning, "(FETCH OPERATION - EXECUTE SCREEN) Failed fetching Procedure Table data.");
                    return;
                }
                _executeProceduresScreen.SetSPsSource(dataTable);
            });

            // On execution get the selected Procedures and Connections
            _executeProceduresScreen.SetExecuteSignal(() =>
            {
                List<DataRowView> SPList = _executeProceduresScreen.GetSelectedProcedures();
                List<DataRowView> CSList = _executeProceduresScreen.GetSelectedConnectionsID();

                mainDBConnection.ExecuteSPsRemote(SPList, CSList);
            });
        }
    }
}
