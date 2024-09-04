namespace OGRIT_Database_Custom_App
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // MainWindow
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1082, 653);
            MinimumSize = new Size(1100, 700);
            Name = "MainWindow";
            Text = "OGRIT DB APP";
            FormClosing += MainWindow_FormClosing;
            ResumeLayout(false);
        }

        #endregion

    }
}
