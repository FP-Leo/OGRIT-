using System.Data.SqlClient;

namespace OGRIT_Database_Custom_App
{
    public partial class MainWindow : Form
    {
        private UserControl? _screen;
        private bool screenSet = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void SetScreen(UserControl screen)
        {
            ResetScreen();
            _screen = screen;
            ShowScreen();
        }
        private void ShowScreen()
        {
            if (_screen != null) {
                screenSet = true;
                Controls.Add(_screen);
            }
        }
        private void ResetScreen() {
            if (_screen != null && screenSet) { 
                Controls.Remove(_screen);
                _screen = null;
                screenSet = false;
            }
        }
    }
}
