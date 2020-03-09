namespace St_Vincent_De_Paul_Society
{
    partial class WelcomeForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            this.ShopLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.UploadButton = new System.Windows.Forms.Button();
            this.ModifyButton = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.PasswordPanel = new System.Windows.Forms.Panel();
            this.ThemePictureBox = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ShopLogoPictureBox)).BeginInit();
            this.PasswordPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThemePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ShopLogoPictureBox
            // 
            this.ShopLogoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ShopLogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ShopLogoPictureBox.Image")));
            this.ShopLogoPictureBox.Location = new System.Drawing.Point(419, 12);
            this.ShopLogoPictureBox.Name = "ShopLogoPictureBox";
            this.ShopLogoPictureBox.Size = new System.Drawing.Size(327, 81);
            this.ShopLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShopLogoPictureBox.TabIndex = 1;
            this.ShopLogoPictureBox.TabStop = false;
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeLabel.Location = new System.Drawing.Point(3, 9);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(465, 81);
            this.WelcomeLabel.TabIndex = 2;
            this.WelcomeLabel.Text = "Welcome! What would you like to do with the product? Please select from the optio" +
    "ns below.";
            this.WelcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogOutButton
            // 
            this.LogOutButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LogOutButton.BackColor = System.Drawing.Color.DarkBlue;
            this.LogOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutButton.ForeColor = System.Drawing.Color.White;
            this.LogOutButton.Location = new System.Drawing.Point(954, 12);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(98, 43);
            this.LogOutButton.TabIndex = 4;
            this.LogOutButton.Text = "Log Out";
            this.toolTip1.SetToolTip(this.LogOutButton, "Click here to Log out");
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // UploadButton
            // 
            this.UploadButton.BackColor = System.Drawing.Color.DarkBlue;
            this.UploadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UploadButton.ForeColor = System.Drawing.Color.White;
            this.UploadButton.Location = new System.Drawing.Point(47, 115);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(98, 43);
            this.UploadButton.TabIndex = 5;
            this.UploadButton.Text = "Upload";
            this.toolTip1.SetToolTip(this.UploadButton, "Click here to uplod any item");
            this.UploadButton.UseVisualStyleBackColor = false;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // ModifyButton
            // 
            this.ModifyButton.BackColor = System.Drawing.Color.DarkBlue;
            this.ModifyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyButton.ForeColor = System.Drawing.Color.White;
            this.ModifyButton.Location = new System.Drawing.Point(193, 115);
            this.ModifyButton.Name = "ModifyButton";
            this.ModifyButton.Size = new System.Drawing.Size(98, 43);
            this.ModifyButton.TabIndex = 6;
            this.ModifyButton.Text = "Modify";
            this.toolTip1.SetToolTip(this.ModifyButton, "Click here to Modify any item");
            this.ModifyButton.UseVisualStyleBackColor = false;
            this.ModifyButton.Click += new System.EventHandler(this.ModifyButton_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.DarkBlue;
            this.Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.ForeColor = System.Drawing.Color.White;
            this.Delete.Location = new System.Drawing.Point(334, 115);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(98, 43);
            this.Delete.TabIndex = 7;
            this.Delete.Text = "Delete";
            this.toolTip1.SetToolTip(this.Delete, "Click here to Delete any item");
            this.Delete.UseVisualStyleBackColor = false;
            // 
            // PasswordPanel
            // 
            this.PasswordPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PasswordPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.PasswordPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordPanel.Controls.Add(this.Delete);
            this.PasswordPanel.Controls.Add(this.WelcomeLabel);
            this.PasswordPanel.Controls.Add(this.ModifyButton);
            this.PasswordPanel.Controls.Add(this.UploadButton);
            this.PasswordPanel.Location = new System.Drawing.Point(325, 196);
            this.PasswordPanel.Name = "PasswordPanel";
            this.PasswordPanel.Size = new System.Drawing.Size(474, 238);
            this.PasswordPanel.TabIndex = 8;
            // 
            // ThemePictureBox
            // 
            this.ThemePictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ThemePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ThemePictureBox.Image")));
            this.ThemePictureBox.Location = new System.Drawing.Point(-2, 346);
            this.ThemePictureBox.Name = "ThemePictureBox";
            this.ThemePictureBox.Size = new System.Drawing.Size(303, 340);
            this.ThemePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ThemePictureBox.TabIndex = 9;
            this.ThemePictureBox.TabStop = false;
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1183, 683);
            this.Controls.Add(this.ThemePictureBox);
            this.Controls.Add(this.PasswordPanel);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.ShopLogoPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WelcomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to the application";
            this.Load += new System.EventHandler(this.WelcomeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ShopLogoPictureBox)).EndInit();
            this.PasswordPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ThemePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ShopLogoPictureBox;
        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.Button ModifyButton;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Panel PasswordPanel;
        private System.Windows.Forms.PictureBox ThemePictureBox;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}