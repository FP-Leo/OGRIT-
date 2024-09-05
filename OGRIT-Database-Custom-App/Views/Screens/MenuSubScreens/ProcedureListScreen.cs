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
            DesignTable();
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
        /// Specifies the column height of the Data Grid of the Show Procedure Screen.
        /// </summary>
        private void DesignTable()
        {
            // Ensure the DataGridView has at least one column
            if (spProcedureGrid.Columns.Count == 0)
            {
                return;
            }

            // Get the total width of the DataGridView container
            int totalWidth = spProcedureGrid.Width;

            // Set the width of the first column to 25% of the container's width
            spProcedureGrid.Columns[0].Width = (int)(totalWidth * 0.25);

            // Calculate the remaining width for the other columns
            int remainingWidth = totalWidth - spProcedureGrid.Columns[0].Width;

            // Get the number of remaining columns
            int remainingColumns = spProcedureGrid.Columns.Count - 1;

            // Set the width of the remaining columns equally
            for (int i = 1; i < spProcedureGrid.Columns.Count; i++)
            {
                spProcedureGrid.Columns[i].Width = remainingWidth / remainingColumns;
            }
        }

        /// <summary>
        /// Fills the data grid with the provided data.
        /// </summary>
        /// <param name="dataTable">The data to be displayed in the data grid.</param>
        public void FillDataGrid(DataTable dataTable)
        {
            spProcedureGrid.DataSource = dataTable;
        }

        /// <summary>
        /// Handles the resize event for the Show Procedures Screen, changes the size of the columns inside the DataGrid.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ProcedureListScreen_Resize(object sender, EventArgs e)
        {
            // initial width 1082
            int newWidth = Math.Min(250, this.Width - 882);
            // initial height 653
            int newHeight = Math.Min(57, this.Height - 623);

            int newX = (menuButtonPanel.Width - newWidth) / 2;  // Center horizontally
            int newY = (menuButtonPanel.Height - newHeight) / 2; // Center vertically

            // Apply the new size and location to the menu button
            spMenuButton.Size = new Size(newWidth, newHeight);
            spMenuButton.Location = new Point(newX, newY);
            spMenuButton.BorderRadius = 8;

            DesignTable();
        }
    }
}
