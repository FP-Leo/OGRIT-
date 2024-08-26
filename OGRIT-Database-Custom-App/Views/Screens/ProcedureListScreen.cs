using System.Data;
using static OGRIT_Database_Custom_App.Generics.DelegateContainer;
using static OGRIT_Database_Custom_App.Generics.ScreenEnums;

namespace OGRIT_Database_Custom_App.Views.Screens
{
    public partial class ProcedureListScreen : UserControl
    {
        private Refresher? _refresher;
        private MenuScreenChanger? _goToMenu;
        public ProcedureListScreen()
        {
            InitializeComponent();
        }

        public void SetGoToMenuOption(MenuScreenChanger goToMenu)
        {
            _goToMenu = goToMenu;
        }

        public void SetRefresher(Refresher? refresher)
        {
            _refresher = refresher;
        }

        private void SpMenuButton_Click(object sender, EventArgs e)
        {
            _goToMenu?.Invoke(SubScreens.ViewProceduresScreen);
        }

        private void ProcedureListScreen_Load(object sender, EventArgs e)
        {
            _refresher?.Invoke();
        }

        public void FillDataGrid(DataTable dataTable)
        {
            spProcedureGrid.DataSource = dataTable;
        }
    }
}
