using OGRIT_Database_Custom_App.Generics;
using OGRIT_Database_Custom_App.Models;
using OGRIT_Database_Custom_App.Views.Screens;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        private readonly MainDatabaseConnetion mainDBConnection;

        // Configuration 
        /// <summary>
        /// The name of the table containing connection information.
        /// </summary>
        private string? ConnectionTable;

        /// <summary>
        /// The schema of the connection table.
        /// </summary>
        private string? ConnectionTableSchema;

        /// <summary>
        /// The name of the table containing stored procedures.
        /// </summary>
        private string? ProcedureTable;

        /// <summary>
        /// The schema of the procedure table.
        /// </summary>
        private string? ProcedureTableSchema;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainController"/> class.
        /// Validates configuration settings and sets up the main database connection.
        /// </summary>
        public MainController()
        {
            ValidateConfig();
            mainDBConnection = new MainDatabaseConnetion();
            mainWindow = new MainWindow();
        }

        /// <summary>
        /// Starts the application by displaying the starting screen and running the main window.
        /// </summary>
        public void Run()
        {
            ChangeScreen(null, Screens.StartingScreen);
            Application.Run(mainWindow);
        }

        /// <summary>
        /// Validates the configuration settings by loading necessary table and schema names.
        /// </summary>
        private void ValidateConfig()
        {
            ConnectionTable = StaticMethodHolder.GetConfigKey("ConnectionTable");
            ConnectionTableSchema = StaticMethodHolder.GetConfigKey("ConnectionTableSchema");
            ProcedureTable = StaticMethodHolder.GetConfigKey("ProcedureTable");
            ProcedureTableSchema = StaticMethodHolder.GetConfigKey("ProcedureTableSchema");
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
        /// Changes the current sub-screen to a new screen.
        /// </summary>
        /// <param name="toBeDestroyed">The sub-screen to be destroyed before switching.</param>
        /// <param name="toBeSet">The screen to be set after destruction.</param>
        private void ChangeScreen(SubScreens toBeDestroyed, Screens toBeSet)
        {
            DestroyScreen(toBeDestroyed);
            SetScreen(toBeSet);
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
        }

        /// <summary>
        /// Destroys the specified sub-screen.
        /// </summary>
        /// <param name="toBeSet">The sub-screen to be destroyed.</param>
        public void DestroyScreen(SubScreens toBeSet)
        {
            switch (toBeSet)
            {
                case SubScreens.ManageConnectionsScreen:
                    ScreenDestroyer.DestroyScreen(ref _connectionsScreen);
                    break;
                case SubScreens.ViewProceduresScreen:
                    ScreenDestroyer.DestroyScreen(ref _showProceduresScreen);
                    break;
                case SubScreens.ExecuteProceduresScreen:
                    //ScreenDestroyer.DestroyScreen(ref _executeProceduresScreen);
                    break;
            }
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
                    ChangeScreen(Screens.LogInScreen, Screens.MenuScreen);
            });
        }

        /// <summary>
        /// Sets the screen changer for the menu screen.
        /// </summary>
        private void SetMenuScreenChanger()
        {
            if (_menuScreen == null)
                return;
            _menuScreen.SetChanger((SubScreens selected) =>
            {
                SetScreen(selected);
            });
        }

        /// <summary>
        /// Sets the screen changer for the manage connections screen.
        /// </summary>
        private void SetConnectionsScreenChanger()
        {
            if(_connectionsScreen == null) return;

            _connectionsScreen.SetChanger((ConnectionMenuOptions option) =>
            {
                switch (option)
                {
                    case ConnectionMenuOptions.ShowConnections:
                        // Get all the Available Connections on Load.
                        string selectQuery = $"SELECT * FROM [{ConnectionTableSchema}].[{ConnectionTable}]";
                        DataTable? dataTable = mainDBConnection.ExecuteSelectQueryAndGetResult(selectQuery);
                        if(dataTable == null) { return; }
                        _connectionsScreen.FillDataGrid(dataTable);
                        break;
                    case ConnectionMenuOptions.Insert:
                        var submittedCS = _connectionsScreen.GetInputedConnectionString();
                        
                        if(submittedCS == null) { return; }

                        string insertQuery = $"INSERT INTO [{ConnectionTableSchema}].[{ConnectionTable}] VALUES ( @var1, @var2, @var3, @var4, @var5, @var6 )";

                        mainDBConnection.AddParamAndExecuteCommand(insertQuery, submittedCS);

                        _connectionsScreen.RefreshTable();
                        break;
                    case ConnectionMenuOptions.Update:
                        int? id = _connectionsScreen.GetUpdateIndex();
                        if (id == null) return;

                        var updatedCS = _connectionsScreen.GetInputedConnectionString();

                        if (updatedCS == null) { return; }

                        string updateQuery = $"UPDATE [{ConnectionTableSchema}].[{ConnectionTable}]  SET ServerIPorName=@var1, Port=@var2, InstanceName=@var3, SQLAuth=@var4, UserName=@var5, Password=@var6 WHERE ID={id}";

                        mainDBConnection.AddParamAndExecuteCommand(updateQuery, updatedCS);

                        _connectionsScreen.ResetUpdateIndex();
                        _connectionsScreen.RefreshTable();
                        break;
                    case ConnectionMenuOptions.Delete:
                        // Not validating with the others since the application can still work without it
                        string? filterColumn = ConfigurationManager.AppSettings["FilterColumn"];
                        if (string.IsNullOrEmpty(filterColumn))
                        {
                            MessageBox.Show("Configuration Error: Filter Column not set.");
                            return;
                        }

                        foreach (DataGridViewRow row in _connectionsScreen.GetSelectedRows())
                        {
                            try
                            {
                                var colValue = row.Cells[filterColumn].Value;
                                string? colText = Convert.ToString(colValue);
                                if (string.IsNullOrEmpty(colText)) {
                                    MessageBox.Show("Failed to convert Filter Column's value to string");
                                    return;
                                }

                                string deleteQuery = $"DELETE FROM [{ConnectionTableSchema}].[{ConnectionTable}] WHERE {filterColumn}={colText}";
                                mainDBConnection.ExecuteQuery(deleteQuery);
                            }
                            catch
                            {
                                MessageBox.Show("Configuration Error: Invalid Filter Column. Please check the Connections Table for a valid Column.");
                                return;
                            }
                        }
                        _connectionsScreen.RefreshTable();
                        break;
                }
            });

            _connectionsScreen.SetGoToMenuOption((SubScreens currentSubScreen) => {
                ChangeScreen(currentSubScreen, Screens.MenuScreen);
            });

            _connectionsScreen.SetUpdater(() => {
                // Already forced it to only be one row in ManageConnectionsScreen.
                var row = _connectionsScreen.GetSelectedRows()[0];

                try
                {
                    var ID = Convert.ToInt32(row.Cells["ID"].Value);
                    var serverNameIP = Convert.ToString(row.Cells["ServerIPorName"].Value);
                    var Port = Convert.ToInt32(row.Cells["Port"].Value);
                    var InstanceName = Convert.ToString(row.Cells["InstanceName"].Value);
                    var SQLAuth = Convert.ToBoolean(row.Cells["SQLAuth"].Value);
                    var username = Convert.ToString(row.Cells["Username"].Value);
                    var password = Convert.ToString(row.Cells["Password"].Value);

                    if (string.IsNullOrEmpty(serverNameIP))
                    {
                        MessageBox.Show("Error: Failed to get Server Name/IP");
                        return;
                    }

                    if (string.IsNullOrEmpty(InstanceName)) {
                        MessageBox.Show("Error: Failed to get Instance Name");
                        return;
                    }

                    var cs = new ConnectionString(serverNameIP, Port, InstanceName, SQLAuth, username, password);
                    _connectionsScreen.SetUpUpdateForm(cs, ID);
                }
                catch(Exception ex) 
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
            });
        }

        /// <summary>
        /// Sets the screen changer for the procedure list screen.
        /// </summary>
        private void SetProcedureListScreenChanger()
        {
            if (_showProceduresScreen == null) return;

            _showProceduresScreen.SetGoToMenuOption((SubScreens currentSubScreen) => {
                ChangeScreen(currentSubScreen, Screens.MenuScreen);
            });

            _showProceduresScreen.SetRefresher(() =>
            {
                string selectQuery = $"SELECT * FROM [{ProcedureTableSchema}].[{ProcedureTable}]";
                DataTable? dataTable = mainDBConnection.ExecuteSelectQueryAndGetResult(selectQuery);
                if (dataTable == null) { return; }
                _showProceduresScreen.FillDataGrid(dataTable);
            });
        }

        /// <summary>
        /// Sets the screen changer for the execution screen.
        /// </summary>
        private void SetExecutionScreenChanger()
        {
            if (_executeProceduresScreen == null) return;

            _executeProceduresScreen.setGoToMenuOption((SubScreens currentSubScreen) => {
                ChangeScreen(currentSubScreen, Screens.MenuScreen);
            });

            _executeProceduresScreen.setFillSignal(() =>
            {
                string selectQuery = $"SELECT * FROM [{ConnectionTableSchema}].[{ConnectionTable}]";
                DataTable? dataTable = mainDBConnection.ExecuteSelectQueryAndGetResult(selectQuery);
                if (dataTable == null) { return; }
                _executeProceduresScreen.SetCSsSource(dataTable);

                selectQuery = $"SELECT * FROM [{ProcedureTableSchema}].[{ProcedureTable}]";
                dataTable = mainDBConnection.ExecuteSelectQueryAndGetResult(selectQuery);
                if (dataTable == null) { return; }
                _executeProceduresScreen.SetSPsSource(dataTable);
            });
        }
    }
}
