using System.Data;
using System.Data.SqlClient;

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
            string serverIP = serverTB.Text;
            string dbi = dbTB.Text;
            string username = usernameTB.Text;
            string password = passwordTB.Text;

            string errorMessage = "Error List:";
            bool validState = true;

            if (string.IsNullOrEmpty(serverIP))
            {
                errorMessage += "Server IP missing\n\r";
                validState = false;
            }

            if (string.IsNullOrEmpty(dbi))
            {
                errorMessage += "Database Instance missing\n\r";
                validState = false;
            }

            if (string.IsNullOrEmpty(username))
            {
                errorMessage += "Username missing\n\r";
                validState = false;
            }

            if (string.IsNullOrEmpty(password))
            {
                errorMessage += "Password missing\n\r";
                validState = false;
            }

            if (!validState)
            {
                MessageBox.Show(errorMessage);
                return;
            }

            string connectionString = $"Data Source={serverIP};Initial Catalog={dbi};User ID={username};Password={password};";
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

        private void LoginCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loginCB.SelectedIndex == selected)
                return;

            selected = loginCB.SelectedIndex;

            //MessageBox.Show("Selected = " + selected);
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
            loginCB = new ComboBox();
            loginLB = new Label();
            // 
            // insideTablePanel
            // 
            insideTablePanel.ColumnCount = 1;
            insideTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            insideTablePanel.Dock = DockStyle.Fill;
            //insideTablePanel.MaximumSize = new Size(337, 550);
            //insideTablePanel.MinimumSize = new Size(337, 550);
            insideTablePanel.Location = new Point(346, 3);
            insideTablePanel.Name = "insideTablePanel";

            // 
            // loginCB
            // 
            loginCB.Dock = DockStyle.Fill;
            loginCB.DropDownStyle = ComboBoxStyle.DropDownList;
            loginCB.FormattingEnabled = true;
            loginCB.Location = new Point(3, 310); // `loginLB`'nin altına yerleştirildi
            loginCB.Name = "loginCB";
            loginCB.Size = new Size(330, 28);
            loginCB.TabIndex = 15;
            loginCB.BindingContext = this.BindingContext;

            var cbOptions = new List<string> { "Windows Authentication", "SQL Server Authentication" };
            loginCB.DataSource = cbOptions;

            loginCB.SelectedIndex = selected;
            loginCB.SelectedIndexChanged += LoginCB_SelectedIndexChanged;
            float outsideRowSize = 17.3914928F;
            float innerRowSize = 10.8702259F;
            insideTablePanel.RowCount = 8;
            if (selected == 1)
            {
                innerRowSize = 13.69593F;
                outsideRowSize = 7.261394F;
                insideTablePanel.RowCount = 12;
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
            insideTablePanel.Controls.Add(dbInstanceLabel, 0, 3);
            insideTablePanel.Controls.Add(dbTB, 0, 4);
            insideTablePanel.Controls.Add(portLabel, 0, 5);
            insideTablePanel.Controls.Add(portTB, 0, 6);
            insideTablePanel.Controls.Add(loginLB, 0, 7);
            insideTablePanel.Controls.Add(loginCB, 0, 8);
            insideTablePanel.Controls.Add(connectButton, 0, insideTablePanel.RowCount +1);

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
            // loginLB
            // 
            loginLB.Anchor = AnchorStyles.Left;
            loginLB.AutoSize = true;
            loginLB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginLB.Location = new Point(3, 280); // `portTB`'nin altına yerleştirildi
            loginLB.Name = "loginLB";
            loginLB.Size = new Size(146, 20);
            loginLB.TabIndex = 18;
            loginLB.Text = "Authentication Type";
            // 
            // connectButton
            // 
            connectButton.BackColor = Color.FromArgb(40, 40, 40);
            connectButton.BackgroundColor = Color.FromArgb(40, 40, 40);
            connectButton.BorderColor = Color.FromArgb(40, 40, 40);
            connectButton.BorderRadius = 7;
            connectButton.BorderSize = 0;
            connectButton.Dock = DockStyle.Fill;
            connectButton.FlatAppearance.BorderSize = 0;
            connectButton.FlatStyle = FlatStyle.Flat;
            connectButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            connectButton.ForeColor = Color.LightGray;
            connectButton.Location = new Point(3, 423); // `loginCB`'nin altına yerleştirildi
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(331, 36);
            connectButton.TabIndex = 14;
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
            dbTB.TabIndex = 4;
            // 
            // portTB
            // 
            portTB.Dock = DockStyle.Fill; // Alanı tam kaplaması için DockStyle.Fill kullanıldı
            portTB.Location = new Point(5, 243); // `portLabel`'ın altında yerleştirildi
            portTB.Margin = new Padding(5, 3, 5, 3);
            portTB.Name = "portTB";
            portTB.PlaceholderText = "1433";
            portTB.Size = new Size(327, 27);
            portTB.TabIndex = 5;
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
            passwordTB.TabIndex = 8;
            // 
            // usernameTB
            // 
            usernameTB.Dock = DockStyle.Fill;
            usernameTB.Location = new Point(5, 297);
            usernameTB.Margin = new Padding(5, 3, 5, 3);
            usernameTB.Name = "usernameTB";
            usernameTB.PlaceholderText = "Value";
            usernameTB.Size = new Size(327, 27);
            usernameTB.TabIndex = 6;

            outsideTablePanel.Controls.Add(insideTablePanel, 1, 0);
            insideTablePanel.ResumeLayout(false);
            insideTablePanel.PerformLayout();
        }
    }
}