namespace OGRIT_Database_Custom_App
{
    public partial class inputForm : UserControl
    {
        private int selected = 0;
        public inputForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        // Event to change Log In Screen Layout.
        private void AuthCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // don't bother redrawing
            if (authCB.SelectedIndex == selected)
                return;

            selected = authCB.SelectedIndex;

            switch (selected)
            {
                case 0:
                    // Remove Username Password Label/TB by making row height% = 0
                    ChangeTableLayout(false);
                    break;
                case 1:
                    // Show UserName Password Label/TB
                    ChangeTableLayout(true);
                    break;
            }
        }
        // 
        // Generic Functions
        //
        public string? GetConnectionString()
        {
            bool validState = true;
            string errorMessage = "\tError List\n\r\n\r";
            int err = 1;

            string serverIP = serverTB.Text;

            string dbi = dbTB.Text;
            string username = usernameTB.Text;
            string password = passwordTB.Text;

            string? connectionString = "";

            if (string.IsNullOrEmpty(serverIP))
            {
                errorMessage += $"{err++}. Server IP missing\n\r";
                validState = false;
            }

            int port = 1433;
            if (portTB.Text != "")
            {
                try
                {
                    port = Convert.ToInt32(portTB.Text);
                }
                catch
                {
                    errorMessage += $"{err++}. Invalid Port\n\r";
                    validState = false;
                }
            }

            if (string.IsNullOrEmpty(dbi))
            {
                errorMessage += $"{err++}. Database Instance missing\n\r";
                validState = false;
            }

            connectionString += $"Data Source={serverIP},{port};Initial Catalog={dbi};";

            if (selected == 1)
            {
                if (string.IsNullOrEmpty(username))
                {
                    errorMessage += $"{err++}. Username missing\n\r";
                    validState = false;
                }

                if (string.IsNullOrEmpty(password))
                {
                    errorMessage += $"{err++}. Password missing\n\r";
                    validState = false;
                }
                connectionString += $"User ID={username};Password={password};";
            }
            else
            {
                connectionString += "Integrated Security=True;";
            }

            if (!validState)
            {
                MessageBox.Show(errorMessage);
                connectionString = null;
            }

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

        private void InitializeForm()
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

            ChangeTableLayout(false);

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

            var cbOptions = new List<string> { "Windows Authentication", "SQL Server Authentication" };
            authCB.DataSource = cbOptions;

            authCB.SelectedIndex = selected;
            authCB.SelectedIndexChanged += AuthCB_SelectedIndexChanged;

            Controls.Add(dbIFTableLayoutPanel);
        }
        private void ChangeTableLayout(bool visibleValue)
        {
            dbIFTableLayoutPanel.RowStyles.Clear();
            int i = 0;

            float rowHeight = 100F / 8;
            float specialRowHeight = 0;

            if (visibleValue) {
                rowHeight = 100F / 12;
                specialRowHeight = rowHeight;
            }

            for (; i < 9; i++)
            {
                dbIFTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, rowHeight));
            }

            for (; i < 12; i++)
            {
                dbIFTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, specialRowHeight));
            }

            usernameLabel.Visible = visibleValue;
            usernameTB.Visible = visibleValue;
            passwordLabel.Visible = visibleValue;
            passwordTB.Visible = visibleValue;
        }
    }
}
