using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OGRIT_Database_Custom_App
{
    public partial class StartingScreen : UserControl
    {
        private readonly MainWindow _parent;
        public StartingScreen()
        {
            InitializeComponent();
        }
        public StartingScreen(MainWindow parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if (_parent != null)
            {
                _parent.startingScreen.Hide();
                _parent.logInScreen.Show();
            }
        }
    }
}
