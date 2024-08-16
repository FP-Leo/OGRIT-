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
            innerTableLayout = new TableLayoutPanel();
            LogInInputFormTableLayout = new TableLayoutPanel();
            LSinputForm = new inputForm();
            connectButton = new RoundButton();
            logoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)miniLogoBox).BeginInit();
            outerTablePanel.SuspendLayout();
            innerTableLayout.SuspendLayout();
            LogInInputFormTableLayout.SuspendLayout();
            SuspendLayout();
            // 
            // logoPanel
            // 
            logoPanel.Controls.Add(miniLogoBox);
            logoPanel.Dock = DockStyle.Fill;
            logoPanel.Location = new Point(667, 3);
            logoPanel.Name = "logoPanel";
            logoPanel.Size = new Size(327, 485);
            logoPanel.TabIndex = 1;
            // 
            // miniLogoBox
            // 
            miniLogoBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            miniLogoBox.Image = Properties.Resources.OGRIT_Mini_Logo;
            miniLogoBox.Location = new Point(162, 403);
            miniLogoBox.Name = "miniLogoBox";
            miniLogoBox.Size = new Size(162, 79);
            miniLogoBox.SizeMode = PictureBoxSizeMode.CenterImage;
            miniLogoBox.TabIndex = 0;
            miniLogoBox.TabStop = false;
            // 
            // outerTablePanel
            // 
            outerTablePanel.ColumnCount = 3;
            outerTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            outerTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            outerTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            outerTablePanel.Controls.Add(logoPanel, 2, 0);
            outerTablePanel.Controls.Add(innerTableLayout, 1, 0);
            outerTablePanel.Dock = DockStyle.Fill;
            outerTablePanel.Location = new Point(0, 0);
            outerTablePanel.Name = "outerTablePanel";
            outerTablePanel.RowCount = 1;
            outerTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            outerTablePanel.Size = new Size(997, 491);
            outerTablePanel.TabIndex = 0;
            // 
            // innerTableLayout
            // 
            innerTableLayout.ColumnCount = 1;
            innerTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            innerTableLayout.Controls.Add(LogInInputFormTableLayout, 0, 1);
            innerTableLayout.Dock = DockStyle.Fill;
            innerTableLayout.Location = new Point(335, 3);
            innerTableLayout.Name = "innerTableLayout";
            innerTableLayout.RowCount = 3;
            innerTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            innerTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            innerTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            innerTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            innerTableLayout.Size = new Size(326, 485);
            innerTableLayout.TabIndex = 2;
            // 
            // LogInInputFormTableLayout
            // 
            LogInInputFormTableLayout.Anchor = AnchorStyles.None;
            LogInInputFormTableLayout.ColumnCount = 1;
            LogInInputFormTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            LogInInputFormTableLayout.Controls.Add(LSinputForm, 0, 0);
            LogInInputFormTableLayout.Controls.Add(connectButton, 0, 1);
            LogInInputFormTableLayout.Location = new Point(3, 27);
            LogInInputFormTableLayout.MaximumSize = new Size(400, 800);
            LogInInputFormTableLayout.MinimumSize = new Size(320, 430);
            LogInInputFormTableLayout.Name = "LogInInputFormTableLayout";
            LogInInputFormTableLayout.RowCount = 2;
            LogInInputFormTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            LogInInputFormTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            LogInInputFormTableLayout.Size = new Size(320, 430);
            LogInInputFormTableLayout.TabIndex = 0;
            // 
            // LSinputForm
            // 
            LSinputForm.Dock = DockStyle.Fill;
            LSinputForm.Location = new Point(3, 3);
            LSinputForm.Name = "LSinputForm";
            LSinputForm.Size = new Size(314, 381);
            LSinputForm.TabIndex = 0;
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
            connectButton.Location = new Point(3, 390);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(314, 37);
            connectButton.TabIndex = 1;
            connectButton.Text = "Connect";
            connectButton.TextColor = Color.LightGray;
            connectButton.UseVisualStyleBackColor = false;
            connectButton.Click += LoginButton_Click;
            // 
            // LogInScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(outerTablePanel);
            MinimumSize = new Size(995, 490);
            Name = "LogInScreen";
            Size = new Size(997, 491);
            logoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)miniLogoBox).EndInit();
            outerTablePanel.ResumeLayout(false);
            innerTableLayout.ResumeLayout(false);
            LogInInputFormTableLayout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel logoPanel;
        private PictureBox miniLogoBox;

        private TableLayoutPanel outerTablePanel;
        private TableLayoutPanel innerTableLayout;
        private TableLayoutPanel LogInInputFormTableLayout;
        private inputForm LSinputForm;
        private RoundButton connectButton;
    }
}