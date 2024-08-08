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
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(825, 450);
            Controls.Add(startingScreen);
            MinimumSize = new Size(845, 500);
            Name = "MainWindow";
            Text = "OGRIT DB APP";
            ResumeLayout(false);
        }

        public void SetUpStartingScreen()
        {
            startingScreen = new StartingScreen(this);
            // 
            // startingScreen
            // 
            startingScreen.Dock = DockStyle.Fill;
            startingScreen.Location = new Point(0, 0);
            startingScreen.MinimumSize = new Size(825, 450);
            startingScreen.Name = "startingScreen1";
            startingScreen.Size = new Size(825, 450);
            startingScreen.TabIndex = 0;
        }

        public void DestroyStartingScreen()
        {
            Controls.Remove(startingScreen);
            startingScreen = null;
            InitializeLogInScreen();
        }

        public void InitializeLogInScreen()
        {
            logInScreen = new LogInScreen(this);
            // 
            // logInScreen
            // 
            logInScreen.Dock = DockStyle.Fill;
            logInScreen.Location = new Point(10, 10);
            logInScreen.Name = "LogInScreen";
            logInScreen.Size = new Size(800, 450);
            logInScreen.TabIndex = 0;
            logInScreen.Visible = true;
            // 
            // MainWindow
            // 
            Controls.Add(logInScreen);
        }

        #endregion

        public LogInScreen logInScreen;
        private StartingScreen startingScreen;
    }
}
