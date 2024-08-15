using static OGRIT_Database_Custom_App.MainWindow;

namespace OGRIT_Database_Custom_App
{
    public partial class MenuScreen : UserControl
    {
        private MenuScreenChanger? _changer;
        public MenuScreen()
        {
            InitializeComponent();
        }

        public void SetChanger(MenuScreenChanger changer)
        {
            this._changer = changer;
        }

        private void OptionOneLabel_Click(object sender, EventArgs e)
        {
            _changer?.Invoke(1);
        }
    }
}
