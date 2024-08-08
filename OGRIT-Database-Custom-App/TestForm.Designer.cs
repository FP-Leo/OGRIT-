using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace OGRIT_Database_Custom_App
{
    partial class TestForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            outsideTablePanel = new TableLayoutPanel();
            logoPanel = new Panel();
            miniLogoBox = new PictureBox();
            insideTablePanel = new TableLayoutPanel();
            loginTypeLB = new Label();
            portLB = new Label();
            serverIPLabel = new Label();
            serverTB = new TextBox();
            dbTB = new TextBox();
            portTB = new TextBox();
            logintTypeTB = new ComboBox();
            usernameLabel = new Label();
            usernameTB = new TextBox();
            passwordLabel = new Label();
            passwordTB = new TextBox();
            connectButton = new RoundButton();
            dbInstanceLabel = new Label();
            outsideTablePanel.SuspendLayout();
            logoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)miniLogoBox).BeginInit();
            insideTablePanel.SuspendLayout();
            SuspendLayout();
            // 
            // outsideTablePanel
            // 
            outsideTablePanel.ColumnCount = 3;
            outsideTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            outsideTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            outsideTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            outsideTablePanel.Controls.Add(logoPanel, 2, 0);
            outsideTablePanel.Controls.Add(insideTablePanel, 1, 0);
            outsideTablePanel.Dock = DockStyle.Fill;
            outsideTablePanel.Location = new Point(0, 0);
            outsideTablePanel.Name = "outsideTablePanel";
            outsideTablePanel.RowCount = 1;
            outsideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            outsideTablePanel.Size = new Size(1030, 556);
            outsideTablePanel.TabIndex = 0;
            // 
            // logoPanel
            // 
            logoPanel.Controls.Add(miniLogoBox);
            logoPanel.Dock = DockStyle.Fill;
            logoPanel.Location = new Point(689, 3);
            logoPanel.Name = "logoPanel";
            logoPanel.Size = new Size(338, 550);
            logoPanel.TabIndex = 1;
            // 
            // miniLogoBox
            // 
            miniLogoBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            miniLogoBox.Image = Properties.Resources.OGRIT_Mini_Logo;
            miniLogoBox.Location = new Point(173, 468);
            miniLogoBox.Name = "miniLogoBox";
            miniLogoBox.Size = new Size(162, 79);
            miniLogoBox.SizeMode = PictureBoxSizeMode.CenterImage;
            miniLogoBox.TabIndex = 0;
            miniLogoBox.TabStop = false;
            // 
            // insideTablePanel
            // 
            insideTablePanel.Anchor = AnchorStyles.None;
            insideTablePanel.ColumnCount = 1;
            insideTablePanel.ColumnStyles.Add(new ColumnStyle());
            insideTablePanel.Controls.Add(loginTypeLB, 0, 7);
            insideTablePanel.Controls.Add(portLB, 0, 5);
            insideTablePanel.Controls.Add(serverIPLabel, 0, 1);
            insideTablePanel.Controls.Add(serverTB, 0, 2);
            insideTablePanel.Controls.Add(dbTB, 0, 4);
            insideTablePanel.Controls.Add(portTB, 0, 6);
            insideTablePanel.Controls.Add(logintTypeTB, 0, 8);
            insideTablePanel.Controls.Add(usernameLabel, 0, 9);
            insideTablePanel.Controls.Add(usernameTB, 0, 10);
            insideTablePanel.Controls.Add(passwordLabel, 0, 11);
            insideTablePanel.Controls.Add(passwordTB, 0, 12);
            insideTablePanel.Controls.Add(connectButton, 0, 13);
            insideTablePanel.Controls.Add(dbInstanceLabel, 0, 3);
            insideTablePanel.Location = new Point(346, 3);
            insideTablePanel.Name = "insideTablePanel";
            insideTablePanel.RowCount = 15;
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 7.023705F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 6.836474F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 6.956022F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 6.824421F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 5.99721861F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 5.58361769F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 6.39201927F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 6.76802158F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 5.94558525F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 7.520024F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 6.580021F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 6.39201927F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 6.909248F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 6.909248F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 7.36235666F));
            insideTablePanel.Size = new Size(337, 550);
            insideTablePanel.TabIndex = 0;
            // 
            // loginTypeLB
            // 
            loginTypeLB.Anchor = AnchorStyles.Left;
            loginTypeLB.AutoSize = true;
            loginTypeLB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginTypeLB.Location = new Point(3, 255);
            loginTypeLB.Name = "loginTypeLB";
            loginTypeLB.Size = new Size(146, 20);
            loginTypeLB.TabIndex = 17;
            loginTypeLB.Text = "Authentication Type";
            // 
            // portLB
            // 
            portLB.Anchor = AnchorStyles.Left;
            portLB.AutoSize = true;
            portLB.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            portLB.Location = new Point(3, 187);
            portLB.Name = "portLB";
            portLB.Size = new Size(37, 20);
            portLB.TabIndex = 16;
            portLB.Text = "Port";
            // 
            // serverIPLabel
            // 
            serverIPLabel.Anchor = AnchorStyles.Left;
            serverIPLabel.AutoSize = true;
            serverIPLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            serverIPLabel.Location = new Point(3, 46);
            serverIPLabel.Name = "serverIPLabel";
            serverIPLabel.Size = new Size(135, 20);
            serverIPLabel.TabIndex = 9;
            serverIPLabel.Text = "Server Name or IP";
            // 
            // serverTB
            // 
            serverTB.Dock = DockStyle.Fill;
            serverTB.Location = new Point(5, 78);
            serverTB.Margin = new Padding(5, 3, 5, 3);
            serverTB.Name = "serverTB";
            serverTB.PlaceholderText = "Value";
            serverTB.Size = new Size(327, 27);
            serverTB.TabIndex = 0;
            // 
            // dbTB
            // 
            dbTB.Dock = DockStyle.Fill;
            dbTB.Location = new Point(5, 153);
            dbTB.Margin = new Padding(5, 3, 5, 3);
            dbTB.Name = "dbTB";
            dbTB.PlaceholderText = "Value";
            dbTB.Size = new Size(327, 27);
            dbTB.TabIndex = 4;
            // 
            // portTB
            // 
            portTB.Location = new Point(3, 215);
            portTB.Name = "portTB";
            portTB.Size = new Size(331, 27);
            portTB.TabIndex = 0;
            // 
            // logintTypeTB
            // 
            logintTypeTB.DataSource = resources.GetObject("logintTypeTB.DataSource");
            logintTypeTB.Dock = DockStyle.Fill;
            logintTypeTB.DropDownStyle = ComboBoxStyle.DropDownList;
            logintTypeTB.FormattingEnabled = true;
            logintTypeTB.Location = new Point(3, 287);
            logintTypeTB.Name = "logintTypeTB";
            logintTypeTB.Size = new Size(331, 28);
            logintTypeTB.TabIndex = 15;
            // 
            // usernameLabel
            // 
            usernameLabel.Anchor = AnchorStyles.Left;
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernameLabel.Location = new Point(3, 326);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(78, 20);
            usernameLabel.TabIndex = 12;
            usernameLabel.Text = "Username";
            // 
            // usernameTB
            // 
            usernameTB.Dock = DockStyle.Fill;
            usernameTB.Location = new Point(5, 360);
            usernameTB.Margin = new Padding(5, 3, 5, 3);
            usernameTB.Name = "usernameTB";
            usernameTB.PlaceholderText = "Value";
            usernameTB.Size = new Size(327, 27);
            usernameTB.TabIndex = 6;
            // 
            // passwordLabel
            // 
            passwordLabel.Anchor = AnchorStyles.Left;
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passwordLabel.Location = new Point(3, 400);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(73, 20);
            passwordLabel.TabIndex = 13;
            passwordLabel.Text = "Password";
            // 
            // passwordTB
            // 
            passwordTB.Anchor = AnchorStyles.None;
            passwordTB.Location = new Point(5, 433);
            passwordTB.Margin = new Padding(5, 3, 5, 3);
            passwordTB.Name = "passwordTB";
            passwordTB.PasswordChar = '*';
            passwordTB.PlaceholderText = "Value";
            passwordTB.Size = new Size(327, 27);
            passwordTB.TabIndex = 8;
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
            connectButton.Location = new Point(3, 469);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(331, 32);
            connectButton.TabIndex = 14;
            connectButton.Text = "Connect";
            connectButton.TextColor = Color.LightGray;
            connectButton.UseVisualStyleBackColor = false;
            // 
            // dbInstanceLabel
            // 
            dbInstanceLabel.Anchor = AnchorStyles.Left;
            dbInstanceLabel.AutoSize = true;
            dbInstanceLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dbInstanceLabel.Location = new Point(3, 121);
            dbInstanceLabel.Name = "dbInstanceLabel";
            dbInstanceLabel.Size = new Size(110, 20);
            dbInstanceLabel.TabIndex = 11;
            dbInstanceLabel.Text = "Instance Name";
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(outsideTablePanel);
            Name = "TestForm";
            Size = new Size(1030, 556);
            outsideTablePanel.ResumeLayout(false);
            logoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)miniLogoBox).EndInit();
            insideTablePanel.ResumeLayout(false);
            insideTablePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel outsideTablePanel;
        private TableLayoutPanel insideTablePanel;
        private TextBox serverTB;
        private Panel logoPanel;
        private PictureBox miniLogoBox;
        private Label passwordLabel;
        private Label usernameLabel;
        private Label dbInstanceLabel;
        private TextBox passwordTB;
        private TextBox usernameTB;
        private TextBox dbTB;
        private Label serverIPLabel;
        private ComboBox logintTypeTB;
        private RoundButton connectButton;
        private TextBox portTB;
        private Label portLB;
        private Label loginTypeLB;
    }
}
