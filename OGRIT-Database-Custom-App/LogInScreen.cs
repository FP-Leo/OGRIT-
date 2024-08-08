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
            passwordLabel = new Label();
            usernameLabel = new Label();
            dbInstanceLabel = new Label();
            passwordTB = new TextBox();
            usernameTB = new TextBox();
            serverTB = new TextBox();
            serverIPLabel = new Label();
            connectButton = new RoundButton();
            portLabel = new Label();
            portTB = new TextBox();
            dbTB = new TextBox();
            authCB = new ComboBox();
            authLabel = new Label();
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

            insideTablePanel.Controls.Add(serverIPLabel, 0, 1);
            insideTablePanel.Controls.Add(serverTB, 0, 2);
            insideTablePanel.Controls.Add(portLabel, 0, 3);
            insideTablePanel.Controls.Add(portTB, 0, 4);
            insideTablePanel.Controls.Add(dbInstanceLabel, 0, 5);
            insideTablePanel.Controls.Add(dbTB, 0, 6);
            insideTablePanel.Controls.Add(authLabel, 0, 7);
            insideTablePanel.Controls.Add(authCB, 0, 8);
            insideTablePanel.Controls.Add(connectButton, 0, insideTablePanel.RowCount - 2);

            // 
            // dbInstanceLabel
            // 
            dbInstanceLabel.Anchor = AnchorStyles.Left;
            dbInstanceLabel.AutoSize = true;
            dbInstanceLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dbInstanceLabel.Location = new Point(3, 137);
            dbInstanceLabel.Name = "dbInstanceLabel";
            dbInstanceLabel.Size = new Size(110, 20);
            dbInstanceLabel.TabIndex = 11;
            dbInstanceLabel.Text = "Instance Name";
            // 
            // serverTB
            // 
            serverTB.Dock = DockStyle.Fill;
            serverTB.Location = new Point(5, 87);
            serverTB.Margin = new Padding(5, 3, 5, 3);
            serverTB.Name = "serverTB";
            serverTB.PlaceholderText = "Value";
            serverTB.Size = new Size(327, 27);
            serverTB.TabIndex = 0;
            // 
            // serverIPLabel
            // 
            serverIPLabel.Anchor = AnchorStyles.Left;
            serverIPLabel.AutoSize = true;
            serverIPLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            serverIPLabel.Location = new Point(3, 53);
            serverIPLabel.Name = "serverIPLabel";
            serverIPLabel.Size = new Size(135, 20);
            serverIPLabel.TabIndex = 9;
            serverIPLabel.Text = "Server Name or IP";

            // 
            // authLabel
            // 
            authLabel.Anchor = AnchorStyles.Left;
            authLabel.AutoSize = true;
            authLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            authLabel.Location = new Point(3, 280); 
            authLabel.Name = "authLabel";
            authLabel.Size = new Size(146, 20);
            authLabel.TabIndex = 18;
            authLabel.Text = "Authentication Type";
            // 
            // authCB
            // 
            authCB.Dock = DockStyle.Fill;
            authCB.DropDownStyle = ComboBoxStyle.DropDownList;
            authCB.FormattingEnabled = true;
            authCB.Location = new Point(3, 399);
            authCB.Name = "authCB";
            authCB.Size = new Size(331, 28);
            authCB.TabIndex = 4;
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
            connectButton.TabIndex = 7;
            connectButton.Text = "Connect";
            connectButton.TextColor = Color.LightGray;
            connectButton.UseVisualStyleBackColor = false;
            connectButton.Click += LoginButton_Click;
            // 
            // dbTB
            // 
            dbTB.Dock = DockStyle.Fill;
            dbTB.Location = new Point(5, 171);
            dbTB.Margin = new Padding(5, 3, 5, 3);
            dbTB.Name = "dbTB";
            dbTB.PlaceholderText = "Value";
            dbTB.Size = new Size(327, 27);
            dbTB.TabIndex = 3;
            // 
            // portTB
            // 
            portTB.Dock = DockStyle.Fill; // Alanı tam kaplaması için DockStyle.Fill kullanıldı
            portTB.Location = new Point(5, 243); // `portLabel`'ın altında yerleştirildi
            portTB.Margin = new Padding(5, 3, 5, 3);
            portTB.Name = "portTB";
            portTB.PlaceholderText = "1433";
            portTB.Size = new Size(327, 27);
            portTB.TabIndex = 1;
            // 
            // portLabel
            // 
            portLabel.Anchor = AnchorStyles.Left;
            portLabel.AutoSize = true;
            portLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            portLabel.Location = new Point(3, 208); // `dbTB`'nin hemen altında olacak şekilde ayarlandı
            portLabel.Name = "portLabel";
            portLabel.Size = new Size(37, 20);
            portLabel.TabIndex = 17;
            portLabel.Text = "Port";
            // 
            // passwordLabel
            // 
            passwordLabel.Anchor = AnchorStyles.Left;
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passwordLabel.Location = new Point(3, 347);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(73, 20);
            passwordLabel.TabIndex = 13;
            passwordLabel.Text = "Password";
            // 
            // usernameLabel
            // 
            usernameLabel.Anchor = AnchorStyles.Left;
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernameLabel.Location = new Point(3, 263);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(78, 20);
            usernameLabel.TabIndex = 12;
            usernameLabel.Text = "Username";
            // 
            // passwordTB
            // 
            passwordTB.Dock = DockStyle.Fill;
            passwordTB.Location = new Point(5, 381);
            passwordTB.Margin = new Padding(5, 3, 5, 3);
            passwordTB.Name = "passwordTB";
            passwordTB.PasswordChar = '*';
            passwordTB.PlaceholderText = "Value";
            passwordTB.Size = new Size(327, 27);
            passwordTB.TabIndex = 6;
            // 
            // usernameTB
            // 
            usernameTB.Dock = DockStyle.Fill;
            usernameTB.Location = new Point(5, 297);
            usernameTB.Margin = new Padding(5, 3, 5, 3);
            usernameTB.Name = "usernameTB";
            usernameTB.PlaceholderText = "Value";
            usernameTB.Size = new Size(327, 27);
            usernameTB.TabIndex = 5;

            outsideTablePanel.Controls.Add(insideTablePanel, 1, 0);
            insideTablePanel.ResumeLayout(false);
            insideTablePanel.PerformLayout();
        }
    }
}