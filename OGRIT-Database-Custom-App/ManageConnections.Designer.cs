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
            mcTableLayoutPanel = new TableLayoutPanel();
            mcControlPanel = new Panel();
            mcUpdateButton = new Button();
            mcAddButton = new Button();
            mcDeleteButton = new Button();
            mcBackButton = new Button();
            mcDataGrid = new DataGridView();
            mcTableLayoutPanel.SuspendLayout();
            mcControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mcDataGrid).BeginInit();
            SuspendLayout();
            // 
            // mcTableLayoutPanel
            // 
            mcTableLayoutPanel.ColumnCount = 2;
            mcTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            mcTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            mcTableLayoutPanel.Controls.Add(mcControlPanel, 0, 0);
            mcTableLayoutPanel.Controls.Add(mcDataGrid, 1, 0);
            mcTableLayoutPanel.Dock = DockStyle.Fill;
            mcTableLayoutPanel.Location = new Point(0, 0);
            mcTableLayoutPanel.Name = "mcTableLayoutPanel";
            mcTableLayoutPanel.RowCount = 1;
            mcTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mcTableLayoutPanel.Size = new Size(800, 450);
            mcTableLayoutPanel.TabIndex = 0;
            // 
            // mcControlPanel
            // 
            mcControlPanel.Controls.Add(mcBackButton);
            mcControlPanel.Controls.Add(mcDeleteButton);
            mcControlPanel.Controls.Add(mcUpdateButton);
            mcControlPanel.Controls.Add(mcAddButton);
            mcControlPanel.Dock = DockStyle.Fill;
            mcControlPanel.Location = new Point(3, 3);
            mcControlPanel.Name = "mcControlPanel";
            mcControlPanel.Size = new Size(154, 444);
            mcControlPanel.TabIndex = 0;
            // 
            // mcUpdateButton
            // 
            mcUpdateButton.Dock = DockStyle.Top;
            mcUpdateButton.Location = new Point(0, 29);
            mcUpdateButton.Name = "mcUpdateButton";
            mcUpdateButton.Size = new Size(154, 29);
            mcUpdateButton.TabIndex = 1;
            mcUpdateButton.Text = "Update Connection";
            mcUpdateButton.UseVisualStyleBackColor = true;
            // 
            // mcAddButton
            // 
            mcAddButton.Dock = DockStyle.Top;
            mcAddButton.Location = new Point(0, 0);
            mcAddButton.Name = "mcAddButton";
            mcAddButton.Size = new Size(154, 29);
            mcAddButton.TabIndex = 0;
            mcAddButton.Text = "Add Connection";
            mcAddButton.UseVisualStyleBackColor = true;
            // 
            // mcDeleteButton
            // 
            mcDeleteButton.Dock = DockStyle.Top;
            mcDeleteButton.Location = new Point(0, 58);
            mcDeleteButton.Name = "mcDeleteButton";
            mcDeleteButton.Size = new Size(154, 29);
            mcDeleteButton.TabIndex = 2;
            mcDeleteButton.Text = "Delete Connection";
            mcDeleteButton.UseVisualStyleBackColor = true;
            // 
            // mcBackButton
            // 
            mcBackButton.Dock = DockStyle.Bottom;
            mcBackButton.Location = new Point(0, 415);
            mcBackButton.Name = "mcBackButton";
            mcBackButton.Size = new Size(154, 29);
            mcBackButton.TabIndex = 3;
            mcBackButton.Text = "Menu";
            mcBackButton.UseVisualStyleBackColor = true;
            // 
            // mcDataGrid
            // 
            mcDataGrid.AllowUserToAddRows = false;
            mcDataGrid.AllowUserToDeleteRows = false;
            mcDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            mcDataGrid.Dock = DockStyle.Fill;
            mcDataGrid.Location = new Point(163, 3);
            mcDataGrid.Name = "mcDataGrid";
            mcDataGrid.ReadOnly = true;
            mcDataGrid.RowHeadersWidth = 51;
            mcDataGrid.Size = new Size(634, 444);
            mcDataGrid.TabIndex = 1;
            // 
            // ManageConnections
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mcTableLayoutPanel);
            MinimumSize = new Size(800, 450);
            Name = "ManageConnections";
            Size = new Size(800, 450);
            Load += ManageConnections_Load;
            mcTableLayoutPanel.ResumeLayout(false);
            mcControlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mcDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mcTableLayoutPanel;
        private Panel mcControlPanel;
        private Button mcUpdateButton;
        private Button mcAddButton;
        private Button mcDeleteButton;
        private Button mcBackButton;
        private DataGridView mcDataGrid;
    }
}
