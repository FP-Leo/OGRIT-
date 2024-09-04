using OGRIT_Database_Custom_App.Views.Generics;

namespace OGRIT_Database_Custom_App
{
    partial class LogInScreen
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lsOuterPanel = new Panel();
            logoBox = new PictureBox();
            lsTablePanel = new TableLayoutPanel();
            connectButton = new RoundButton();
            LISinputForm = new DbDataInput();
            rememberMeCheckBox = new CheckBox();
            lsOuterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            lsTablePanel.SuspendLayout();
            SuspendLayout();
            // 
            // lsOuterPanel
            // 
            lsOuterPanel.Controls.Add(logoBox);
            lsOuterPanel.Controls.Add(lsTablePanel);
            lsOuterPanel.Dock = DockStyle.Fill;
            lsOuterPanel.Location = new Point(0, 0);
            lsOuterPanel.Name = "lsOuterPanel";
            lsOuterPanel.Size = new Size(1060, 587);
            lsOuterPanel.TabIndex = 1;
            // 
            // logoBox
            // 
            logoBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            logoBox.BackgroundImage = Properties.Resources.OGRIT_Mini_Logo;
            logoBox.BackgroundImageLayout = ImageLayout.Center;
            logoBox.Location = new Point(890, 505);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(154, 68);
            logoBox.TabIndex = 2;
            logoBox.TabStop = false;
            // 
            // lsTablePanel
            // 
            lsTablePanel.Anchor = AnchorStyles.None;
            lsTablePanel.ColumnCount = 1;
            lsTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            lsTablePanel.Controls.Add(connectButton, 0, 2);
            lsTablePanel.Controls.Add(LISinputForm, 0, 0);
            lsTablePanel.Controls.Add(rememberMeCheckBox, 0, 1);
            lsTablePanel.Location = new Point(355, 118);
            lsTablePanel.MinimumSize = new Size(350, 350);
            lsTablePanel.Name = "lsTablePanel";
            lsTablePanel.RowCount = 3;
            lsTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            lsTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            lsTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            lsTablePanel.Size = new Size(350, 350);
            lsTablePanel.TabIndex = 1;
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
            connectButton.Location = new Point(5, 320);
            connectButton.Margin = new Padding(5);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(340, 25);
            connectButton.TabIndex = 6;
            connectButton.Text = "Connect";
            connectButton.TextColor = Color.LightGray;
            connectButton.UseVisualStyleBackColor = false;
            connectButton.Click += LoginButton_Click;
            // 
            // LISinputForm
            // 
            LISinputForm.Dock = DockStyle.Fill;
            LISinputForm.Location = new Point(3, 3);
            LISinputForm.Name = "LISinputForm";
            LISinputForm.Size = new Size(344, 274);
            LISinputForm.TabIndex = 4;
            // 
            // rememberMeCheckBox
            // 
            rememberMeCheckBox.Anchor = AnchorStyles.Left;
            rememberMeCheckBox.AutoSize = true;
            rememberMeCheckBox.Location = new Point(8, 285);
            rememberMeCheckBox.Margin = new Padding(8, 3, 3, 3);
            rememberMeCheckBox.Name = "rememberMeCheckBox";
            rememberMeCheckBox.Size = new Size(129, 24);
            rememberMeCheckBox.TabIndex = 5;
            rememberMeCheckBox.Text = "Remember Me";
            rememberMeCheckBox.UseVisualStyleBackColor = true;
            // 
            // LogInScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lsOuterPanel);
            Name = "LogInScreen";
            Size = new Size(1060, 587);
            Resize += LogInScreen_Resize;
            lsOuterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            lsTablePanel.ResumeLayout(false);
            lsTablePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel lsOuterPanel;
        private PictureBox logoBox;
        private TableLayoutPanel lsTablePanel;
        private DbDataInput LISinputForm;
        private RoundButton connectButton;
        private CheckBox rememberMeCheckBox;
    }
}
