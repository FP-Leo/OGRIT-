using OGRIT_Database_Custom_App.Models;
using OGRIT_Database_Custom_App.Generics;
using System.Configuration;

namespace OGRIT_Database_Custom_App
{
    /// <summary>
    /// Represents a user control for database data input, handling the input and validation of connection string components.
    /// </summary>
    public partial class DbDataInput : UserControl
    {
        /// <summary>
        /// Indicates whether SQL authentication is enabled.
        /// </summary>
        private bool SQLAuth = false;

        /// <summary>
        /// Holds the connection string object created from the user input.
        /// </summary>
        private ConnectionString? connectionString;

        /// <summary>
        /// Represents the current validity state of the input data.
        /// </summary>
        private bool validState = true;

        /// <summary>
        /// Stores the error messages generated during input validation.
        /// </summary>
        private string errorMessageList = string.Empty;

        /// <summary>
        /// Keeps track of the number of errors encountered during validation.
        /// </summary>
        private int err = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbDataInput"/> class.
        /// </summary>
        public DbDataInput()
        {
            InitializeComponent();
            InitializeInputComponent();
        }

        // Event to change Log In Screen Layout.
        /// <summary>
        /// Handles the event when the selected authentication type is changed.
        /// Updates the UI to reflect the selected authentication type.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void AuthCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currentIndex = SQLAuth ? 1 : 0;
            // Skip redrawing if the selected index hasn't changed
            if (authCB.SelectedIndex == currentIndex)
                return;

            SQLAuth = !SQLAuth;
            // Remove Username Password Label/TB by making row height% = 0 if SQLAuth == false else show
            ChangeTableLayout();
        }

        // 
        // To show errors properly
        //
        /// <summary>
        /// Adds an error message to the error list and updates the validity state.
        /// </summary>
        /// <param name="errorMessage">The error message to add.</param>
        private void AddToErrorList(string errorMessage)
        {
            errorMessageList += $"{err++}. {errorMessage}\n\r";
            validState = false;
        }

        //
        // To validate connection string input, it doesnt use logic just stops empty fields.s
        //
        /// <summary>
        /// Validates the user input and creates a <see cref="ConnectionString"/> object if the input is valid.
        /// </summary>
        /// <returns>A <see cref="ConnectionString"/> object if the input is valid; otherwise, <c>null</c>.</returns>
        public ConnectionString? ValidateInput()
        {
            validState = true;
            errorMessageList = "\tError List\n\r\n\r";
            err = 1;

            string serverIP = serverTB.Text;
            string dbi = dbTB.Text;
            string username = usernameTB.Text;
            string password = passwordTB.Text;

            if (string.IsNullOrEmpty(serverIP)) AddToErrorList("Server IP missing");

            int port = 0;
            try
            {
                port = Convert.ToInt32(portTB.Text);
            }
            catch
            {
                AddToErrorList("Invalid Port");
            }

            if (string.IsNullOrEmpty(dbi)) AddToErrorList("Database Instance missing");

            if (SQLAuth)
            {
                if (string.IsNullOrEmpty(username)) AddToErrorList("Username missing");

                if (string.IsNullOrEmpty(password)) AddToErrorList("Password missing");
            }

            if (!validState)
            {
                MessageBox.Show(errorMessageList);
                return null;
            }

            connectionString = new ConnectionString(serverIP, port, dbi, SQLAuth, username, password, false);

            return connectionString;
        }

