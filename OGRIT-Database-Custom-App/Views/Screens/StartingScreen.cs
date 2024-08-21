using static OGRIT_Database_Custom_App.Generics.DelegateContainer;

namespace OGRIT_Database_Custom_App
{
    public partial class StartingScreen : UserControl
    {
        private ScreenChanger? _changer;
        public StartingScreen()
        {
            InitializeComponent();
        }
        private void ContinueButton_Click(object sender, EventArgs e)
        {
            _changer?.Invoke();
        }
        //
        // Set Screen Changer
        //
        public void SetChanger(ScreenChanger changer)
        {
            _changer = changer;
        }
    }
}
