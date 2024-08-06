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
            serverIPLabel = new Label();
            serverTB = new TextBox();
            dbInstanceLabel = new Label();
            dbTB = new TextBox();
            loginCB = new ComboBox();
            usernameLabel = new Label();
            usernameTB = new TextBox();
            passwordLabel = new Label();
            passwordTB = new TextBox();
            connectButton = new RoundButton();
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
            insideTablePanel.ColumnCount = 1;
            insideTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            insideTablePanel.Controls.Add(serverIPLabel, 0, 1);
            insideTablePanel.Controls.Add(serverTB, 0, 2);
            insideTablePanel.Controls.Add(dbInstanceLabel, 0, 3);
            insideTablePanel.Controls.Add(dbTB, 0, 4);
            insideTablePanel.Controls.Add(loginCB, 0, 5);
            insideTablePanel.Controls.Add(usernameLabel, 0, 6);
            insideTablePanel.Controls.Add(usernameTB, 0, 7);
            insideTablePanel.Controls.Add(passwordLabel, 0, 8);
            insideTablePanel.Controls.Add(passwordTB, 0, 9);
            insideTablePanel.Controls.Add(connectButton, 0, 10);
            insideTablePanel.Dock = DockStyle.Fill;
            insideTablePanel.Location = new Point(346, 3);
            insideTablePanel.Name = "insideTablePanel";
            insideTablePanel.RowCount = 12;
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 13.69593F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 7.261394F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 7.261394F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 7.261394F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 7.261394F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 7.261394F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 7.261394F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 7.261394F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 7.261394F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 7.25848961F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 7.25848961F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 13.6959343F));
            insideTablePanel.Size = new Size(337, 550);
            insideTablePanel.TabIndex = 0;
            // 
            // serverIPLabel
            // 
            serverIPLabel.Anchor = AnchorStyles.Left;
            serverIPLabel.AutoSize = true;
            serverIPLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            serverIPLabel.Location = new Point(3, 84);
            serverIPLabel.Name = "serverIPLabel";
            serverIPLabel.Size = new Size(135, 20);
            serverIPLabel.TabIndex = 9;
            serverIPLabel.Text = "Server Name or IP";
            // 
            // serverTB
            // 
            serverTB.Dock = DockStyle.Fill;
            serverTB.Location = new Point(5, 117);
            serverTB.Margin = new Padding(5, 3, 5, 3);
            serverTB.Name = "serverTB";
            serverTB.PlaceholderText = "Value";
            serverTB.Size = new Size(327, 27);
            serverTB.TabIndex = 0;
            // 
            // dbInstanceLabel
            // 
            dbInstanceLabel.Anchor = AnchorStyles.Left;
            dbInstanceLabel.AutoSize = true;
            dbInstanceLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dbInstanceLabel.Location = new Point(3, 162);
            dbInstanceLabel.Name = "dbInstanceLabel";
            dbInstanceLabel.Size = new Size(110, 20);
            dbInstanceLabel.TabIndex = 11;
            dbInstanceLabel.Text = "Instance Name";
            // 
            // dbTB
            // 
            dbTB.Dock = DockStyle.Fill;
            dbTB.Location = new Point(5, 195);
            dbTB.Margin = new Padding(5, 3, 5, 3);
            dbTB.Name = "dbTB";
            dbTB.PlaceholderText = "Value";
            dbTB.Size = new Size(327, 27);
            dbTB.TabIndex = 4;
            // 
            // loginCB
            // 
            loginCB.Anchor = AnchorStyles.Left;
            loginCB.DataSource = resources.GetObject("loginCB.DataSource");
            loginCB.DropDownStyle = ComboBoxStyle.DropDownList;
            loginCB.FormattingEnabled = true;
            loginCB.Location = new Point(3, 236);
            loginCB.Name = "loginCB";
            loginCB.Size = new Size(330, 28);
            loginCB.TabIndex = 15;
            // 
            // usernameLabel
            // 
            usernameLabel.Anchor = AnchorStyles.Left;
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernameLabel.Location = new Point(3, 279);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(78, 20);
            usernameLabel.TabIndex = 12;
            usernameLabel.Text = "Username";
            // 
            // usernameTB
            // 
            usernameTB.Dock = DockStyle.Fill;
            usernameTB.Location = new Point(5, 312);
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
            passwordLabel.Location = new Point(3, 357);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(73, 20);
            passwordLabel.TabIndex = 13;
            passwordLabel.Text = "Password";
            // 
            // passwordTB
            // 
            passwordTB.Dock = DockStyle.Fill;
            passwordTB.Location = new Point(5, 390);
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
            connectButton.Location = new Point(3, 429);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(331, 33);
            connectButton.TabIndex = 14;
            connectButton.Text = "Connect";
            connectButton.TextColor = Color.LightGray;
            connectButton.UseVisualStyleBackColor = false;
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
        private ComboBox loginCB;
        private RoundButton connectButton;
    }
}
