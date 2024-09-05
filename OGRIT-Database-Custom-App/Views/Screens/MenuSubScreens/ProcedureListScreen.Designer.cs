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
            spGridTablePanel = new TableLayoutPanel();
            spProcedureGrid = new DataGridView();
            logoPanel = new Panel();
            logoBox = new PictureBox();
            menuButtonPanel = new Panel();
            spMenuButton = new Generics.RoundButton();
            spTablePanel.SuspendLayout();
            spGridTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spProcedureGrid).BeginInit();
            logoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            menuButtonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // spTablePanel
            // 
            spTablePanel.ColumnCount = 1;
            spTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            spTablePanel.Controls.Add(spGridTablePanel, 0, 1);
            spTablePanel.Controls.Add(logoPanel, 0, 3);
            spTablePanel.Controls.Add(menuButtonPanel, 0, 2);
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
            spProcedureGrid.RowHeadersVisible = false;
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
            // menuButtonPanel
            // 
            menuButtonPanel.Controls.Add(spMenuButton);
            menuButtonPanel.Dock = DockStyle.Fill;
            menuButtonPanel.Location = new Point(3, 442);
            menuButtonPanel.Name = "menuButtonPanel";
            menuButtonPanel.Size = new Size(1054, 52);
            menuButtonPanel.TabIndex = 3;
            // 
            // spMenuButton
            // 
            spMenuButton.Anchor = AnchorStyles.None;
            spMenuButton.BackColor = Color.FromArgb(40, 40, 40);
            spMenuButton.BackgroundColor = Color.FromArgb(40, 40, 40);
            spMenuButton.BorderColor = Color.FromArgb(40, 40, 40);
            spMenuButton.BorderRadius = 7;
            spMenuButton.BorderSize = 0;
            spMenuButton.FlatAppearance.BorderSize = 0;
            spMenuButton.FlatStyle = FlatStyle.Flat;
            spMenuButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            spMenuButton.ForeColor = Color.White;
            spMenuButton.Location = new Point(427, 10);
            spMenuButton.Margin = new Padding(5, 10, 5, 10);
            spMenuButton.Name = "spMenuButton";
            spMenuButton.Size = new Size(200, 30);
            spMenuButton.TabIndex = 1;
            spMenuButton.Text = "Menu";
            spMenuButton.TextColor = Color.White;
            spMenuButton.UseVisualStyleBackColor = false;
            spMenuButton.Click += SpMenuButton_Click;
            // 
            // ProcedureListScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(spTablePanel);
            Name = "ProcedureListScreen";
            Size = new Size(1060, 587);
            Load += ProcedureListScreen_Load;
            Resize += ProcedureListScreen_Resize;
            spTablePanel.ResumeLayout(false);
            spGridTablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spProcedureGrid).EndInit();
            logoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            menuButtonPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel spTablePanel;
        private TableLayoutPanel spGridTablePanel;
        private DataGridView spProcedureGrid;
        private Panel logoPanel;
        private PictureBox logoBox;
        private Panel menuButtonPanel;
        private Generics.RoundButton spMenuButton;
    }
}
