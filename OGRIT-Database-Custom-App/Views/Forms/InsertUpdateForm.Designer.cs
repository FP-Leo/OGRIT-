using OGRIT_Database_Custom_App.Views.Generics;

namespace OGRIT_Database_Custom_App
{
    partial class InsertUpdateForm
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
            IUFormOuterTablePanel = new TableLayoutPanel();
            IUinputForm = new DbDataInput();
            IUButtonTableLayout = new TableLayoutPanel();
            submitUpdateButton = new RoundButton();
            cancelButton = new RoundButton();
            IUFormOuterTablePanel.SuspendLayout();
            IUButtonTableLayout.SuspendLayout();
            SuspendLayout();
            // 
            // IUFormOuterTablePanel
            // 
            IUFormOuterTablePanel.ColumnCount = 1;
            IUFormOuterTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            IUFormOuterTablePanel.Controls.Add(IUinputForm, 0, 0);
            IUFormOuterTablePanel.Controls.Add(IUButtonTableLayout, 0, 1);
            IUFormOuterTablePanel.Dock = DockStyle.Fill;
            IUFormOuterTablePanel.Location = new Point(0, 0);
            IUFormOuterTablePanel.Name = "IUFormOuterTablePanel";
            IUFormOuterTablePanel.RowCount = 2;
            IUFormOuterTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            IUFormOuterTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            IUFormOuterTablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            IUFormOuterTablePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            IUFormOuterTablePanel.Size = new Size(332, 453);
            IUFormOuterTablePanel.TabIndex = 0;
            // 
            // IUinputForm
            // 
            IUinputForm.Dock = DockStyle.Fill;
            IUinputForm.Location = new Point(3, 3);
            IUinputForm.Name = "IUinputForm";
            IUinputForm.Size = new Size(326, 379);
            IUinputForm.TabIndex = 0;
            // 
            // IUButtonTableLayout
            // 
            IUButtonTableLayout.ColumnCount = 2;
            IUButtonTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            IUButtonTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            IUButtonTableLayout.Controls.Add(submitUpdateButton, 0, 0);
            IUButtonTableLayout.Controls.Add(cancelButton, 1, 0);
            IUButtonTableLayout.Dock = DockStyle.Fill;
            IUButtonTableLayout.Location = new Point(3, 388);
            IUButtonTableLayout.Name = "IUButtonTableLayout";
            IUButtonTableLayout.RowCount = 1;
            IUButtonTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            IUButtonTableLayout.Size = new Size(326, 62);
            IUButtonTableLayout.TabIndex = 1;
            // 
            // submitUpdateButton
            // 
            submitUpdateButton.BackColor = Color.FromArgb(40, 40, 40);
            submitUpdateButton.BackgroundColor = Color.FromArgb(40, 40, 40);
            submitUpdateButton.BorderColor = Color.FromArgb(40, 40, 40);
            submitUpdateButton.BorderRadius = 5;
            submitUpdateButton.BorderSize = 0;
            submitUpdateButton.Dock = DockStyle.Fill;
            submitUpdateButton.FlatAppearance.BorderSize = 0;
            submitUpdateButton.FlatStyle = FlatStyle.Flat;
            submitUpdateButton.ForeColor = Color.White;
            submitUpdateButton.Location = new Point(3, 10);
            submitUpdateButton.Margin = new Padding(3, 10, 3, 10);
            submitUpdateButton.Name = "submitUpdateButton";
            submitUpdateButton.Size = new Size(157, 42);
            submitUpdateButton.TabIndex = 0;
            submitUpdateButton.TextColor = Color.White;
            submitUpdateButton.UseVisualStyleBackColor = false;
            submitUpdateButton.Click += submitUpdateButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.FromArgb(40, 40, 40);
            cancelButton.BackgroundColor = Color.FromArgb(40, 40, 40);
            cancelButton.BorderColor = Color.FromArgb(40, 40, 40);
            cancelButton.BorderRadius = 5;
            cancelButton.BorderSize = 0;
            cancelButton.Dock = DockStyle.Fill;
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.ForeColor = Color.White;
            cancelButton.Location = new Point(166, 10);
            cancelButton.Margin = new Padding(3, 10, 3, 10);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(157, 42);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.TextColor = Color.White;
            cancelButton.UseVisualStyleBackColor = false;
            // 
            // InsertUpdateForm
            // 
            AcceptButton = submitUpdateButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(332, 453);
            Controls.Add(IUFormOuterTablePanel);
            MaximumSize = new Size(350, 500);
            MinimumSize = new Size(350, 500);
            Name = "InsertUpdateForm";
            Text = "Form";
            IUFormOuterTablePanel.ResumeLayout(false);
            IUButtonTableLayout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel IUFormOuterTablePanel;
        private DbDataInput IUinputForm;
        private TableLayoutPanel IUButtonTableLayout;
        private RoundButton submitUpdateButton;
        private RoundButton cancelButton;
    }
}