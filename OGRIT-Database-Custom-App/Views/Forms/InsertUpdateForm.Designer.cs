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
            submitButton = new RoundButton();
            cancelButton = new RoundButton();
            IUFormOuterTablePanel.SuspendLayout();
            IUButtonTableLayout.SuspendLayout();
            SuspendLayout();
            // 
            // IUFormOuterTablePanel
            // 
            IUFormOuterTablePanel.ColumnCount = 1;
            IUFormOuterTablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            IUFormOuterTablePanel.Controls.Add(IUinputForm, 0, 1);
            IUFormOuterTablePanel.Controls.Add(IUButtonTableLayout, 0, 2);
            IUFormOuterTablePanel.Dock = DockStyle.Fill;
            IUFormOuterTablePanel.Location = new Point(0, 0);
            IUFormOuterTablePanel.Name = "IUFormOuterTablePanel";
            IUFormOuterTablePanel.RowCount = 4;
            IUFormOuterTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            IUFormOuterTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            IUFormOuterTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            IUFormOuterTablePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            IUFormOuterTablePanel.Size = new Size(332, 453);
            IUFormOuterTablePanel.TabIndex = 0;
            // 
            // IUinputForm
            // 
            IUinputForm.Location = new Point(3, 48);
            IUinputForm.Name = "IUinputForm";
            IUinputForm.Size = new Size(326, 305);
            IUinputForm.TabIndex = 0;
            // 
            // IUButtonTableLayout
            // 
            IUButtonTableLayout.ColumnCount = 2;
            IUButtonTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            IUButtonTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            IUButtonTableLayout.Controls.Add(submitButton, 0, 0);
            IUButtonTableLayout.Controls.Add(cancelButton, 1, 0);
            IUButtonTableLayout.Dock = DockStyle.Fill;
            IUButtonTableLayout.Location = new Point(3, 365);
            IUButtonTableLayout.Name = "IUButtonTableLayout";
            IUButtonTableLayout.RowCount = 1;
            IUButtonTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            IUButtonTableLayout.Size = new Size(326, 39);
            IUButtonTableLayout.TabIndex = 1;
            // 
            // submitButton
            // 
            submitButton.BackColor = Color.FromArgb(40, 40, 40);
            submitButton.BackgroundColor = Color.FromArgb(40, 40, 40);
            submitButton.BorderColor = Color.FromArgb(40, 40, 40);
            submitButton.BorderRadius = 5;
            submitButton.BorderSize = 0;
            submitButton.FlatAppearance.BorderSize = 0;
            submitButton.FlatStyle = FlatStyle.Flat;
            submitButton.ForeColor = Color.White;
            submitButton.Location = new Point(3, 3);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(157, 32);
            submitButton.TabIndex = 0;
            submitButton.Text = "Submit";
            submitButton.TextColor = Color.White;
            submitButton.UseVisualStyleBackColor = false;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.FromArgb(40, 40, 40);
            cancelButton.BackgroundColor = Color.FromArgb(40, 40, 40);
            cancelButton.BorderColor = Color.FromArgb(40, 40, 40);
            cancelButton.BorderRadius = 5;
            cancelButton.BorderSize = 0;
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.ForeColor = Color.White;
            cancelButton.Location = new Point(166, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(157, 32);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.TextColor = Color.White;
            cancelButton.UseVisualStyleBackColor = false;
            // 
            // InsertUpdateForm
            // 
            AcceptButton = submitButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(332, 453);
            Controls.Add(IUFormOuterTablePanel);
            MaximumSize = new Size(400, 600);
            MinimumSize = new Size(350, 500);
            Name = "InsertUpdateForm";
            Text = "InsertUpdateForm";
            IUFormOuterTablePanel.ResumeLayout(false);
            IUButtonTableLayout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel IUFormOuterTablePanel;
        private DbDataInput IUinputForm;
        private TableLayoutPanel IUButtonTableLayout;
        private RoundButton submitButton;
        private RoundButton cancelButton;
    }
}