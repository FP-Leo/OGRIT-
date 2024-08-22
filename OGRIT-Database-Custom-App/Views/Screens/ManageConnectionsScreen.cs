using System.Data;
using static OGRIT_Database_Custom_App.Generics.ScreenEnums;
using static OGRIT_Database_Custom_App.Generics.DelegateContainer;

namespace OGRIT_Database_Custom_App
{
    public partial class ManageConnectionsScreen : UserControl
    {
        private ConnectionScreenChanger? _changer;

        private InsertUpdateForm _insertUpdateForm;
        bool ScreenExist = false;
        public ManageConnectionsScreen()
        {
            _insertUpdateForm = new InsertUpdateForm();
            InitializeComponent();
        }

        private void ManageConnections_Load(object sender, EventArgs e)
        {
            _changer?.Invoke(ConnectionMenuOptions.ShowConnections);
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

        private void mcMenuButton_Click(object sender, EventArgs e)
        {
            _changer?.Invoke(ConnectionMenuOptions.Menu);
        }

        private void mcInsertButton_Click(object sender, EventArgs e)
        {
            _insertUpdateForm.ResetInputFormText();
            _insertUpdateForm.Text = "Insert Form";
            _insertUpdateForm.setButtonText("Submit");
            _insertUpdateForm.ShowDialog();
        }

        private void mcUpdateButton_Click(object sender, EventArgs e)
        {

            _insertUpdateForm.ResetInputFormText();
            _insertUpdateForm.Text = "Update Form";
            _insertUpdateForm.setButtonText("Update");
            _insertUpdateForm.ShowDialog();
        }
    }
}
