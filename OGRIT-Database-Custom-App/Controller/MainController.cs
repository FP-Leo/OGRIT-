namespace OGRIT_Database_Custom_App.Controller
{
    public class MainController
    {
        private MainWindow _mainWindow;

        public MainController()
        {
            _mainWindow = new MainWindow();
        }

        public void Run()
        {
            Application.Run(_mainWindow);
        }
    }
}
