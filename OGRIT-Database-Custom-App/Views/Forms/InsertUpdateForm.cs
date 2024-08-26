using OGRIT_Database_Custom_App.Models;

namespace OGRIT_Database_Custom_App
{
    public partial class InsertUpdateForm : System.Windows.Forms.Form
    {
        private ConnectionString? _connectionString;
        public InsertUpdateForm()
        {
            InitializeComponent();
        }
        public void SetButtonText(string text)
        {
            submitUpdateButton.Text = text;
        }

        public void ResetInputFormText()
        {
            IUinputForm.ResetInput();
        }

        public void SetInputFormText(ConnectionString cs)
        {
            IUinputForm.SetInput(cs);
        }

        private void SubmitUpdateButton_Click(object sender, EventArgs e)
        {
            _connectionString = IUinputForm.ValidateInput();

            if (_connectionString == null)
            {
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public ConnectionString? GetConnectionString() {
            return _connectionString;
        }
    }
}
