using System.Data;
using static OGRIT_Database_Custom_App.Generics.DelegateContainer;
using static OGRIT_Database_Custom_App.Generics.ScreenEnums;

namespace OGRIT_Database_Custom_App.Views.Screens
{
    public partial class ExecuteProceduresScreen : UserControl
    {
        // Triggers
        private MenuScreenChanger? _goToMenu;
        private FillSignal? _fillSignal;
        private ExecuteSignal? _executeSignal;
        public ExecuteProceduresScreen()
        {
            InitializeComponent();
        }
        // Function to set reactions to triggers
        public void SetGoToMenuOption(MenuScreenChanger goToMenu)
        {
            _goToMenu = goToMenu;
        }
        public void SetFillSignal(FillSignal fillSignal)
        {
            _fillSignal = fillSignal;
        }
        public void SetExecuteSignal(ExecuteSignal executeSignal)
        {
            _executeSignal = executeSignal;
        }
        // On press trigger screen change signal( go to menu )
        private void EpMenuButton_Click(object sender, EventArgs e)
        {
            _goToMenu?.Invoke(SubScreens.ViewProceduresScreen);
        }
        // On Load trigger execute signal from the controller
        private void ExecuteProceduresScreen_Load(object sender, EventArgs e)
        {
            _fillSignal?.Invoke();
        }
        // Function to take the Connection List and fill the Right ListBox with the Server + DB's names
        public void SetCSsSource(DataTable source)
        {
            if (!source.Columns.Contains("DisplayColumn"))
            {
                source.Columns.Add("DisplayColumn", typeof(string));
                foreach(DataRow row in source.Rows)
                {
                    row["DisplayColumn"] = row["ServerIPorName"] + ":" + row["Port"] + "/" + row["InstanceName"];
                }
            }

            // Set the DataSource and use the new computed column as the DisplayMember
            epCSsListBox.DataSource = source;
            epCSsListBox.DisplayMember = "DisplayColumn";
        }
        // Function to take the Procedure List and fill the Left ListBox with the procedure's names
        public void SetSPsSource(DataTable source)
        {
            epSPsListBox.DataSource = source;
            epSPsListBox.DisplayMember = "ProcedureName";
        }
        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            _executeSignal?.Invoke();
        }
        public List<string> GetSelectedProcedures()
        {
            List<string> selectedProcedures = [];

            foreach(int i in epSPsListBox.SelectedIndices)
            {
                DataRowView? dataRow = epSPsListBox.Items[i] as DataRowView;

                if (dataRow == null)
                    continue;

                string? procedureName = dataRow["ProcedureName"] as string;
                if (procedureName == null)
                    continue;
                selectedProcedures.Add(procedureName);
            }

            return selectedProcedures;
        }
        public List<int> GetSelectedConnectionsID()
        {
            List<int> selectedConnectionsId= [];

            foreach (int i in epCSsListBox.SelectedIndices)
            {
                var dataRow = epCSsListBox.Items[i] as DataRowView;
                if (dataRow == null)
                    continue;

                int? connectionID = dataRow["ID"] as int?;

                if (connectionID == null) continue;
                    
                selectedConnectionsId.Add((int)connectionID);
            }

            return selectedConnectionsId;
        }
    }
}
