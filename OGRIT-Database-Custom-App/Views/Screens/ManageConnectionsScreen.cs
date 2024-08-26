using System.Data;
using static OGRIT_Database_Custom_App.Generics.ScreenEnums;
using static OGRIT_Database_Custom_App.Generics.DelegateContainer;
using OGRIT_Database_Custom_App.Models;

namespace OGRIT_Database_Custom_App
{
    public partial class ManageConnectionsScreen : UserControl
    {
        private ConnectionScreenChanger? _changer;
        private MenuScreenChanger? _goToMenu;
        private UpdateSetter? _updater;
        private int? _updateIndex;

        private readonly InsertUpdateForm _insertUpdateForm;

        private ConnectionString? inputedConnectionString;
        public ManageConnectionsScreen()
        {
            _insertUpdateForm = new InsertUpdateForm();
            InitializeComponent();
        }

        public void RefreshTable()
        {
            _changer?.Invoke(ConnectionMenuOptions.ShowConnections);
        }

        private void ManageConnections_Load(object sender, EventArgs e)
        {
            RefreshTable();
        }
        // To get the main DB connection from MainWindow
        public void FillDataGrid(DataTable dataTable)
        {
            mcDataGrid.DataSource = dataTable;
        }

        public void SetChanger(ConnectionScreenChanger changer)
        {
            _changer = changer;
        }

        public void SetGoToMenuOption(MenuScreenChanger goToMenu)
        {
            _goToMenu = goToMenu;
        }

        public void SetUpdater(UpdateSetter updater)
        {
            _updater = updater;
        }

        private void McMenuButton_Click(object sender, EventArgs e)
        {
            _goToMenu?.Invoke(SubScreens.ManageConnectionsScreen);
        }

        private void McInsertButton_Click(object sender, EventArgs e)
        {
            _insertUpdateForm.ResetInputFormText();
            InitializeInputForm("Insert Form", "Submit");
            GetConnectionStringFromForm(ConnectionMenuOptions.Insert);
        }

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

        private void GetConnectionStringFromForm(ConnectionMenuOptions option)
        {
            if (_insertUpdateForm.DialogResult == DialogResult.OK)
            {
                inputedConnectionString = _insertUpdateForm.GetConnectionString();
                _changer?.Invoke(option);
            }
        }

        public ConnectionString? GetInputedConnectionString()
        {
            return inputedConnectionString;
        }

        private void McDeleteButton_Click(object sender, EventArgs e)
        {
            if(mcDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please first select the rows you want to delete!");
                return;
            }

            _changer?.Invoke(ConnectionMenuOptions.Delete);
        }

        public DataGridViewSelectedRowCollection GetSelectedRows()
        {
            return mcDataGrid.SelectedRows;
        }

        
        // This isn't very clean, will probably change in the future. It was done to avoid using logic on a view
        public void SetUpUpdateForm(ConnectionString toBeUpdated, int updateIndex)
        {
            _insertUpdateForm.SetInputFormText(toBeUpdated);
            _updateIndex = updateIndex;
            InitializeInputForm("Update Form", "Update");
            GetConnectionStringFromForm(ConnectionMenuOptions.Update);
        }
        public void ResetUpdateIndex()
        {
            _updateIndex = null;
        }

        public int? GetUpdateIndex()
        {
            return _updateIndex;
        }

        private void InitializeInputForm(string Title, string ButtonText)
        {
            _insertUpdateForm.Text = Title;
            _insertUpdateForm.SetButtonText(ButtonText);
            _insertUpdateForm.ShowDialog();
        }
    }
}
