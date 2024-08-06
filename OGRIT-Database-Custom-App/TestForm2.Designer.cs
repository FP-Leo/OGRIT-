namespace OGRIT_Database_Custom_App
{
    partial class TestForm2
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
            outsideTablePanel = new TableLayoutPanel();
            logoPanel = new Panel();
            miniLogoBox = new PictureBox();
            panel1 = new Panel();
            insideTablePanel = new TableLayoutPanel();
            serverIPLabel = new Label();
            serverTB = new TextBox();
            dbInstanceLabel = new Label();
            dbTB = new TextBox();
            loginCB = new ComboBox();
            connectButton = new RoundButton();
            outsideTablePanel.SuspendLayout();
            logoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)miniLogoBox).BeginInit();
            panel1.SuspendLayout();
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
            outsideTablePanel.Controls.Add(panel1, 1, 0);
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
            // panel1
            // 
            panel1.Controls.Add(insideTablePanel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(346, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(337, 550);
            panel1.TabIndex = 2;
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
            insideTablePanel.Controls.Add(connectButton, 0, 6);
            insideTablePanel.Dock = DockStyle.Fill;
            insideTablePanel.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            insideTablePanel.Location = new Point(0, 0);
            insideTablePanel.MaximumSize = new Size(350, 550);
            insideTablePanel.Name = "insideTablePanel";
            insideTablePanel.RowCount = 8;
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 17.3914928F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10.8702259F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10.8702259F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10.8702259F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10.8702259F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10.8702259F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10.8658781F));
            insideTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 17.3914928F));
            insideTablePanel.Size = new Size(337, 550);
            insideTablePanel.TabIndex = 1;
            // 
            // serverIPLabel
            // 
            serverIPLabel.Anchor = AnchorStyles.Left;
            serverIPLabel.AutoSize = true;
            serverIPLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            serverIPLabel.Location = new Point(3, 114);
            serverIPLabel.Name = "serverIPLabel";
            serverIPLabel.Size = new Size(135, 20);
            serverIPLabel.TabIndex = 9;
            serverIPLabel.Text = "Server Name or IP";
            // 
            // serverTB
            // 
            serverTB.Anchor = AnchorStyles.Left;
            serverTB.Location = new Point(5, 170);
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
            dbInstanceLabel.Location = new Point(3, 232);
            dbInstanceLabel.Name = "dbInstanceLabel";
            dbInstanceLabel.Size = new Size(110, 20);
            dbInstanceLabel.TabIndex = 11;
            dbInstanceLabel.Text = "Instance Name";
            // 
            // dbTB
            // 
            dbTB.Anchor = AnchorStyles.Left;
            dbTB.Location = new Point(5, 288);
            dbTB.Margin = new Padding(5, 3, 5, 3);
            dbTB.Name = "dbTB";
            dbTB.PlaceholderText = "Value";
            dbTB.Size = new Size(327, 27);
            dbTB.TabIndex = 4;
            // 
            // loginCB
            // 
            loginCB.Dock = DockStyle.Fill;
            loginCB.DropDownStyle = ComboBoxStyle.DropDownList;
            loginCB.FormattingEnabled = true;
            loginCB.Location = new Point(3, 334);
            loginCB.Name = "loginCB";
            loginCB.Size = new Size(331, 28);
            loginCB.TabIndex = 15;
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
            connectButton.Location = new Point(3, 393);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(331, 53);
            connectButton.TabIndex = 14;
            connectButton.Text = "Connect";
            connectButton.TextColor = Color.LightGray;
            connectButton.UseVisualStyleBackColor = false;
            // 
            // TestForm2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(outsideTablePanel);
            Name = "TestForm2";
            Size = new Size(1030, 556);
            outsideTablePanel.ResumeLayout(false);
            logoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)miniLogoBox).EndInit();
            panel1.ResumeLayout(false);
            insideTablePanel.ResumeLayout(false);
            insideTablePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel outsideTablePanel;
        private Panel logoPanel;
        private PictureBox miniLogoBox;
        private Panel panel1;
        private TableLayoutPanel insideTablePanel;
        private Label serverIPLabel;
        private TextBox serverTB;
        private Label dbInstanceLabel;
        private TextBox dbTB;
        private ComboBox loginCB;
        private RoundButton connectButton;
    }
}
