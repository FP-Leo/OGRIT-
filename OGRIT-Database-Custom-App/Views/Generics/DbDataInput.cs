using OGRIT_Database_Custom_App.Models;
using OGRIT_Database_Custom_App.Generics;
using System.Configuration;

namespace OGRIT_Database_Custom_App
{
    public partial class DbDataInput : UserControl
    {
        private bool SQLAuth = false;
        private ConnectionString? connectionString;
        private bool validState = true;
        private string errorMessageList = string.Empty;
        private int err = 0;

        public DbDataInput()
        {
            InitializeComponent();
            InitializeInputComponent();
        }

        // Event to change Log In Screen Layout.
        private void AuthCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currentIndex = SQLAuth ? 1 : 0;
            // don't bother redrawing
            if (authCB.SelectedIndex == currentIndex)
                return;

            SQLAuth = !SQLAuth;

            // Remove Username Password Label/TB by making row height% = 0 if SQLAuth == false else show
            ChangeTableLayout();
        }
        // 
        // To show errors properly
        //
        private void AddToErrorList(string errorMessage)
        {
            errorMessageList += $"{err++}. {errorMessage}\n\r";
            validState = false;
        }
        //
        // To validate connection string input, it doesnt use logic just stops empty fields.s
        //
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
        private static TextBox CustomTextBox(string Name, string PlaceholderText, int TabIndex)
        {
            return new TextBox
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(5, 3, 5, 3),
                Name = Name,
                PlaceholderText = PlaceholderText,
                TabIndex = TabIndex,
                Visible =true
            };
        }
        // To draw the user control
        private void InitializeInputComponent()
        {
            // dbIFTableLayoutPanel decalaration
            dbIFTableLayoutPanel = new TableLayoutPanel();
            // Label declaration;
            serverIPLabel = CustomLabel("serverIPLabel", 9, "Server Name or IP");
            dbInstanceLabel = CustomLabel("dbInstanceLabel", 11, "Instance Name");
            portLabel = CustomLabel("portLabel", 17, "Port");
            usernameLabel = CustomLabel("usernameLabel", 12, "Username");
            passwordLabel = CustomLabel("passwordLabel", 13, "Password");
            authLabel = CustomLabel("authLabel", 18, "Authentication Type");
            // TextBox declaration;
            serverTB = CustomTextBox("serverTB", "Value", 0);
            portTB = CustomTextBox("portTB", "Value", 1);
            dbTB = CustomTextBox("dbTB", "Value", 2);
            usernameTB = CustomTextBox("usernameTB", "Value", 4);
            passwordTB = CustomTextBox("passwordTB", "Value", 5);
            passwordTB.PasswordChar = '*';
            // ComboBox declaration;
            authCB = new ComboBox();

            // 
            // dbIFTableLayoutPanel settings
            // 
            dbIFTableLayoutPanel.ColumnCount = 1;
            dbIFTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            dbIFTableLayoutPanel.Anchor = AnchorStyles.None;
            dbIFTableLayoutPanel.Dock = DockStyle.Fill;
            dbIFTableLayoutPanel.Location = new Point(3, 30);
            dbIFTableLayoutPanel.Name = "dbIFTableLayoutPanel";
            dbIFTableLayoutPanel.RowCount = 12;
            dbIFTableLayoutPanel.TabIndex = 0;

            // Adding based on location;
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

            // 
            // authCB
            // 
            authCB.Dock = DockStyle.Fill;
            authCB.DropDownStyle = ComboBoxStyle.DropDownList;
            authCB.FormattingEnabled = true;
            //authCB.Location = new Point(3, 399);
            authCB.Name = "authCB";
            //authCB.Size = new Size(331, 28);
            authCB.TabIndex = 3;
            authCB.BindingContext = this.BindingContext;
            authCB.Visible = true;

            string[] cbOptions = ["Windows Authentication", "SQL Server Authentication"];
            authCB.DataSource = cbOptions;
            authCB.SelectedIndexChanged += AuthCB_SelectedIndexChanged;

            SetDefaultInput();

            Controls.Add(dbIFTableLayoutPanel);
        }
        // To dynamically change it based on auth type.
        private void ChangeTableLayout()
        {
            authCB.SelectedIndex = SQLAuth ? 1 : 0;
            dbIFTableLayoutPanel.RowStyles.Clear();

            float rowHeight = 100F / 8;
            float specialRowHeight = 0F;
            SizeType st = SizeType.Absolute;

            if (SQLAuth) {
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
        public void SetInput(ConnectionString cs)
        {
            serverTB.Text = cs.GetServerNameIP();
            portTB.Text = Convert.ToString(cs.GetPort());
            dbTB.Text = cs.GetInstanceName();
            SQLAuth = cs.IsSQLAuth();
            usernameTB.Text = cs.GetUsername();

            ChangeTableLayout();
        }
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
