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
            this.ModifyButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ProductDisplayDataGridView = new System.Windows.Forms.DataGridView();
            this.OutOfStockButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ShopLogoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDisplayDataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShopLogoPictureBox
            // 
            this.ShopLogoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ShopLogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ShopLogoPictureBox.Image")));
            this.ShopLogoPictureBox.Location = new System.Drawing.Point(337, 59);
            this.ShopLogoPictureBox.Margin = new System.Windows.Forms.Padding(2);
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
            this.LogOutButton.Location = new System.Drawing.Point(691, 59);
            this.LogOutButton.Margin = new System.Windows.Forms.Padding(2);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(65, 28);
            this.LogOutButton.TabIndex = 6;
            this.LogOutButton.Text = "&Log Out";
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
            this.BackButton.Location = new System.Drawing.Point(691, 102);
            this.BackButton.Margin = new System.Windows.Forms.Padding(2);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(65, 28);
            this.BackButton.TabIndex = 7;
            this.BackButton.Text = "&Back";
            this.toolTip1.SetToolTip(this.BackButton, "Click here to go back");
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ProductCategoryLabel
            // 
            this.ProductCategoryLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProductCategoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductCategoryLabel.Location = new System.Drawing.Point(141, 152);
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
            this.ProductCategoryComboBox.Location = new System.Drawing.Point(141, 183);
            this.ProductCategoryComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.ProductCategoryComboBox.Name = "ProductCategoryComboBox";
            this.ProductCategoryComboBox.Size = new System.Drawing.Size(169, 21);
            this.ProductCategoryComboBox.TabIndex = 1;
            this.toolTip1.SetToolTip(this.ProductCategoryComboBox, "Please select a Category you want to delete/modify");
            this.ProductCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.ProductCategoryComboBox_SelectedIndexChanged);
            // 
            // ProductLocationModifyFormLabel
            // 
            this.ProductLocationModifyFormLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProductLocationModifyFormLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductLocationModifyFormLabel.Location = new System.Drawing.Point(138, 268);
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
            this.ProductLocationModifyFormComboBox.Location = new System.Drawing.Point(141, 299);
            this.ProductLocationModifyFormComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.ProductLocationModifyFormComboBox.Name = "ProductLocationModifyFormComboBox";
            this.ProductLocationModifyFormComboBox.Size = new System.Drawing.Size(169, 21);
            this.ProductLocationModifyFormComboBox.TabIndex = 2;
            this.toolTip1.SetToolTip(this.ProductLocationModifyFormComboBox, "Please select a Location you want to delete/modify");
            this.ProductLocationModifyFormComboBox.SelectedIndexChanged += new System.EventHandler(this.ProductLocationModifyFormComboBox_SelectedIndexChanged);
            // 
            // ChooseProductsModifyScreenLabel
            // 
            this.ChooseProductsModifyScreenLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ChooseProductsModifyScreenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseProductsModifyScreenLabel.Location = new System.Drawing.Point(497, 152);
            this.ChooseProductsModifyScreenLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ChooseProductsModifyScreenLabel.Name = "ChooseProductsModifyScreenLabel";
            this.ChooseProductsModifyScreenLabel.Size = new System.Drawing.Size(237, 29);
            this.ChooseProductsModifyScreenLabel.TabIndex = 11;
            this.ChooseProductsModifyScreenLabel.Text = "Choose from products below:";
            // 
            // ModifyButton
            // 
            this.ModifyButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ModifyButton.BackColor = System.Drawing.Color.DarkBlue;
            this.ModifyButton.Enabled = false;
            this.ModifyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyButton.ForeColor = System.Drawing.Color.White;
            this.ModifyButton.Location = new System.Drawing.Point(566, 361);
            this.ModifyButton.Margin = new System.Windows.Forms.Padding(2);
            this.ModifyButton.Name = "ModifyButton";
            this.ModifyButton.Size = new System.Drawing.Size(65, 28);
            this.ModifyButton.TabIndex = 4;
            this.ModifyButton.Text = "&Modify";
            this.toolTip1.SetToolTip(this.ModifyButton, "Click here to Modify");
            this.ModifyButton.UseVisualStyleBackColor = false;
            this.ModifyButton.Click += new System.EventHandler(this.ModifyButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DeleteButton.BackColor = System.Drawing.Color.DarkBlue;
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.ForeColor = System.Drawing.Color.White;
            this.DeleteButton.Location = new System.Drawing.Point(389, 361);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(149, 28);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "&Delete (Other Reasons)";
            this.toolTip1.SetToolTip(this.DeleteButton, "Click here to Modify");
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Visible = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ProductDisplayDataGridView
            // 
            this.ProductDisplayDataGridView.AllowUserToAddRows = false;
            this.ProductDisplayDataGridView.AllowUserToDeleteRows = false;
            this.ProductDisplayDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProductDisplayDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductDisplayDataGridView.Location = new System.Drawing.Point(389, 183);
            this.ProductDisplayDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.ProductDisplayDataGridView.Name = "ProductDisplayDataGridView";
            this.ProductDisplayDataGridView.RowHeadersWidth = 62;
            this.ProductDisplayDataGridView.RowTemplate.Height = 28;
            this.ProductDisplayDataGridView.Size = new System.Drawing.Size(403, 153);
            this.ProductDisplayDataGridView.TabIndex = 16;
            this.toolTip1.SetToolTip(this.ProductDisplayDataGridView, "Select the product from the list to proceed");
            this.ProductDisplayDataGridView.SelectionChanged += new System.EventHandler(this.ProductDisplayDataGridView_SelectionChanged);
            // 
            // OutOfStockButton
            // 
            this.OutOfStockButton.BackColor = System.Drawing.Color.DarkBlue;
            this.OutOfStockButton.Enabled = false;
            this.OutOfStockButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.OutOfStockButton.ForeColor = System.Drawing.Color.White;
            this.OutOfStockButton.Location = new System.Drawing.Point(668, 361);
            this.OutOfStockButton.Name = "OutOfStockButton";
            this.OutOfStockButton.Size = new System.Drawing.Size(110, 28);
            this.OutOfStockButton.TabIndex = 5;
            this.OutOfStockButton.Text = "&Delete (Sold)";
            this.toolTip1.SetToolTip(this.OutOfStockButton, "Click here to mark an item as out of stock on website");
            this.OutOfStockButton.UseVisualStyleBackColor = false;
            this.OutOfStockButton.Click += new System.EventHandler(this.OutOfStockButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(841, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // ModifyScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(841, 487);
            this.Controls.Add(this.OutOfStockButton);
            this.Controls.Add(this.ProductDisplayDataGridView);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.ModifyButton);
            this.Controls.Add(this.ChooseProductsModifyScreenLabel);
            this.Controls.Add(this.ProductLocationModifyFormComboBox);
            this.Controls.Add(this.ProductLocationModifyFormLabel);
            this.Controls.Add(this.ProductCategoryComboBox);
            this.Controls.Add(this.ProductCategoryLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.ShopLogoPictureBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ModifyScreen";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 13);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to the modify screen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModifyScreen_FormClosing_1);
            this.Load += new System.EventHandler(this.ModifyScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ShopLogoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductDisplayDataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Button ModifyButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.DataGridView ProductDisplayDataGridView;
        private System.Windows.Forms.Button OutOfStockButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}