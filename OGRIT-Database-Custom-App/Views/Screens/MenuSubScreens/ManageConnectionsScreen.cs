using System.Data;
using static OGRIT_Database_Custom_App.Generics.ScreenEnums;
using static OGRIT_Database_Custom_App.Generics.DelegateContainer;
using OGRIT_Database_Custom_App.Models;
using OGRIT_Database_Custom_App.Generics;

namespace OGRIT_Database_Custom_App
{
    /// <summary>
    /// Represents the screen for managing database connections, including viewing, inserting, updating, and deleting connections.
    /// </summary>
    public partial class ManageConnectionsScreen : UserControl
    {
        /// <summary>
        /// Delegate to change the screen based on user actions.
        /// </summary>
        private ConnectionScreenMenuSignal? _connectionScreenMenuSignal;

        /// <summary>
        /// Delegate to change to a different menu screen.
        /// </summary>
        private MenuScreenChanger? _goToMenuSignal;

        /// <summary>
        /// Delegate for updating connection information.
        /// </summary>
        private UpdateFormSignal? _updateFormSignal;

        /// <summary>
        /// Index of the connection to be updated.
        /// </summary>
        private int? _updateIndex;

        /// <summary>
        /// Delegate to refresh the data displayed on the screen.
        /// </summary>
        private Refresher? _refresher;

        /// <summary>
        /// Form used for inserting or updating connection information.
        /// </summary>
        private readonly InsertUpdateForm _insertUpdateForm;

        /// <summary>
        /// Holds the connection string that is being inserted or updated.
        /// </summary>
        private ConnectionString? inputedConnectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageConnectionsScreen"/> class.
        /// </summary>
        public ManageConnectionsScreen()
        {
            _insertUpdateForm = new InsertUpdateForm();
            InitializeComponent();
            DesignTable();
        }

        /// <summary>
        /// Refreshes the data table displayed on the screen.
        /// </summary>
        public void RefreshTable()
        {
            _refresher?.Invoke();
        }

        /// <summary>
        /// Handles the load event of the screen, refreshing the data table.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ManageConnections_Load(object sender, EventArgs e)
        {
            RefreshTable();
        }

        // To get the main DB connection from MainWindow
        /// <summary>
        /// Fills the data grid with the provided data table.
        /// </summary>
        /// <param name="dataTable">The data table to display.</param>
        public void FillDataGrid(DataTable dataTable)
        {
            mcDataGrid.DataSource = dataTable;
        }

        /// <summary>
        /// Sets the delegate to change the connection screen.
        /// </summary>
        /// <param name="connectionScreenMenuSignal">The delegate to change the screen.</param>
        public void SetConnectionScreenMenuSignal(ConnectionScreenMenuSignal connectionScreenMenuSignal)
        {
            _connectionScreenMenuSignal = connectionScreenMenuSignal;
        }

        /// <summary>
        /// Sets the delegate to navigate to a different menu screen.
        /// </summary>
        /// <param name="goToMenuSignal">The delegate to navigate to the menu screen.</param>
        public void SetGoToMenuSignal(MenuScreenChanger goToMenuSignal)
        {
            _goToMenuSignal = goToMenuSignal;
        }

