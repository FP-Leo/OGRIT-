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
            startingScreen = new StartingScreen(this);
            SuspendLayout();
            // 
            // startingScreen1
            // 
            startingScreen.Dock = DockStyle.Fill;
            startingScreen.Location = new Point(0, 0);
            startingScreen.MinimumSize = new Size(800, 450);
            startingScreen.Name = "StartingScreen";
            startingScreen.Size = new Size(800, 450);
            startingScreen.TabIndex = 0;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(800, 450);
            Controls.Add(startingScreen);
            MinimumSize = new Size(800, 450);
            Name = "MainWindow";
            Text = "Form1";
            //InitializeLogInScreen();
            ResumeLayout(false);
        }

        public void InitializeLogInScreen()
        {
            logInScreen = new LogInScreen(this);
            SuspendLayout();
            // 
            // logInScreen
            // 
            logInScreen.Dock = DockStyle.Fill;
            logInScreen.Location = new Point(10, 10);
            logInScreen.Name = "LogInScreen";
            logInScreen.Size = new Size(800, 450);
            logInScreen.TabIndex = 0;
            logInScreen.Visible = false;
            // 
            // MainWindow
            // 
            Controls.Add(logInScreen);
        }

        #endregion

        public StartingScreen startingScreen;
        public LogInScreen logInScreen;
    }
}
