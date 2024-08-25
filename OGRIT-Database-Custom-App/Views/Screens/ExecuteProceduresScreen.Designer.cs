namespace OGRIT_Database_Custom_App.Views.Screens
{
    partial class ExecuteProceduresScreen
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
            epOuterTablePanel = new TableLayoutPanel();
            epGridTablePanel = new TableLayoutPanel();
            epCSsListBox = new ListBox();
            epSPsListBox = new ListBox();
            epExecuteTableLayout = new TableLayoutPanel();
            executeButton = new Generics.RoundButton();
            epMenuTableLayout = new TableLayoutPanel();
            epMenuButton = new Generics.RoundButton();
            logoPanel = new Panel();
            logoBox = new PictureBox();
            epOuterTablePanel.SuspendLayout();
            epGridTablePanel.SuspendLayout();
            epExecuteTableLayout.SuspendLayout();
            epMenuTableLayout.SuspendLayout();
            logoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // epOuterTablePanel
            // 
            epOuterTablePanel.ColumnCount = 1;
            epOuterTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            epOuterTablePanel.Controls.Add(epGridTablePanel, 0, 1);
            epOuterTablePanel.Controls.Add(epExecuteTableLayout, 0, 2);
            epOuterTablePanel.Controls.Add(epMenuTableLayout, 0, 0);
            epOuterTablePanel.Controls.Add(logoPanel, 0, 3);
            epOuterTablePanel.Dock = DockStyle.Fill;
            epOuterTablePanel.Location = new Point(0, 0);
            epOuterTablePanel.Name = "epOuterTablePanel";
            epOuterTablePanel.RowCount = 4;
            epOuterTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            epOuterTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
            epOuterTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            epOuterTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            epOuterTablePanel.Size = new Size(1060, 587);
            epOuterTablePanel.TabIndex = 0;
            // 
            // epGridTablePanel
            // 
            epGridTablePanel.ColumnCount = 4;
            epGridTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.5F));
            epGridTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.5F));
            epGridTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.5F));
            epGridTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.5F));
            epGridTablePanel.Controls.Add(epCSsListBox, 2, 0);
            epGridTablePanel.Controls.Add(epSPsListBox, 1, 0);
            epGridTablePanel.Dock = DockStyle.Fill;
            epGridTablePanel.Location = new Point(3, 61);
            epGridTablePanel.Name = "epGridTablePanel";
            epGridTablePanel.RowCount = 1;
            epGridTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            epGridTablePanel.Size = new Size(1054, 375);
            epGridTablePanel.TabIndex = 2;
            // 
            // epCSsListBox
            // 
            epCSsListBox.Dock = DockStyle.Fill;
            epCSsListBox.FormattingEnabled = true;
            epCSsListBox.Location = new Point(536, 10);
            epCSsListBox.Margin = new Padding(10);
            epCSsListBox.Name = "epCSsListBox";
            epCSsListBox.SelectionMode = SelectionMode.MultiSimple;
            epCSsListBox.Size = new Size(427, 355);
            epCSsListBox.TabIndex = 5;
            // 
            // epSPsListBox
            // 
            epSPsListBox.Dock = DockStyle.Fill;
            epSPsListBox.FormattingEnabled = true;
            epSPsListBox.Location = new Point(89, 10);
            epSPsListBox.Margin = new Padding(10);
            epSPsListBox.Name = "epSPsListBox";
            epSPsListBox.SelectionMode = SelectionMode.MultiSimple;
            epSPsListBox.Size = new Size(427, 355);
            epSPsListBox.TabIndex = 3;
            // 
            // epExecuteTableLayout
            // 
            epExecuteTableLayout.ColumnCount = 3;
            epExecuteTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            epExecuteTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            epExecuteTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            epExecuteTableLayout.Controls.Add(executeButton, 1, 0);
            epExecuteTableLayout.Dock = DockStyle.Fill;
            epExecuteTableLayout.Location = new Point(3, 442);
            epExecuteTableLayout.Name = "epExecuteTableLayout";
            epExecuteTableLayout.RowCount = 1;
            epExecuteTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            epExecuteTableLayout.Size = new Size(1054, 52);
            epExecuteTableLayout.TabIndex = 3;
            // 
            // executeButton
            // 
            executeButton.BackColor = Color.FromArgb(40, 40, 40);
            executeButton.BackgroundColor = Color.FromArgb(40, 40, 40);
            executeButton.BorderColor = Color.FromArgb(40, 40, 40);
            executeButton.BorderRadius = 7;
            executeButton.BorderSize = 0;
            executeButton.Dock = DockStyle.Fill;
            executeButton.FlatAppearance.BorderSize = 0;
            executeButton.FlatStyle = FlatStyle.Flat;
            executeButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            executeButton.ForeColor = Color.White;
            executeButton.Location = new Point(479, 5);
            executeButton.Margin = new Padding(5);
            executeButton.Name = "executeButton";
            executeButton.Size = new Size(95, 42);
            executeButton.TabIndex = 0;
            executeButton.Text = "Execute";
            executeButton.TextColor = Color.White;
            executeButton.UseVisualStyleBackColor = false;
            // 
            // epMenuTableLayout
            // 
            epMenuTableLayout.ColumnCount = 2;
            epMenuTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.5F));
            epMenuTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 92.5F));
            epMenuTableLayout.Controls.Add(epMenuButton, 0, 0);
            epMenuTableLayout.Dock = DockStyle.Fill;
            epMenuTableLayout.Location = new Point(3, 3);
            epMenuTableLayout.Name = "epMenuTableLayout";
            epMenuTableLayout.RowCount = 1;
            epMenuTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            epMenuTableLayout.Size = new Size(1054, 52);
            epMenuTableLayout.TabIndex = 4;
            // 
            // epMenuButton
            // 
            epMenuButton.BackColor = Color.FromArgb(40, 40, 40);
            epMenuButton.BackgroundColor = Color.FromArgb(40, 40, 40);
            epMenuButton.BorderColor = Color.FromArgb(40, 40, 40);
            epMenuButton.BorderRadius = 7;
            epMenuButton.BorderSize = 0;
            epMenuButton.Dock = DockStyle.Fill;
            epMenuButton.FlatAppearance.BorderSize = 0;
            epMenuButton.FlatStyle = FlatStyle.Flat;
            epMenuButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            epMenuButton.ForeColor = Color.White;
            epMenuButton.Location = new Point(5, 10);
            epMenuButton.Margin = new Padding(5, 10, 5, 10);
            epMenuButton.Name = "epMenuButton";
            epMenuButton.Size = new Size(69, 32);
            epMenuButton.TabIndex = 2;
            epMenuButton.Text = "Menu";
            epMenuButton.TextColor = Color.White;
            epMenuButton.UseVisualStyleBackColor = false;
            epMenuButton.Click += epMenuButton_Click;
            // 
            // logoPanel
            // 
            logoPanel.Controls.Add(logoBox);
            logoPanel.Dock = DockStyle.Fill;
            logoPanel.Location = new Point(3, 500);
            logoPanel.Name = "logoPanel";
            logoPanel.Size = new Size(1054, 84);
            logoPanel.TabIndex = 5;
            // 
            // logoBox
            // 
            logoBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            logoBox.BackgroundImage = Properties.Resources.OGRIT_Mini_Logo;
            logoBox.BackgroundImageLayout = ImageLayout.Center;
            logoBox.Location = new Point(890, 12);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(154, 64);
            logoBox.TabIndex = 4;
            logoBox.TabStop = false;
            // 
            // ExecuteProceduresScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(epOuterTablePanel);
            Name = "ExecuteProceduresScreen";
            Size = new Size(1060, 587);
            Load += ExecuteProceduresScreen_Load;
            epOuterTablePanel.ResumeLayout(false);
            epGridTablePanel.ResumeLayout(false);
            epExecuteTableLayout.ResumeLayout(false);
            epMenuTableLayout.ResumeLayout(false);
            logoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel epOuterTablePanel;
        private TableLayoutPanel epGridTablePanel;
        private TableLayoutPanel epExecuteTableLayout;
        private Generics.RoundButton executeButton;
        private TableLayoutPanel epMenuTableLayout;
        private Generics.RoundButton epMenuButton;
        private Panel logoPanel;
        private PictureBox logoBox;
        private ListBox epCSsListBox;
        private ListBox epSPsListBox;
    }
}
