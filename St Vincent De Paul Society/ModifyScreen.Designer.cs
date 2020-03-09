namespace St_Vincent_De_Paul_Society
{
    partial class ModifyScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyScreen));
            this.ShopLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.ProductCategoryLabel = new System.Windows.Forms.Label();
            this.ProductCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.ProductLocationModifyFormLabel = new System.Windows.Forms.Label();
            this.ProductLocationModifyFormComboBox = new System.Windows.Forms.ComboBox();
            this.ChooseProductsModifyScreenLabel = new System.Windows.Forms.Label();
            this.ChooseProductsModifyScreenListBox = new System.Windows.Forms.ListBox();
            this.ModifyButton = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ShopLogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ShopLogoPictureBox
            // 
            this.ShopLogoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ShopLogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ShopLogoPictureBox.Image")));
            this.ShopLogoPictureBox.Location = new System.Drawing.Point(322, 8);
            this.ShopLogoPictureBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ShopLogoPictureBox.Name = "ShopLogoPictureBox";
            this.ShopLogoPictureBox.Size = new System.Drawing.Size(218, 53);
            this.ShopLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShopLogoPictureBox.TabIndex = 2;
            this.ShopLogoPictureBox.TabStop = false;
            // 
            // LogOutButton
            // 
            this.LogOutButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LogOutButton.BackColor = System.Drawing.Color.DarkBlue;
            this.LogOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutButton.ForeColor = System.Drawing.Color.White;
            this.LogOutButton.Location = new System.Drawing.Point(676, 8);
            this.LogOutButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(65, 28);
            this.LogOutButton.TabIndex = 5;
            this.LogOutButton.Text = "Log Out";
            this.toolTip1.SetToolTip(this.LogOutButton, "Click here to Log out");
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BackButton.BackColor = System.Drawing.Color.DarkBlue;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(676, 51);
            this.BackButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(65, 28);
            this.BackButton.TabIndex = 6;
            this.BackButton.Text = "Back";
            this.toolTip1.SetToolTip(this.BackButton, "Click here to go back");
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ProductCategoryLabel
            // 
            this.ProductCategoryLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProductCategoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductCategoryLabel.Location = new System.Drawing.Point(126, 101);
            this.ProductCategoryLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProductCategoryLabel.Name = "ProductCategoryLabel";
            this.ProductCategoryLabel.Size = new System.Drawing.Size(263, 29);
            this.ProductCategoryLabel.TabIndex = 7;
            this.ProductCategoryLabel.Text = "Choose Product Category:";
            // 
            // ProductCategoryComboBox
            // 
            this.ProductCategoryComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProductCategoryComboBox.FormattingEnabled = true;
            this.ProductCategoryComboBox.Location = new System.Drawing.Point(126, 132);
            this.ProductCategoryComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ProductCategoryComboBox.Name = "ProductCategoryComboBox";
            this.ProductCategoryComboBox.Size = new System.Drawing.Size(169, 21);
            this.ProductCategoryComboBox.TabIndex = 8;
            this.ProductCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.ProductCategoryComboBox_SelectedIndexChanged);
            // 
            // ProductLocationModifyFormLabel
            // 
            this.ProductLocationModifyFormLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProductLocationModifyFormLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductLocationModifyFormLabel.Location = new System.Drawing.Point(123, 217);
            this.ProductLocationModifyFormLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProductLocationModifyFormLabel.Name = "ProductLocationModifyFormLabel";
            this.ProductLocationModifyFormLabel.Size = new System.Drawing.Size(267, 29);
            this.ProductLocationModifyFormLabel.TabIndex = 9;
            this.ProductLocationModifyFormLabel.Text = "Choose Product Location:";
            // 
            // ProductLocationModifyFormComboBox
            // 
            this.ProductLocationModifyFormComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProductLocationModifyFormComboBox.Enabled = false;
            this.ProductLocationModifyFormComboBox.FormattingEnabled = true;
            this.ProductLocationModifyFormComboBox.Location = new System.Drawing.Point(126, 248);
            this.ProductLocationModifyFormComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ProductLocationModifyFormComboBox.Name = "ProductLocationModifyFormComboBox";
            this.ProductLocationModifyFormComboBox.Size = new System.Drawing.Size(169, 21);
            this.ProductLocationModifyFormComboBox.TabIndex = 10;
            this.ProductLocationModifyFormComboBox.SelectedIndexChanged += new System.EventHandler(this.ProductLocationModifyFormComboBox_SelectedIndexChanged);
            // 
            // ChooseProductsModifyScreenLabel
            // 
            this.ChooseProductsModifyScreenLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ChooseProductsModifyScreenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseProductsModifyScreenLabel.Location = new System.Drawing.Point(370, 101);
            this.ChooseProductsModifyScreenLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ChooseProductsModifyScreenLabel.Name = "ChooseProductsModifyScreenLabel";
            this.ChooseProductsModifyScreenLabel.Size = new System.Drawing.Size(237, 29);
            this.ChooseProductsModifyScreenLabel.TabIndex = 11;
            this.ChooseProductsModifyScreenLabel.Text = "Choose from products below:";
            // 
            // ChooseProductsModifyScreenListBox
            // 
            this.ChooseProductsModifyScreenListBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ChooseProductsModifyScreenListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseProductsModifyScreenListBox.FormattingEnabled = true;
            this.ChooseProductsModifyScreenListBox.ItemHeight = 16;
            this.ChooseProductsModifyScreenListBox.Location = new System.Drawing.Point(373, 162);
            this.ChooseProductsModifyScreenListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ChooseProductsModifyScreenListBox.Name = "ChooseProductsModifyScreenListBox";
            this.ChooseProductsModifyScreenListBox.Size = new System.Drawing.Size(369, 100);
            this.ChooseProductsModifyScreenListBox.TabIndex = 12;
            // 
            // ModifyButton
            // 
            this.ModifyButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ModifyButton.BackColor = System.Drawing.Color.DarkBlue;
            this.ModifyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyButton.ForeColor = System.Drawing.Color.White;
            this.ModifyButton.Location = new System.Drawing.Point(676, 310);
            this.ModifyButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ModifyButton.Name = "ModifyButton";
            this.ModifyButton.Size = new System.Drawing.Size(65, 28);
            this.ModifyButton.TabIndex = 13;
            this.ModifyButton.Text = "Modify";
            this.toolTip1.SetToolTip(this.ModifyButton, "Click here to Modify");
            this.ModifyButton.UseVisualStyleBackColor = false;
            this.ModifyButton.Click += new System.EventHandler(this.ModifyButton_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SearchTextBox.Location = new System.Drawing.Point(373, 132);
            this.SearchTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(168, 20);
            this.SearchTextBox.TabIndex = 14;
            this.SearchTextBox.Text = "Type anything to search";
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            this.SearchTextBox.Enter += new System.EventHandler(this.SearchTextBox_Enter);
            this.SearchTextBox.Leave += new System.EventHandler(this.SearchTextBox_Leave);
            // 
            // ModifyScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(863, 487);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.ModifyButton);
            this.Controls.Add(this.ChooseProductsModifyScreenListBox);
            this.Controls.Add(this.ChooseProductsModifyScreenLabel);
            this.Controls.Add(this.ProductLocationModifyFormComboBox);
            this.Controls.Add(this.ProductLocationModifyFormLabel);
            this.Controls.Add(this.ProductCategoryComboBox);
            this.Controls.Add(this.ProductCategoryLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.ShopLogoPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ModifyScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to the modify screen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModifyScreen_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ShopLogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ShopLogoPictureBox;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label ProductCategoryLabel;
        private System.Windows.Forms.ComboBox ProductCategoryComboBox;
        private System.Windows.Forms.Label ProductLocationModifyFormLabel;
        private System.Windows.Forms.ComboBox ProductLocationModifyFormComboBox;
        private System.Windows.Forms.Label ChooseProductsModifyScreenLabel;
        private System.Windows.Forms.ListBox ChooseProductsModifyScreenListBox;
        private System.Windows.Forms.Button ModifyButton;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}