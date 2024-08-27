using static OGRIT_Database_Custom_App.Generics.DelegateContainer;

namespace OGRIT_Database_Custom_App
{
    /// <summary>
    /// Represents the starting screen of the application that allows the user to proceed to the next screen.
    /// </summary>
    public partial class StartingScreen : UserControl
    {
        /// <summary>
        /// Delegate used to change the screen.
        /// </summary>
        private ScreenChanger? _changer;

        /// <summary>
        /// Initializes a new instance of the <see cref="StartingScreen"/> class.
        /// </summary>
        public StartingScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of the continue button and triggers the screen changer delegate.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void ContinueButton_Click(object sender, EventArgs e)
        {
            _changer?.Invoke();
        }

        /// <summary>
        /// Sets the delegate used to change the screen.
        /// </summary>
        /// <param name="changer">The delegate to change the screen.</param>
        public void SetChanger(ScreenChanger changer)
        {
            _changer = changer;
        }
    }
}