        // To avoid code repetitions.
        /// <summary>
        /// Creates a customized label with the specified properties.
        /// </summary>
        /// <param name="name">The name of the label.</param>
        /// <param name="tabIndex">The tab index of the label.</param>
        /// <param name="text">The text to display on the label.</param>
        /// <returns>A <see cref="Label"/> object with the specified properties.</returns>
        private static Label CustomLabel(string name, int tabIndex, string text)
        {
            return new Label
            {
                Anchor = AnchorStyles.Left,
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0),
                Name = name,
                TabIndex = tabIndex,
                Text = text,
                Visible = true
            };
        }

        /// <summary>
        /// Creates a customized text box with the specified properties.
        /// </summary>
        /// <param name="Name">The name of the text box.</param>
        /// <param name="PlaceholderText">The placeholder text for the text box.</param>
        /// <param name="TabIndex">The tab index of the text box.</param>
        /// <returns>A <see cref="TextBox"/> object with the specified properties.</returns>
        private static TextBox CustomTextBox(string Name, string PlaceholderText, int TabIndex)
        {
            return new TextBox
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(5, 3, 5, 3),
                Name = Name,
                PlaceholderText = PlaceholderText,
                TabIndex = TabIndex,
                Visible = true
            };
        }

        // To draw the user control
        /// <summary>
        /// Initializes the input components of the user control.
        /// </summary>
        private void InitializeInputComponent()
        {
            // dbIFTableLayoutPanel declaration
            dbIFTableLayoutPanel = new TableLayoutPanel();
            // Label declarations
            serverIPLabel = CustomLabel("serverIPLabel", 9, "Server Name or IP");
            dbInstanceLabel = CustomLabel("dbInstanceLabel", 11, "Instance Name");
            portLabel = CustomLabel("portLabel", 17, "Port");
            usernameLabel = CustomLabel("usernameLabel", 12, "Username");
            passwordLabel = CustomLabel("passwordLabel", 13, "Password");
            authLabel = CustomLabel("authLabel", 18, "Authentication Type");
            // TextBox declarations
            serverTB = CustomTextBox("serverTB", "Value", 0);
            portTB = CustomTextBox("portTB", "Value", 1);
            dbTB = CustomTextBox("dbTB", "Value", 2);
            usernameTB = CustomTextBox("usernameTB", "Value", 4);
            passwordTB = CustomTextBox("passwordTB", "Value", 5);
            passwordTB.PasswordChar = '*';
            // ComboBox declaration
            authCB = new ComboBox();

            // dbIFTableLayoutPanel settings
            dbIFTableLayoutPanel.ColumnCount = 1;
            dbIFTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            dbIFTableLayoutPanel.Anchor = AnchorStyles.None;
            dbIFTableLayoutPanel.Dock = DockStyle.Fill;
            dbIFTableLayoutPanel.Location = new Point(3, 30);
            dbIFTableLayoutPanel.Name = "dbIFTableLayoutPanel";
            dbIFTableLayoutPanel.RowCount = 12;
            dbIFTableLayoutPanel.TabIndex = 0;

            // Adding controls based on location
            dbIFTableLayoutPanel.Controls.Add(serverIPLabel, 0, 0);
            dbIFTableLayoutPanel.Controls.Add(serverTB, 0, 1);
            dbIFTableLayoutPanel.Controls.Add(portLabel, 0, 2);
            dbIFTableLayoutPanel.Controls.Add(portTB, 0, 3);
            dbIFTableLayoutPanel.Controls.Add(dbInstanceLabel, 0, 4);
            dbIFTableLayoutPanel.Controls.Add(dbTB, 0, 5);
            dbIFTableLayoutPanel.Controls.Add(authLabel, 0, 6);
            dbIFTableLayoutPanel.Controls.Add(authCB, 0, 7);
            dbIFTableLayoutPanel.Controls.Add(usernameLabel, 0, 8);
            dbIFTableLayoutPanel.Controls.Add(usernameTB, 0, 9);
            dbIFTableLayoutPanel.Controls.Add(passwordLabel, 0, 10);
            dbIFTableLayoutPanel.Controls.Add(passwordTB, 0, 11);

            // authCB settings
            authCB.Dock = DockStyle.Fill;
            authCB.DropDownStyle = ComboBoxStyle.DropDownList;
            authCB.FormattingEnabled = true;
            authCB.Name = "authCB";
            authCB.TabIndex = 3;
            authCB.BindingContext = this.BindingContext;
            authCB.Visible = true;

            string[] cbOptions = { "Windows Authentication", "SQL Server Authentication" };
            authCB.DataSource = cbOptions;
            authCB.SelectedIndexChanged += AuthCB_SelectedIndexChanged;

            SetDefaultInput();

            Controls.Add(dbIFTableLayoutPanel);
        }

        /// <summary>
        /// Dynamically changes the layout based on the selected authentication type.
        /// </summary>
        private void ChangeTableLayout()
        {
            authCB.SelectedIndex = SQLAuth ? 1 : 0;
            dbIFTableLayoutPanel.RowStyles.Clear();

            float rowHeight = 100F / 8;
            float specialRowHeight = 0F;
            SizeType st = SizeType.Absolute;

            if (SQLAuth)
            {
                rowHeight = 100F / 12;
                specialRowHeight = rowHeight;
                st = SizeType.Percent;
            }

            int i = 0;
            for (; i < 9; i++)
            {
                dbIFTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, rowHeight));
            }

            for (; i < 12; i++)
            {
                dbIFTableLayoutPanel.RowStyles.Add(new RowStyle(st, specialRowHeight));
            }

            // If SQLAuth == true these need to be shown.
            usernameLabel.Visible = SQLAuth;
            usernameTB.Visible = SQLAuth;
            passwordLabel.Visible = SQLAuth;
            passwordTB.Visible = SQLAuth;

            authCB.SelectedIndex = SQLAuth ? 1 : 0;
        }

        /// <summary>
        /// Resets the input fields to their default values.
        /// </summary>
        public void ResetInput()
        {
            serverTB.Text = string.Empty;
            portTB.Text = string.Empty;
            dbTB.Text = string.Empty;
            usernameTB.Text = string.Empty;
            passwordTB.Text = string.Empty;

            SQLAuth = false;
            authCB.SelectedIndex = 0;

            ChangeTableLayout();
        }

        /// <summary>
        /// Sets the input fields based on the provided <see cref="ConnectionString"/> object.
        /// </summary>
        /// <param name="cs">The <see cref="ConnectionString"/> object to use for setting the input fields.</param>
        public void SetInput(ConnectionString cs)
        {
            serverTB.Text = cs.GetServerNameIP();
            portTB.Text = Convert.ToString(cs.GetPort());
            dbTB.Text = cs.GetInstanceName();
            SQLAuth = cs.IsSQLAuth();
            usernameTB.Text = cs.GetUsername();

            ChangeTableLayout();
        }

        /// <summary>
        /// Sets the input fields based on the provided values.
        /// </summary>
        /// <param name="serverTBText">The server IP or name.</param>
        /// <param name="portTBText">The port number.</param>
        /// <param name="dbTBText">The database instance name.</param>
        /// <param name="usernameTBText">The username (if using SQL authentication).</param>
        public void SetInput(string? serverTBText, string? portTBText, string? dbTBText, string? usernameTBText)
        {
            serverTB.Text = serverTBText;
            portTB.Text = portTBText;
            dbTB.Text = dbTBText;

            SQLAuth = false;
            usernameTB.Text = usernameTBText;
            if (!string.IsNullOrEmpty(usernameTBText))
            {
                SQLAuth = true;
            }

            ChangeTableLayout();
        }

        /// <summary>
        /// Sets the input fields to their default values as specified in the configuration file.
        /// </summary>
        public void SetDefaultInput()
        {
            SetInput(ConfigurationManager.AppSettings["defaultServer"],
                     ConfigurationManager.AppSettings["defaultPort"],
                     ConfigurationManager.AppSettings["defaultInstance"],
                     ConfigurationManager.AppSettings["defaultUsername"]
                     );
        }
    }
}
