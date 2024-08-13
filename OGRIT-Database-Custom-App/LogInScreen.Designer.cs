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
            logoPanel = new Panel();
            miniLogoBox = new PictureBox();
            outerTablePanel = new TableLayoutPanel();
            logoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)miniLogoBox).BeginInit();
            outerTablePanel.SuspendLayout();
            SuspendLayout();
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
            // outsideTablePanel
            // 
            outerTablePanel.ColumnCount = 3;
            outerTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            outerTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            outerTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            outerTablePanel.Controls.Add(logoPanel, 2, 0);
            outerTablePanel.Dock = DockStyle.Fill;
            outerTablePanel.Location = new Point(0, 0);
            outerTablePanel.Name = "outsideTablePanel";
            outerTablePanel.RowCount = 1;
            outerTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            outerTablePanel.Size = new Size(1030, 556);
            outerTablePanel.TabIndex = 0;
            // 
            // LogInScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(outerTablePanel);
            Name = "LogInScreen";
            Size = new Size(1030, 556);
            logoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)miniLogoBox).EndInit();
            outerTablePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel innerTablePanel;
        private TextBox serverTB;
        private Label passwordLabel;
        private Label usernameLabel;
        private Label dbInstanceLabel;
        private TextBox passwordTB;
        private TextBox usernameTB;
        private TextBox dbTB;
        private Label serverIPLabel;
        private RoundButton connectButton;
        private ComboBox authCB;
        private TextBox portTB;
        private Label portLabel;
        private Panel logoPanel;
        private PictureBox miniLogoBox;
        private TableLayoutPanel outerTablePanel;
        private Label authLabel;
        
    }
}