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
            msOuterTableLayout = new TableLayoutPanel();
            msInnerPanel = new Panel();
            msInnerTableLayout = new TableLayoutPanel();
            menuLabel = new Label();
            optionOneLabel = new Label();
            msOuterTableLayout.SuspendLayout();
            msInnerPanel.SuspendLayout();
            msInnerTableLayout.SuspendLayout();
            SuspendLayout();
            // 
            // msOuterTableLayout
            // 
            msOuterTableLayout.ColumnCount = 3;
            msOuterTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.8F));
            msOuterTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.6F));
            msOuterTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            msOuterTableLayout.Controls.Add(msInnerPanel, 1, 0);
            msOuterTableLayout.Dock = DockStyle.Fill;
            msOuterTableLayout.Location = new Point(0, 0);
            msOuterTableLayout.Name = "msOuterTableLayout";
            msOuterTableLayout.RowCount = 1;
            msOuterTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            msOuterTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            msOuterTableLayout.Size = new Size(800, 450);
            msOuterTableLayout.TabIndex = 0;
            // 
            // msInnerPanel
            // 
            msInnerPanel.Controls.Add(msInnerTableLayout);
            msInnerPanel.Dock = DockStyle.Fill;
            msInnerPanel.Location = new Point(266, 3);
            msInnerPanel.Name = "msInnerPanel";
            msInnerPanel.Size = new Size(263, 444);
            msInnerPanel.TabIndex = 0;
            // 
            // msInnerTableLayout
            // 
            msInnerTableLayout.ColumnCount = 1;
            msInnerTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            msInnerTableLayout.Controls.Add(menuLabel, 0, 1);
            msInnerTableLayout.Controls.Add(optionOneLabel, 0, 2);
            msInnerTableLayout.Dock = DockStyle.Fill;
            msInnerTableLayout.Location = new Point(0, 0);
            msInnerTableLayout.Name = "msInnerTableLayout";
            msInnerTableLayout.RowCount = 4;
            msInnerTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 23.5294113F));
            msInnerTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 17.6470585F));
            msInnerTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 11.7647057F));
            msInnerTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 47.0588226F));
            msInnerTableLayout.Size = new Size(263, 444);
            msInnerTableLayout.TabIndex = 0;
            // 
            // menuLabel
            // 
            menuLabel.AutoSize = true;
            menuLabel.Dock = DockStyle.Fill;
            menuLabel.Font = new Font("Sitka Heading Semibold", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            menuLabel.Location = new Point(3, 104);
            menuLabel.Name = "menuLabel";
            menuLabel.Size = new Size(257, 78);
            menuLabel.TabIndex = 0;
            menuLabel.Text = "Menu";
            menuLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // optionOneLabel
            // 
            optionOneLabel.Anchor = AnchorStyles.Left;
            optionOneLabel.AutoSize = true;
            optionOneLabel.Cursor = Cursors.Hand;
            optionOneLabel.Location = new Point(3, 198);
            optionOneLabel.Name = "optionOneLabel";
            optionOneLabel.Size = new Size(163, 20);
            optionOneLabel.TabIndex = 1;
            optionOneLabel.Text = "1. Manage Connections";
            optionOneLabel.Click += OptionOneLabel_Click;
            // 
            // MenuScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(msOuterTableLayout);
            MinimumSize = new Size(800, 450);
            Name = "MenuScreen";
            Size = new Size(800, 450);
            msOuterTableLayout.ResumeLayout(false);
            msInnerPanel.ResumeLayout(false);
            msInnerTableLayout.ResumeLayout(false);
            msInnerTableLayout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel msOuterTableLayout;
        private Panel msInnerPanel;
        private TableLayoutPanel msInnerTableLayout;
        private Label menuLabel;
        private Label optionOneLabel;
    }
}
