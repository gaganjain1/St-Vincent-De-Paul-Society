namespace St_Vincent_De_Paul_Society
{
    partial class LogInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
            this.ShopLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.ThemePictureBox = new System.Windows.Forms.PictureBox();
            this.PasswordPanel = new System.Windows.Forms.Panel();
            this.LogInButton = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.EmployeeLogInLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ShopLogoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThemePictureBox)).BeginInit();
            this.PasswordPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShopLogoPictureBox
            // 
            this.ShopLogoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ShopLogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ShopLogoPictureBox.Image")));
            this.ShopLogoPictureBox.Location = new System.Drawing.Point(465, 12);
            this.ShopLogoPictureBox.Name = "ShopLogoPictureBox";
            this.ShopLogoPictureBox.Size = new System.Drawing.Size(327, 81);
            this.ShopLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShopLogoPictureBox.TabIndex = 0;
            this.ShopLogoPictureBox.TabStop = false;
            // 
            // ThemePictureBox
            // 
            this.ThemePictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ThemePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ThemePictureBox.Image")));
            this.ThemePictureBox.Location = new System.Drawing.Point(54, 345);
            this.ThemePictureBox.Name = "ThemePictureBox";
            this.ThemePictureBox.Size = new System.Drawing.Size(303, 340);
            this.ThemePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ThemePictureBox.TabIndex = 2;
            this.ThemePictureBox.TabStop = false;
            // 
            // PasswordPanel
            // 
            this.PasswordPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PasswordPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.PasswordPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordPanel.Controls.Add(this.LogInButton);
            this.PasswordPanel.Controls.Add(this.PasswordTextBox);
            this.PasswordPanel.Controls.Add(this.PasswordLabel);
            this.PasswordPanel.Controls.Add(this.EmployeeLogInLabel);
            this.PasswordPanel.Location = new System.Drawing.Point(390, 168);
            this.PasswordPanel.Name = "PasswordPanel";
            this.PasswordPanel.Size = new System.Drawing.Size(474, 238);
            this.PasswordPanel.TabIndex = 3;
            // 
            // LogInButton
            // 
            this.LogInButton.BackColor = System.Drawing.Color.DarkBlue;
            this.LogInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogInButton.ForeColor = System.Drawing.Color.White;
            this.LogInButton.Location = new System.Drawing.Point(231, 141);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(98, 43);
            this.LogInButton.TabIndex = 3;
            this.LogInButton.Text = "Log In";
            this.LogInButton.UseVisualStyleBackColor = false;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(231, 81);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(170, 26);
            this.PasswordTextBox.TabIndex = 2;
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBox_TextChanged);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(50, 80);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(175, 44);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Password :";
            // 
            // EmployeeLogInLabel
            // 
            this.EmployeeLogInLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmployeeLogInLabel.Location = new System.Drawing.Point(154, 23);
            this.EmployeeLogInLabel.Name = "EmployeeLogInLabel";
            this.EmployeeLogInLabel.Size = new System.Drawing.Size(209, 44);
            this.EmployeeLogInLabel.TabIndex = 0;
            this.EmployeeLogInLabel.Text = "Employee Log In";
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1295, 773);
            this.Controls.Add(this.PasswordPanel);
            this.Controls.Add(this.ThemePictureBox);
            this.Controls.Add(this.ShopLogoPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Management for Website";
            ((System.ComponentModel.ISupportInitialize)(this.ShopLogoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThemePictureBox)).EndInit();
            this.PasswordPanel.ResumeLayout(false);
            this.PasswordPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ShopLogoPictureBox;
        private System.Windows.Forms.PictureBox ThemePictureBox;
        private System.Windows.Forms.Panel PasswordPanel;
        private System.Windows.Forms.Label EmployeeLogInLabel;
        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label PasswordLabel;
    }
}

