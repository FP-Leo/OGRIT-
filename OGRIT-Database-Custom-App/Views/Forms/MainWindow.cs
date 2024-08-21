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
            _screen = screen;
        }

        public void ShowScreen()
        {
            if (_screen != null) {
                screenSet = true;
                Controls.Add(_screen);
            }
        }

        public void CloseScreen() {
            if (_screen != null && screenSet) { 
                Controls.Remove(_screen);
                _screen = null;
                screenSet = false;
            }
        }
    }
}
