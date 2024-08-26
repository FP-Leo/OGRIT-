using OGRIT_Database_Custom_App.Generics;
using OGRIT_Database_Custom_App.Models;
using OGRIT_Database_Custom_App.Views.Screens;
using System.Configuration;
using System.Data;
using static OGRIT_Database_Custom_App.Generics.ScreenEnums;

namespace OGRIT_Database_Custom_App.Controller
{
    public class MainController
    {
        // Views
        private readonly MainWindow mainWindow;
        private StartingScreen? _startingScreen;
        private LogInScreen? _logInScreen;
        private MenuScreen? _menuScreen;
        //// SubScreens
        private ManageConnectionsScreen? _connectionsScreen;
        private ProcedureListScreen? _showProceduresScreen;
        private ExecuteProceduresScreen? _executeProceduresScreen;

        // Models
        private readonly MainDatabaseConnetion mainDBConnection;

        // Configuration 
        private string? ConnectionTable;
        private string? ConnectionTableSchema;
        private string? ProcedureTable;
        private string? ProcedureTableSchema;
        public MainController()
        {
            ValidateConfig();
            mainDBConnection = new MainDatabaseConnetion();
            mainWindow = new MainWindow();
        }
        public void Run()
        {
            ChangeScreen(null, Screens.StartingScreen);
            Application.Run(mainWindow);
        }

        private void ValidateConfig()
        {
            ConnectionTable = StaticMethodHolder.GetConfigKey("ConnectionTable");
            ConnectionTableSchema = StaticMethodHolder.GetConfigKey("ConnectionTableSchema");
            ProcedureTable = StaticMethodHolder.GetConfigKey("ProcedureTable");
            ProcedureTableSchema = StaticMethodHolder.GetConfigKey("ProcedureTableSchema");
        }
        // Screen Switcher
        private void ChangeScreen(Screens? toBeDestroyed, Screens toBeSet)
        {
            if (toBeDestroyed != null) {
                DestroyScreen((Screens)toBeDestroyed);
            }
            SetScreen(toBeSet);
        }
        private void ChangeScreen(SubScreens toBeDestroyed, Screens toBeSet)
        {
            DestroyScreen(toBeDestroyed);
            SetScreen(toBeSet);
        }
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
        private void SetLogInScreenChanger()
        {
            if (_logInScreen == null)
                return;

            _logInScreen.SetChanger((ConnectionString connection) =>
            {
                mainDBConnection.setConnectionString(connection);
                
                if(mainDBConnection.OpenConnection())
                    ChangeScreen(Screens.LogInScreen, Screens.MenuScreen);
            });
        }
        private void SetMenuScreenChanger()
        {
            if (_menuScreen == null)
                return;
            _menuScreen.SetChanger((SubScreens selected) =>
            {
                SetScreen(selected);
            });
        }
        private void SetConnectionsScreenChanger()
        {
            if(_connectionsScreen == null) return;
            //_connectionsScreen.SetConnection(DatabaseConnection.);

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

                        mainDBConnection.InsertConnection(submittedCS);

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
        }
        private void SetProcedureListScreenChanger()
        {
            if (_showProceduresScreen == null) return;

            _showProceduresScreen.SetGoToMenuOption((SubScreens currentSubScreen) => {
                ChangeScreen(currentSubScreen, Screens.MenuScreen);
            });

            _showProceduresScreen.SetRefresher(() =>
            {
                string selectQuery = "SELECT * FROM [dbo].[ServerProcedures]";
                DataTable? dataTable = mainDBConnection.ExecuteSelectQueryAndGetResult(selectQuery);
                if (dataTable == null) { return; }
                _showProceduresScreen.FillDataGrid(dataTable);
            });
        }
        private void SetExecutionScreenChanger()
        {
            if (_executeProceduresScreen == null) return;

            _executeProceduresScreen.setGoToMenuOption((SubScreens currentSubScreen) => {
                ChangeScreen(currentSubScreen, Screens.MenuScreen);
            });

            _executeProceduresScreen.setFillSignal(() =>
            {
                string selectQuery = "SELECT * FROM [dbo].[ServerConfig]";
                DataTable? dataTable = mainDBConnection.ExecuteSelectQueryAndGetResult(selectQuery);
                if (dataTable == null) { return; }
                //_executeProceduresScreen.epCSComboBox
                _executeProceduresScreen.SetCSsSource(dataTable);
                selectQuery = "SELECT * FROM [dbo].[ServerProcedures]";
                dataTable = mainDBConnection.ExecuteSelectQueryAndGetResult(selectQuery);
                if (dataTable == null) { return; }
                _executeProceduresScreen.SetSPsSource(dataTable);
            });
        }
    }
}
