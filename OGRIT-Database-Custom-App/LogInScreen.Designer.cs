namespace OGRIT_Database_Custom_App
{
    partial class LogInScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            passwordLabel = new Label();
            usernameLabel = new Label();
            dbInstanceLabel = new Label();
            passwordTB = new TextBox();
            usernameTB = new TextBox();
            dbTB = new TextBox();
            serverTB = new TextBox();
            dbLabel = new Label();
            panel1 = new Panel();
            miniLogoBox = new PictureBox();
            roundButton1 = new RoundButton();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)miniLogoBox).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Controls.Add(panel1, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(830, 452);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(passwordLabel, 0, 7);
            tableLayoutPanel2.Controls.Add(usernameLabel, 0, 5);
            tableLayoutPanel2.Controls.Add(dbInstanceLabel, 0, 3);
            tableLayoutPanel2.Controls.Add(passwordTB, 0, 8);
            tableLayoutPanel2.Controls.Add(usernameTB, 0, 6);
            tableLayoutPanel2.Controls.Add(dbTB, 0, 4);
            tableLayoutPanel2.Controls.Add(serverTB, 0, 2);
            tableLayoutPanel2.Controls.Add(dbLabel, 0, 1);
            tableLayoutPanel2.Controls.Add(roundButton1, 0, 9);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(279, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 11;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            tableLayoutPanel2.Size = new Size(270, 446);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // passwordLabel
            // 
            passwordLabel.Anchor = AnchorStyles.Left;
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passwordLabel.Location = new Point(3, 290);
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
            usernameLabel.Location = new Point(3, 210);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(78, 20);
            usernameLabel.TabIndex = 12;
            usernameLabel.Text = "Username";
            // 
            // dbInstanceLabel
            // 
            dbInstanceLabel.Anchor = AnchorStyles.Left;
            dbInstanceLabel.AutoSize = true;
            dbInstanceLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dbInstanceLabel.Location = new Point(3, 130);
            dbInstanceLabel.Name = "dbInstanceLabel";
            dbInstanceLabel.Size = new Size(132, 20);
            dbInstanceLabel.TabIndex = 11;
            dbInstanceLabel.Text = "Database Instance";
            // 
            // passwordTB
            // 
            passwordTB.Dock = DockStyle.Fill;
            passwordTB.Location = new Point(5, 323);
            passwordTB.Margin = new Padding(5, 3, 5, 3);
            passwordTB.Name = "passwordTB";
            passwordTB.PasswordChar = '*';
            passwordTB.PlaceholderText = "Value";
            passwordTB.Size = new Size(260, 27);
            passwordTB.TabIndex = 8;
            // 
            // usernameTB
            // 
            usernameTB.Dock = DockStyle.Fill;
            usernameTB.Location = new Point(5, 243);
            usernameTB.Margin = new Padding(5, 3, 5, 3);
            usernameTB.Name = "usernameTB";
            usernameTB.PlaceholderText = "Value";
            usernameTB.Size = new Size(260, 27);
            usernameTB.TabIndex = 6;
            // 
            // dbTB
            // 
            dbTB.Dock = DockStyle.Fill;
            dbTB.Location = new Point(5, 163);
            dbTB.Margin = new Padding(5, 3, 5, 3);
            dbTB.Name = "dbTB";
            dbTB.PlaceholderText = "Value";
            dbTB.Size = new Size(260, 27);
            dbTB.TabIndex = 4;
            // 
            // serverTB
            // 
            serverTB.Dock = DockStyle.Fill;
            serverTB.Location = new Point(5, 83);
            serverTB.Margin = new Padding(5, 3, 5, 3);
            serverTB.Name = "serverTB";
            serverTB.PlaceholderText = "Value";
            serverTB.Size = new Size(260, 27);
            serverTB.TabIndex = 0;
            // 
            // dbLabel
            // 
            dbLabel.Anchor = AnchorStyles.Left;
            dbLabel.AutoSize = true;
            dbLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dbLabel.Location = new Point(3, 50);
            dbLabel.Name = "dbLabel";
            dbLabel.Size = new Size(89, 20);
            dbLabel.TabIndex = 9;
            dbLabel.Text = "Database IP";
            // 
            // panel1
            // 
            panel1.Controls.Add(miniLogoBox);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(555, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(272, 446);
            panel1.TabIndex = 1;
            // 
            // miniLogoBox
            // 
            miniLogoBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            miniLogoBox.Image = Properties.Resources.OGRIT_Mini_Logo;
            miniLogoBox.Location = new Point(107, 364);
            miniLogoBox.Name = "miniLogoBox";
            miniLogoBox.Size = new Size(162, 79);
            miniLogoBox.SizeMode = PictureBoxSizeMode.CenterImage;
            miniLogoBox.TabIndex = 0;
            miniLogoBox.TabStop = false;
            // 
            // roundButton1
            // 
            roundButton1.BackColor = Color.FromArgb(40, 40, 40);
            roundButton1.BackgroundColor = Color.FromArgb(40, 40, 40);
            roundButton1.BorderColor = Color.FromArgb(40, 40, 40);
            roundButton1.BorderRadius = 7;
            roundButton1.BorderSize = 0;
            roundButton1.Dock = DockStyle.Fill;
            roundButton1.FlatAppearance.BorderSize = 0;
            roundButton1.FlatStyle = FlatStyle.Flat;
            roundButton1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roundButton1.ForeColor = Color.LightGray;
            roundButton1.Location = new Point(3, 363);
            roundButton1.Name = "roundButton1";
            roundButton1.Size = new Size(264, 34);
            roundButton1.TabIndex = 14;
            roundButton1.Text = "Connect";
            roundButton1.TextColor = Color.LightGray;
            roundButton1.UseVisualStyleBackColor = false;
            roundButton1.Click += LoginButton_Click;
            // 
            // LogInScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "LogInScreen";
            Size = new Size(830, 452);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)miniLogoBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox serverTB;
        private Panel panel1;
        private PictureBox miniLogoBox;
        private Label passwordLabel;
        private Label usernameLabel;
        private Label dbInstanceLabel;
        private TextBox passwordTB;
        private TextBox usernameTB;
        private TextBox dbTB;
        private Label dbLabel;
        private RoundButton roundButton1;
    }
}