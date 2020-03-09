namespace St_Vincent_De_Paul_Society
{
    partial class UploadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadForm));
            this.ShopLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.ProductNamePanel = new System.Windows.Forms.Panel();
            this.ProductNameTextBox = new System.Windows.Forms.TextBox();
            this.ProductNameLabel = new System.Windows.Forms.Label();
            this.ProductDescriptionPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ProductDescriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ProductDescriptionLabel = new System.Windows.Forms.Label();
            this.ThemePictureBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DeletePictureButton = new System.Windows.Forms.Button();
            this.ImageListBox = new System.Windows.Forms.ListBox();
            this.AddMorePicturesButton = new System.Windows.Forms.Button();
            this.ImageLabel = new System.Windows.Forms.Label();
            this.AddPhotosPictureBox = new System.Windows.Forms.PictureBox();
            this.AddPhotosButton = new System.Windows.Forms.Button();
            this.ImagePictureBox = new System.Windows.Forms.PictureBox();
            this.ProductSizeMainPanel = new System.Windows.Forms.Panel();
            this.ProductSizeLabel = new System.Windows.Forms.Label();
            this.ProductSizeRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ProductDetailsMessageLabel = new System.Windows.Forms.Label();
            this.UploadButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ModifyUploadPageButton = new System.Windows.Forms.Button();
            this.ProductPriceLabel = new System.Windows.Forms.Label();
            this.ProductPriceTextBox = new System.Windows.Forms.TextBox();
            this.ProductPricePanel = new System.Windows.Forms.Panel();
            this.ProductTypeLabel = new System.Windows.Forms.Label();
            this.ProductTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ProductTypePanel = new System.Windows.Forms.Panel();
            this.ProductLocationUploadFormLabel = new System.Windows.Forms.Label();
            this.ProductLocationComboBox = new System.Windows.Forms.ComboBox();
            this.ProductLocationPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SalePriceTextBox = new System.Windows.Forms.TextBox();
            this.SalePriceLabel = new System.Windows.Forms.Label();
            this.ScrollUpButton = new System.Windows.Forms.Button();
            this.ScrollDownButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ShopLogoPictureBox)).BeginInit();
            this.ProductNamePanel.SuspendLayout();
            this.ProductDescriptionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThemePictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddPhotosPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).BeginInit();
            this.ProductSizeMainPanel.SuspendLayout();
            this.ProductPricePanel.SuspendLayout();
            this.ProductTypePanel.SuspendLayout();
            this.ProductLocationPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShopLogoPictureBox
            // 
            this.ShopLogoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ShopLogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ShopLogoPictureBox.Image")));
            this.ShopLogoPictureBox.Location = new System.Drawing.Point(440, 26);
            this.ShopLogoPictureBox.Name = "ShopLogoPictureBox";
            this.ShopLogoPictureBox.Size = new System.Drawing.Size(327, 82);
            this.ShopLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShopLogoPictureBox.TabIndex = 1;
            this.ShopLogoPictureBox.TabStop = false;
            // 
            // ProductNamePanel
            // 
            this.ProductNamePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProductNamePanel.BackColor = System.Drawing.Color.AliceBlue;
            this.ProductNamePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductNamePanel.Controls.Add(this.ProductNameTextBox);
            this.ProductNamePanel.Controls.Add(this.ProductNameLabel);
            this.ProductNamePanel.Location = new System.Drawing.Point(237, 162);
            this.ProductNamePanel.Name = "ProductNamePanel";
            this.ProductNamePanel.Size = new System.Drawing.Size(480, 62);
            this.ProductNamePanel.TabIndex = 4;
            // 
            // ProductNameTextBox
            // 
            this.ProductNameTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.ProductNameTextBox.ForeColor = System.Drawing.Color.Gray;
            this.ProductNameTextBox.Location = new System.Drawing.Point(218, 17);
            this.ProductNameTextBox.Name = "ProductNameTextBox";
            this.ProductNameTextBox.Size = new System.Drawing.Size(241, 26);
            this.ProductNameTextBox.TabIndex = 2;
            this.ProductNameTextBox.Text = "What are you selling?";
            this.ProductNameTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProductNameTextBox_MouseClick);
            this.ProductNameTextBox.Leave += new System.EventHandler(this.ProductNameTextBox_Leave);
            // 
            // ProductNameLabel
            // 
            this.ProductNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductNameLabel.Location = new System.Drawing.Point(20, 17);
            this.ProductNameLabel.Name = "ProductNameLabel";
            this.ProductNameLabel.Size = new System.Drawing.Size(176, 45);
            this.ProductNameLabel.TabIndex = 1;
            this.ProductNameLabel.Text = "Product Name:";
            // 
            // ProductDescriptionPanel
            // 
            this.ProductDescriptionPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProductDescriptionPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.ProductDescriptionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductDescriptionPanel.Controls.Add(this.label1);
            this.ProductDescriptionPanel.Controls.Add(this.ProductDescriptionRichTextBox);
            this.ProductDescriptionPanel.Controls.Add(this.ProductDescriptionLabel);
            this.ProductDescriptionPanel.Location = new System.Drawing.Point(237, 232);
            this.ProductDescriptionPanel.Name = "ProductDescriptionPanel";
            this.ProductDescriptionPanel.Size = new System.Drawing.Size(480, 220);
            this.ProductDescriptionPanel.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "max. 1000 characters";
            // 
            // ProductDescriptionRichTextBox
            // 
            this.ProductDescriptionRichTextBox.ForeColor = System.Drawing.Color.Gray;
            this.ProductDescriptionRichTextBox.Location = new System.Drawing.Point(22, 52);
            this.ProductDescriptionRichTextBox.MaxLength = 1500;
            this.ProductDescriptionRichTextBox.Name = "ProductDescriptionRichTextBox";
            this.ProductDescriptionRichTextBox.Size = new System.Drawing.Size(402, 149);
            this.ProductDescriptionRichTextBox.TabIndex = 3;
            this.ProductDescriptionRichTextBox.Text = "Describe what you are selling";
            this.ProductDescriptionRichTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProductDescriptionRichTextBox_MouseClick);
            this.ProductDescriptionRichTextBox.TextChanged += new System.EventHandler(this.ProductDescriptionRichTextBox_TextChanged);
            this.ProductDescriptionRichTextBox.Enter += new System.EventHandler(this.ProductDescriptionRichTextBox_Enter);
            this.ProductDescriptionRichTextBox.Leave += new System.EventHandler(this.ProductDescriptionRichTextBox_Leave);
            // 
            // ProductDescriptionLabel
            // 
            this.ProductDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductDescriptionLabel.Location = new System.Drawing.Point(20, 17);
            this.ProductDescriptionLabel.Name = "ProductDescriptionLabel";
            this.ProductDescriptionLabel.Size = new System.Drawing.Size(405, 45);
            this.ProductDescriptionLabel.TabIndex = 1;
            this.ProductDescriptionLabel.Text = "Product Description ";
            // 
            // ThemePictureBox
            // 
            this.ThemePictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ThemePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ThemePictureBox.Image")));
            this.ThemePictureBox.Location = new System.Drawing.Point(8, 396);
            this.ThemePictureBox.Name = "ThemePictureBox";
            this.ThemePictureBox.Size = new System.Drawing.Size(220, 340);
            this.ThemePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ThemePictureBox.TabIndex = 3;
            this.ThemePictureBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ScrollDownButton);
            this.panel1.Controls.Add(this.ScrollUpButton);
            this.panel1.Controls.Add(this.DeletePictureButton);
            this.panel1.Controls.Add(this.ImageListBox);
            this.panel1.Controls.Add(this.AddMorePicturesButton);
            this.panel1.Controls.Add(this.ImageLabel);
            this.panel1.Controls.Add(this.AddPhotosPictureBox);
            this.panel1.Controls.Add(this.AddPhotosButton);
            this.panel1.Controls.Add(this.ImagePictureBox);
            this.panel1.Location = new System.Drawing.Point(723, 162);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 458);
            this.panel1.TabIndex = 9;
            // 
            // DeletePictureButton
            // 
            this.DeletePictureButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeletePictureButton.BackColor = System.Drawing.Color.DarkBlue;
            this.DeletePictureButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeletePictureButton.ForeColor = System.Drawing.Color.White;
            this.DeletePictureButton.Location = new System.Drawing.Point(336, 356);
            this.DeletePictureButton.Name = "DeletePictureButton";
            this.DeletePictureButton.Size = new System.Drawing.Size(105, 37);
            this.DeletePictureButton.TabIndex = 17;
            this.DeletePictureButton.Text = "Delete Image";
            this.toolTip1.SetToolTip(this.DeletePictureButton, "Click here to go back");
            this.DeletePictureButton.UseVisualStyleBackColor = false;
            this.DeletePictureButton.Visible = false;
            this.DeletePictureButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ImageListBox
            // 
            this.ImageListBox.FormattingEnabled = true;
            this.ImageListBox.ItemHeight = 20;
            this.ImageListBox.Location = new System.Drawing.Point(19, 295);
            this.ImageListBox.Name = "ImageListBox";
            this.ImageListBox.Size = new System.Drawing.Size(259, 144);
            this.ImageListBox.TabIndex = 16;
            this.ImageListBox.Visible = false;
            this.ImageListBox.SelectedIndexChanged += new System.EventHandler(this.ImageListBox_SelectedIndexChanged);
            // 
            // AddMorePicturesButton
            // 
            this.AddMorePicturesButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddMorePicturesButton.BackColor = System.Drawing.Color.DarkBlue;
            this.AddMorePicturesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddMorePicturesButton.ForeColor = System.Drawing.Color.White;
            this.AddMorePicturesButton.Location = new System.Drawing.Point(51, 17);
            this.AddMorePicturesButton.Name = "AddMorePicturesButton";
            this.AddMorePicturesButton.Size = new System.Drawing.Size(328, 66);
            this.AddMorePicturesButton.TabIndex = 15;
            this.AddMorePicturesButton.Text = "Add more Images";
            this.toolTip1.SetToolTip(this.AddMorePicturesButton, "Click here to go back");
            this.AddMorePicturesButton.UseVisualStyleBackColor = false;
            this.AddMorePicturesButton.Visible = false;
            this.AddMorePicturesButton.Click += new System.EventHandler(this.AddMorePicturesButton_Click);
            // 
            // ImageLabel
            // 
            this.ImageLabel.Location = new System.Drawing.Point(136, 86);
            this.ImageLabel.Name = "ImageLabel";
            this.ImageLabel.Size = new System.Drawing.Size(184, 20);
            this.ImageLabel.TabIndex = 3;
            this.ImageLabel.Text = "Image appears here";
            // 
            // AddPhotosPictureBox
            // 
            this.AddPhotosPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("AddPhotosPictureBox.Image")));
            this.AddPhotosPictureBox.Location = new System.Drawing.Point(70, 29);
            this.AddPhotosPictureBox.Name = "AddPhotosPictureBox";
            this.AddPhotosPictureBox.Size = new System.Drawing.Size(76, 45);
            this.AddPhotosPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AddPhotosPictureBox.TabIndex = 1;
            this.AddPhotosPictureBox.TabStop = false;
            this.AddPhotosPictureBox.Click += new System.EventHandler(this.AddPhotosPictureBox_Click);
            // 
            // AddPhotosButton
            // 
            this.AddPhotosButton.BackColor = System.Drawing.Color.DarkBlue;
            this.AddPhotosButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPhotosButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AddPhotosButton.Location = new System.Drawing.Point(51, 17);
            this.AddPhotosButton.Name = "AddPhotosButton";
            this.AddPhotosButton.Size = new System.Drawing.Size(328, 66);
            this.AddPhotosButton.TabIndex = 7;
            this.AddPhotosButton.Text = "             Add Photo";
            this.toolTip1.SetToolTip(this.AddPhotosButton, "Click here to upload an image");
            this.AddPhotosButton.UseVisualStyleBackColor = false;
            this.AddPhotosButton.Click += new System.EventHandler(this.AddPhotosButton_Click);
            // 
            // ImagePictureBox
            // 
            this.ImagePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImagePictureBox.Location = new System.Drawing.Point(19, 111);
            this.ImagePictureBox.Name = "ImagePictureBox";
            this.ImagePictureBox.Size = new System.Drawing.Size(402, 178);
            this.ImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagePictureBox.TabIndex = 2;
            this.ImagePictureBox.TabStop = false;
            // 
            // ProductSizeMainPanel
            // 
            this.ProductSizeMainPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProductSizeMainPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.ProductSizeMainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductSizeMainPanel.Controls.Add(this.ProductSizeLabel);
            this.ProductSizeMainPanel.Controls.Add(this.ProductSizeRichTextBox);
            this.ProductSizeMainPanel.Location = new System.Drawing.Point(723, 626);
            this.ProductSizeMainPanel.Name = "ProductSizeMainPanel";
            this.ProductSizeMainPanel.Size = new System.Drawing.Size(448, 59);
            this.ProductSizeMainPanel.TabIndex = 10;
            // 
            // ProductSizeLabel
            // 
            this.ProductSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductSizeLabel.Location = new System.Drawing.Point(3, 12);
            this.ProductSizeLabel.Name = "ProductSizeLabel";
            this.ProductSizeLabel.Size = new System.Drawing.Size(170, 45);
            this.ProductSizeLabel.TabIndex = 4;
            this.ProductSizeLabel.Text = "Product Size:";
            // 
            // ProductSizeRichTextBox
            // 
            this.ProductSizeRichTextBox.ForeColor = System.Drawing.Color.Gray;
            this.ProductSizeRichTextBox.Location = new System.Drawing.Point(232, 12);
            this.ProductSizeRichTextBox.Name = "ProductSizeRichTextBox";
            this.ProductSizeRichTextBox.Size = new System.Drawing.Size(210, 32);
            this.ProductSizeRichTextBox.TabIndex = 8;
            this.ProductSizeRichTextBox.Text = "if applicable";
            this.ProductSizeRichTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProductSizeRichTextBox_MouseClick);
            this.ProductSizeRichTextBox.Leave += new System.EventHandler(this.ProductSizeRichTextBox_Leave);
            // 
            // ProductDetailsMessageLabel
            // 
            this.ProductDetailsMessageLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProductDetailsMessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductDetailsMessageLabel.Location = new System.Drawing.Point(302, 129);
            this.ProductDetailsMessageLabel.Name = "ProductDetailsMessageLabel";
            this.ProductDetailsMessageLabel.Size = new System.Drawing.Size(426, 23);
            this.ProductDetailsMessageLabel.TabIndex = 11;
            this.ProductDetailsMessageLabel.Text = "Please enter the product details below:";
            // 
            // UploadButton
            // 
            this.UploadButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UploadButton.BackColor = System.Drawing.Color.DarkBlue;
            this.UploadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UploadButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UploadButton.Location = new System.Drawing.Point(723, 693);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(130, 45);
            this.UploadButton.TabIndex = 9;
            this.UploadButton.Text = "Upload";
            this.toolTip1.SetToolTip(this.UploadButton, "Click here to Confirm");
            this.UploadButton.UseVisualStyleBackColor = false;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BackButton.BackColor = System.Drawing.Color.DarkBlue;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(1005, 93);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(98, 43);
            this.BackButton.TabIndex = 14;
            this.BackButton.Text = "Back";
            this.toolTip1.SetToolTip(this.BackButton, "Click here to go back");
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // LogOutButton
            // 
            this.LogOutButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogOutButton.BackColor = System.Drawing.Color.DarkBlue;
            this.LogOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutButton.ForeColor = System.Drawing.Color.White;
            this.LogOutButton.Location = new System.Drawing.Point(1005, 26);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(98, 43);
            this.LogOutButton.TabIndex = 13;
            this.LogOutButton.Text = "Log Out";
            this.toolTip1.SetToolTip(this.LogOutButton, "Click here to Log out");
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // ModifyUploadPageButton
            // 
            this.ModifyUploadPageButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ModifyUploadPageButton.BackColor = System.Drawing.Color.DarkBlue;
            this.ModifyUploadPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyUploadPageButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ModifyUploadPageButton.Location = new System.Drawing.Point(723, 693);
            this.ModifyUploadPageButton.Name = "ModifyUploadPageButton";
            this.ModifyUploadPageButton.Size = new System.Drawing.Size(130, 45);
            this.ModifyUploadPageButton.TabIndex = 15;
            this.ModifyUploadPageButton.Text = "Modify";
            this.toolTip1.SetToolTip(this.ModifyUploadPageButton, "Click here to Confirm");
            this.ModifyUploadPageButton.UseVisualStyleBackColor = false;
            this.ModifyUploadPageButton.Visible = false;
            this.ModifyUploadPageButton.Click += new System.EventHandler(this.ModifyUploadPageButton_Click);
            // 
            // ProductPriceLabel
            // 
            this.ProductPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductPriceLabel.Location = new System.Drawing.Point(20, 17);
            this.ProductPriceLabel.Name = "ProductPriceLabel";
            this.ProductPriceLabel.Size = new System.Drawing.Size(176, 45);
            this.ProductPriceLabel.TabIndex = 1;
            this.ProductPriceLabel.Text = "Product Price:";
            // 
            // ProductPriceTextBox
            // 
            this.ProductPriceTextBox.ForeColor = System.Drawing.Color.Gray;
            this.ProductPriceTextBox.Location = new System.Drawing.Point(240, 18);
            this.ProductPriceTextBox.Name = "ProductPriceTextBox";
            this.ProductPriceTextBox.Size = new System.Drawing.Size(218, 26);
            this.ProductPriceTextBox.TabIndex = 4;
            this.ProductPriceTextBox.Text = "Product Price";
            this.ProductPriceTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProductPriceTextBox_MouseClick);
            this.ProductPriceTextBox.Enter += new System.EventHandler(this.ProductPriceTextBox_Enter);
            this.ProductPriceTextBox.Leave += new System.EventHandler(this.ProductPriceTextBox_Leave);
            // 
            // ProductPricePanel
            // 
            this.ProductPricePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProductPricePanel.BackColor = System.Drawing.Color.AliceBlue;
            this.ProductPricePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductPricePanel.Controls.Add(this.ProductPriceTextBox);
            this.ProductPricePanel.Controls.Add(this.ProductPriceLabel);
            this.ProductPricePanel.Location = new System.Drawing.Point(237, 456);
            this.ProductPricePanel.Name = "ProductPricePanel";
            this.ProductPricePanel.Size = new System.Drawing.Size(480, 62);
            this.ProductPricePanel.TabIndex = 6;
            // 
            // ProductTypeLabel
            // 
            this.ProductTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductTypeLabel.Location = new System.Drawing.Point(20, 17);
            this.ProductTypeLabel.Name = "ProductTypeLabel";
            this.ProductTypeLabel.Size = new System.Drawing.Size(176, 45);
            this.ProductTypeLabel.TabIndex = 1;
            this.ProductTypeLabel.Text = "Product Type:";
            // 
            // ProductTypeComboBox
            // 
            this.ProductTypeComboBox.FormattingEnabled = true;
            this.ProductTypeComboBox.Location = new System.Drawing.Point(240, 17);
            this.ProductTypeComboBox.Name = "ProductTypeComboBox";
            this.ProductTypeComboBox.Size = new System.Drawing.Size(218, 28);
            this.ProductTypeComboBox.TabIndex = 5;
            // 
            // ProductTypePanel
            // 
            this.ProductTypePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProductTypePanel.BackColor = System.Drawing.Color.AliceBlue;
            this.ProductTypePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductTypePanel.Controls.Add(this.ProductTypeComboBox);
            this.ProductTypePanel.Controls.Add(this.ProductTypeLabel);
            this.ProductTypePanel.Location = new System.Drawing.Point(237, 608);
            this.ProductTypePanel.Name = "ProductTypePanel";
            this.ProductTypePanel.Size = new System.Drawing.Size(480, 62);
            this.ProductTypePanel.TabIndex = 7;
            // 
            // ProductLocationUploadFormLabel
            // 
            this.ProductLocationUploadFormLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductLocationUploadFormLabel.Location = new System.Drawing.Point(20, 17);
            this.ProductLocationUploadFormLabel.Name = "ProductLocationUploadFormLabel";
            this.ProductLocationUploadFormLabel.Size = new System.Drawing.Size(244, 45);
            this.ProductLocationUploadFormLabel.TabIndex = 1;
            this.ProductLocationUploadFormLabel.Text = "Product Location:";
            // 
            // ProductLocationComboBox
            // 
            this.ProductLocationComboBox.FormattingEnabled = true;
            this.ProductLocationComboBox.Location = new System.Drawing.Point(240, 17);
            this.ProductLocationComboBox.Name = "ProductLocationComboBox";
            this.ProductLocationComboBox.Size = new System.Drawing.Size(218, 28);
            this.ProductLocationComboBox.TabIndex = 6;
            // 
            // ProductLocationPanel
            // 
            this.ProductLocationPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProductLocationPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.ProductLocationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductLocationPanel.Controls.Add(this.ProductLocationComboBox);
            this.ProductLocationPanel.Controls.Add(this.ProductLocationUploadFormLabel);
            this.ProductLocationPanel.Location = new System.Drawing.Point(237, 675);
            this.ProductLocationPanel.Name = "ProductLocationPanel";
            this.ProductLocationPanel.Size = new System.Drawing.Size(480, 62);
            this.ProductLocationPanel.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.SalePriceTextBox);
            this.panel2.Controls.Add(this.SalePriceLabel);
            this.panel2.Location = new System.Drawing.Point(237, 529);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(480, 62);
            this.panel2.TabIndex = 16;
            // 
            // SalePriceTextBox
            // 
            this.SalePriceTextBox.ForeColor = System.Drawing.Color.Gray;
            this.SalePriceTextBox.Location = new System.Drawing.Point(240, 18);
            this.SalePriceTextBox.Name = "SalePriceTextBox";
            this.SalePriceTextBox.Size = new System.Drawing.Size(218, 26);
            this.SalePriceTextBox.TabIndex = 4;
            this.SalePriceTextBox.Text = "Sale Price";
            this.SalePriceTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SalePriceTextBox_MouseClick);
            this.SalePriceTextBox.Enter += new System.EventHandler(this.SalePriceTextBox_Enter);
            this.SalePriceTextBox.Leave += new System.EventHandler(this.SalePriceTextBox_Leave);
            // 
            // SalePriceLabel
            // 
            this.SalePriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalePriceLabel.Location = new System.Drawing.Point(20, 17);
            this.SalePriceLabel.Name = "SalePriceLabel";
            this.SalePriceLabel.Size = new System.Drawing.Size(176, 45);
            this.SalePriceLabel.TabIndex = 1;
            this.SalePriceLabel.Text = "Sale Price:";
            // 
            // ScrollUpButton
            // 
            this.ScrollUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScrollUpButton.Location = new System.Drawing.Point(284, 330);
            this.ScrollUpButton.Name = "ScrollUpButton";
            this.ScrollUpButton.Size = new System.Drawing.Size(46, 37);
            this.ScrollUpButton.TabIndex = 18;
            this.ScrollUpButton.Text = "ʌ";
            this.ScrollUpButton.UseVisualStyleBackColor = true;
            this.ScrollUpButton.Visible = false;
            this.ScrollUpButton.Click += new System.EventHandler(this.ScrollUpButton_Click);
            // 
            // ScrollDownButton
            // 
            this.ScrollDownButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScrollDownButton.Location = new System.Drawing.Point(284, 373);
            this.ScrollDownButton.Name = "ScrollDownButton";
            this.ScrollDownButton.Size = new System.Drawing.Size(46, 38);
            this.ScrollDownButton.TabIndex = 19;
            this.ScrollDownButton.Text = "V";
            this.ScrollDownButton.UseVisualStyleBackColor = true;
            this.ScrollDownButton.Visible = false;
            this.ScrollDownButton.Click += new System.EventHandler(this.ScrollDownButton_Click);
            // 
            // UploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1184, 839);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ModifyUploadPageButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.ProductDetailsMessageLabel);
            this.Controls.Add(this.ProductSizeMainPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ProductLocationPanel);
            this.Controls.Add(this.ProductTypePanel);
            this.Controls.Add(this.ProductPricePanel);
            this.Controls.Add(this.ThemePictureBox);
            this.Controls.Add(this.ProductDescriptionPanel);
            this.Controls.Add(this.ProductNamePanel);
            this.Controls.Add(this.ShopLogoPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UploadForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Welcome to the product upload page";
            this.Load += new System.EventHandler(this.UploadForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ShopLogoPictureBox)).EndInit();
            this.ProductNamePanel.ResumeLayout(false);
            this.ProductNamePanel.PerformLayout();
            this.ProductDescriptionPanel.ResumeLayout(false);
            this.ProductDescriptionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThemePictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddPhotosPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).EndInit();
            this.ProductSizeMainPanel.ResumeLayout(false);
            this.ProductPricePanel.ResumeLayout(false);
            this.ProductPricePanel.PerformLayout();
            this.ProductTypePanel.ResumeLayout(false);
            this.ProductLocationPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ShopLogoPictureBox;
        private System.Windows.Forms.Panel ProductNamePanel;
        private System.Windows.Forms.TextBox ProductNameTextBox;
        private System.Windows.Forms.Label ProductNameLabel;
        private System.Windows.Forms.Panel ProductDescriptionPanel;
        private System.Windows.Forms.Label ProductDescriptionLabel;
        private System.Windows.Forms.PictureBox ThemePictureBox;
        private System.Windows.Forms.RichTextBox ProductDescriptionRichTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox AddPhotosPictureBox;
        private System.Windows.Forms.Button AddPhotosButton;
        private System.Windows.Forms.PictureBox ImagePictureBox;
        private System.Windows.Forms.Label ImageLabel;
        private System.Windows.Forms.Panel ProductSizeMainPanel;
        private System.Windows.Forms.Label ProductSizeLabel;
        private System.Windows.Forms.RichTextBox ProductSizeRichTextBox;
        private System.Windows.Forms.Label ProductDetailsMessageLabel;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddMorePicturesButton;
        private System.Windows.Forms.Button ModifyUploadPageButton;
        private System.Windows.Forms.ListBox ImageListBox;
        private System.Windows.Forms.Button DeletePictureButton;
        private System.Windows.Forms.Label ProductPriceLabel;
        private System.Windows.Forms.TextBox ProductPriceTextBox;
        private System.Windows.Forms.Panel ProductPricePanel;
        private System.Windows.Forms.Label ProductTypeLabel;
        private System.Windows.Forms.ComboBox ProductTypeComboBox;
        private System.Windows.Forms.Panel ProductTypePanel;
        private System.Windows.Forms.Label ProductLocationUploadFormLabel;
        private System.Windows.Forms.ComboBox ProductLocationComboBox;
        private System.Windows.Forms.Panel ProductLocationPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox SalePriceTextBox;
        private System.Windows.Forms.Label SalePriceLabel;
        private System.Windows.Forms.Button ScrollDownButton;
        private System.Windows.Forms.Button ScrollUpButton;
    }
}