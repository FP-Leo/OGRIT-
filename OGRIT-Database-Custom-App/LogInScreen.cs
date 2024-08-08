using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OGRIT_Database_Custom_App
{
    public partial class LogInScreen : UserControl
    {
        private readonly MainWindow _parent;
        private int selected = 0;
        public LogInScreen()
        {
            InitializeComponent();
        }
        public LogInScreen(MainWindow parent)
        {
            InitializeComponent();
            _parent = parent;
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (_parent == null)
            {
                return;
            }

            string? connectionString = GetConnectionString();

            if (connectionString == null) {
                return;
            }

            try
            {
                var connection = new SqlConnection(connectionString);
                string query = "SELECT * FROM [dbo].[dbInfo]";
                try
                {
                    SqlDataAdapter dataAdapter = new(query, connection);
                    DataTable dataTable = new();
                    dataAdapter.Fill(dataTable);
                    //dataGridView1.DataSource = dataTable;
                    _parent.logInScreen.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private string? GetConnectionString()
        {
            bool validState = true;
            string errorMessage = "\tError List\n\r\n\r";
            int err = 1;

            string serverIP = serverTB.Text;

            string dbi = dbTB.Text;
            string username = usernameTB.Text;
            string password = passwordTB.Text;

            string connectionString = "";

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

        private void AuthCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (authCB.SelectedIndex == selected)
                return;

            selected = authCB.SelectedIndex;

            DrawInnerPannel();

        }
        private void LogInScreen_Load(object sender, EventArgs e)
        {
            DrawInnerPannel();
        }

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

        private void DrawInnerPannel()
        {
            if (insideTablePanel != null)
            {
                Controls.Remove(insideTablePanel);
                insideTablePanel.Dispose();
                insideTablePanel = null;
            }

            insideTablePanel = new TableLayoutPanel();
            insideTablePanel.SuspendLayout();
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
            insideTablePanel.ColumnCount = 1;
            insideTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            insideTablePanel.Anchor = AnchorStyles.None;
            insideTablePanel.MaximumSize = new Size(440, 850);
            //insideTablePanel.MinimumSize = new Size(337, 550);
            insideTablePanel.Location = new Point(346, 3);
            insideTablePanel.Name = "insideTablePanel";

            // Changing sizes based on how many rows there are, first and last (outside) row are there for space.
            float outsideRowSize = 11.2068968F;
            float innerRowSize = 8.620689F;
            insideTablePanel.RowCount = 11;
            if (selected == 1)
            {
                outsideRowSize = 1.0F;
                innerRowSize = 7.5F;
                insideTablePanel.RowCount = 15;
                insideTablePanel.Controls.Add(usernameLabel, 0, 8);
                insideTablePanel.Controls.Add(usernameTB, 0, 9);
                insideTablePanel.Controls.Add(passwordLabel, 0, 10);
                insideTablePanel.Controls.Add(passwordTB, 0, 11); 
            }
            insideTablePanel.RowStyles.Clear();
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, outsideRowSize));
            for (int i = 0; i < insideTablePanel.RowCount - 2; i++)
            {
                insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, innerRowSize));
            }
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, outsideRowSize));
            insideTablePanel.Size = new Size(337, 550);
            insideTablePanel.TabIndex = 0;

            // Adding based on location;
            insideTablePanel.Controls.Add(serverIPLabel, 0, 1);
            insideTablePanel.Controls.Add(serverTB, 0, 2);
            insideTablePanel.Controls.Add(portLabel, 0, 3);
            insideTablePanel.Controls.Add(portTB, 0, 4);
            insideTablePanel.Controls.Add(dbInstanceLabel, 0, 5);
            insideTablePanel.Controls.Add(dbTB, 0, 6);
            insideTablePanel.Controls.Add(authLabel, 0, 7);
            insideTablePanel.Controls.Add(authCB, 0, 8);
            // Button is the second to last one on both designes.
            insideTablePanel.Controls.Add(connectButton, 0, insideTablePanel.RowCount - 2);

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

            outsideTablePanel.Controls.Add(insideTablePanel, 1, 0);
            insideTablePanel.ResumeLayout(false);
            insideTablePanel.PerformLayout();
        }
    }
}