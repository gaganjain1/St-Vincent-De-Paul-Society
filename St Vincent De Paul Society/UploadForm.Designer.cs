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
            this.ProductNamePanel = new System.Windows.Forms.Panel();
            this.ProductNameTextBox = new System.Windows.Forms.TextBox();
            this.ProductNameLabel = new System.Windows.Forms.Label();
            this.ProductDescriptionPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ProductDescriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ProductDescriptionLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ScrollDownPictureBox = new System.Windows.Forms.PictureBox();
            this.ScrollUpPictureBox = new System.Windows.Forms.PictureBox();
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
            this.ProductTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ProductLocationComboBox = new System.Windows.Forms.ComboBox();
            this.ProductPriceLabel = new System.Windows.Forms.Label();
            this.ProductPriceTextBox = new System.Windows.Forms.TextBox();
            this.ProductPricePanel = new System.Windows.Forms.Panel();
            this.ProductTypeLabel = new System.Windows.Forms.Label();
            this.ProductTypePanel = new System.Windows.Forms.Panel();
            this.ProductLocationUploadFormLabel = new System.Windows.Forms.Label();
            this.ProductLocationPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SalePriceTextBox = new System.Windows.Forms.TextBox();
            this.SalePriceLabel = new System.Windows.Forms.Label();
            this.ThemePictureBox = new System.Windows.Forms.PictureBox();
            this.ShopLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.MandatoryLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ProductNamePanel.SuspendLayout();
            this.ProductDescriptionPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScrollDownPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScrollUpPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddPhotosPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).BeginInit();
            this.ProductSizeMainPanel.SuspendLayout();
            this.ProductPricePanel.SuspendLayout();
            this.ProductTypePanel.SuspendLayout();
            this.ProductLocationPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThemePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShopLogoPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductNamePanel
            // 
            this.ProductNamePanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProductNamePanel.BackColor = System.Drawing.Color.AliceBlue;
            this.ProductNamePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductNamePanel.Controls.Add(this.ProductNameTextBox);
            this.ProductNamePanel.Controls.Add(this.ProductNameLabel);
            this.ProductNamePanel.Location = new System.Drawing.Point(161, 155);
            this.ProductNamePanel.Margin = new System.Windows.Forms.Padding(2);
            this.ProductNamePanel.Name = "ProductNamePanel";
            this.ProductNamePanel.Size = new System.Drawing.Size(321, 41);
            this.ProductNamePanel.TabIndex = 4;
            // 
            // ProductNameTextBox
            // 
            this.ProductNameTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.ProductNameTextBox.ForeColor = System.Drawing.Color.Gray;
            this.ProductNameTextBox.Location = new System.Drawing.Point(145, 11);
            this.ProductNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ProductNameTextBox.Name = "ProductNameTextBox";
            this.ProductNameTextBox.Size = new System.Drawing.Size(162, 20);
            this.ProductNameTextBox.TabIndex = 1;
            this.ProductNameTextBox.Text = "What are you selling?";
            this.ProductNameTextBox.Enter += new System.EventHandler(this.ProductNameTextBox_Enter);
            this.ProductNameTextBox.Leave += new System.EventHandler(this.ProductNameTextBox_Leave);
            // 
            // ProductNameLabel
            // 
            this.ProductNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductNameLabel.Location = new System.Drawing.Point(13, 11);
            this.ProductNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProductNameLabel.Name = "ProductNameLabel";
            this.ProductNameLabel.Size = new System.Drawing.Size(139, 29);
            this.ProductNameLabel.TabIndex = 1;
            this.ProductNameLabel.Text = "Product Name*:";
            // 
            // ProductDescriptionPanel
            // 
            this.ProductDescriptionPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProductDescriptionPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.ProductDescriptionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductDescriptionPanel.Controls.Add(this.label1);
            this.ProductDescriptionPanel.Controls.Add(this.ProductDescriptionRichTextBox);
            this.ProductDescriptionPanel.Controls.Add(this.ProductDescriptionLabel);
            this.ProductDescriptionPanel.Location = new System.Drawing.Point(161, 201);
            this.ProductDescriptionPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ProductDescriptionPanel.Name = "ProductDescriptionPanel";
            this.ProductDescriptionPanel.Size = new System.Drawing.Size(321, 144);
            this.ProductDescriptionPanel.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "max. 1000 characters";
            // 
            // ProductDescriptionRichTextBox
            // 
            this.ProductDescriptionRichTextBox.ForeColor = System.Drawing.Color.Gray;
            this.ProductDescriptionRichTextBox.Location = new System.Drawing.Point(15, 34);
            this.ProductDescriptionRichTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ProductDescriptionRichTextBox.MaxLength = 1500;
            this.ProductDescriptionRichTextBox.Name = "ProductDescriptionRichTextBox";
            this.ProductDescriptionRichTextBox.Size = new System.Drawing.Size(269, 98);
            this.ProductDescriptionRichTextBox.TabIndex = 2;
            this.ProductDescriptionRichTextBox.Text = "Describe what you are selling";
            this.ProductDescriptionRichTextBox.Enter += new System.EventHandler(this.ProductDescriptionRichTextBox_Enter);
            this.ProductDescriptionRichTextBox.Leave += new System.EventHandler(this.ProductDescriptionRichTextBox_Leave);
            // 
            // ProductDescriptionLabel
            // 
            this.ProductDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductDescriptionLabel.Location = new System.Drawing.Point(13, 11);
            this.ProductDescriptionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProductDescriptionLabel.Name = "ProductDescriptionLabel";
            this.ProductDescriptionLabel.Size = new System.Drawing.Size(270, 29);
            this.ProductDescriptionLabel.TabIndex = 1;
            this.ProductDescriptionLabel.Text = "Product Description* ";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ScrollDownPictureBox);
            this.panel1.Controls.Add(this.ScrollUpPictureBox);
            this.panel1.Controls.Add(this.DeletePictureButton);
            this.panel1.Controls.Add(this.ImageListBox);
            this.panel1.Controls.Add(this.AddMorePicturesButton);
            this.panel1.Controls.Add(this.ImageLabel);
            this.panel1.Controls.Add(this.AddPhotosPictureBox);
            this.panel1.Controls.Add(this.AddPhotosButton);
            this.panel1.Controls.Add(this.ImagePictureBox);
            this.panel1.Location = new System.Drawing.Point(485, 155);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 298);
            this.panel1.TabIndex = 9;
            // 
            // ScrollDownPictureBox
            // 
            this.ScrollDownPictureBox.Image = global::St_Vincent_De_Paul_Society.Properties.Resources.down;
            this.ScrollDownPictureBox.Location = new System.Drawing.Point(189, 238);
            this.ScrollDownPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollDownPictureBox.Name = "ScrollDownPictureBox";
            this.ScrollDownPictureBox.Size = new System.Drawing.Size(22, 18);
            this.ScrollDownPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ScrollDownPictureBox.TabIndex = 21;
            this.ScrollDownPictureBox.TabStop = false;
            this.ScrollDownPictureBox.Visible = false;
            this.ScrollDownPictureBox.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // ScrollUpPictureBox
            // 
            this.ScrollUpPictureBox.Image = global::St_Vincent_De_Paul_Society.Properties.Resources.up__1_;
            this.ScrollUpPictureBox.Location = new System.Drawing.Point(189, 216);
            this.ScrollUpPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.ScrollUpPictureBox.Name = "ScrollUpPictureBox";
            this.ScrollUpPictureBox.Size = new System.Drawing.Size(22, 18);
            this.ScrollUpPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ScrollUpPictureBox.TabIndex = 20;
            this.ScrollUpPictureBox.TabStop = false;
            this.ScrollUpPictureBox.Visible = false;
            this.ScrollUpPictureBox.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // DeletePictureButton
            // 
            this.DeletePictureButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DeletePictureButton.BackColor = System.Drawing.Color.DarkBlue;
            this.DeletePictureButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeletePictureButton.ForeColor = System.Drawing.Color.White;
            this.DeletePictureButton.Location = new System.Drawing.Point(225, 270);
            this.DeletePictureButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeletePictureButton.Name = "DeletePictureButton";
            this.DeletePictureButton.Size = new System.Drawing.Size(70, 24);
            this.DeletePictureButton.TabIndex = 8;
            this.DeletePictureButton.Text = "Delete Image";
            this.toolTip1.SetToolTip(this.DeletePictureButton, "Click here to go back");
            this.DeletePictureButton.UseVisualStyleBackColor = false;
            this.DeletePictureButton.Visible = false;
            this.DeletePictureButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ImageListBox
            // 
            this.ImageListBox.FormattingEnabled = true;
            this.ImageListBox.Location = new System.Drawing.Point(13, 192);
            this.ImageListBox.Margin = new System.Windows.Forms.Padding(2);
            this.ImageListBox.Name = "ImageListBox";
            this.ImageListBox.Size = new System.Drawing.Size(174, 95);
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
            this.AddMorePicturesButton.Location = new System.Drawing.Point(34, 11);
            this.AddMorePicturesButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddMorePicturesButton.Name = "AddMorePicturesButton";
            this.AddMorePicturesButton.Size = new System.Drawing.Size(219, 43);
            this.AddMorePicturesButton.TabIndex = 7;
            this.AddMorePicturesButton.Text = "&Add more Images";
            this.toolTip1.SetToolTip(this.AddMorePicturesButton, "Click here to go back");
            this.AddMorePicturesButton.UseVisualStyleBackColor = false;
            this.AddMorePicturesButton.Visible = false;
            this.AddMorePicturesButton.Click += new System.EventHandler(this.AddMorePicturesButton_Click);
            // 
            // ImageLabel
            // 
            this.ImageLabel.Location = new System.Drawing.Point(91, 56);
            this.ImageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ImageLabel.Name = "ImageLabel";
            this.ImageLabel.Size = new System.Drawing.Size(123, 13);
            this.ImageLabel.TabIndex = 3;
            this.ImageLabel.Text = "Image appears here";
            // 
            // AddPhotosPictureBox
            // 
            this.AddPhotosPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("AddPhotosPictureBox.Image")));
            this.AddPhotosPictureBox.Location = new System.Drawing.Point(47, 19);
            this.AddPhotosPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.AddPhotosPictureBox.Name = "AddPhotosPictureBox";
            this.AddPhotosPictureBox.Size = new System.Drawing.Size(51, 29);
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
            this.AddPhotosButton.Location = new System.Drawing.Point(34, 11);
            this.AddPhotosButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddPhotosButton.Name = "AddPhotosButton";
            this.AddPhotosButton.Size = new System.Drawing.Size(219, 43);
            this.AddPhotosButton.TabIndex = 7;
            this.AddPhotosButton.Text = "             Add Photo";
            this.toolTip1.SetToolTip(this.AddPhotosButton, "Click here to upload an image");
            this.AddPhotosButton.UseVisualStyleBackColor = false;
            this.AddPhotosButton.Click += new System.EventHandler(this.AddPhotosButton_Click);
            // 
            // ImagePictureBox
            // 
            this.ImagePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImagePictureBox.Location = new System.Drawing.Point(13, 72);
            this.ImagePictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.ImagePictureBox.Name = "ImagePictureBox";
            this.ImagePictureBox.Size = new System.Drawing.Size(268, 116);
            this.ImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagePictureBox.TabIndex = 2;
            this.ImagePictureBox.TabStop = false;
            this.ImagePictureBox.Click += new System.EventHandler(this.ImagePictureBox_Click);
            // 
            // ProductSizeMainPanel
            // 
            this.ProductSizeMainPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProductSizeMainPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.ProductSizeMainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductSizeMainPanel.Controls.Add(this.ProductSizeLabel);
            this.ProductSizeMainPanel.Controls.Add(this.ProductSizeRichTextBox);
            this.ProductSizeMainPanel.Location = new System.Drawing.Point(485, 457);
            this.ProductSizeMainPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ProductSizeMainPanel.Name = "ProductSizeMainPanel";
            this.ProductSizeMainPanel.Size = new System.Drawing.Size(299, 39);
            this.ProductSizeMainPanel.TabIndex = 10;
            // 
            // ProductSizeLabel
            // 
            this.ProductSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductSizeLabel.Location = new System.Drawing.Point(2, 8);
            this.ProductSizeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProductSizeLabel.Name = "ProductSizeLabel";
            this.ProductSizeLabel.Size = new System.Drawing.Size(113, 29);
            this.ProductSizeLabel.TabIndex = 4;
            this.ProductSizeLabel.Text = "Product Size:";
            // 
            // ProductSizeRichTextBox
            // 
            this.ProductSizeRichTextBox.ForeColor = System.Drawing.Color.Gray;
            this.ProductSizeRichTextBox.Location = new System.Drawing.Point(155, 8);
            this.ProductSizeRichTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ProductSizeRichTextBox.Name = "ProductSizeRichTextBox";
            this.ProductSizeRichTextBox.Size = new System.Drawing.Size(141, 22);
            this.ProductSizeRichTextBox.TabIndex = 9;
            this.ProductSizeRichTextBox.Text = "if applicable";
            this.ProductSizeRichTextBox.Enter += new System.EventHandler(this.ProductSizeRichTextBox_Enter);
            this.ProductSizeRichTextBox.Leave += new System.EventHandler(this.ProductSizeRichTextBox_Leave);
            // 
            // ProductDetailsMessageLabel
            // 
            this.ProductDetailsMessageLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProductDetailsMessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductDetailsMessageLabel.Location = new System.Drawing.Point(204, 134);
            this.ProductDetailsMessageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProductDetailsMessageLabel.Name = "ProductDetailsMessageLabel";
            this.ProductDetailsMessageLabel.Size = new System.Drawing.Size(284, 15);
            this.ProductDetailsMessageLabel.TabIndex = 11;
            this.ProductDetailsMessageLabel.Text = "Please enter the product details below:";
            // 
            // UploadButton
            // 
            this.UploadButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UploadButton.BackColor = System.Drawing.Color.DarkBlue;
            this.UploadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UploadButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UploadButton.Location = new System.Drawing.Point(485, 500);
            this.UploadButton.Margin = new System.Windows.Forms.Padding(2);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(87, 29);
            this.UploadButton.TabIndex = 10;
            this.UploadButton.Text = "&Upload";
            this.toolTip1.SetToolTip(this.UploadButton, "Click here to Confirm");
            this.UploadButton.UseVisualStyleBackColor = false;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BackButton.BackColor = System.Drawing.Color.DarkBlue;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(673, 110);
            this.BackButton.Margin = new System.Windows.Forms.Padding(2);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(65, 28);
            this.BackButton.TabIndex = 12;
            this.BackButton.Text = "&Back";
            this.toolTip1.SetToolTip(this.BackButton, "Click here to go back");
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // LogOutButton
            // 
            this.LogOutButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LogOutButton.BackColor = System.Drawing.Color.DarkBlue;
            this.LogOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOutButton.ForeColor = System.Drawing.Color.White;
            this.LogOutButton.Location = new System.Drawing.Point(673, 67);
            this.LogOutButton.Margin = new System.Windows.Forms.Padding(2);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(65, 28);
            this.LogOutButton.TabIndex = 11;
            this.LogOutButton.Text = "Log &Out";
            this.toolTip1.SetToolTip(this.LogOutButton, "Click here to Log out");
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // ModifyUploadPageButton
            // 
            this.ModifyUploadPageButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ModifyUploadPageButton.BackColor = System.Drawing.Color.DarkBlue;
            this.ModifyUploadPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyUploadPageButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ModifyUploadPageButton.Location = new System.Drawing.Point(485, 499);
            this.ModifyUploadPageButton.Margin = new System.Windows.Forms.Padding(2);
            this.ModifyUploadPageButton.Name = "ModifyUploadPageButton";
            this.ModifyUploadPageButton.Size = new System.Drawing.Size(87, 29);
            this.ModifyUploadPageButton.TabIndex = 10;
            this.ModifyUploadPageButton.Text = "&Modify";
            this.toolTip1.SetToolTip(this.ModifyUploadPageButton, "Click here to Modify an item");
            this.ModifyUploadPageButton.UseVisualStyleBackColor = false;
            this.ModifyUploadPageButton.Visible = false;
            this.ModifyUploadPageButton.Click += new System.EventHandler(this.ModifyUploadPageButton_Click);
            // 
            // ProductTypeComboBox
            // 
            this.ProductTypeComboBox.FormattingEnabled = true;
            this.ProductTypeComboBox.Location = new System.Drawing.Point(160, 11);
            this.ProductTypeComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.ProductTypeComboBox.Name = "ProductTypeComboBox";
            this.ProductTypeComboBox.Size = new System.Drawing.Size(147, 21);
            this.ProductTypeComboBox.TabIndex = 5;
            this.toolTip1.SetToolTip(this.ProductTypeComboBox, "Please select the category ");
            // 
            // ProductLocationComboBox
            // 
            this.ProductLocationComboBox.FormattingEnabled = true;
            this.ProductLocationComboBox.Location = new System.Drawing.Point(160, 11);
            this.ProductLocationComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.ProductLocationComboBox.Name = "ProductLocationComboBox";
            this.ProductLocationComboBox.Size = new System.Drawing.Size(147, 21);
            this.ProductLocationComboBox.TabIndex = 6;
            this.toolTip1.SetToolTip(this.ProductLocationComboBox, "Please select the location");
            // 
            // ProductPriceLabel
            // 
            this.ProductPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductPriceLabel.Location = new System.Drawing.Point(13, 11);
            this.ProductPriceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProductPriceLabel.Name = "ProductPriceLabel";
            this.ProductPriceLabel.Size = new System.Drawing.Size(117, 29);
            this.ProductPriceLabel.TabIndex = 1;
            this.ProductPriceLabel.Text = "Product Price*:";
            // 
            // ProductPriceTextBox
            // 
            this.ProductPriceTextBox.ForeColor = System.Drawing.Color.Gray;
            this.ProductPriceTextBox.Location = new System.Drawing.Point(160, 12);
            this.ProductPriceTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ProductPriceTextBox.Name = "ProductPriceTextBox";
            this.ProductPriceTextBox.Size = new System.Drawing.Size(147, 20);
            this.ProductPriceTextBox.TabIndex = 3;
            this.ProductPriceTextBox.Text = "Product Price";
            this.ProductPriceTextBox.Enter += new System.EventHandler(this.ProductPriceTextBox_Enter);
            this.ProductPriceTextBox.Leave += new System.EventHandler(this.ProductPriceTextBox_Leave);
            // 
            // ProductPricePanel
            // 
            this.ProductPricePanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProductPricePanel.BackColor = System.Drawing.Color.AliceBlue;
            this.ProductPricePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductPricePanel.Controls.Add(this.ProductPriceTextBox);
            this.ProductPricePanel.Controls.Add(this.ProductPriceLabel);
            this.ProductPricePanel.Location = new System.Drawing.Point(161, 346);
            this.ProductPricePanel.Margin = new System.Windows.Forms.Padding(2);
            this.ProductPricePanel.Name = "ProductPricePanel";
            this.ProductPricePanel.Size = new System.Drawing.Size(321, 41);
            this.ProductPricePanel.TabIndex = 6;
            // 
            // ProductTypeLabel
            // 
            this.ProductTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductTypeLabel.Location = new System.Drawing.Point(13, 11);
            this.ProductTypeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProductTypeLabel.Name = "ProductTypeLabel";
            this.ProductTypeLabel.Size = new System.Drawing.Size(117, 29);
            this.ProductTypeLabel.TabIndex = 1;
            this.ProductTypeLabel.Text = "Product Type*:";
            // 
            // ProductTypePanel
            // 
            this.ProductTypePanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProductTypePanel.BackColor = System.Drawing.Color.AliceBlue;
            this.ProductTypePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductTypePanel.Controls.Add(this.ProductTypeComboBox);
            this.ProductTypePanel.Controls.Add(this.ProductTypeLabel);
            this.ProductTypePanel.Location = new System.Drawing.Point(161, 445);
            this.ProductTypePanel.Margin = new System.Windows.Forms.Padding(2);
            this.ProductTypePanel.Name = "ProductTypePanel";
            this.ProductTypePanel.Size = new System.Drawing.Size(321, 41);
            this.ProductTypePanel.TabIndex = 7;
            // 
            // ProductLocationUploadFormLabel
            // 
            this.ProductLocationUploadFormLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductLocationUploadFormLabel.Location = new System.Drawing.Point(13, 11);
            this.ProductLocationUploadFormLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProductLocationUploadFormLabel.Name = "ProductLocationUploadFormLabel";
            this.ProductLocationUploadFormLabel.Size = new System.Drawing.Size(163, 29);
            this.ProductLocationUploadFormLabel.TabIndex = 1;
            this.ProductLocationUploadFormLabel.Text = "Product Location*:";
            // 
            // ProductLocationPanel
            // 
            this.ProductLocationPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProductLocationPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.ProductLocationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductLocationPanel.Controls.Add(this.ProductLocationComboBox);
            this.ProductLocationPanel.Controls.Add(this.ProductLocationUploadFormLabel);
            this.ProductLocationPanel.Location = new System.Drawing.Point(161, 489);
            this.ProductLocationPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ProductLocationPanel.Name = "ProductLocationPanel";
            this.ProductLocationPanel.Size = new System.Drawing.Size(321, 41);
            this.ProductLocationPanel.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.SalePriceTextBox);
            this.panel2.Controls.Add(this.SalePriceLabel);
            this.panel2.Location = new System.Drawing.Point(161, 394);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(321, 41);
            this.panel2.TabIndex = 16;
            // 
            // SalePriceTextBox
            // 
            this.SalePriceTextBox.ForeColor = System.Drawing.Color.Gray;
            this.SalePriceTextBox.Location = new System.Drawing.Point(160, 12);
            this.SalePriceTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.SalePriceTextBox.Name = "SalePriceTextBox";
            this.SalePriceTextBox.Size = new System.Drawing.Size(147, 20);
            this.SalePriceTextBox.TabIndex = 4;
            this.SalePriceTextBox.Text = "Sale Price";
            this.SalePriceTextBox.Enter += new System.EventHandler(this.SalePriceTextBox_Enter);
            this.SalePriceTextBox.Leave += new System.EventHandler(this.SalePriceTextBox_Leave);
            // 
            // SalePriceLabel
            // 
            this.SalePriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalePriceLabel.Location = new System.Drawing.Point(13, 11);
            this.SalePriceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SalePriceLabel.Name = "SalePriceLabel";
            this.SalePriceLabel.Size = new System.Drawing.Size(117, 29);
            this.SalePriceLabel.TabIndex = 1;
            this.SalePriceLabel.Text = "Sale Price:";
            // 
            // ThemePictureBox
            // 
            this.ThemePictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ThemePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ThemePictureBox.Image")));
            this.ThemePictureBox.Location = new System.Drawing.Point(8, 307);
            this.ThemePictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.ThemePictureBox.Name = "ThemePictureBox";
            this.ThemePictureBox.Size = new System.Drawing.Size(147, 221);
            this.ThemePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ThemePictureBox.TabIndex = 3;
            this.ThemePictureBox.TabStop = false;
            // 
            // ShopLogoPictureBox
            // 
            this.ShopLogoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ShopLogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ShopLogoPictureBox.Image")));
            this.ShopLogoPictureBox.Location = new System.Drawing.Point(296, 67);
            this.ShopLogoPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.ShopLogoPictureBox.Name = "ShopLogoPictureBox";
            this.ShopLogoPictureBox.Size = new System.Drawing.Size(218, 53);
            this.ShopLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ShopLogoPictureBox.TabIndex = 1;
            this.ShopLogoPictureBox.TabStop = false;
            // 
            // MandatoryLabel
            // 
            this.MandatoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MandatoryLabel.Location = new System.Drawing.Point(611, 501);
            this.MandatoryLabel.Name = "MandatoryLabel";
            this.MandatoryLabel.Size = new System.Drawing.Size(173, 27);
            this.MandatoryLabel.TabIndex = 17;
            this.MandatoryLabel.Text = "* means it\'s a mandatory field";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(789, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem1.Text = "Help";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(57, 6);
            // 
            // UploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(789, 545);
            this.Controls.Add(this.MandatoryLabel);
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
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UploadForm";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 19);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to the product upload page";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UploadForm_FormClosing);
            this.Load += new System.EventHandler(this.UploadForm_Load);
            this.ProductNamePanel.ResumeLayout(false);
            this.ProductNamePanel.PerformLayout();
            this.ProductDescriptionPanel.ResumeLayout(false);
            this.ProductDescriptionPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScrollDownPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScrollUpPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddPhotosPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).EndInit();
            this.ProductSizeMainPanel.ResumeLayout(false);
            this.ProductPricePanel.ResumeLayout(false);
            this.ProductPricePanel.PerformLayout();
            this.ProductTypePanel.ResumeLayout(false);
            this.ProductLocationPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThemePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShopLogoPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.PictureBox ScrollUpPictureBox;
        private System.Windows.Forms.PictureBox ScrollDownPictureBox;
        private System.Windows.Forms.Label MandatoryLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}