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
        public void setButtonText(string text)
        {
            submitUpdateButton.Text = text;
        }

        public void ResetInputFormText()
        {
            IUinputForm.ResetInput();
        }

        private void submitUpdateButton_Click(object sender, EventArgs e)
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
