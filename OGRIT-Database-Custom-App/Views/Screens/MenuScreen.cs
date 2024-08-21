using static OGRIT_Database_Custom_App.Generics.DelegateContainer;
using static OGRIT_Database_Custom_App.Generics.ScreenEnums;

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

        private void MenuScreen_Resize(object sender, EventArgs e)
        {

            int newWidth = Math.Min(500, this.Width - 800);
            int newHeight = Math.Min(500, this.Height - 400);
            Console.WriteLine("New Height: " + newHeight);
            menuTablePanel.Size = new Size(newWidth, newHeight);

            menuTablePanel.Location = new Point(
                (menuPanel.Width - menuTablePanel.Width) / 2,
                (menuPanel.Height - menuTablePanel.Height) / 2);
        }

        private void ManageConnectionButton_Click(object sender, EventArgs e)
        {
            _changer?.Invoke(MenuOptions.ManageConnections);
        }

        private void viewProcedureButton_Click(object sender, EventArgs e)
        {
            _changer?.Invoke(MenuOptions.ViewProcedures);
        }

        private void executeProcedureButton_Click(object sender, EventArgs e)
        {
            _changer?.Invoke(MenuOptions.ExecuteProcedures);
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            _changer?.Invoke(MenuOptions.Quit);
        }
    }
}
