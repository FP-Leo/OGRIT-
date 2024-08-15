using System.Data;
using System.Data.SqlClient;
using static OGRIT_Database_Custom_App.MainWindow;

namespace OGRIT_Database_Custom_App
{
    public partial class LogInScreen : UserControl
    {
        private int selected = 0;
        private LogInScreenChanger? _changer;
        public LogInScreen()
        {
            InitializeComponent();
            DrawInnerPanel();
        }
        //
        // Events
        //

        // Event to validate DB connection.
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string? connectionString = GetConnectionString();

            if (connectionString == null) {
                return;
            }

            try
            {
                var connection = new SqlConnection(connectionString);
                // Ensure that you're connected to the DB by using try and catch, if so pass the connection
                // To do: Ensure that ServiceTable exists on that DB.
                _changer?.Invoke(connection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                    // Remove Username Password Label/TB by making row % = 0, inner row = 11F, outter row = 8
                    ChangeInnerTableLayout(false, 11.2068968F, 8.620689F, 0F);
                    break;
                case 1:
                    // Show UserName Password Label/TB, inner/specialrow = 7.5F, outerrow = 1F
                    ChangeInnerTableLayout(true, 7.5F, 1.0F, 7.5F);
                    break;
            }
        }
        // 
        // Generic Functions
        //
        private string? GetConnectionString()
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
        // To avoid code repetiton
        private static Label CustomLabel(string name, int tabIndex, string text)
        {
            return new Label
            {
                Anchor = AnchorStyles.Left,
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0),
                Name = name,
                TabIndex = tabIndex,
                Text = text
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
                TabIndex = TabIndex
            };
        }
        //
        // Set Screen Changer
        //
        public void SetChanger(LogInScreenChanger changer)
        {
            _changer = changer;
        }
        //
        // innerPanelDesign
        //
        private void DrawInnerPanel()
        {
            innerTablePanel = new TableLayoutPanel();
            innerTablePanel.SuspendLayout();
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
            // Button declaration;
            connectButton = new RoundButton();

            // 
            // insideTablePanel
            // 
            innerTablePanel.ColumnCount = 1;
            innerTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            innerTablePanel.Anchor = AnchorStyles.None;
            innerTablePanel.MaximumSize = new Size(440, 850);
            //insideTablePanel.MinimumSize = new Size(337, 550);
            innerTablePanel.Location = new Point(346, 3);
            innerTablePanel.Name = "innerTablePanel";

            // Changing sizes based on how many rows there are, first and last (outside) row are there for space.
            innerTablePanel.RowCount = 15;
            innerTablePanel.Size = new Size(337, 550);
            innerTablePanel.TabIndex = 0;

            // Adding based on location;
            innerTablePanel.Controls.Add(serverIPLabel, 0, 1);
            innerTablePanel.Controls.Add(serverTB, 0, 2);
            innerTablePanel.Controls.Add(portLabel, 0, 3);
            innerTablePanel.Controls.Add(portTB, 0, 4);
            innerTablePanel.Controls.Add(dbInstanceLabel, 0, 5);
            innerTablePanel.Controls.Add(dbTB, 0, 6);
            innerTablePanel.Controls.Add(authLabel, 0, 7);
            innerTablePanel.Controls.Add(authCB, 0, 8);
            innerTablePanel.Controls.Add(usernameLabel, 0, 9);
            innerTablePanel.Controls.Add(usernameTB, 0, 10);
            innerTablePanel.Controls.Add(passwordLabel, 0, 11);
            innerTablePanel.Controls.Add(passwordTB, 0, 12);
            // Button is the second to last one on both designes.
            innerTablePanel.Controls.Add(connectButton, 0, 13);
            
            ChangeInnerTableLayout(false, 11.2068968F, 8.620689F, 0F);

            // 
            // authCB
            // 
            authCB.Dock = DockStyle.Fill;
            authCB.DropDownStyle = ComboBoxStyle.DropDownList;
            authCB.FormattingEnabled = true;
            authCB.Location = new Point(3, 399);
            authCB.Name = "authCB";
            authCB.Size = new Size(331, 28);
            authCB.TabIndex = 3;
            authCB.BindingContext = this.BindingContext;

            var cbOptions = new List<string> { "Windows Authentication", "SQL Server Authentication" };
            authCB.DataSource = cbOptions;

            authCB.SelectedIndex = selected;
            authCB.SelectedIndexChanged += AuthCB_SelectedIndexChanged;
            // 
            // connectButton
            // 
            connectButton.BackColor = Color.FromArgb(40, 40, 40);
            connectButton.BackgroundColor = Color.FromArgb(40, 40, 40);
            connectButton.BorderColor = Color.FromArgb(40, 40, 40);
            connectButton.BorderRadius = 4;
            connectButton.BorderSize = 0;
            connectButton.Dock = DockStyle.Fill;
            connectButton.FlatAppearance.BorderSize = 0;
            connectButton.FlatStyle = FlatStyle.Flat;
            connectButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            connectButton.ForeColor = Color.LightGray;
            connectButton.Location = new Point(3, 440);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(331, 41);
            connectButton.TabIndex = 6;
            connectButton.Text = "Connect";
            connectButton.TextColor = Color.LightGray;
            connectButton.UseVisualStyleBackColor = false;
            connectButton.Click += LoginButton_Click;

            outerTablePanel.Controls.Add(innerTablePanel, 1, 0);
            innerTablePanel.ResumeLayout(false);
            innerTablePanel.PerformLayout();
        }
        //
        // Change Design based on AuthCB
        //
        private void ChangeInnerTableLayout(bool visibleValue, float innerRow, float outterRow, float specialRows)
        {
            innerTablePanel.RowStyles.Clear();
            innerTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, outterRow));
            int i = 1;
            for (; i < 9; i++)
            {
                innerTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, innerRow));
            }
            for (; i < 13; i++)
            {
                innerTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, specialRows));
            }

            innerTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, innerRow));

            innerTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, outterRow));

            usernameLabel.Visible = visibleValue;
            usernameTB.Visible = visibleValue;
            passwordLabel.Visible = visibleValue;
            passwordTB.Visible = visibleValue;
        }
    }
}