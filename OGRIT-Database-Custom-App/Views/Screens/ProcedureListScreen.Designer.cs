namespace OGRIT_Database_Custom_App.Views.Screens
{
    partial class ProcedureListScreen
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
            spTablePanel = new TableLayoutPanel();
            spButtonTablePanel = new TableLayoutPanel();
            spMenuButton = new Generics.RoundButton();
            spGridTablePanel = new TableLayoutPanel();
            spProcedureGrid = new DataGridView();
            logoPanel = new Panel();
            logoBox = new PictureBox();
            spTablePanel.SuspendLayout();
            spButtonTablePanel.SuspendLayout();
            spGridTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spProcedureGrid).BeginInit();
            logoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // spTablePanel
            // 
            spTablePanel.ColumnCount = 1;
            spTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            spTablePanel.Controls.Add(spButtonTablePanel, 0, 2);
            spTablePanel.Controls.Add(spGridTablePanel, 0, 1);
            spTablePanel.Controls.Add(logoPanel, 0, 3);
            spTablePanel.Dock = DockStyle.Fill;
            spTablePanel.Location = new Point(0, 0);
            spTablePanel.Name = "spTablePanel";
            spTablePanel.RowCount = 4;
            spTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            spTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            spTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            spTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            spTablePanel.Size = new Size(1060, 587);
            spTablePanel.TabIndex = 0;
            // 
            // spButtonTablePanel
            // 
            spButtonTablePanel.ColumnCount = 3;
            spButtonTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            spButtonTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            spButtonTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            spButtonTablePanel.Controls.Add(spMenuButton, 1, 0);
            spButtonTablePanel.Dock = DockStyle.Fill;
            spButtonTablePanel.Location = new Point(3, 442);
            spButtonTablePanel.Name = "spButtonTablePanel";
            spButtonTablePanel.RowCount = 1;
            spButtonTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            spButtonTablePanel.Size = new Size(1054, 52);
            spButtonTablePanel.TabIndex = 0;
            // 
            // spMenuButton
            // 
            spMenuButton.BackColor = Color.FromArgb(40, 40, 40);
            spMenuButton.BackgroundColor = Color.FromArgb(40, 40, 40);
            spMenuButton.BorderColor = Color.FromArgb(40, 40, 40);
            spMenuButton.BorderRadius = 7;
            spMenuButton.BorderSize = 0;
            spMenuButton.Dock = DockStyle.Fill;
            spMenuButton.FlatAppearance.BorderSize = 0;
            spMenuButton.FlatStyle = FlatStyle.Flat;
            spMenuButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            spMenuButton.ForeColor = Color.White;
            spMenuButton.Location = new Point(426, 10);
            spMenuButton.Margin = new Padding(5, 10, 5, 10);
            spMenuButton.Name = "spMenuButton";
            spMenuButton.Size = new Size(200, 32);
            spMenuButton.TabIndex = 0;
            spMenuButton.Text = "Menu";
            spMenuButton.TextColor = Color.White;
            spMenuButton.UseVisualStyleBackColor = false;
            spMenuButton.Click += SpMenuButton_Click;
            // 
            // spGridTablePanel
            // 
            spGridTablePanel.ColumnCount = 3;
            spGridTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            spGridTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            spGridTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            spGridTablePanel.Controls.Add(spProcedureGrid, 1, 0);
            spGridTablePanel.Dock = DockStyle.Fill;
            spGridTablePanel.Location = new Point(3, 32);
            spGridTablePanel.Name = "spGridTablePanel";
            spGridTablePanel.RowCount = 1;
            spGridTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            spGridTablePanel.Size = new Size(1054, 404);
            spGridTablePanel.TabIndex = 1;
            // 
            // spProcedureGrid
            // 
            spProcedureGrid.AllowUserToAddRows = false;
            spProcedureGrid.AllowUserToDeleteRows = false;
            spProcedureGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            spProcedureGrid.Dock = DockStyle.Fill;
            spProcedureGrid.Location = new Point(161, 3);
            spProcedureGrid.Name = "spProcedureGrid";
            spProcedureGrid.ReadOnly = true;
            spProcedureGrid.RowHeadersWidth = 51;
            spProcedureGrid.Size = new Size(731, 398);
            spProcedureGrid.TabIndex = 0;
            // 
            // logoPanel
            // 
            logoPanel.Controls.Add(logoBox);
            logoPanel.Dock = DockStyle.Fill;
            logoPanel.Location = new Point(3, 500);
            logoPanel.Name = "logoPanel";
            logoPanel.Size = new Size(1054, 84);
            logoPanel.TabIndex = 2;
            // 
            // logoBox
            // 
            logoBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            logoBox.BackgroundImage = Properties.Resources.OGRIT_Mini_Logo;
            logoBox.BackgroundImageLayout = ImageLayout.Center;
            logoBox.Location = new Point(890, 12);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(154, 64);
            logoBox.TabIndex = 3;
            logoBox.TabStop = false;
            // 
            // ProcedureListScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(spTablePanel);
            Name = "ProcedureListScreen";
            Size = new Size(1060, 587);
            Load += ProcedureListScreen_Load;
            spTablePanel.ResumeLayout(false);
            spButtonTablePanel.ResumeLayout(false);
            spGridTablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spProcedureGrid).EndInit();
            logoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel spTablePanel;
        private TableLayoutPanel spButtonTablePanel;
        private Generics.RoundButton spMenuButton;
        private TableLayoutPanel spGridTablePanel;
        private DataGridView spProcedureGrid;
        private Panel logoPanel;
        private PictureBox logoBox;
    }
}
