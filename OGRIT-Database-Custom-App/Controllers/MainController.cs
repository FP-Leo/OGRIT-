using OGRIT_Database_Custom_App.Generics;
using OGRIT_Database_Custom_App.Model;
using OGRIT_Database_Custom_App.Models;
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
        private readonly DatabaseConnection mainDBConnection;
        public MainController()
        {
            mainDBConnection = new DatabaseConnection();
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
            mainWindow.CloseScreen();
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
                    _menuScreen = ScreenInitializer.InitializeMenuScreen();
                    SetMenuScreenChanger();
                    mainWindow.SetScreen(_menuScreen);
                    break;
            }
            mainWindow.ShowScreen();
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

                ChangeScreen(Screens.LogInScreen, Screens.MenuScreen);
            });
        }
        private void SetMenuScreenChanger()
        {
            if (_menuScreen == null)
                return;
            _menuScreen.SetChanger((MenuOptions selected) =>
            {
                switch (selected)
                {
                    case MenuOptions.ManageConnections:
                        //InitializeConnectionsScreen();
                        break;
                    case MenuOptions.ViewProcedures:
                        //InitializeProcedureList();
                        break;
                    case MenuOptions.ExecuteProcedures:
                        //InitializeExecutionScreen();
                        break;
                    case MenuOptions.Quit:
                        System.Windows.Forms.Application.Exit();
                        break;
                }
            });
        }
        private void SetConnectionsScreenChanger()
        {
            /*
            _connectionsScreen.SetConnection(_connection);
            _connectionsScreen.setChanger((ConnectionMenuOptions option) =>
            {
                DestroyConnectionsScreen();
                switch (option)
                {
                    case ConnectionMenuOptions.Menu:
                        InitializeMenuScreen();
                        break;
                }
            });*/
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
