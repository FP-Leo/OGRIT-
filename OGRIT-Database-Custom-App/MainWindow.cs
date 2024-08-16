using System.Data.SqlClient;

namespace OGRIT_Database_Custom_App
{
    public partial class MainWindow : Form
    {
        private SqlConnection? _connection;
        public MainWindow()
        {
            InitializeComponent();
            SetUpStartingScreen();
        }

        public void SetUpStartingScreen()
        {
            startingScreen = new StartingScreen
            {
                // 
                // startingScreen
                // 
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                MinimumSize = new Size(825, 450),
                Name = "startingScreen1",
                Size = new Size(825, 450),
                TabIndex = 0,
                Visible = true
            };

            startingScreen.SetChanger(() =>
                {
                    DestroyStartingScreen();
                }
            );

            Controls.Add(startingScreen);
        }
        public void DestroyStartingScreen()
        {
            if (startingScreen == null) 
                return;

            Controls.Remove(startingScreen);
            startingScreen?.Dispose();
            startingScreen = null;
            InitializeLogInScreen();
        }
        public void InitializeLogInScreen()
        {
            // 
            // logInScreen
            // 
            logInScreen = new LogInScreen()
            {
                Dock = DockStyle.Fill,
                Location = new Point(10, 10),
                Name = "LogInScreen",
                Size = new Size(800, 450),
                TabIndex = 0,
                Visible = true
            };

            logInScreen.SetChanger((SqlConnection connection) =>
            {
                _connection = connection;
                DestroyLogInScreen();
            });
            // 
            // MainWindow
            // 
            Controls.Add(logInScreen);
        }
        public void DestroyLogInScreen()
        {
            if (logInScreen == null)
                return;
            Controls.Remove(logInScreen);
            logInScreen?.Dispose();
            logInScreen = null;
            InitializeMenuScreen();
        }

        public void InitializeMenuScreen()
        {
            // 
            // MenuScreen
            // 
            menuScreen = new MenuScreen()
            {
                Dock = DockStyle.Fill,
                Location = new Point(10, 10),
                Name = "MenuScreen",
                Size = new Size(800, 450),
                TabIndex = 0,
                Visible = true
            };

            menuScreen.SetChanger((int selected) =>
            {
                DestroyMenuScreen();
                switch (selected)
                {
                    case 1:
                        InitializeConnectionsScreen();
                        break;
                }
            });
            // 
            // MainWindow
            // 
            Controls.Add(menuScreen);
        }
        public void DestroyMenuScreen()
        {
            if (menuScreen == null)
                return;
            Controls.Remove(menuScreen);
            menuScreen?.Dispose();
            menuScreen = null;
        }

        public void InitializeConnectionsScreen()
        {
            // 
            // connectionsScreen
            // 
            connectionsScreen = new ManageConnections()
            {
                Dock = DockStyle.Fill,
                Location = new Point(10, 10),
                Name = "ConnectionScreen",
                Size = new Size(800, 450),
                TabIndex = 0,
                Visible = true
            };

             connectionsScreen.SetConnection(_connection);
            // 
            // MainWindow
            // 
            Controls.Add(connectionsScreen);
        }
        public void DestroyConnectionsScreen()
        {
            if (connectionsScreen == null)
                return;
            Controls.Remove(connectionsScreen);
            connectionsScreen?.Dispose();
            connectionsScreen = null;
        }

        public delegate void ScreenChanger();
        public delegate void MenuScreenChanger(int selected);
        public delegate void LogInScreenChanger(SqlConnection connection);
    }
}
