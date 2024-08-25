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

        private InsertUpdateForm _insertUpdateForm;

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

        public void setChanger(ConnectionScreenChanger changer)
        {
            _changer = changer;
        }

        public void setGoToMenuOption(MenuScreenChanger goToMenu)
        {
            _goToMenu = goToMenu;
        }

        private void mcMenuButton_Click(object sender, EventArgs e)
        {
            _goToMenu?.Invoke(SubScreens.ManageConnectionsScreen);
        }

        private void mcInsertButton_Click(object sender, EventArgs e)
        {
            _insertUpdateForm.ResetInputFormText();
            _insertUpdateForm.Text = "Insert Form";
            _insertUpdateForm.setButtonText("Submit");
            _insertUpdateForm.ShowDialog();
            GetConnectionStringFromForm(ConnectionMenuOptions.Insert);
        }

        private void mcUpdateButton_Click(object sender, EventArgs e)
        {

            _insertUpdateForm.ResetInputFormText();
            _insertUpdateForm.Text = "Update Form";
            _insertUpdateForm.setButtonText("Update");
            _insertUpdateForm.ShowDialog();
            GetConnectionStringFromForm(ConnectionMenuOptions.Update);
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
    }
}
