namespace OGRIT_Database_Custom_App
{
    public partial class InsertUpdateForm : System.Windows.Forms.Form
    {
        public InsertUpdateForm()
        {
            InitializeComponent();
        }
        public void setButtonText(string text) { 
            submitUpdateButton.Text = text;
        }

        public void ResetInputFormText()
        {
            IUinputForm.ResetInput();
        }
    }
}
