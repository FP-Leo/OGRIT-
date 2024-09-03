using OGRIT_Database_Custom_App.Generics;
using System.Data;
using static OGRIT_Database_Custom_App.Generics.DelegateContainer;
using static OGRIT_Database_Custom_App.Generics.ScreenEnums;

namespace OGRIT_Database_Custom_App.Views.Screens
{
    /// <summary>
    /// Represents a screen for executing stored procedures in the application.
    /// </summary>
    public partial class ExecuteProceduresScreen : UserControl
    {
        /// <summary>
        /// Delegate to navigate to the menu screen.
        /// </summary>
        private MenuScreenChanger? _goToMenuSignal;

        /// <summary>
        /// Delegate to signal filling the screen with data.
        /// </summary>
        private FillSignal? _fillSignal;

        /// <summary>
        /// Delegate to signal selected queries execution on the selected databases.
        /// </summary>
        private ExecuteSignal? _executeSignal;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ExecuteProceduresScreen"/> class.
        /// </summary>
        public ExecuteProceduresScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the delegate to navigate to the menu screen.
        /// </summary>
        /// <param name="goToMenuSignal">The delegate that navigates to the menu screen.</param>
        public void SetGoToMenuSignal(MenuScreenChanger goToMenuSignal)
        {
            _goToMenuSignal = goToMenuSignal;
        }

        /// <summary>
        /// Sets the delegate to signal filling the screen with data.
        /// </summary>
        /// <param name="fillSignal">The delegate that signals to fill the screen.</param>
        public void SetFillSignal(FillSignal fillSignal)
        {
            _fillSignal = fillSignal;
        }
        /// <summary>
        /// Sets the delegate to signal selected query execution
        /// </summary>
        /// <param name="executeSignal">The delegate that signals the selected query execution.</param>
        public void SetExecuteSignal(ExecuteSignal executeSignal)
        {
            _executeSignal = executeSignal;
        }

        /// <summary>
        /// Handles the event when the menu button is clicked, navigating back to the menu screen.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void EpMenuButton_Click(object sender, EventArgs e)
        {
            _goToMenuSignal?.Invoke(SubScreens.ViewProceduresScreen);
        }

        /// <summary>
        /// Handles the load event of the screen, triggering the fill signal if it is set.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ExecuteProceduresScreen_Load(object sender, EventArgs e)
        {
            _fillSignal?.Invoke();
        }

        /// <summary>
        /// Sets the data source for the connection strings list box.
        /// </summary>
        /// <param name="source">The data table containing connection string information.</param>
        public void SetCSsSource(DataTable source)
        {
            if (!source.Columns.Contains("DisplayColumn"))
            {
                // Create new Computed Column for better understanding of which Connection represents which Database.
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
        /// <summary>
        /// Sets the data source for the stored procedures list box.
        /// </summary>
        /// <param name="source">The data table containing stored procedure names.</param>
        public void SetSPsSource(DataTable source)
        {
            epSPsListBox.DataSource = source;
            epSPsListBox.DisplayMember = "ProcedureName";
        }
        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            _executeSignal?.Invoke();
        }
        /// <summary>
        /// Retrieves the selected stored procedures from the `epSPsListBox`.
        /// This method iterates over the selected indices of the `epSPsListBox` and returns a list of the corresponding `DataRowView` objects,
        /// which represent the stored procedures selected by the user.
        /// Used when the Execution Signal is fired.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="DataRowView"/> objects representing the selected stored procedures.</returns>
        public List<DataRowView> GetSelectedProcedures()
        {
            List<DataRowView> selectedProcedures = [];

            foreach(int i in epSPsListBox.SelectedIndices)
            {
                if (epSPsListBox.Items[i] is not DataRowView dataRow)
                {
                    StaticMethodHolder.WriteToLog(LogType.Warning, $"Failed to convert {i+1}th selected Procedure to DataRowView");
                    continue;
                }

                selectedProcedures.Add(dataRow);
            }

            return selectedProcedures;
        }
        /// <summary>
        /// Retrieves the selected connections from the `epCSsListBox`.
        /// This method iterates over the selected indices of the `epCSsListBox` and returns a list of the corresponding `DataRowView` objects,
        /// which represent the connections selected by the user.
        /// Used when the Execution Signal is fired.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="DataRowView"/> objects representing the selected connections.</returns>
        public List<DataRowView> GetSelectedConnectionsID()
        {
            List<DataRowView> selectedConnections= [];

            foreach (int i in epCSsListBox.SelectedIndices)
            {
                if (epCSsListBox.Items[i] is not DataRowView dataRow)
                {
                    StaticMethodHolder.WriteToLog(LogType.Warning, $"Failed to convert {i + 1}th selected Connection to DataRowView");
                    continue;
                }

                selectedConnections.Add(dataRow);
            }

            return selectedConnections;
        }
    }
}
