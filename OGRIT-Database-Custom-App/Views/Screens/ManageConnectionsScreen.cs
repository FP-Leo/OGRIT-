using System.Data;
using static OGRIT_Database_Custom_App.Generics.ScreenEnums;
using static OGRIT_Database_Custom_App.Generics.DelegateContainer;
using OGRIT_Database_Custom_App.Models;

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
        private ConnectionScreenChanger? _changer;

        /// <summary>
        /// Delegate to change to a different menu screen.
        /// </summary>
        private MenuScreenChanger? _goToMenu;

        /// <summary>
        /// Delegate for updating connection information.
        /// </summary>
        private UpdateSetter? _updater;

        /// <summary>
        /// Index of the connection to be updated.
        /// </summary>
        private int? _updateIndex;

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
        }

        /// <summary>
        /// Refreshes the data table displayed on the screen.
        /// </summary>
        public void RefreshTable()
        {
            _changer?.Invoke(ConnectionMenuOptions.ShowConnections);
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
        /// <param name="changer">The delegate to change the screen.</param>
        public void SetChanger(ConnectionScreenChanger changer)
        {
            _changer = changer;
        }

        /// <summary>
        /// Sets the delegate to navigate to a different menu screen.
        /// </summary>
        /// <param name="goToMenu">The delegate to navigate to the menu screen.</param>
        public void SetGoToMenuOption(MenuScreenChanger goToMenu)
        {
            _goToMenu = goToMenu;
        }

        /// <summary>
        /// Sets the delegate to update connection information.
        /// </summary>
        /// <param name="updater">The delegate for updating connection information.</param>
        public void SetUpdater(UpdateSetter updater)
        {
            _updater = updater;
        }

        /// <summary>
        /// Handles the click event for the menu button, navigating to the manage connections screen.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void McMenuButton_Click(object sender, EventArgs e)
        {
            _goToMenu?.Invoke(SubScreens.ManageConnectionsScreen);
        }

        /// <summary>
        /// Handles the click event for the insert button, displaying the insert form and getting the connection string.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void McInsertButton_Click(object sender, EventArgs e)
        {
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
            _updater?.Invoke();
        }

        /// <summary>
        /// Retrieves the connection string from the input form based on the specified option.
        /// </summary>
        /// <param name="option">The operation to perform (Insert, Update, etc.).</param>
        private void GetConnectionStringFromForm(ConnectionMenuOptions option)
        {
            if (_insertUpdateForm.DialogResult == DialogResult.OK)
            {
                inputedConnectionString = _insertUpdateForm.GetConnectionString();
                _changer?.Invoke(option);
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

            _changer?.Invoke(ConnectionMenuOptions.Delete);
        }

        /// <summary>
        /// Gets the currently selected rows from the data grid.
        /// </summary>
        /// <returns>The collection of selected rows.</returns>
        public DataGridViewSelectedRowCollection GetSelectedRows()
        {
            return mcDataGrid.SelectedRows;
        }

        // This isn't very clean, will probably change in the future. It was done to avoid using logic on a view
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
    }
}
