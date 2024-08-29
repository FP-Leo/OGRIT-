using OGRIT_Database_Custom_App.Models;

namespace OGRIT_Database_Custom_App
{
    /// <summary>
    /// Represents a form for inserting or updating database connection details.
    /// </summary>
    public partial class InsertUpdateForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// The connection string object that holds the details of the database connection.
        /// </summary>
        private ConnectionString? _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="InsertUpdateForm"/> class.
        /// </summary>
        public InsertUpdateForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the text of the submit/update button on the form.
        /// </summary>
        /// <param name="text">The text to display on the button.</param>
        public void SetButtonText(string text)
        {
            submitUpdateButton.Text = text;
        }

        /// <summary>
        /// Resets the input form fields to empty values.
        /// </summary>
        public void ResetInputFormText()
        {
            IUinputForm.ResetInput();
        }

        /// <summary>
        /// Sets the input form fields with the provided connection string details.
        /// </summary>
        /// <param name="cs">The connection string object containing the details to display in the form.</param>
        public void SetInputFormText(ConnectionString cs)
        {
            IUinputForm.SetInput(cs);
        }

        /// <summary>
        /// Event handler for the submit/update button click event.
        /// Validates the input and sets the connection string if valid.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
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

        /// <summary>
        /// Retrieves the connection string that was set by the form.
        /// </summary>
        /// <returns>The <see cref="ConnectionString"/> object containing the database connection details, or <c>null</c> if not set.</returns>
        public ConnectionString? GetConnectionString()
        {
            return _connectionString;
        }
    }
}
