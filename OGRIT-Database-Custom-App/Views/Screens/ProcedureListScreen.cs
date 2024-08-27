using System.Data;
using static OGRIT_Database_Custom_App.Generics.DelegateContainer;
using static OGRIT_Database_Custom_App.Generics.ScreenEnums;

namespace OGRIT_Database_Custom_App.Views.Screens
{
    /// <summary>
    /// Represents a screen that displays a list of procedures in a data grid and allows navigation to other screens.
    /// </summary>
    public partial class ProcedureListScreen : UserControl
    {
        /// <summary>
        /// Delegate to refresh the data displayed on the screen.
        /// </summary>
        private Refresher? _refresher;

        /// <summary>
        /// Delegate to change the menu screen.
        /// </summary>
        private MenuScreenChanger? _goToMenu;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcedureListScreen"/> class.
        /// </summary>
        public ProcedureListScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the delegate for changing the menu screen.
        /// </summary>
        /// <param name="goToMenu">The delegate to change the menu screen.</param>
        public void SetGoToMenuOption(MenuScreenChanger goToMenu)
        {
            _goToMenu = goToMenu;
        }

        /// <summary>
        /// Sets the delegate for refreshing the data on the screen.
        /// </summary>
        /// <param name="refresher">The delegate to refresh the data.</param>
        public void SetRefresher(Refresher? refresher)
        {
            _refresher = refresher;
        }

        /// <summary>
        /// Handles the click event for the menu button, navigating to the view procedures screen.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void SpMenuButton_Click(object sender, EventArgs e)
        {
            _goToMenu?.Invoke(SubScreens.ViewProceduresScreen);
        }

        /// <summary>
        /// Handles the load event of the screen, triggering the refresher delegate to update the data.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ProcedureListScreen_Load(object sender, EventArgs e)
        {
            _refresher?.Invoke();
        }

        /// <summary>
        /// Fills the data grid with the provided data.
        /// </summary>
        /// <param name="dataTable">The data to be displayed in the data grid.</param>
        public void FillDataGrid(DataTable dataTable)
        {
            spProcedureGrid.DataSource = dataTable;
        }
    }
}
