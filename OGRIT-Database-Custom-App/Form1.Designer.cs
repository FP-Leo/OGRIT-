namespace OGRIT_Database_Custom_App
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            companyNameLabel = new Label();
            AppDescriptionLabel = new Label();
            ContinueButton = new Button();
            backButton = new Button();
            passwordTB = new TextBox();
            usernameTB = new TextBox();
            dbInstanceTB = new TextBox();
            serverIPTB = new TextBox();
            serverIPLabel = new Label();
            dbInstanceLabel = new Label();
            usernameLabel = new Label();
            passwordLabel = new Label();
            loginButton = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // companyNameLabel
            // 
            companyNameLabel.AutoSize = true;
            companyNameLabel.Font = new Font("Verdana", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            companyNameLabel.Location = new Point(256, 117);
            companyNameLabel.Name = "companyNameLabel";
            companyNameLabel.Size = new Size(306, 97);
            companyNameLabel.TabIndex = 0;
            companyNameLabel.Text = "OGRIT";
            companyNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AppDescriptionLabel
            // 
            AppDescriptionLabel.AutoSize = true;
            AppDescriptionLabel.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            AppDescriptionLabel.Location = new Point(129, 214);
            AppDescriptionLabel.Name = "AppDescriptionLabel";
            AppDescriptionLabel.Size = new Size(562, 54);
            AppDescriptionLabel.TabIndex = 1;
            AppDescriptionLabel.Text = "Custom Database Application";
            AppDescriptionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ContinueButton
            // 
            ContinueButton.Location = new Point(316, 307);
            ContinueButton.Name = "ContinueButton";
            ContinueButton.Size = new Size(195, 57);
            ContinueButton.TabIndex = 2;
            ContinueButton.Text = "Continue";
            ContinueButton.UseVisualStyleBackColor = true;
            ContinueButton.Click += ContinueButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(12, 12);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 3;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Visible = false;
            backButton.Click += BackButton_Click;
            // 
            // passwordTB
            // 
            passwordTB.Location = new Point(316, 267);
            passwordTB.Name = "passwordTB";
            passwordTB.Size = new Size(195, 27);
            passwordTB.TabIndex = 4;
            passwordTB.Visible = false;
            // 
            // usernameTB
            // 
            usernameTB.Location = new Point(316, 214);
            usernameTB.Name = "usernameTB";
            usernameTB.Size = new Size(195, 27);
            usernameTB.TabIndex = 5;
            usernameTB.Visible = false;
            // 
            // dbInstanceTB
            // 
            dbInstanceTB.Location = new Point(316, 161);
            dbInstanceTB.Name = "dbInstanceTB";
            dbInstanceTB.Size = new Size(195, 27);
            dbInstanceTB.TabIndex = 6;
            dbInstanceTB.Visible = false;
            // 
            // serverIPTB
            // 
            serverIPTB.Location = new Point(316, 108);
            serverIPTB.Name = "serverIPTB";
            serverIPTB.Size = new Size(195, 27);
            serverIPTB.TabIndex = 7;
            serverIPTB.Visible = false;
            // 
            // serverIPLabel
            // 
            serverIPLabel.AutoSize = true;
            serverIPLabel.Location = new Point(316, 85);
            serverIPLabel.Name = "serverIPLabel";
            serverIPLabel.Size = new Size(88, 20);
            serverIPLabel.TabIndex = 8;
            serverIPLabel.Text = "Database IP";
            serverIPLabel.Visible = false;
            // 
            // dbInstanceLabel
            // 
            dbInstanceLabel.AutoSize = true;
            dbInstanceLabel.Location = new Point(316, 135);
            dbInstanceLabel.Name = "dbInstanceLabel";
            dbInstanceLabel.Size = new Size(130, 20);
            dbInstanceLabel.TabIndex = 9;
            dbInstanceLabel.Text = "Database Instance";
            dbInstanceLabel.Visible = false;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(316, 194);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(75, 20);
            usernameLabel.TabIndex = 10;
            usernameLabel.Text = "Username";
            usernameLabel.Visible = false;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(316, 241);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(70, 20);
            passwordLabel.TabIndex = 11;
            passwordLabel.Text = "Password";
            passwordLabel.UseMnemonic = false;
            passwordLabel.Visible = false;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(316, 307);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(195, 57);
            loginButton.TabIndex = 12;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Visible = false;
            loginButton.Click += LoginButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(550, 280);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(238, 171);
            dataGridView1.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(loginButton);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(dbInstanceLabel);
            Controls.Add(serverIPLabel);
            Controls.Add(serverIPTB);
            Controls.Add(dbInstanceTB);
            Controls.Add(usernameTB);
            Controls.Add(passwordTB);
            Controls.Add(backButton);
            Controls.Add(ContinueButton);
            Controls.Add(AppDescriptionLabel);
            Controls.Add(companyNameLabel);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label companyNameLabel;
        private Label AppDescriptionLabel;
        private Button ContinueButton;
        private Button backButton;
        private TextBox passwordTB;
        private TextBox usernameTB;
        private TextBox dbInstanceTB;
        private TextBox serverIPTB;
        private Label serverIPLabel;
        private Label dbInstanceLabel;
        private Label usernameLabel;
        private Label passwordLabel;
        private Button loginButton;
        private DataGridView dataGridView1;
    }
}