        /// <summary>
        /// Sets the delegate to retrieve selected connection string information for update.
        /// </summary>
        /// <param name="updateFormSignal">The delegate for updating connection information.</param>
        public void SetUpdater(UpdateFormSignal updateFormSignal)
        {
            _updateFormSignal = updateFormSignal;
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
        /// Handles the click event for the menu button, navigating to the Menu Screen.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void McMenuButton_Click(object sender, EventArgs e)
        {
            _goToMenuSignal?.Invoke(SubScreens.ManageConnectionsScreen);
        }

        /// <summary>
        /// Handles the click event for the insert button, displaying the insert form and getting the connection string.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void McInsertButton_Click(object sender, EventArgs e)
        {
            StaticMethodHolder.WriteToLog(LogType.Information, "Insert Connection Form shown.");
            _insertUpdateForm.ResetInputFormText();
            InitializeInputForm("Insert Form", "Submit");
            GetConnectionStringFromForm(ConnectionMenuOptions.Insert);
        }

        /// <summary>
        /// Handles the click event for the update button, displaying the update form and getting the connection string.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void McUpdateButton_Click(object sender, EventArgs e)
        {
            _insertUpdateForm.ResetInputFormText();
            if (mcDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please first select the rows you want to update!");
                return;
            }

            if (mcDataGrid.SelectedRows.Count > 1)
            {
                MessageBox.Show("Please update one at a time!");
                return;
            }
            _updateFormSignal?.Invoke();
        }

        /// <summary>
        /// Retrieves the connection string from the input form based on the specified option.
        /// </summary>
        /// <param name="option">The operation to perform (Insert, Update).</param>
        private void GetConnectionStringFromForm(ConnectionMenuOptions option)
        {
            if (option != ConnectionMenuOptions.Insert && option != ConnectionMenuOptions.Update)
                return;

            if (_insertUpdateForm.DialogResult == DialogResult.OK)
            {
                inputedConnectionString = _insertUpdateForm.GetConnectionString();
                _connectionScreenMenuSignal?.Invoke(option);
            }
        }

        /// <summary>
        /// Gets the connection string that was inputted in the form.
        /// </summary>
        /// <returns>The inputted connection string.</returns>
        public ConnectionString? GetInputedConnectionString()
        {
            return inputedConnectionString;
        }

        /// <summary>
        /// Handles the click event for the delete button, initiating the delete operation.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void McDeleteButton_Click(object sender, EventArgs e)
        {
            if (mcDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please first select the rows you want to delete!");
                return;
            }

            // Show a confirmation dialog
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete the selected rows?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            // Proceed only if the user clicked "Yes"
            if (result == DialogResult.Yes)
            {
                _connectionScreenMenuSignal?.Invoke(ConnectionMenuOptions.Delete);
            }
        }


        /// <summary>
        /// Gets the currently selected rows from the data grid.
        /// </summary>
        /// <returns>The collection of selected rows.</returns>
        public DataGridViewSelectedRowCollection GetSelectedRows()
        {
            return mcDataGrid.SelectedRows;
        }

        /// <summary>
        /// Sets up the update form with the provided connection string and update index.
        /// </summary>
        /// <param name="toBeUpdated">The connection string to update.</param>
        /// <param name="updateIndex">The index of the connection to update.</param>
        public void SetUpUpdateForm(ConnectionString toBeUpdated, int updateIndex)
        {
            _insertUpdateForm.SetInputFormText(toBeUpdated);
            _updateIndex = updateIndex;
            InitializeInputForm("Update Form", "Update");
            GetConnectionStringFromForm(ConnectionMenuOptions.Update);
        }

        /// <summary>
        /// Resets the update index to null.
        /// </summary>
        public void ResetUpdateIndex()
        {
            _updateIndex = null;
        }

        /// <summary>
        /// Gets the current update index.
        /// </summary>
        /// <returns>The update index, or null if not set.</returns>
        public int? GetUpdateIndex()
        {
            return _updateIndex;
        }

        /// <summary>
        /// Initializes and displays the input form with the specified title and button text.
        /// </summary>
        /// <param name="Title">The title of the form.</param>
        /// <param name="ButtonText">The text for the form's button.</param>
        private void InitializeInputForm(string Title, string ButtonText)
        {
            _insertUpdateForm.Text = Title;
            _insertUpdateForm.SetButtonText(ButtonText);
            _insertUpdateForm.ShowDialog();
        }

        /// <summary>
        /// Handles the resize event for the Manage Connection Screen, changes the size of the columns inside the DataGrid.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ManageConnectionsScreen_Resize(object sender, EventArgs e)
        {
            DesignTable();
        }

        /// <summary>
        /// Specifies the column height of the Data Grid of the Manage Connection Screen.
        /// </summary>
        private void DesignTable()
        {
            // Ensure the DataGridView has at least one column
            if (mcDataGrid.Columns.Count == 0)
            {
                return;
            }

            // Get the total width of the DataGridView container
            int totalWidth = mcDataGrid.Width;

            mcDataGrid.Columns[0].Width = 35;

            // Set the width of the second column to 25% of the container's width
            mcDataGrid.Columns[1].Width = (int)((totalWidth - 35) * 0.25);

            // Calculate the remaining width for the other columns
            int remainingWidth = totalWidth - mcDataGrid.Columns[1].Width - 36;

            // Get the number of remaining columns
            int remainingColumns = mcDataGrid.Columns.Count - 2;

            // Set the width of the remaining columns equally
            for (int i = 2; i < mcDataGrid.Columns.Count; i++)
            {
                mcDataGrid.Columns[i].Width = remainingWidth / remainingColumns;
            }
        }
    }
}
