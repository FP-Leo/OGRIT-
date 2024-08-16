namespace OGRIT_Database_Custom_App
{
    partial class inputForm
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
            SuspendLayout();
            // 
            // inputForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Name = "inputForm";
            Size = new Size(330, 440);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel dbIFTableLayoutPanel;

        private Label serverIPLabel;
        private Label dbInstanceLabel;
        private Label portLabel;
        private Label usernameLabel;
        private Label passwordLabel;
        private Label authLabel;

        private TextBox serverTB;
        private TextBox dbTB;
        private TextBox portTB;
        private TextBox usernameTB;
        private TextBox passwordTB;

        private ComboBox authCB;
    }
}
