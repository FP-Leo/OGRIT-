using static OGRIT_Database_Custom_App.Generics.DelegateContainer;
using static OGRIT_Database_Custom_App.Generics.ScreenEnums;

namespace OGRIT_Database_Custom_App.Views.Screens
{
    public partial class ProcedureListScreen : UserControl
    {
        private MenuScreenChanger? _goToMenu;
        public ProcedureListScreen()
        {
            InitializeComponent();
        }

        public void setGoToMenuOption(MenuScreenChanger goToMenu)
        {
            _goToMenu = goToMenu;
        }

        private void spMenuButton_Click(object sender, EventArgs e)
        {
            _goToMenu?.Invoke(SubScreens.ViewProceduresScreen);
        }
    }
}
