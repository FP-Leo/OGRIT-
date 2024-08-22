using OGRIT_Database_Custom_App.Generics;
using OGRIT_Database_Custom_App.Model;
using OGRIT_Database_Custom_App.Models;
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
        private ManageConnectionsScreen? _connectionsScreen;

        // Models
        private readonly MainDatabaseConnetion mainDBConnection;
        public MainController()
        {
            mainDBConnection = new MainDatabaseConnetion();
            mainWindow = new MainWindow();
        }

        public void Run()
        {
            ChangeScreen(null, Screens.StartingScreen);
            Application.Run(mainWindow);
        }
        // Screen Switcher
        private void ChangeScreen(Screens? toBeDestroyed, Screens toBeSet)
        {
            if (toBeDestroyed != null) {
                DestroyScreen((Screens)toBeDestroyed);
            }
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
                case Screens.ManageConnectionsScreen:
                    _connectionsScreen = ScreenInitializer.InitializeConnectionsScreen();
                    SetConnectionsScreenChanger();
                    mainWindow.SetScreen(_connectionsScreen);
                    break;
                case Screens.ViewProceduresScreen:
                    //InitializeProcedureList();
                    break;
                case Screens.ExecuteProceduresScreen:
                    //InitializeExecutionScreen();
                    break;
                default:
                    System.Windows.Forms.Application.Exit();
                    break;
            }
        }
        public void DestroyScreen(Screens toBeSet)
        {
            switch (toBeSet)
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
                case Screens.ManageConnectionsScreen:
                    ScreenDestroyer.DestroyScreen(ref _connectionsScreen);
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
                ChangeScreen(Screens.StartingScreen, Screens.LogInScreen);
            });
        }
        private void SetLogInScreenChanger()
        {
            if (_logInScreen == null)
                return;

            _logInScreen.SetChanger((ConnectionString connection) =>
            {
                string? result = mainDBConnection.SetConnection(connection);
                if (result != null)
                {
                    MessageBox.Show(result);
                    return;
                }
                mainDBConnection.OpenConnection();

                ChangeScreen(Screens.LogInScreen, Screens.MenuScreen);
            });
        }
        private void SetMenuScreenChanger()
        {
            if (_menuScreen == null)
                return;
            _menuScreen.SetChanger((Screens selected) =>
            {
                ChangeScreen(null, selected);
            });
        }
        private void SetConnectionsScreenChanger()
        {
            if(_connectionsScreen == null) return;
            //_connectionsScreen.SetConnection(DatabaseConnection.);
            _connectionsScreen.setChanger((ConnectionMenuOptions option) =>
            {
                switch (option)
                {
                    case ConnectionMenuOptions.ShowConnections:
                        // Get all the Available Connections on Load.
                        string selectQuery = "SELECT * FROM [dbo].[ServerConfig]";
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
                    case ConnectionMenuOptions.Menu:
                        ChangeScreen(Screens.ManageConnectionsScreen, Screens.MenuScreen);
                        break;
                }
            });
        }
        private void SetProcedureListScreenChanger()
        {
            // To be implemented
        }
        private void SetExecutionScreenChanger()
        {
            // To be implemented
        }
    }
}
