using System.Data;
using static OGRIT_Database_Custom_App.Generics.DelegateContainer;
using static OGRIT_Database_Custom_App.Generics.ScreenEnums;

namespace OGRIT_Database_Custom_App.Views.Screens
{
    public partial class ExecuteProceduresScreen : UserControl
    {
        private MenuScreenChanger? _goToMenu;
        private FillSignal? _fillSignal;
        public ExecuteProceduresScreen()
        {
            InitializeComponent();
        }

        public void setGoToMenuOption(MenuScreenChanger goToMenu)
        {
            _goToMenu = goToMenu;
        }

        public void setFillSignal(FillSignal fillSignal) { 
            _fillSignal = fillSignal;
        }

        private void epMenuButton_Click(object sender, EventArgs e)
        {
            _goToMenu?.Invoke(SubScreens.ViewProceduresScreen);
        }

        private void ExecuteProceduresScreen_Load(object sender, EventArgs e)
        {
            _fillSignal?.Invoke();
        }

        public void SetCSsSource(DataTable source)
        {
            foreach (DataRow row in source.Rows)
            {
                string displayText = $"{row["ServerIPorName"]}/{row["InstanceName"]}";
                epCSsListBox.Items.Add(displayText);
            }
        }

        public void SetSPsSource(DataTable source) { 
            epSPsListBox.DataSource = source;
            epSPsListBox.DisplayMember = "ProcedureName";
        }
    }
}
