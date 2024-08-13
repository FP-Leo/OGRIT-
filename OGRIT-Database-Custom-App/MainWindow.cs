namespace OGRIT_Database_Custom_App
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            SetUpStartingScreen();
            InitializeComponent();
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
                TabIndex = 0
            };

            startingScreen.SetChanger(() =>
                {
                    DestroyStartingScreen();
                }
            );
        }

        public void DestroyStartingScreen()
        {
            Controls.Remove(startingScreen);
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

            logInScreen.SetChanger(() =>
            {
                Console.WriteLine("To be implemented");
            });
            // 
            // MainWindow
            // 
            Controls.Add(logInScreen);
        }

        public delegate void ScreenChanger();
    }
}
