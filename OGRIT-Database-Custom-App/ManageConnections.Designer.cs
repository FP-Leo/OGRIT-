namespace OGRIT_Database_Custom_App
{
    partial class ManageConnections
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
            mcOuterTableLayout = new TableLayoutPanel();
            mcDataGrid = new DataGridView();
            mcBodyTableLayoutPanel = new TableLayoutPanel();
            mcControlPanel = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            mcInsertButton = new RoundButton();
            mcUpdateButton = new RoundButton();
            mcDeleteButton = new RoundButton();
            mcMenuButton = new RoundButton();
            mcHeaderLayoutPanel = new TableLayoutPanel();
            label1 = new Label();
            mcLogoPictureBox = new PictureBox();
            mcOuterTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mcDataGrid).BeginInit();
            mcBodyTableLayoutPanel.SuspendLayout();
            mcControlPanel.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            mcHeaderLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mcLogoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // mcOuterTableLayout
            // 
            mcOuterTableLayout.ColumnCount = 1;
            mcOuterTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mcOuterTableLayout.Controls.Add(mcBodyTableLayoutPanel, 0, 1);
            mcOuterTableLayout.Controls.Add(mcHeaderLayoutPanel, 0, 0);
            mcOuterTableLayout.Controls.Add(mcLogoPictureBox, 0, 2);
            mcOuterTableLayout.Dock = DockStyle.Fill;
            mcOuterTableLayout.Location = new Point(0, 0);
            mcOuterTableLayout.Name = "mcOuterTableLayout";
            mcOuterTableLayout.RowCount = 3;
            mcOuterTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            mcOuterTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            mcOuterTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            mcOuterTableLayout.Size = new Size(1060, 587);
            mcOuterTableLayout.TabIndex = 0;
            // 
            // mcDataGrid
            // 
            mcDataGrid.AllowUserToAddRows = false;
            mcDataGrid.AllowUserToDeleteRows = false;
            mcDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            mcDataGrid.Dock = DockStyle.Fill;
            mcDataGrid.Location = new Point(213, 3);
            mcDataGrid.Name = "mcDataGrid";
            mcDataGrid.ReadOnly = true;
            mcDataGrid.RowHeadersWidth = 51;
            mcDataGrid.Size = new Size(838, 457);
            mcDataGrid.TabIndex = 1;
            // 
            // mcBodyTableLayoutPanel
            // 
            mcBodyTableLayoutPanel.ColumnCount = 2;
            mcBodyTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            mcBodyTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            mcBodyTableLayoutPanel.Controls.Add(mcControlPanel, 0, 0);
            mcBodyTableLayoutPanel.Controls.Add(mcDataGrid, 1, 0);
            mcBodyTableLayoutPanel.Dock = DockStyle.Fill;
            mcBodyTableLayoutPanel.Location = new Point(3, 61);
            mcBodyTableLayoutPanel.Name = "mcBodyTableLayoutPanel";
            mcBodyTableLayoutPanel.RowCount = 1;
            mcBodyTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mcBodyTableLayoutPanel.Size = new Size(1054, 463);
            mcBodyTableLayoutPanel.TabIndex = 1;
            // 
            // mcControlPanel
            // 
            mcControlPanel.Controls.Add(tableLayoutPanel2);
            mcControlPanel.Dock = DockStyle.Fill;
            mcControlPanel.Location = new Point(3, 3);
            mcControlPanel.Name = "mcControlPanel";
            mcControlPanel.Size = new Size(204, 457);
            mcControlPanel.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(mcInsertButton, 0, 0);
            tableLayoutPanel2.Controls.Add(mcUpdateButton, 0, 1);
            tableLayoutPanel2.Controls.Add(mcDeleteButton, 0, 2);
            tableLayoutPanel2.Controls.Add(mcMenuButton, 0, 4);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel2.Size = new Size(204, 457);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // mcInsertButton
            // 
            mcInsertButton.BackColor = Color.FromArgb(40, 40, 40);
            mcInsertButton.BackgroundColor = Color.FromArgb(40, 40, 40);
            mcInsertButton.BorderColor = Color.FromArgb(40, 40, 40);
            mcInsertButton.BorderRadius = 7;
            mcInsertButton.BorderSize = 0;
            mcInsertButton.Dock = DockStyle.Fill;
            mcInsertButton.FlatAppearance.BorderSize = 0;
            mcInsertButton.FlatStyle = FlatStyle.Flat;
            mcInsertButton.ForeColor = Color.White;
            mcInsertButton.Location = new Point(3, 3);
            mcInsertButton.Name = "mcInsertButton";
            mcInsertButton.Size = new Size(198, 51);
            mcInsertButton.TabIndex = 0;
            mcInsertButton.Text = "Insert";
            mcInsertButton.TextColor = Color.White;
            mcInsertButton.UseVisualStyleBackColor = false;
            // 
            // mcUpdateButton
            // 
            mcUpdateButton.BackColor = Color.FromArgb(40, 40, 40);
            mcUpdateButton.BackgroundColor = Color.FromArgb(40, 40, 40);
            mcUpdateButton.BorderColor = Color.FromArgb(40, 40, 40);
            mcUpdateButton.BorderRadius = 7;
            mcUpdateButton.BorderSize = 0;
            mcUpdateButton.Dock = DockStyle.Fill;
            mcUpdateButton.FlatAppearance.BorderSize = 0;
            mcUpdateButton.FlatStyle = FlatStyle.Flat;
            mcUpdateButton.ForeColor = Color.White;
            mcUpdateButton.Location = new Point(3, 60);
            mcUpdateButton.Name = "mcUpdateButton";
            mcUpdateButton.Size = new Size(198, 51);
            mcUpdateButton.TabIndex = 1;
            mcUpdateButton.Text = "Update";
            mcUpdateButton.TextColor = Color.White;
            mcUpdateButton.UseVisualStyleBackColor = false;
            // 
            // mcDeleteButton
            // 
            mcDeleteButton.BackColor = Color.FromArgb(40, 40, 40);
            mcDeleteButton.BackgroundColor = Color.FromArgb(40, 40, 40);
            mcDeleteButton.BorderColor = Color.FromArgb(40, 40, 40);
            mcDeleteButton.BorderRadius = 7;
            mcDeleteButton.BorderSize = 0;
            mcDeleteButton.Dock = DockStyle.Fill;
            mcDeleteButton.FlatAppearance.BorderSize = 0;
            mcDeleteButton.FlatStyle = FlatStyle.Flat;
            mcDeleteButton.ForeColor = Color.White;
            mcDeleteButton.Location = new Point(3, 117);
            mcDeleteButton.Name = "mcDeleteButton";
            mcDeleteButton.Size = new Size(198, 51);
            mcDeleteButton.TabIndex = 2;
            mcDeleteButton.Text = "Delete";
            mcDeleteButton.TextColor = Color.White;
            mcDeleteButton.UseVisualStyleBackColor = false;
            // 
            // mcMenuButton
            // 
            mcMenuButton.BackColor = Color.FromArgb(40, 40, 40);
            mcMenuButton.BackgroundColor = Color.FromArgb(40, 40, 40);
            mcMenuButton.BorderColor = Color.FromArgb(40, 40, 40);
            mcMenuButton.BorderRadius = 7;
            mcMenuButton.BorderSize = 0;
            mcMenuButton.Dock = DockStyle.Fill;
            mcMenuButton.FlatAppearance.BorderSize = 0;
            mcMenuButton.FlatStyle = FlatStyle.Flat;
            mcMenuButton.ForeColor = Color.White;
            mcMenuButton.Location = new Point(3, 402);
            mcMenuButton.Name = "mcMenuButton";
            mcMenuButton.Size = new Size(198, 52);
            mcMenuButton.TabIndex = 3;
            mcMenuButton.Text = "Menu";
            mcMenuButton.TextColor = Color.White;
            mcMenuButton.UseVisualStyleBackColor = false;
            // 
            // mcHeaderLayoutPanel
            // 
            mcHeaderLayoutPanel.ColumnCount = 2;
            mcHeaderLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            mcHeaderLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            mcHeaderLayoutPanel.Controls.Add(label1, 1, 0);
            mcHeaderLayoutPanel.Dock = DockStyle.Fill;
            mcHeaderLayoutPanel.Location = new Point(3, 3);
            mcHeaderLayoutPanel.Name = "mcHeaderLayoutPanel";
            mcHeaderLayoutPanel.RowCount = 1;
            mcHeaderLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mcHeaderLayoutPanel.Size = new Size(1054, 52);
            mcHeaderLayoutPanel.TabIndex = 2;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Century Schoolbook", 18F);
            label1.ForeColor = Color.FromArgb(145, 162, 255);
            label1.Location = new Point(540, 8);
            label1.Name = "label1";
            label1.Size = new Size(184, 35);
            label1.TabIndex = 0;
            label1.Text = "Connections";
            // 
            // mcLogoPictureBox
            // 
            mcLogoPictureBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            mcLogoPictureBox.Image = Properties.Resources.OGRIT_Mini_Logo;
            mcLogoPictureBox.Location = new Point(891, 530);
            mcLogoPictureBox.Name = "mcLogoPictureBox";
            mcLogoPictureBox.Size = new Size(166, 54);
            mcLogoPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            mcLogoPictureBox.TabIndex = 3;
            mcLogoPictureBox.TabStop = false;
            // 
            // ManageConnections
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mcOuterTableLayout);
            Name = "ManageConnections";
            Size = new Size(1060, 587);
            Load += ManageConnections_Load;
            mcOuterTableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mcDataGrid).EndInit();
            mcBodyTableLayoutPanel.ResumeLayout(false);
            mcControlPanel.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            mcHeaderLayoutPanel.ResumeLayout(false);
            mcHeaderLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mcLogoPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mcOuterTableLayout;
        private TableLayoutPanel mcBodyTableLayoutPanel;
        private Panel mcControlPanel;
        private TableLayoutPanel tableLayoutPanel2;
        private RoundButton mcInsertButton;
        private RoundButton mcUpdateButton;
        private RoundButton mcDeleteButton;
        private RoundButton mcMenuButton;
        private DataGridView mcDataGrid;
        private TableLayoutPanel mcHeaderLayoutPanel;
        private Label label1;
        private PictureBox mcLogoPictureBox;
    }
}
