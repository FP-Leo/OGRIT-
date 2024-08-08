namespace OGRIT_Database_Custom_App
{
    partial class StartingScreen
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
            tableLayoutPanel1 = new TableLayoutPanel();
            logoBox = new PictureBox();
            appLabel = new Label();
            mottoLabel = new Label();
            continueButton = new RoundButton();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(logoBox, 0, 0);
            tableLayoutPanel1.Controls.Add(appLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(mottoLabel, 0, 3);
            tableLayoutPanel1.Controls.Add(continueButton, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // logoBox
            // 
            logoBox.Anchor = AnchorStyles.Bottom;
            logoBox.Image = Properties.Resources.OGRIT_Logo;
            logoBox.Location = new Point(3, 3);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(794, 151);
            logoBox.SizeMode = PictureBoxSizeMode.CenterImage;
            logoBox.TabIndex = 7;
            logoBox.TabStop = false;
            // 
            // appLabel
            // 
            appLabel.Anchor = AnchorStyles.Top;
            appLabel.AutoSize = true;
            appLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            appLabel.ForeColor = Color.FromArgb(145, 162, 199);
            appLabel.Location = new Point(282, 157);
            appLabel.Name = "appLabel";
            appLabel.Size = new Size(236, 23);
            appLabel.TabIndex = 9;
            appLabel.Text = "Custom Database Application";
            // 
            // mottoLabel
            // 
            mottoLabel.Anchor = AnchorStyles.Top;
            mottoLabel.AutoSize = true;
            mottoLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mottoLabel.ForeColor = Color.FromArgb(145, 162, 199);
            mottoLabel.Location = new Point(199, 404);
            mottoLabel.Name = "mottoLabel";
            mottoLabel.Size = new Size(402, 23);
            mottoLabel.TabIndex = 10;
            mottoLabel.Text = "Your success in databases is strengthed with OGRIT";
            // 
            // continueButton
            // 
            continueButton.Anchor = AnchorStyles.Top;
            continueButton.AutoSize = true;
            continueButton.BackColor = Color.FromArgb(40, 40, 40);
            continueButton.BackgroundColor = Color.FromArgb(40, 40, 40);
            continueButton.BorderColor = Color.PaleVioletRed;
            continueButton.BorderRadius = 9;
            continueButton.BorderSize = 0;
            continueButton.FlatAppearance.BorderSize = 0;
            continueButton.FlatStyle = FlatStyle.Flat;
            continueButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            continueButton.ForeColor = Color.LightGray;
            continueButton.Location = new Point(331, 227);
            continueButton.MaximumSize = new Size(250, 90);
            continueButton.MinimumSize = new Size(130, 60);
            continueButton.Name = "continueButton";
            continueButton.Size = new Size(137, 65);
            continueButton.TabIndex = 11;
            continueButton.Text = "Continue";
            continueButton.TextColor = Color.LightGray;
            continueButton.UseVisualStyleBackColor = false;
            continueButton.Click += ContinueButton_Click;
            // 
            // StartingScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            MinimumSize = new Size(800, 450);
            Name = "StartingScreen";
            Size = new Size(800, 450);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox logoBox;
        private Label appLabel;
        private Label mottoLabel;
        private RoundButton continueButton;
    }
}