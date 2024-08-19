namespace OGRIT_Database_Custom_App
{
    partial class MenuScreen
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
            menuPanel = new Panel();
            logoBox = new PictureBox();
            menuTablePanel = new TableLayoutPanel();
            menuButtonTablePanel = new TableLayoutPanel();
            executeProcedureButton = new RoundButton();
            viewProcedureButton = new RoundButton();
            connectButton = new RoundButton();
            quitButton = new RoundButton();
            menuLabel = new Label();
            linePanel = new Panel();
            menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            menuTablePanel.SuspendLayout();
            menuButtonTablePanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuPanel
            // 
            menuPanel.Controls.Add(logoBox);
            menuPanel.Controls.Add(menuTablePanel);
            menuPanel.Dock = DockStyle.Fill;
            menuPanel.Location = new Point(0, 0);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(1060, 587);
            menuPanel.TabIndex = 0;
            menuPanel.Resize += MenuScreen_Resize;
            // 
            // logoBox
            // 
            logoBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            logoBox.BackgroundImage = Properties.Resources.OGRIT_Mini_Logo;
            logoBox.BackgroundImageLayout = ImageLayout.Center;
            logoBox.Location = new Point(894, 507);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(154, 68);
            logoBox.TabIndex = 3;
            logoBox.TabStop = false;
            // 
            // menuTablePanel
            // 
            menuTablePanel.Anchor = AnchorStyles.None;
            menuTablePanel.ColumnCount = 1;
            menuTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            menuTablePanel.Controls.Add(menuButtonTablePanel, 0, 3);
            menuTablePanel.Controls.Add(menuLabel, 0, 0);
            menuTablePanel.Controls.Add(linePanel, 0, 1);
            menuTablePanel.Location = new Point(354, 85);
            menuTablePanel.MinimumSize = new Size(400, 400);
            menuTablePanel.Name = "menuTablePanel";
            menuTablePanel.RowCount = 4;
            menuTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            menuTablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 2F));
            menuTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            menuTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            menuTablePanel.Size = new Size(400, 400);
            menuTablePanel.TabIndex = 0;
            // 
            // menuButtonTablePanel
            // 
            menuButtonTablePanel.ColumnCount = 1;
            menuButtonTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            menuButtonTablePanel.Controls.Add(executeProcedureButton, 0, 2);
            menuButtonTablePanel.Controls.Add(viewProcedureButton, 0, 1);
            menuButtonTablePanel.Controls.Add(connectButton, 0, 0);
            menuButtonTablePanel.Controls.Add(quitButton, 0, 3);
            menuButtonTablePanel.Dock = DockStyle.Fill;
            menuButtonTablePanel.Location = new Point(3, 163);
            menuButtonTablePanel.Name = "menuButtonTablePanel";
            menuButtonTablePanel.RowCount = 4;
            menuButtonTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            menuButtonTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            menuButtonTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            menuButtonTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            menuButtonTablePanel.Size = new Size(394, 234);
            menuButtonTablePanel.TabIndex = 2;
            // 
            // executeProcedureButton
            // 
            executeProcedureButton.BackColor = Color.FromArgb(40, 40, 40);
            executeProcedureButton.BackgroundColor = Color.FromArgb(40, 40, 40);
            executeProcedureButton.BorderColor = Color.FromArgb(40, 40, 40);
            executeProcedureButton.BorderRadius = 8;
            executeProcedureButton.BorderSize = 0;
            executeProcedureButton.Dock = DockStyle.Fill;
            executeProcedureButton.FlatAppearance.BorderSize = 0;
            executeProcedureButton.FlatStyle = FlatStyle.Flat;
            executeProcedureButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            executeProcedureButton.ForeColor = Color.LightGray;
            executeProcedureButton.Location = new Point(75, 126);
            executeProcedureButton.Margin = new Padding(75, 10, 75, 10);
            executeProcedureButton.Name = "executeProcedureButton";
            executeProcedureButton.Size = new Size(244, 38);
            executeProcedureButton.TabIndex = 6;
            executeProcedureButton.Text = "Execute Procedures";
            executeProcedureButton.TextColor = Color.LightGray;
            executeProcedureButton.UseVisualStyleBackColor = false;
            executeProcedureButton.Click += executeProcedureButton_Click;
            // 
            // viewProcedureButton
            // 
            viewProcedureButton.BackColor = Color.FromArgb(40, 40, 40);
            viewProcedureButton.BackgroundColor = Color.FromArgb(40, 40, 40);
            viewProcedureButton.BorderColor = Color.FromArgb(40, 40, 40);
            viewProcedureButton.BorderRadius = 8;
            viewProcedureButton.BorderSize = 0;
            viewProcedureButton.Dock = DockStyle.Fill;
            viewProcedureButton.FlatAppearance.BorderSize = 0;
            viewProcedureButton.FlatStyle = FlatStyle.Flat;
            viewProcedureButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewProcedureButton.ForeColor = Color.LightGray;
            viewProcedureButton.Location = new Point(75, 68);
            viewProcedureButton.Margin = new Padding(75, 10, 75, 10);
            viewProcedureButton.Name = "viewProcedureButton";
            viewProcedureButton.Size = new Size(244, 38);
            viewProcedureButton.TabIndex = 5;
            viewProcedureButton.Text = "View Procedure List";
            viewProcedureButton.TextColor = Color.LightGray;
            viewProcedureButton.UseVisualStyleBackColor = false;
            viewProcedureButton.Click += viewProcedureButton_Click;
            // 
            // connectButton
            // 
            connectButton.BackColor = Color.FromArgb(40, 40, 40);
            connectButton.BackgroundColor = Color.FromArgb(40, 40, 40);
            connectButton.BorderColor = Color.FromArgb(40, 40, 40);
            connectButton.BorderRadius = 8;
            connectButton.BorderSize = 0;
            connectButton.Dock = DockStyle.Fill;
            connectButton.FlatAppearance.BorderSize = 0;
            connectButton.FlatStyle = FlatStyle.Flat;
            connectButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            connectButton.ForeColor = Color.LightGray;
            connectButton.Location = new Point(75, 10);
            connectButton.Margin = new Padding(75, 10, 75, 10);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(244, 38);
            connectButton.TabIndex = 4;
            connectButton.Text = "Manage Connection";
            connectButton.TextColor = Color.LightGray;
            connectButton.UseVisualStyleBackColor = false;
            connectButton.Click += ManageConnectionButton_Click;
            // 
            // quitButton
            // 
            quitButton.BackColor = Color.FromArgb(40, 40, 40);
            quitButton.BackgroundColor = Color.FromArgb(40, 40, 40);
            quitButton.BorderColor = Color.PaleVioletRed;
            quitButton.BorderRadius = 8;
            quitButton.BorderSize = 0;
            quitButton.Dock = DockStyle.Fill;
            quitButton.FlatAppearance.BorderSize = 0;
            quitButton.FlatStyle = FlatStyle.Flat;
            quitButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            quitButton.ForeColor = Color.LightGray;
            quitButton.Location = new Point(75, 184);
            quitButton.Margin = new Padding(75, 10, 75, 10);
            quitButton.Name = "quitButton";
            quitButton.Size = new Size(244, 40);
            quitButton.TabIndex = 7;
            quitButton.Text = "Quit";
            quitButton.TextColor = Color.LightGray;
            quitButton.UseVisualStyleBackColor = false;
            quitButton.Click += quitButton_Click;
            // 
            // menuLabel
            // 
            menuLabel.Anchor = AnchorStyles.None;
            menuLabel.AutoSize = true;
            menuLabel.Font = new Font("Century Schoolbook", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuLabel.ForeColor = Color.FromArgb(145, 162, 255);
            menuLabel.Location = new Point(153, 22);
            menuLabel.Name = "menuLabel";
            menuLabel.Size = new Size(94, 35);
            menuLabel.TabIndex = 0;
            menuLabel.Text = "Menu";
            // 
            // linePanel
            // 
            linePanel.BackColor = Color.FromArgb(240, 240, 240);
            linePanel.Dock = DockStyle.Fill;
            linePanel.Location = new Point(0, 79);
            linePanel.Margin = new Padding(0);
            linePanel.Name = "linePanel";
            linePanel.Size = new Size(400, 2);
            linePanel.TabIndex = 1;
            // 
            // MenuScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(menuPanel);
            Name = "MenuScreen";
            Size = new Size(1060, 587);
            menuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            menuTablePanel.ResumeLayout(false);
            menuTablePanel.PerformLayout();
            menuButtonTablePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel menuPanel;
        private TableLayoutPanel menuTablePanel;
        private Label menuLabel;
        private PictureBox logoBox;
        private TableLayoutPanel menuButtonTablePanel;
        private RoundButton executeProcedureButton;
        private RoundButton viewProcedureButton;
        private RoundButton connectButton;
        private Panel linePanel;
        private RoundButton quitButton;
    }
}
