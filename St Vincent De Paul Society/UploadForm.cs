using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net;

namespace St_Vincent_De_Paul_Society
{
    public partial class UploadForm : Form
    {
        // Declaring field variables globally
        string productName;
        string productDescription;
        decimal productPrice = 0m;
        decimal salePrice = 0m;
        string productType;
        string productLocation;
        string productSize;
        static List<string> imageList = new List<string>();
        int flag = 0;
        int item_id;               
        string modifyProductName;
        private int productCategoryModify = -1;
        private int productLocationModify = -1;
        private string selectedProductDetails;
        private Boolean isModifyOrDelete = false;
        private Boolean isUpload = false;
        private string selectedProductName;
        static String imageLocation = "";

        //Database variables
        static string connectionString = "SERVER=mysql4299.cp.blacknight.com; PORT=3306; DATABASE=db1399990_sa179849_main; UID=u_sa179849; PASSWORD=Y1JCUFZ8mVGlzuYf";
        MySqlConnection connection = new MySqlConnection(connectionString);

        //FTP server details
        static String ftpUrl = "ftp://ftp.d1399990-122920.blacknighthosting.com/webspace/siteapps/WordPress-179849/htdocs/wp-content/uploads/2020/03/";
        static String ftpUsername = "CarrigGlass";
        static String ftpPassword = "Vincent_123";

       

        public UploadForm()
        {
            InitializeComponent();
            // Calling method to fill the combo boxes.
			FillComboBox();
        }
        
        // Code to execute functionality on loading UploadForm 
        private void UploadForm_Load(object sender, EventArgs e)
        {

            if (productLocationModify != -1 && productCategoryModify != -1)
            {
                ProductTypeComboBox.SelectedIndex = productCategoryModify;
                ProductLocationComboBox.SelectedIndex = productLocationModify;
                ModifyUploadPageButton.Visible = true;
                UploadButton.Visible = false;
                if (imageList.Count == 0)
                {
                    AddPhotosButton.Visible = true;
                    AddMorePicturesButton.Visible = false;
                }
                else
                {
                    AddPhotosButton.Visible = false;
                    AddMorePicturesButton.Visible = true;
                }

                if (selectedProductDetails != "")
                {
                    try
                    {
                        if (selectedProductDetails.Length > 1)
                        {
                            // assigning the value of item id to the variable.
                            item_id = int.Parse(selectedProductDetails.Substring(0, 2));
                        }
                        else
                        {
                            // assigning the value of item id to the variable.
                            item_id = int.Parse(selectedProductDetails.Substring(0, 1));
                        }
                        //Clearing image list before adding values.
                        imageList.Clear();

                        // Database connection on form load
                        // Selecting item name, item description, prize, sale and size from database for the item id.
                        string dataLoad_sql3 = "select  ITEM_NAME, ITEM_DESCRIPTION, PRIZE,SALE, SIZE from INVENTORY where item_id = '" + item_id + "' ;";
                        MySqlCommand data_command3 = new MySqlCommand(dataLoad_sql3, connection);
                        connection.Open();
                        MySqlDataReader dataload3;
                        dataload3 = data_command3.ExecuteReader();
                        dataload3.Read();
                        modifyProductName = dataload3.GetString(0);
                        ProductNameTextBox.Text = dataload3.GetString(0);
                        ProductDescriptionRichTextBox.Text = dataload3.GetString(1);
                        ProductPriceTextBox.Text = dataload3.GetString(2);

                        if (dataload3.GetValue(dataload3.GetOrdinal("SALE")) == DBNull.Value)
                        {
                            SalePriceTextBox.Text = "0";
                        }
                        else
                        {
                            decimal SalePriceText = dataload3.GetDecimal(3);
                            SalePriceTextBox.Text = SalePriceText.ToString();
                        }

                        ProductSizeRichTextBox.Text = dataload3.GetString(4);
                        dataload3.Close();
                        connection.Close();

                        //Selecting post id from wp table for the selected product name.
                        string dataLoad_sql4 = "select id from wp_posts where post_title = '" + selectedProductName + "' and post_type='product' ;";
                        MySqlCommand cmd = new MySqlCommand(dataLoad_sql4, connection);
                        connection.Open();
                        MySqlDataReader dataload5;
                        dataload5 = cmd.ExecuteReader();
                        dataload5.Read();
                        int wp_item_id = dataload5.GetInt32(0);
                        connection.Close();

                        //Selecting image names from the database for the wordpress id and adding to the image list.
                        string dataLoad_sql5 = "select post_title from wp_posts where post_parent = '" + wp_item_id + "' ;";
                        MySqlCommand cmd1 = new MySqlCommand(dataLoad_sql5, connection);
                        connection.Open();
                        MySqlDataReader dataload6;
                        dataload6 = cmd1.ExecuteReader();
                        while (dataload6.Read())
                        {
                            String image_list = (dataload6["post_title"].ToString()).Replace(" ", "-");
                            ImageListBox.Visible = true;
                            ImageListBox.Items.Add(image_list);
                            byte[] img1 = GetImgByte(ftpUrl + image_list + ".jpg");
                            ByteToImage(img1, image_list);
                        }
                        connection.Close();

                        ImagePictureBox.ImageLocation = imageList[0];
                        connection.Close();

                        // Code to add validations when there are more than one items/pictures in listbox
                        if (imageList.Count > 1)
                        {
                            DeletePictureButton.Visible = true;
                            ScrollUpPictureBox.Visible = true;
                            ScrollDownPictureBox.Visible = true;
                        }
                        else if (imageList.Count == 1)
                        {
                            DeletePictureButton.Visible = true;
                        }



                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("There is a problem with the database of this application (Error 1). Please contact online and media coordinator to resolve this error. " + Ex, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else
                {
                    ModifyUploadPageButton.Visible = false;
                    UploadButton.Visible = true;
                }


            }
        }



        // method to automatically fill combo boxes (product category and product location) from database 
        void FillComboBox()
        {
            try
            {
                // Selecting the list of categories and sub-categories from the database.
                string dataLoad_sql = "select Concat(c.category_name, ' ' ,s.sub_category_name) as 'Categories'  from CATEGORY c, SUB_CATEGORY s where c.CATEGORY_ID=s.CATEGORY_ID;";
                MySqlCommand data_command = new MySqlCommand(dataLoad_sql, connection);
                connection.Open();
                MySqlDataReader dataload;
                dataload = data_command.ExecuteReader();            
               
                while (dataload.Read())
                {

                    string categories = dataload.GetString(0);
                    ProductTypeComboBox.Items.Add(categories);
                }

                connection.Close();

                // Selecting shop names from the database.               
                string dataLoad_sql1 = "SELECT shop_name FROM SHOP;";
                MySqlCommand data_command1 = new MySqlCommand(dataLoad_sql1, connection);
                connection.Open();
                MySqlDataReader dataload1;
                dataload1 = data_command1.ExecuteReader();

                while (dataload1.Read())
                {

                    string shops = dataload1.GetString(0);
                    ProductLocationComboBox.Items.Add(shops);
                }
                connection.Close();
            }

            catch (Exception Ex)
            {
                MessageBox.Show("There is a problem with the database of this application (Error 2). Please contact online and media coordinator to resolve this error. ", "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine(Ex);
            }
        }


        // Setting product category, product location, product details, product name and identifying if upload, delete or modify redirected from modify form
        public int productCategoryModifySet {
            set
            {
                productCategoryModify = value;
            }
        }

        public Boolean isModifyOrDeleteSet
        {
            set
            {
                isModifyOrDelete = value;
            }
        }

        public Boolean isUploadSet
        {
            set
            {
                isUpload = value;
            }
        }

        public int productLocationLocationSet
        {
            set
            {
                productLocationModify = value;
            }
        }

 
		public string selectedProduct
        {
            set
            {
                selectedProductDetails = value;
            }
        }

        public string selectedProduct_Name
        {
            set
            {
                selectedProductName = value;
            }
        }

        /* Method UploadFileToFtp() created to upload images on FTP server. */
        public static void UploadFileToFtp(string url, string filePath, string username, string password)
        {
            var fileName = Path.GetFileName(filePath);
            var request = (FtpWebRequest)WebRequest.Create(url + fileName);

            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            using (var fileStream = File.OpenRead(filePath))
            {
                using (var requestStream = request.GetRequestStream())
                {
                    fileStream.CopyTo(requestStream);
                    requestStream.Close();
                }
            }

        }

        /* Method GetImgByte() created to download images from FTP server. */
        public static byte[] GetImgByte(string ftpFilePath)
        {
            WebClient ftpClient = new WebClient();
            ftpClient.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

            byte[] imageByte = ftpClient.DownloadData(ftpFilePath);
            return imageByte;
        }

        /* Method ByteToImage() to convert bytes to images from FTP server. */
        public static Bitmap ByteToImage(byte[] blob, String image)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            Image img2 = new Bitmap(bm);
            img2.Save(@"C:\Users\Public\" + image + ".jpg");
            imageList.Add(@"C:\Users\Public\" + image + ".jpg");
            mStream.Dispose();
            return bm;
        }

        /*Method called to upload image on the server*/
        public static void UploadImage()
        {
            String imageName1 = Path.GetFileName(imageLocation);
            String ImageFullPath = imageLocation.Replace(imageName1, "");
            String ImageName = imageName1.Replace(" ", "-");
            String ImageName1 = ImageName.Replace(".jpg", "");
            Image image1 = new Bitmap(imageLocation);

            //Code to upload imgae to the FTP server
            if (imageName1.Contains(" "))
            {
                Bitmap bmp0 = new Bitmap(image1);
                Image img0 = new Bitmap(bmp0);
                img0.Save(ImageFullPath + ImageName);
                UploadFileToFtp(ftpUrl, ImageFullPath + ImageName, ftpUsername, ftpPassword);
                File.Delete(ImageFullPath + ImageName);
            }
            else
            {
                UploadFileToFtp(ftpUrl, imageLocation, ftpUsername, ftpPassword);
            }

            //Code added to resize the image and upload image to the FTP server.
            Bitmap bmp = new Bitmap(image1, 175, 300);
            Image img = new Bitmap(bmp);
            String imagename = ImageName1 + "-175x300.jpg";
            img.Save(ImageFullPath + imagename);
            UploadFileToFtp(ftpUrl, ImageFullPath + imagename, ftpUsername, ftpPassword);
            File.Delete(ImageFullPath + imagename);

            Bitmap bmp1 = new Bitmap(image1, 100, 100);
            Image img1 = new Bitmap(bmp1);
            String imagename1 = ImageName1 + "-100x100.jpg";
            img1.Save(ImageFullPath + imagename1);
            UploadFileToFtp(ftpUrl, ImageFullPath + imagename1, ftpUsername, ftpPassword);
            File.Delete(ImageFullPath + imagename1);

            Bitmap bmp2 = new Bitmap(image1, 150, 150);
            Image img2 = new Bitmap(bmp2);
            String imagename2 = ImageName1 + "-150x150.jpg";
            img2.Save(ImageFullPath + imagename2);
            UploadFileToFtp(ftpUrl, ImageFullPath + imagename2, ftpUsername, ftpPassword);
            File.Delete(ImageFullPath + imagename2);

            Bitmap bmp3 = new Bitmap(image1, 265, 331);
            Image img3 = new Bitmap(bmp3);
            String imagename3 = ImageName1 + "-265x331.jpg";
            img3.Save(ImageFullPath + imagename3);
            UploadFileToFtp(ftpUrl, ImageFullPath + imagename3, ftpUsername, ftpPassword);
            File.Delete(ImageFullPath + imagename3);


        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            DialogResult resultLogout = MessageBox.Show("Do you wish to Log out??", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DialogResult.Yes == resultLogout)
            {
                  this.Hide();

                //Declaring a variable for LoginForm
                   LogInForm form1 = new LogInForm();

                //Showing WelcomeForm
                form1.ShowDialog();

            }

            else
            {


            }

        }

        // Method to upload a new item into the website
        private void UploadButton_Click(object sender, EventArgs e)
        {
            int status = 0;


            // check if product name is entered (mandatory field)
            if (ProductNameTextBox.Text == "" || ProductNameTextBox.Text == "What are you selling?")
            {
                MessageBox.Show("Please Enter a valid Product name", "Product name missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                try
                {
                    // save product name
                    productName = ProductNameTextBox.Text.Trim();
                    //Database query to check duplicate product name
                    string query0 = "select id from wp_posts where post_type = 'product' and post_title = '" + productName + "';";
                    MySqlCommand sql_command0 = new MySqlCommand(query0, connection);
                    connection.Open();
                    MySqlDataReader mydata0;
                    mydata0 = sql_command0.ExecuteReader();
                    if (mydata0.Read())
                    {
                        status = 1;
                        MessageBox.Show("Please use a different Product name. Product name entered already exists on the website.", "Product Name already exists!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                    }
                    mydata0.Close();
                    connection.Close();
                }
                catch
                {
                    status = 1;
                    MessageBox.Show("Issue occured while processing the product name. Please don't use any special character in the product name.", "Product Name error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
                
                if (status != 1)
                {
                    // check if product description is entered (mandatory field)
                    if (ProductDescriptionRichTextBox.Text == "" || ProductDescriptionRichTextBox.Text == "Describe what you are selling")
                    {
                        MessageBox.Show("Please Enter valid Product description", "Product description missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        productDescription = ProductDescriptionRichTextBox.Text;

                        // product price is mandatory, sale price is not
                        if (ProductPriceTextBox.Text == "Product Price" || ProductPriceTextBox.Text == "")
                        {
                            MessageBox.Show("Please enter the price of the product.", "Product price missing", MessageBoxButtons.OK, MessageBoxIcon.Error);



                        }
                        else
                        {
                            // accepting value for Product and sale price fields
                            if (decimal.TryParse(ProductPriceTextBox.Text, out productPrice))
                            {
                                if (!SalePriceTextBox.Text.Contains("Sale Price") || SalePriceTextBox.Text.Length == 0)
                                {
                                    if (!decimal.TryParse(SalePriceTextBox.Text, out salePrice))
                                    {
                                        MessageBox.Show("Please Enter only number or decimal digits", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    }
                                    else
                                    {
                                        decimal.TryParse(SalePriceTextBox.Text, out salePrice);
                                    }
                                }

                                // Checking whether a product category has been chosen (Mandatory field)
                                if (ProductTypeComboBox.SelectedIndex < 0)
                                {
                                    MessageBox.Show("Please select a product type", "Product category missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                                else
                                {
                                    // Set product category
                                    productType = ProductTypeComboBox.Text;

                                    // Checking whether a product location has been choosen (Mandatory field)
                                    if (ProductLocationComboBox.SelectedIndex < 0)

                                    {
                                        MessageBox.Show("Please select a location", "Product Location Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    }
                                    else
                                    {
                                        // Set product location
                                        productLocation = ProductLocationComboBox.Text;


                                        // Check whether an image is selected (Mandatory field)
                                        if (ImagePictureBox.ImageLocation is null)
                                        {
                                            MessageBox.Show("Please Upload at least 1 image to continue.", "Image missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                        else
                                        {

                                            // "Size is a mandatory entry for clothing articles. Checking whether the product is from the clothing category and if so, checking whether a size is entered"
                                            if ((ProductTypeComboBox.SelectedItem.ToString() == "Clothing Womens" || ProductTypeComboBox.SelectedItem.ToString() == "Clothing Mens" || ProductTypeComboBox.SelectedItem.ToString() == "Clothing KIDS" || ProductTypeComboBox.SelectedItem.ToString() == "Clothing SHOES") && (ProductSizeRichTextBox.Text == "if applicable" || ProductSizeRichTextBox.Text == ""))
                                            {
                                                MessageBox.Show("please enter the size or indicate 'One Size' if the product has no size", "Product size missing ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }

                                            // All mandatory entries have been made
                                            else
                                            {
                                                // Code to display pictures in listbox
                                                try
                                                {
                                                    byte[] img = new byte[ImageListBox.Items.Count];
                                                    List<string> myimages = new List<string>();
                                                    for (int i = 0; i < imageList.Count; i++)
                                                    {
                                                        MemoryStream ms = new MemoryStream();
                                                        img = File.ReadAllBytes(imageList[i].ToString());
                                                        //Code to get Image Name
                                                        string myimage = (ImageListBox.Items[i].ToString()).Replace("- Title Image", "");
                                                        myimages.Add(myimage);
                                                    }


                                                    // Validations for Product size field
                                                    if (ProductSizeRichTextBox.Text != "" && ProductSizeRichTextBox.Text != "if applicable")
                                                    {
                                                        productSize = ProductSizeRichTextBox.Text;
                                                    }

                                                    if (ProductSizeRichTextBox.Text == "if applicable")
                                                    {
                                                        productSize = "no size";

                                                    }

                                                    // Dialog box code when user clicks on 'Upload' button
                                                    DialogResult uploadConfirmation = MessageBox.Show("Are you sure you want to upload the Item ?", "Confirm Upload", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                                    if (uploadConfirmation == DialogResult.Yes)
                                                    {
                                                        //Database code when user clicks on Yes button
                                                        //Selected value assignment to variables to use in the queries below.
                                                        string[] categories = productType.Split();
                                                        string trimmed_productLocation = productLocation.Replace("Vincent's ", "").Replace(" Road", "");
                                                        string in_stock_date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                                                        int category_id = 0;
                                                        string str1 = categories[0];
                                                        string str2 = categories[1];

                                                        if (str2 == "HOME")
                                                            str2 = str2 + " DECOR";
                                                        try
                                                        {
                                                            //Selecting category id from the database based on the category selected from the database.
                                                            String sql0 = "SELECT CATEGORY_ID FROM CATEGORY WHERE CATEGORY_NAME LIKE '%" + str1 + "%';";
                                                            MySqlCommand command0 = new MySqlCommand(sql0, connection);
                                                            connection.Open();
                                                            MySqlDataReader myreader0;
                                                            myreader0 = command0.ExecuteReader();
                                                            myreader0.Read();
                                                            category_id = myreader0.GetInt32(0);
                                                            myreader0.Close();
                                                            connection.Close();
                                                        }
                                                        catch
                                                        {
                                                            MessageBox.Show("Error retrieving the category from database. Try uploading a product with different category.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            return;
                                                        }

                                                        //Creating MySqlDataReader variables
                                                        MySqlDataReader myreader, mydata, mydata1, mydata2;
                                                        // Creating wp_category_id and initialising to 0.
                                                        int wp_category_id = 0;
                                                        if (str2 == "OTHER")
                                                        {
                                                            try
                                                            {
                                                                //Selecting category id from the wp table and assign to wp_category_id.
                                                                string sql2 = "SELECT term_id FROM wp_terms WHERE name LIKE '" + str2 + "' and slug like '%" + str1 + "%';";
                                                                MySqlCommand command2 = new MySqlCommand(sql2, connection);
                                                                connection.Open();
                                                                mydata1 = command2.ExecuteReader();
                                                                mydata1.Read();
                                                                wp_category_id = mydata1.GetInt32(0);
                                                                mydata1.Close();
                                                                connection.Close();
                                                            }
                                                            catch
                                                            {
                                                                MessageBox.Show("Error retrieving the category from wordpress database. Try uploading a product with different category.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                return;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            try
                                                            {
                                                                //Selecting category id from the wp table and assign to wp_category_id.
                                                                string sql2 = "SELECT term_id FROM wp_terms WHERE name LIKE '" + str2 + "' and term_id between '58' and '80';";
                                                                MySqlCommand command2 = new MySqlCommand(sql2, connection);
                                                                connection.Open();
                                                                mydata1 = command2.ExecuteReader();
                                                                mydata1.Read();
                                                                wp_category_id = mydata1.GetInt32(0);
                                                                mydata1.Close();
                                                                connection.Close();
                                                            }
                                                            catch
                                                            {
                                                                MessageBox.Show("Error retrieving the category from wordpress database. Try uploading a product with different category.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                return;
                                                            }
                                                        }
                                                        int db_category_id = 0;
                                                        try
                                                        {
                                                            //Selecting the sub category id from the database for the selected ctaegory from the combobox.
                                                            string sql = "SELECT SUB_CATEGORY_ID FROM SUB_CATEGORY WHERE SUB_CATEGORY_NAME LIKE '%" + str2 + "%' and CATEGORY_ID = '" + category_id + "';";
                                                            MySqlCommand command = new MySqlCommand(sql, connection);
                                                            connection.Open();
                                                            myreader = command.ExecuteReader();
                                                            myreader.Read();
                                                            db_category_id = myreader.GetInt32(0);
                                                            myreader.Close();
                                                            connection.Close();
                                                        }
                                                        catch
                                                        {
                                                            MessageBox.Show("Error retrieving the sub-category from database. Try uploading a product with different category.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            return;
                                                        }
                                                        int db_shop_id = 0;
                                                        try
                                                        {
                                                            //Selecting the shop id from the database for the selected shop from the combobox.
                                                            string sql1 = "SELECT SHOP_ID FROM SHOP WHERE SHOP_NAME LIKE '%" + trimmed_productLocation + "%';";
                                                            MySqlCommand command1 = new MySqlCommand(sql1, connection);
                                                            connection.Open();
                                                            mydata = command1.ExecuteReader();
                                                            mydata.Read();
                                                            db_shop_id = mydata.GetInt32(0);
                                                            mydata.Close();
                                                            connection.Close();
                                                        }
                                                        catch
                                                        {
                                                            MessageBox.Show("Error retrieving the shop name from database. Try uploading a product to a different shop.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            return;
                                                        }

                                                        int wp_shop_id = 0;
                                                        try
                                                        {
                                                            ////Selecting the shop id from the database for the selected shop from the combobox.
                                                            string sql3 = "SELECT id FROM wp_users WHERE user_nicename LIKE '%" + trimmed_productLocation + "%';";
                                                            MySqlCommand command3 = new MySqlCommand(sql3, connection);
                                                            connection.Open();
                                                            mydata2 = command3.ExecuteReader();
                                                            //mydata2.Read();
                                                            if (mydata2.Read())
                                                            {
                                                                wp_shop_id = mydata2.GetInt32(0);
                                                            }
                                                            //wp_shop_id = mydata2.GetInt32(0);
                                                            mydata2.Close();
                                                            connection.Close();
                                                        }
                                                        catch
                                                        {
                                                            MessageBox.Show("Error retrieving the shop name from wordpress database. Try uploading a product to a different shop.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            return;
                                                        }

                                                        try
                                                        {
                                                            //Inserting the product details in to the inventory table.
                                                            string mysql = "INSERT INTO INVENTORY (ITEM_NAME, ITEM_DESCRIPTION, SUB_CATEGORY_ID,PRIZE, SALE, SIZE, PICTURE, IN_STOCK_DATE,ITEM_STATUS,SHOP_ID,SEASON_ID) VALUES('"
                                                            + productName + "', '" + productDescription + "', '" + db_category_id + "','" + productPrice + "','" + salePrice + "','" + productSize + "', '" + img + "' ,'" + in_stock_date + "', 'In Stock','" + db_shop_id + "', '1');";
                                                            MySqlCommand command5 = new MySqlCommand(mysql, connection);
                                                            connection.Open();
                                                            command5.ExecuteNonQuery();
                                                            connection.Close();
                                                        }
                                                        catch
                                                        {
                                                            MessageBox.Show("Error entering the product details in inventory table. Try uploading a product with different detais.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            return;

                                                        }

                                                        try
                                                        {
                                                            //Wordpress queries
                                                            //Query to insert the product details into wordpress table.
                                                            string productName1 = productName.Replace(" ", "-");
                                                            string mysql1 = "INSERT INTO wp_posts (post_author, post_date, post_date_gmt, post_content,post_title, post_excerpt, post_status,comment_status, ping_status, post_password, post_name, to_ping, pinged, post_modified, post_modified_gmt,post_content_filtered, post_parent , guid, menu_order, post_type, post_mime_type, comment_count) VALUES('" + wp_shop_id + "', '"
                                                            + in_stock_date + "','" + in_stock_date + "','', '"
                                                            + productName + "','" + productDescription + "','publish', 'closed', 'closed','', '" + productName1 + "','','', '" + in_stock_date + "','" + in_stock_date + "','' , '0', '','0', 'product','', '0') ; ";
                                                            MySqlCommand command4 = new MySqlCommand(mysql1, connection);
                                                            connection.Open();
                                                            command4.ExecuteNonQuery();
                                                            connection.Close();
                                                        }
                                                        catch
                                                        {
                                                            //int id=0;
                                                            try
                                                            {
                                                                MySqlConnection connection1 = new MySqlConnection(connectionString);
                                                                string sql3 = "SELECT ITEM_ID from INVENTORY where ITEM_NAME='" + productName + "';";
                                                                MySqlCommand command3 = new MySqlCommand(sql3, connection1);
                                                                connection1.Open();
                                                                MySqlDataReader myreader2;
                                                                myreader2 = command3.ExecuteReader();
                                                                //mydata2.Read();
                                                                myreader2.Read();
                                                                int id = myreader2.GetInt32(0);
                                                                myreader2.Close();
                                                                connection1.Close();

                                                                string dataLoad_sql4 = "DELETE FROM INVENTORY WHERE ITEM_ID = '" + id + "';";
                                                                MySqlCommand data_command4 = new MySqlCommand(dataLoad_sql4, connection1);
                                                                connection1.Open();
                                                                data_command4.ExecuteNonQuery();
                                                                connection1.Close();
                                                                MessageBox.Show("Error entering the product details in wordpress table. Try uploading a product with different detais.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                return;
                                                            }
                                                            catch
                                                            {
                                                                MessageBox.Show("Error entering the product details in wordpress table. Try uploading a product with different detais.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                return;
                                                            }

                                                        }
                                                        int wordpress_item_id = 0;
                                                        try
                                                        {
                                                            //Selecting the id from wp table for the product and assign to wordpress_item_id.
                                                            string mysql2 = "select id from wp_posts where post_type = 'product' and post_title = '" + productName + "';";
                                                            MySqlCommand command6 = new MySqlCommand(mysql2, connection);
                                                            connection.Open();
                                                            MySqlDataReader myreader1;
                                                            myreader1 = command6.ExecuteReader();
                                                            myreader1.Read();
                                                            wordpress_item_id = myreader1.GetInt32(0);
                                                            myreader1.Close();
                                                            connection.Close();
                                                        }
                                                        catch
                                                        {
                                                            try
                                                            {
                                                                MySqlConnection connection1 = new MySqlConnection(connectionString);
                                                                string sql3 = "SELECT ITEM_ID from INVENTORY where ITEM_NAME='" + productName + "';";
                                                                MySqlCommand command3 = new MySqlCommand(sql3, connection1);
                                                                connection1.Open();
                                                                MySqlDataReader myreader2;
                                                                myreader2 = command3.ExecuteReader();
                                                                //mydata2.Read();
                                                                myreader2.Read();
                                                                int id = myreader2.GetInt32(0);
                                                                myreader2.Close();
                                                                connection1.Close();


                                                                string dataLoad_sql4 = "DELETE FROM INVENTORY WHERE ITEM_ID = '" + id + "';";
                                                                MySqlCommand data_command4 = new MySqlCommand(dataLoad_sql4, connection1);
                                                                connection1.Open();
                                                                data_command4.ExecuteNonQuery();
                                                                connection1.Close();
                                                                MessageBox.Show("Error adding product in wordpress table. Try uploading a different product.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                return;
                                                            }
                                                            catch
                                                            {
                                                                MessageBox.Show("Error adding product in wordpress table. Try uploading a different product.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                return;
                                                            }
                                                        }

                                                        if (salePrice != 0)
                                                        {
                                                            try
                                                            {
                                                                //Queries to be inserted when sale price isnt equal to 0
                                                                string mysql3 = "INSERT INTO wp_term_relationships VALUES ('" + wordpress_item_id + "','" + wp_category_id + "','0'); INSERT INTO wp_postmeta(post_id,meta_key,meta_value) VALUES('" + wordpress_item_id + "','_regular_price', '" + productPrice + "'); INSERT INTO wp_postmeta(post_id,meta_key,meta_value) VALUES('" + wordpress_item_id + "','_price', '" + salePrice + "');  INSERT INTO wp_postmeta(post_id,meta_key,meta_value) VALUES('" + wordpress_item_id + "','_sale_price', '" + salePrice + "');";
                                                                MySqlCommand command11 = new MySqlCommand(mysql3, connection);
                                                                connection.Open();
                                                                command11.ExecuteNonQuery();
                                                                connection.Close();
                                                            }
                                                            catch
                                                            {
                                                                try
                                                                {

                                                                    MySqlConnection connection1 = new MySqlConnection(connectionString);
                                                                    string sql3 = "SELECT ITEM_ID from INVENTORY where ITEM_NAME='" + productName + "';";
                                                                    MySqlCommand command3 = new MySqlCommand(sql3, connection1);
                                                                    connection1.Open();
                                                                    MySqlDataReader myreader2;
                                                                    myreader2 = command3.ExecuteReader();
                                                                    myreader2.Read();
                                                                    int id = myreader2.GetInt32(0);
                                                                    myreader2.Close();
                                                                    connection1.Close();
                                                                    string dataLoad_sql4 = "DELETE FROM INVENTORY WHERE ITEM_ID = '" + id + "';";
                                                                    MySqlCommand data_command4 = new MySqlCommand(dataLoad_sql4, connection1);
                                                                    connection1.Open();
                                                                    data_command4.ExecuteNonQuery();
                                                                    connection1.Close();
                                                                    string dataLoad_sql5 = "DELETE FROM wp_posts WHERE id = '" + wordpress_item_id + "';";
                                                                    MySqlCommand data_command5 = new MySqlCommand(dataLoad_sql5, connection1);
                                                                    connection1.Open();
                                                                    data_command5.ExecuteNonQuery();
                                                                    connection1.Close();

                                                                    MessageBox.Show("Error occured while entering the product price details in wordpress table. Try uploading a product with different detais.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                    return;
                                                                }
                                                                catch
                                                                {
                                                                    MessageBox.Show("Error occured while entering the product price details in wordpress table. Try uploading a product with different detais.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                    return;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            try
                                                            {
                                                                //Queries to be inserted when sale price is equal to 0
                                                                string mysql3 = "INSERT INTO wp_term_relationships VALUES ('" + wordpress_item_id + "','" + wp_category_id + "','0'); INSERT INTO wp_postmeta(post_id,meta_key,meta_value) VALUES('" + wordpress_item_id + "','_regular_price', '" + productPrice + "'); INSERT INTO wp_postmeta(post_id,meta_key,meta_value) VALUES('" + wordpress_item_id + "','_price', '" + productPrice + "'); ";
                                                                MySqlCommand command11 = new MySqlCommand(mysql3, connection);
                                                                connection.Open();
                                                                command11.ExecuteNonQuery();
                                                                connection.Close();
                                                            }
                                                            catch
                                                            {
                                                                try
                                                                {
                                                                    MySqlConnection connection1 = new MySqlConnection(connectionString);
                                                                    string sql3 = "SELECT ITEM_ID from INVENTORY where ITEM_NAME='" + productName + "';";
                                                                    MySqlCommand command3 = new MySqlCommand(sql3, connection1);
                                                                    connection1.Open();
                                                                    MySqlDataReader myreader2;
                                                                    myreader2 = command3.ExecuteReader();
                                                                    myreader2.Read();
                                                                    int id = myreader2.GetInt32(0);
                                                                    myreader2.Close();
                                                                    connection1.Close();

                                                                    string dataLoad_sql4 = "DELETE FROM INVENTORY WHERE ITEM_ID = '" + id + "';";
                                                                    MySqlCommand data_command4 = new MySqlCommand(dataLoad_sql4, connection1);
                                                                    connection1.Open();
                                                                    data_command4.ExecuteNonQuery();
                                                                    connection1.Close();

                                                                    string dataLoad_sql5 = "DELETE FROM wp_posts WHERE id = '" + wordpress_item_id + "';";
                                                                    MySqlCommand data_command5 = new MySqlCommand(dataLoad_sql5, connection1);
                                                                    connection1.Open();
                                                                    data_command5.ExecuteNonQuery();
                                                                    connection1.Close();

                                                                    MessageBox.Show("Error occured while entering the product price details in wordpress table. Try uploading a product with different detais.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                    return;
                                                                }
                                                                catch
                                                                {
                                                                    MessageBox.Show("Error occured while entering the product price details in wordpress table. Try uploading a product with different detais.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                    return;
                                                                }
                                                            }
                                                        }

                                                        try
                                                        {
                                                            //Updating wp_posts table with additional product details.
                                                            string mysql4 = "update wp_posts set guid = 'http://localhost/mysite/wordpress/?post_type=product&#038;p=" + wordpress_item_id + "'  where id = '" + wordpress_item_id + "';INSERT INTO wp_postmeta(post_id,meta_key,meta_value) VALUES('" + wordpress_item_id + "','_sold_individually', 'yes'); update wp_posts set post_content='<span style=\"color: #201f1e; font-family: ''Segoe UI'', ''Segoe UI Web (West European)'', ''Segoe UI'', -apple-system, BlinkMacSystemFont, Roboto, ''Helvetica Neue'', sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: #ffffff; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;\">" + productName + " available for purchase at Vincent''s, " + productLocation.Replace("Vincent's ", "") + "</span>' where id = '" + wordpress_item_id + "'; ";
                                                            MySqlCommand command7 = new MySqlCommand(mysql4, connection);
                                                            connection.Open();
                                                            command7.ExecuteNonQuery();
                                                            connection.Close();
                                                        }
                                                        catch
                                                        {
                                                            try
                                                            {
                                                                MySqlConnection connection1 = new MySqlConnection(connectionString);
                                                                string sql3 = "SELECT ITEM_ID from INVENTORY where ITEM_NAME='" + productName + "';";
                                                                MySqlCommand command3 = new MySqlCommand(sql3, connection1);
                                                                connection1.Open();
                                                                MySqlDataReader myreader2;
                                                                myreader2 = command3.ExecuteReader();
                                                                myreader2.Read();
                                                                int id = myreader2.GetInt32(0);
                                                                myreader2.Close();
                                                                connection1.Close();

                                                                string dataLoad_sql4 = "DELETE FROM INVENTORY WHERE ITEM_ID = '" + id + "';";
                                                                MySqlCommand data_command4 = new MySqlCommand(dataLoad_sql4, connection1);
                                                                connection1.Open();
                                                                data_command4.ExecuteNonQuery();
                                                                connection1.Close();

                                                                string dataLoad_sql5 = "DELETE FROM wp_posts WHERE id = '" + wordpress_item_id + "';";
                                                                MySqlCommand data_command5 = new MySqlCommand(dataLoad_sql5, connection1);
                                                                connection1.Open();
                                                                data_command5.ExecuteNonQuery();
                                                                connection1.Close();

                                                                MessageBox.Show("Error occured while entering the product details in wordpress table. Try uploading a product with different detais.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                return;
                                                            }
                                                            catch
                                                            {
                                                                MessageBox.Show("Error occured while entering the product details in wordpress table. Try uploading a product with different detais.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                return;
                                                            }
                                                        }

                                                        //Code to add images to the product.
                                                        int count = 1;
                                                        int image_id = 0;
                                                        foreach (string image in myimages)
                                                        {
                                                            string imageName = image.Replace(".jpg", "");
                                                            string imageName1 = imageName.Trim().Replace(" ", "-");

                                                            try
                                                            {
                                                                //Selecting id for the images if already inserted.
                                                                string mysql6 = "select id from wp_posts where post_type = 'attachment' and post_title = '" + imageName + "';";
                                                                MySqlCommand command9 = new MySqlCommand(mysql6, connection);
                                                                connection.Open();
                                                                MySqlDataReader myreader2;
                                                                myreader2 = command9.ExecuteReader();


                                                                //If no image id found in the database then add the image in the database.
                                                                if (!myreader2.Read())
                                                                {
                                                                    try
                                                                    {
                                                                        //Inserting image details in the database. 
                                                                        string mysql5 = "INSERT INTO wp_posts (post_author, post_date, post_date_gmt, post_content,post_title, post_excerpt, post_status,comment_status, ping_status, post_password, post_name, to_ping, pinged, post_modified, post_modified_gmt,post_content_filtered, post_parent , guid, menu_order, post_type, post_mime_type, comment_count) VALUES('" + wp_shop_id + "', '" + in_stock_date + "', '" + in_stock_date + "', '', '" + imageName + "','','inherit', 'open', 'closed','', '" + imageName1 + "','','', '" + in_stock_date + "','" + in_stock_date + "','' , '" + wordpress_item_id + "', 'http://localhost/mysite/wordpress/wp-content/uploads/2020/03/" + imageName1 + ".jpg','0', 'attachment','image/jpeg', '0') ;";
                                                                        MySqlConnection conn8 = new MySqlConnection(connectionString);
                                                                        MySqlCommand command8 = new MySqlCommand(mysql5, conn8);
                                                                        conn8.Open();
                                                                        command8.ExecuteNonQuery();
                                                                        conn8.Close();
                                                                    }
                                                                    catch
                                                                    {
                                                                        try
                                                                        {
                                                                            MySqlConnection connection1 = new MySqlConnection(connectionString);
                                                                            string sql3 = "SELECT ITEM_ID from INVENTORY where ITEM_NAME='" + productName + "';";
                                                                            MySqlCommand command3 = new MySqlCommand(sql3, connection1);
                                                                            connection1.Open();
                                                                            MySqlDataReader myreader3;
                                                                            myreader3 = command3.ExecuteReader();
                                                                            myreader3.Read();
                                                                            int id = myreader3.GetInt32(0);
                                                                            myreader3.Close();
                                                                            connection1.Close();

                                                                            string dataLoad_sql4 = "DELETE FROM INVENTORY WHERE ITEM_ID = '" + id + "';";
                                                                            MySqlCommand data_command4 = new MySqlCommand(dataLoad_sql4, connection1);
                                                                            connection1.Open();
                                                                            data_command4.ExecuteNonQuery();
                                                                            connection1.Close();

                                                                            string dataLoad_sql5 = "DELETE FROM wp_posts WHERE id = '" + wordpress_item_id + "';";
                                                                            MySqlCommand data_command5 = new MySqlCommand(dataLoad_sql5, connection1);
                                                                            connection1.Open();
                                                                            data_command5.ExecuteNonQuery();
                                                                            connection1.Close();

                                                                            MessageBox.Show("Error occured while adding image details in the wordpress database. Try uploading a product with different image name.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                            return;
                                                                        }
                                                                        catch
                                                                        {
                                                                            MessageBox.Show("Error occured while adding image details in the wordpress database. Try uploading a product with different image name.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                            return;
                                                                        }
                                                                    }

                                                                    try
                                                                    {
                                                                        //Query to select the image id for the inserted image and assign to image_id.
                                                                        string mysql8 = "select id from wp_posts where post_type = 'attachment' and post_title = '" + imageName + "';";
                                                                        MySqlConnection conn12 = new MySqlConnection(connectionString);
                                                                        MySqlCommand command12 = new MySqlCommand(mysql8, conn12);
                                                                        conn12.Open();
                                                                        MySqlDataReader myreader3;
                                                                        myreader3 = command12.ExecuteReader();
                                                                        myreader3.Read();
                                                                        image_id = myreader3.GetInt32(0);
                                                                        myreader3.Close();
                                                                        conn12.Close();
                                                                    }
                                                                    catch
                                                                    {
                                                                        try
                                                                        {
                                                                            MySqlConnection connection1 = new MySqlConnection(connectionString);
                                                                            string sql3 = "SELECT ITEM_ID from INVENTORY where ITEM_NAME='" + productName + "';";
                                                                            MySqlCommand command3 = new MySqlCommand(sql3, connection1);
                                                                            connection1.Open();
                                                                            MySqlDataReader myreader3;
                                                                            myreader3 = command3.ExecuteReader();
                                                                            myreader3.Read();
                                                                            int id = myreader3.GetInt32(0);
                                                                            myreader3.Close();
                                                                            connection1.Close();

                                                                            string dataLoad_sql4 = "DELETE FROM INVENTORY WHERE ITEM_ID = '" + id + "';";
                                                                            MySqlCommand data_command4 = new MySqlCommand(dataLoad_sql4, connection1);
                                                                            connection1.Open();
                                                                            data_command4.ExecuteNonQuery();
                                                                            connection1.Close();

                                                                            string dataLoad_sql5 = "DELETE FROM wp_posts WHERE id = '" + wordpress_item_id + "';";
                                                                            MySqlCommand data_command5 = new MySqlCommand(dataLoad_sql5, connection1);
                                                                            connection1.Open();
                                                                            data_command5.ExecuteNonQuery();
                                                                            connection1.Close();

                                                                            MessageBox.Show("Error occured while retrieving image details from the wordpress database. Try uploading a product with different image.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                            return;
                                                                        }
                                                                        catch
                                                                        {
                                                                            MessageBox.Show("Error occured while retrieving image details from the wordpress database. Try uploading a product with different image.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                            return;
                                                                        }
                                                                    }

                                                                    if (count == 1)
                                                                    {
                                                                        try
                                                                        {
                                                                            //Assigning the image id to the respective product.
                                                                            string mysql7 = "INSERT INTO wp_postmeta (post_id,meta_key,meta_value) VALUES('" + wordpress_item_id + "', '_thumbnail_id', '" + image_id + "');INSERT INTO wp_postmeta (post_id,meta_key,meta_value) VALUES('" + image_id + "','_wp_attached_file','2020/03/" + imageName1 + ".jpg'); INSERT INTO wp_postmeta (post_id,meta_key,meta_value) VALUES('" + image_id + "','_wp_attachment_metadata','a:5:{s:5:\"width\";i:468;s:6:\"height\";i:801;s:4:\"file\";s:22:\"2020/03/" + imageName1 + ".jpg\";s:5:\"sizes\";a:6:{s:6:\"medium\";a:4:{s:4:\"file\";s:22:\"" + imageName1 + "-175x300.jpg\";s:5:\"width\";i:175;s:6:\"height\";i:300;s:9:\"mime-type\";s:10:\"image/jpeg\";}s:9:\"thumbnail\";a:4:{s:4:\"file\";s:22:\"" + imageName1 + "-150x150.jpg\";s:5:\"width\";i:150;s:6:\"height\";i:150;s:9:\"mime-type\";s:10:\"image/jpeg\";}s:21:\"woocommerce_thumbnail\";a:5:{s:4:\"file\";s:22:\"" + imageName1 + "-265x331.jpg\";s:5:\"width\";i:265;s:6:\"height\";i:331;s:9:\"mime-type\";s:10:\"image/jpeg\";s:9:\"uncropped\";b:0;}s:29:\"woocommerce_gallery_thumbnail\";a:4:{s:4:\"file\";s:22:\"" + imageName1 + "-100x100.jpg\";s:5:\"width\";i:100;s:6:\"height\";i:100;s:9:\"mime-type\";s:10:\"image/jpeg\";}s:12:\"shop_catalog\";a:4:{s:4:\"file\";s:22:\"" + imageName1 + "-265x331.jpg\";s:5:\"width\";i:265;s:6:\"height\";i:331;s:9:\"mime-type\";s:10:\"image/jpeg\";}s:14:\"shop_thumbnail\";a:4:{s:4:\"file\";s:22:\"" + imageName1 + "-100x100.jpg\";s:5:\"width\";i:100;s:6:\"height\";i:100;s:9:\"mime-type\";s:10:\"image/jpeg\";}}s:10:\"image_meta\";a:12:{s:8:\"aperture\";s:1:\"0\";s:6:\"credit\";s:15:\"Siddhant Kandoi\";s:6:\"camera\";s:0:\"\";s:7:\"caption\";s:0:\"\";s:17:\"created_timestamp\";s:10:\"1583371749\";s:9:\"copyright\";s:0:\"\";s:12:\"focal_length\";s:1:\"0\";s:3:\"iso\";s:1:\"0\";s:13:\"shutter_speed\";s:1:\"0\";s:5:\"title\";s:0:\"\";s:11:\"orientation\";s:1:\"0\";s:8:\"keywords\";a:0:{}}}');";
                                                                            MySqlConnection conn10 = new MySqlConnection(connectionString);
                                                                            MySqlCommand command10 = new MySqlCommand(mysql7, conn10);
                                                                            conn10.Open();
                                                                            command10.ExecuteNonQuery();
                                                                            conn10.Close();
                                                                            count++;
                                                                            UploadImage();
                                                                        }
                                                                        catch
                                                                        {
                                                                            try
                                                                            {
                                                                                MySqlConnection connection1 = new MySqlConnection(connectionString);
                                                                                string sql3 = "SELECT ITEM_ID from INVENTORY where ITEM_NAME='" + productName + "';";
                                                                                MySqlCommand command3 = new MySqlCommand(sql3, connection1);
                                                                                connection1.Open();
                                                                                MySqlDataReader myreader3;
                                                                                myreader3 = command3.ExecuteReader();
                                                                                myreader3.Read();
                                                                                int id = myreader3.GetInt32(0);
                                                                                myreader3.Close();
                                                                                connection1.Close();

                                                                                string dataLoad_sql4 = "DELETE FROM INVENTORY WHERE ITEM_ID = '" + id + "';";
                                                                                MySqlCommand data_command4 = new MySqlCommand(dataLoad_sql4, connection1);
                                                                                connection1.Open();
                                                                                data_command4.ExecuteNonQuery();
                                                                                connection1.Close();

                                                                                string dataLoad_sql5 = "DELETE FROM wp_posts WHERE id = '" + wordpress_item_id + "';DELETE FROM WP_POSTS WHERE ID = '" + image_id + "';";
                                                                                MySqlCommand data_command5 = new MySqlCommand(dataLoad_sql5, connection1);
                                                                                connection1.Open();
                                                                                data_command5.ExecuteNonQuery();
                                                                                connection1.Close();

                                                                                MessageBox.Show("Error occured while retrieving image details from the wordpress database. Try uploading a product with different image.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                                return;

                                                                            }
                                                                            catch
                                                                            {
                                                                                MessageBox.Show("Error occured while retrieving image details from the wordpress database. Try uploading a product with different image.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                                return;
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        try
                                                                        {
                                                                            //Assigning the image id to the respective product.
                                                                            string mysql7 = "INSERT INTO wp_postmeta (post_id,meta_key,meta_value) VALUES('" + wordpress_item_id + "','_product_image_gallery','" + image_id + "');INSERT INTO wp_postmeta (post_id,meta_key,meta_value) VALUES('" + image_id + "','_wp_attached_file','2020/03/" + imageName1 + ".jpg'); INSERT INTO wp_postmeta (post_id,meta_key,meta_value) VALUES('" + image_id + "','_wp_attachment_metadata','a:5:{s:5:\"width\";i:468;s:6:\"height\";i:801;s:4:\"file\";s:22:\"2020/03/" + imageName1 + ".jpg\";s:5:\"sizes\";a:6:{s:6:\"medium\";a:4:{s:4:\"file\";s:22:\"" + imageName1 + "-175x300.jpg\";s:5:\"width\";i:175;s:6:\"height\";i:300;s:9:\"mime-type\";s:10:\"image/jpeg\";}s:9:\"thumbnail\";a:4:{s:4:\"file\";s:22:\"" + imageName1 + "-150x150.jpg\";s:5:\"width\";i:150;s:6:\"height\";i:150;s:9:\"mime-type\";s:10:\"image/jpeg\";}s:21:\"woocommerce_thumbnail\";a:5:{s:4:\"file\";s:22:\"" + imageName1 + "-265x331.jpg\";s:5:\"width\";i:265;s:6:\"height\";i:331;s:9:\"mime-type\";s:10:\"image/jpeg\";s:9:\"uncropped\";b:0;}s:29:\"woocommerce_gallery_thumbnail\";a:4:{s:4:\"file\";s:22:\"" + imageName1 + "-100x100.jpg\";s:5:\"width\";i:100;s:6:\"height\";i:100;s:9:\"mime-type\";s:10:\"image/jpeg\";}s:12:\"shop_catalog\";a:4:{s:4:\"file\";s:22:\"" + imageName1 + "-265x331.jpg\";s:5:\"width\";i:265;s:6:\"height\";i:331;s:9:\"mime-type\";s:10:\"image/jpeg\";}s:14:\"shop_thumbnail\";a:4:{s:4:\"file\";s:22:\"" + imageName1 + "-100x100.jpg\";s:5:\"width\";i:100;s:6:\"height\";i:100;s:9:\"mime-type\";s:10:\"image/jpeg\";}}s:10:\"image_meta\";a:12:{s:8:\"aperture\";s:1:\"0\";s:6:\"credit\";s:15:\"Siddhant Kandoi\";s:6:\"camera\";s:0:\"\";s:7:\"caption\";s:0:\"\";s:17:\"created_timestamp\";s:10:\"1583371749\";s:9:\"copyright\";s:0:\"\";s:12:\"focal_length\";s:1:\"0\";s:3:\"iso\";s:1:\"0\";s:13:\"shutter_speed\";s:1:\"0\";s:5:\"title\";s:0:\"\";s:11:\"orientation\";s:1:\"0\";s:8:\"keywords\";a:0:{}}}');";
                                                                            MySqlConnection conn10 = new MySqlConnection(connectionString);
                                                                            MySqlCommand command10 = new MySqlCommand(mysql7, conn10);
                                                                            conn10.Open();
                                                                            command10.ExecuteNonQuery();
                                                                            conn10.Close();
                                                                            count++;
                                                                            UploadImage();
                                                                        }
                                                                        catch
                                                                        {
                                                                            try
                                                                            {
                                                                                MySqlConnection connection1 = new MySqlConnection(connectionString);
                                                                                string sql3 = "SELECT ITEM_ID from INVENTORY where ITEM_NAME='" + productName + "';";
                                                                                MySqlCommand command3 = new MySqlCommand(sql3, connection1);
                                                                                connection1.Open();
                                                                                MySqlDataReader myreader3;
                                                                                myreader3 = command3.ExecuteReader();
                                                                                myreader3.Read();
                                                                                int id = myreader3.GetInt32(0);
                                                                                myreader3.Close();
                                                                                connection1.Close();

                                                                                string dataLoad_sql4 = "DELETE FROM INVENTORY WHERE ITEM_ID = '" + id + "';";
                                                                                MySqlCommand data_command4 = new MySqlCommand(dataLoad_sql4, connection1);
                                                                                connection1.Open();
                                                                                data_command4.ExecuteNonQuery();
                                                                                connection1.Close();

                                                                                string dataLoad_sql5 = "DELETE FROM wp_posts WHERE id = '" + wordpress_item_id + "';DELETE FROM WP_POSTS WHERE ID = '" + image_id + "';";
                                                                                MySqlCommand data_command5 = new MySqlCommand(dataLoad_sql5, connection1);
                                                                                connection1.Open();
                                                                                data_command5.ExecuteNonQuery();
                                                                                connection1.Close();

                                                                                MessageBox.Show("Error occured while retrieving image details from the wordpress database. Try uploading a product with different image.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                                return;
                                                                            }
                                                                            catch
                                                                            {
                                                                                MessageBox.Show("Error occured while retrieving image details from the wordpress database. Try uploading a product with different image.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                                return;
                                                                            }
                                                                        }
                                                                    }
                                                                    connection.Close();
                                                                }
                                                                else
                                                                {

                                                                    try
                                                                    {
                                                                        MySqlConnection connection1 = new MySqlConnection(connectionString);
                                                                        string sql3 = "SELECT ITEM_ID from INVENTORY where ITEM_NAME='" + productName + "';";
                                                                        MySqlCommand command3 = new MySqlCommand(sql3, connection1);
                                                                        connection1.Open();
                                                                        MySqlDataReader myreader3;
                                                                        myreader3 = command3.ExecuteReader();
                                                                        myreader3.Read();
                                                                        int id = myreader3.GetInt32(0);
                                                                        myreader3.Close();
                                                                        connection1.Close();

                                                                        string dataLoad_sql4 = "DELETE FROM INVENTORY WHERE ITEM_ID = '" + id + "';";
                                                                        MySqlCommand data_command4 = new MySqlCommand(dataLoad_sql4, connection1);
                                                                        connection1.Open();
                                                                        data_command4.ExecuteNonQuery();
                                                                        connection1.Close();

                                                                        string dataLoad_sql5 = "DELETE FROM wp_posts WHERE id = '" + wordpress_item_id + "';";
                                                                        MySqlCommand data_command5 = new MySqlCommand(dataLoad_sql5, connection1);
                                                                        connection1.Open();
                                                                        data_command5.ExecuteNonQuery();
                                                                        connection1.Close();

                                                                        MessageBox.Show("Image with same name already exists. Please add a different image or rename the image before adding.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                        return;
                                                                    }
                                                                    catch
                                                                    {
                                                                        MessageBox.Show("Image with same name already exists. Please add a different image or rename the image before adding.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                        return;
                                                                    }
                                                                    //return;
                                                                }
                                                            }
                                                            catch
                                                            {
                                                                try
                                                                {
                                                                    MySqlConnection connection1 = new MySqlConnection(connectionString);
                                                                    string sql3 = "SELECT ITEM_ID from INVENTORY where ITEM_NAME='" + productName + "';";
                                                                    MySqlCommand command3 = new MySqlCommand(sql3, connection1);
                                                                    connection1.Open();
                                                                    MySqlDataReader myreader3;
                                                                    myreader3 = command3.ExecuteReader();
                                                                    myreader3.Read();
                                                                    int id = myreader3.GetInt32(0);
                                                                    myreader3.Close();
                                                                    connection1.Close();

                                                                    string dataLoad_sql4 = "DELETE FROM INVENTORY WHERE ITEM_ID = '" + id + "';";
                                                                    MySqlCommand data_command4 = new MySqlCommand(dataLoad_sql4, connection1);
                                                                    connection1.Open();
                                                                    data_command4.ExecuteNonQuery();
                                                                    connection1.Close();

                                                                    string dataLoad_sql5 = "DELETE FROM wp_posts WHERE id = '" + wordpress_item_id + "';";
                                                                    MySqlCommand data_command5 = new MySqlCommand(dataLoad_sql5, connection1);
                                                                    connection1.Open();
                                                                    data_command5.ExecuteNonQuery();
                                                                    connection1.Close();

                                                                    MessageBox.Show("Error occured while retrieving details from database. Try uploading a product with different image name.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                    return;
                                                                }
                                                                catch
                                                                {
                                                                    MessageBox.Show("Error occured while retrieving details from database. Try uploading a product with different image name.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                    return;
                                                                }
                                                            }


                                                        }


                                                        //Code to set validations after successfully uploading a product
                                                        MessageBox.Show("Item has been successfully added", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        ProductNameTextBox.Text = "What are you selling?";
                                                        ProductDescriptionRichTextBox.Text = "Describe what you are selling";
                                                        ProductSizeRichTextBox.Text = "if applicable";
                                                        ProductPriceTextBox.Text = "Product Price";
                                                        SalePriceTextBox.Text = "Sale Price";
                                                        ProductTypeComboBox.SelectedIndex = -1;
                                                        ProductLocationComboBox.SelectedIndex = -1;
                                                        ImagePictureBox.Image = null;
                                                        ImageListBox.Visible = false;
                                                        ImagePictureBox.Visible = true;
                                                        ImageLabel.Visible = true;
                                                        imageList.Clear();
                                                        ImageListBox.Items.Clear();
                                                        AddMorePicturesButton.Visible = false;
                                                        ScrollUpPictureBox.Visible = false;
                                                        ScrollDownPictureBox.Visible = false;
                                                        DeletePictureButton.Visible = false;


                                                    }
                                                }

                                                catch (Exception Ex)
                                                {
                                                    MessageBox.Show("There is a problem with the database of this application (Error 3). Please contact online and media coordinator to resolve this error. ", "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    Console.WriteLine(Ex);
                                                }

                                            }

                                        }
                                    }

                                }

                            }

                            else
                            {
                                MessageBox.Show("Please enter a valid  price of the product.", "Product price missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }

                    }

                }
            }

         }
          
            // Events after clicking on Back Button
            private void BackButton_Click(object sender, EventArgs e)
            {

            DialogResult resultBack = MessageBox.Show("Are you sure you want to go back? Unsaved records will be lost.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (resultBack == DialogResult.Yes)
            {
                this.Hide();

                if(isModifyOrDelete == true)
                {
                   
                    ModifyScreen form4 = new ModifyScreen();
                    form4.ShowDialog();
                    form4.setIsDelete = false;

                }
                else
                {
                    //Declaring a variable for WelcomeForm
                    WelcomeForm form2 = new WelcomeForm();

                    //Showing WelcomeForm
                    form2.ShowDialog();

                }

            }
        
        }
             
            // Code to add a picture to upload
            private void AddPhotosButton_Click(object sender, EventArgs e)
            {

                //string imageLocation = "";
                try
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                    if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        //Code Added by Shefali to upload images on FTP server
                        flag = 1;
                        imageLocation = dialog.FileName;

                        ImagePictureBox.ImageLocation = imageLocation;
                        imageList.Add(imageLocation);
                        ImageListBox.Items.Add(Path.GetFileName(imageLocation) +"- Title Image");
                        DeletePictureButton.Visible = true;
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("Error encountered while uploading this image. Try using a different image. ", "Connection Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                }

            if  (! (ImagePictureBox.ImageLocation is null))
            {
                AddMorePicturesButton.Visible = true;
                ImageLabel.Visible = false;
            }

        }

        // Code to add more than one picture
        private void AddMorePicturesButton_Click(object sender, EventArgs e)
        {
           
            //String imageLocation = "";

            try
            { 
                // Code to open dialog box and perform actions to upload more images
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Code added by Shefali to upload images on FTP server
                    flag = 1;
                    imageLocation = dialog.FileName;
                    imageList.Add(imageLocation);
                    ImageListBox.Items.Add(Path.GetFileName(imageLocation));
                    
                    ImageListBox.Visible = true;
                    AddMorePicturesButton.Visible = false;
                    AddMorePicturesButton.Visible = true;
                    ImageListBox.SelectedIndex = 0;
                    ScrollDownPictureBox.Visible = true;
                    ScrollUpPictureBox.Visible = true;
                                      
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Error encountered while uploading this image. Try using a different image.", "FTP Connection Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            }
      
        }

        // Code to perform an action when user clicks on camera icon
        private void AddPhotosPictureBox_Click(object sender, EventArgs e)
        {
            AddPhotosButton.PerformClick();
        }


        // Code to perform an action when user clicks on Delete Picture button
        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            try
            {
                if (ImageListBox.SelectedIndex != -1 || ImageListBox.Visible == false )
                {


                if(imageList.Count == 1)
                {
                     dr =  MessageBox.Show("Are you sure you want to delete the Image " + ImageListBox.Items[0] + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else if(imageList.Count > 1 && ImageListBox.SelectedIndex != -1)
                {
                    dr =   MessageBox.Show("Are you sure you want to delete the Image " + ImageListBox.SelectedItem + "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                    if (dr == DialogResult.Yes)
                    {

                        if (ImageListBox.SelectedIndex != -1 && imageList.Count != 1)
                        {
                            if (imageList.Count != 0 && imageList.Count > 1)
                            {
                                //Database queries to delete the image.
                                flag = 1;
                                string imageName = ImageListBox.SelectedItem.ToString();
                                string imageName1 = imageName.Replace(".jpg", "");
                                try
                                {
                                    // Select id from the wp table for the image to be deleted.
                                    string mysql6 = "select id from wp_posts where post_type = 'attachment' and post_name = '" + imageName1 + "';";
                                    MySqlCommand command9 = new MySqlCommand(mysql6, connection);
                                    connection.Open();
                                    MySqlDataReader myreader2;
                                    myreader2 = command9.ExecuteReader();

                                    string productName = ProductNameTextBox.Text.Trim();
                                    int wordpress_item_id = 0;
                                    try
                                    {
                                        //Selecting the id from wp table for the product and assign to wordpress_item_id.
                                        string mysql2 = "select id from wp_posts where post_type = 'product' and post_title = '" + productName + "';";
                                        MySqlConnection conn7 = new MySqlConnection(connectionString);
                                        MySqlCommand command6 = new MySqlCommand(mysql2, conn7);
                                        conn7.Open();
                                        MySqlDataReader myreader1;
                                        myreader1 = command6.ExecuteReader();
                                        if (myreader1.Read())
                                        {
                                            wordpress_item_id = myreader1.GetInt32(0);
                                        }
                                        myreader1.Close();
                                        conn7.Close();
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Error deleting the image from database.", "Image Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }

                                    //If image is found in the database then delete the image from the database.
                                    if (myreader2.Read() && wordpress_item_id != 0)
                                    {
                                        int image_id = myreader2.GetInt32(0);
                                        string mysql5 = "DELETE FROM wp_posts Where id = '" + image_id + "'; DELETE FROM wp_postmeta Where meta_value = '" + image_id + "'; DELETE FROM wp_postmeta Where post_id = '" + image_id + "' ;";
                                        MySqlConnection conn8 = new MySqlConnection(connectionString);
                                        MySqlCommand command8 = new MySqlCommand(mysql5, conn8);
                                        conn8.Open();
                                        command8.ExecuteNonQuery();
                                        conn8.Close();
                                    }

                                    connection.Close();

                                }
                                catch {
                                    MessageBox.Show("Error deleting the image from database.", "Image Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }

                                
                                imageList.RemoveAt(ImageListBox.SelectedIndex);
                                ImageListBox.Items.RemoveAt(ImageListBox.SelectedIndex);
                                ImageListBox.SelectedIndex = 0;

                                if (imageList.Count == 1)
                                {

                                    ImagePictureBox.Visible = true;
                                    ImageListBox.Visible = false;
                                    ScrollUpPictureBox.Visible = false;
                                    ScrollDownPictureBox.Visible = false;
                                   
                                    ImagePictureBox.ImageLocation = imageList[0];
                                    ImageListBox.Items[0] = Path.GetFileName(imageList[0]) + "- Title Image";
                                }

                                else
                                {
                                    
                                    ImagePictureBox.Visible = true;
                                    ImageListBox.Visible = true;
                                    ImagePictureBox.ImageLocation = imageList[0];
                                    ImageListBox.Items[0] = Path.GetFileName(imageList[0]) + "- Title Image";
                                }
                            }

                        }
                        else if (imageList.Count == 1)
                        {

                            //Database queries to delete the image.
                            flag = 1;
                            string imageName = Path.GetFileName(ImagePictureBox.ImageLocation);
                            string imageName1 = imageName.Replace(".jpg", "");
                            // Select id from the wp table for the image to be deleted.
                            try { 
                            string mysql6 = "select id from wp_posts where post_type = 'attachment' and post_name = '" + imageName1 + "';";
                            MySqlCommand command9 = new MySqlCommand(mysql6, connection);
                            connection.Open();
                            MySqlDataReader myreader2;
                            myreader2 = command9.ExecuteReader();

                            string productName = ProductNameTextBox.Text.Trim();
                            int wordpress_item_id = 0;
                            try
                            {
                                //Selecting the id from wp table for the product and assign to wordpress_item_id.
                                string mysql2 = "select id from wp_posts where post_type = 'product' and post_title = '" + productName + "';";
                                MySqlConnection conn7 = new MySqlConnection(connectionString);
                                MySqlCommand command6 = new MySqlCommand(mysql2, conn7);
                                conn7.Open();
                                MySqlDataReader myreader1;
                                myreader1 = command6.ExecuteReader();
                                if (myreader1.Read())
                                {
                                    wordpress_item_id = myreader1.GetInt32(0);
                                }
                                myreader1.Close();
                                conn7.Close();
                            }
                            catch
                            {
                                    MessageBox.Show("Error deleting the image from database.", "Image Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            //If image is found in the database then delete the image from the database.
                            if (myreader2.Read() && wordpress_item_id != 0)
                            {
                                int image_id = myreader2.GetInt32(0);
                                string mysql5 = "DELETE FROM wp_posts Where id = '" + image_id + "'; DELETE FROM wp_postmeta Where meta_value = '" + image_id + "'; DELETE FROM wp_postmeta Where post_id = '" + image_id + "' ;";
                                MySqlConnection conn8 = new MySqlConnection(connectionString);
                                MySqlCommand command8 = new MySqlCommand(mysql5, conn8);
                                conn8.Open();
                                command8.ExecuteNonQuery();
                                conn8.Close();
                            }

                            connection.Close();
                            }
                            catch
                            {
                                MessageBox.Show("Error deleting the image from database.", "Image Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            ImagePictureBox.Image = null;
                            imageList.RemoveAt(0);
                            ImageListBox.Items.RemoveAt(0);
                            DeletePictureButton.Visible = false;
                            AddMorePicturesButton.Visible = false;
                            AddPhotosButton.Visible = true;
                        }
                    }
                    
              }

                else
                {
                    MessageBox.Show("Please select an image and add the article from list box to delete", "Image Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            catch(Exception Ex)
            {
                MessageBox.Show("There is a problem with the database of this application (Error 6). Please contact online and media coordinator to resolve this error. " + Ex, "Database connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("There is a problem with the database of this application (Error 6). Please contact online and media coordinator to resolve this error. " + Ex);
            }


        }

        // Code to perform an action when user clicks on Modify button on Upload page
        private void ModifyUploadPageButton_Click(object sender, EventArgs e)
        {


            // Validations for Product name text box
            if (ProductNameTextBox.Text == "" || ProductNameTextBox.Text == "What are you selling?")
            {
                MessageBox.Show("Please Enter a valid Product name", "Product name missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                productName = ProductNameTextBox.Text.Trim();

                // Validations for Product description text box
                if (ProductDescriptionRichTextBox.Text == "" || ProductDescriptionRichTextBox.Text == "Describe what you are selling")
                {
                    MessageBox.Show("Please Enter valid Product description", "Product description missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    productDescription = ProductDescriptionRichTextBox.Text;

                    // product price is mandatory, sale price is not
                    if (ProductPriceTextBox.Text == "Product Price" || ProductPriceTextBox.Text == "")
                    {
                        MessageBox.Show("Please enter the price of the product.", "Product price missing", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        // accepting value for Product and sale price fields
                        if (decimal.TryParse(ProductPriceTextBox.Text, out productPrice))
                        {
                            if (!SalePriceTextBox.Text.Contains("Sale Price") || SalePriceTextBox.Text.Length == 0)
                            {
                                if (!decimal.TryParse(SalePriceTextBox.Text, out salePrice))
                                {
                                    MessageBox.Show("Please Enter only number or decimal digits", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                }
                                else
                                {
                                    decimal.TryParse(SalePriceTextBox.Text, out salePrice);
                                }
                            }



                            // Checking whether a product category has been chosen (Mandatory Field)
                            if (ProductTypeComboBox.SelectedIndex < 0)
                            {
                                MessageBox.Show("Please select a product type", "Product category missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }

                            else
                            {
                                // Set product category
                                productType = ProductTypeComboBox.SelectedItem.ToString();

                                // Checking whether a product location has been chosen (Mandatory Field)
                                if (ProductLocationComboBox.SelectedIndex < 0)

                                {
                                    MessageBox.Show("Please select a location", "Product location missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                }

                                else
                                {
                                    // Set product location
                                    productLocation = ProductLocationComboBox.SelectedItem.ToString();


                                    // Check whether an image is selected (Mandatory field)
                                    if (ImagePictureBox.ImageLocation is null)
                                    {
                                        MessageBox.Show("Please Upload at least 1 image to continue.", "Image missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }

                                    else
                                    {

                                        //  "Size is a mandatory entry for clothing articles. Checking whether the product is from the clothing category and if so, checking whether a size is entered"
                                        if ((ProductTypeComboBox.SelectedItem.ToString() == "Clothing Womens" || ProductTypeComboBox.SelectedItem.ToString() == "Clothing Mens" || ProductTypeComboBox.SelectedItem.ToString() == "Clothing KIDS" || ProductTypeComboBox.SelectedItem.ToString() == "Clothing SHOES") && (ProductSizeRichTextBox.Text == "if applicable" || ProductSizeRichTextBox.Text == ""))
                                        {

                                            MessageBox.Show("Please enter the size", "Product size missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }

                                        // All mandatory entries have been made
                                        else
                                        {
                                            
                                            try
                                            {



                                                if (ProductSizeRichTextBox.Text != "" && ProductSizeRichTextBox.Text != "if applicable")
                                                {
                                                    productSize = ProductSizeRichTextBox.Text;
                                                }

                                                if (ProductSizeRichTextBox.Text == "if applicable")
                                                {
                                                    productSize = "no size";

                                                }


                                                // Dialog box code when user clicks on 'Modify' button
                                                DialogResult modifyConfirmation = MessageBox.Show("Are you sure you want to modify the Item ?", "Confirm Modify", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                                if (modifyConfirmation == DialogResult.Yes)
                                                {


                                                    // Sql connection queries for Modifying an item on the website.
                                                    string[] categories = productType.Split();
                                                    string trimmed_productLocation = productLocation.Replace("Vincent's ", "").Replace(" Road", "");
                                                    string in_stock_date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                                                    int category_id = 0;
                                                    string str1 = categories[0];
                                                    string str2 = categories[1];
                                                    if (str2 == "HOME")
                                                        str2 = str2 + " DECOR";
                                                    try
                                                    {
                                                        //Selecting category id from the database based on the category selected from the database.
                                                        String sql0 = "SELECT CATEGORY_ID FROM CATEGORY WHERE CATEGORY_NAME LIKE '%" + str1 + "%';";
                                                        MySqlCommand command0 = new MySqlCommand(sql0, connection);
                                                        connection.Open();
                                                        MySqlDataReader myreader0;
                                                        myreader0 = command0.ExecuteReader();
                                                        myreader0.Read();
                                                        category_id = myreader0.GetInt32(0);
                                                        myreader0.Close();
                                                        connection.Close();
                                                    }
                                                    catch
                                                    {
                                                        MessageBox.Show("Error retrieving the category from database. Try uploading a product with different category.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                        return;
                                                    }

                                                    //Creating MySqlDataReader variables
                                                    MySqlDataReader myreader, mydata, mydata1, mydata2;
                                                    // Creating wp_category_id and wp_shop_id and initialising to 0.
                                                    int wp_category_id = 0;
                                                    int db_category_id = 0;
                                                    int db_shop_id = 0;
                                                    int wp_shop_id = 0;
                                                    int wordpress_item_id = 0;

                                                    if (str2 == "OTHER")
                                                    {
                                                        try
                                                        {
                                                            //Selecting category id from the wp table and assign to wp_category_id.
                                                            string sql2 = "SELECT term_id FROM wp_terms WHERE name LIKE '" + str2 + "' and slug like '%" + str1 + "%';";
                                                            MySqlCommand command2 = new MySqlCommand(sql2, connection);
                                                            connection.Open();
                                                            mydata1 = command2.ExecuteReader();
                                                            mydata1.Read();
                                                            wp_category_id = mydata1.GetInt32(0);
                                                            mydata1.Close();
                                                            connection.Close();
                                                        }
                                                        catch
                                                        {
                                                            MessageBox.Show("Error retrieving the category from wordpress database. Try uploading a product with different category.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            return;
                                                        }
                                                    }

                                                    else
                                                    {
                                                        try
                                                        {
                                                            //Selecting category id from the wp table and assign to wp_category_id.
                                                            string sql2 = "SELECT term_id FROM wp_terms WHERE name LIKE '" + str2 + "' and term_id between '58' and '80';";
                                                            MySqlCommand command2 = new MySqlCommand(sql2, connection);
                                                            connection.Open();
                                                            mydata1 = command2.ExecuteReader();
                                                            mydata1.Read();
                                                            wp_category_id = mydata1.GetInt32(0);
                                                            mydata1.Close();
                                                            connection.Close();
                                                        }
                                                        catch
                                                        {
                                                            MessageBox.Show("Error retrieving the category from wordpress database. Try uploading a product with different category.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            return;
                                                        }
                                                    }
                                                    try
                                                    {
                                                        //Selecting the sub category id from the database for the selected ctaegory from the combobox.
                                                        string sql = "SELECT SUB_CATEGORY_ID FROM SUB_CATEGORY WHERE SUB_CATEGORY_NAME LIKE '%" + str2 + "%' and CATEGORY_ID = '" + category_id + "';";
                                                        MySqlCommand command = new MySqlCommand(sql, connection);
                                                        connection.Open();
                                                        myreader = command.ExecuteReader();
                                                        myreader.Read();
                                                        db_category_id = myreader.GetInt32(0);
                                                        myreader.Close();
                                                        connection.Close();
                                                    }
                                                    catch
                                                    {
                                                        MessageBox.Show("Error retrieving the sub-category from database. Try updating a product from a different category.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                        return;
                                                    }

                                                    try
                                                    {
                                                        //Selecting the shop id from the database for the selected shop from the combobox.
                                                        string sql1 = "SELECT SHOP_ID FROM SHOP WHERE SHOP_NAME LIKE '%" + trimmed_productLocation + "%';";
                                                        MySqlCommand command1 = new MySqlCommand(sql1, connection);
                                                        connection.Open();
                                                        mydata = command1.ExecuteReader();
                                                        mydata.Read();
                                                        db_shop_id = mydata.GetInt32(0);
                                                        mydata.Close();
                                                        connection.Close();
                                                    }
                                                    catch
                                                    {
                                                        MessageBox.Show("Error retrieving the shop name from database. Try updating a product from a different shop.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                        return;
                                                    }

                                                    try
                                                    {
                                                        //Selecting the wordpress shop id from the database for the selected shop from the combobox.
                                                        string sql3 = "SELECT id FROM wp_users WHERE user_nicename LIKE '%" + trimmed_productLocation + "%';";
                                                        MySqlCommand command3 = new MySqlCommand(sql3, connection);
                                                        connection.Open();
                                                        mydata2 = command3.ExecuteReader();
                                                        mydata2.Read();
                                                        if (mydata2.Read())
                                                        {
                                                            wp_shop_id = mydata2.GetInt32(0);
                                                        }
                                                        wp_shop_id = mydata2.GetInt32(0);
                                                        mydata2.Close();
                                                        connection.Close();
                                                    }
                                                    catch
                                                    {
                                                        MessageBox.Show("Error retrieving the shop name from wordpress database. Try updating a product from a different shop.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                        return;
                                                    }


                                                    //Inserting records when imgae is not present in the record.
                                                    if (ImagePictureBox.Image == null)
                                                    {
                                                        try
                                                        {
                                                            //Query to update the product details in the inventory table. 
                                                            string dataLoad_sql4 = "update INVENTORY set ITEM_NAME='" + ProductNameTextBox.Text + "', ITEM_DESCRIPTION='" + ProductDescriptionRichTextBox.Text + "', PRIZE='" + productPrice + "', SALE='" + salePrice + "' , SIZE ='" + ProductSizeRichTextBox.Text + "',SHOP_ID='" + db_shop_id + "',SUB_CATEGORY_ID='" + db_category_id + "' where ITEM_ID = '" + item_id + "';";
                                                            MySqlCommand data_command4 = new MySqlCommand(dataLoad_sql4, connection);
                                                            connection.Open();
                                                            data_command4.ExecuteNonQuery();
                                                            connection.Close();
                                                        }
                                                        catch
                                                        {
                                                            MessageBox.Show("Error updating the product details in inventory table. Try updating a product with different details.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            return;
                                                        }

                                                        try
                                                        {
                                                            //Selecting the id from wp table for the product and assign to wordpress_item_id.
                                                            string sql4 = "select id from wp_posts where post_type = 'product' and post_title = '" + modifyProductName + "';";
                                                            MySqlCommand command4 = new MySqlCommand(sql4, connection);
                                                            connection.Open();
                                                            MySqlDataReader myreader2;
                                                            myreader2 = command4.ExecuteReader();
                                                            myreader2.Read();
                                                            wordpress_item_id = myreader2.GetInt32(0);
                                                            myreader2.Close();
                                                            connection.Close();
                                                        }
                                                        catch
                                                        {
                                                            MessageBox.Show("Error retrieving the product details from wordpress table. Try updating a product with different details.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            return;
                                                        }
                                                        try
                                                        {
                                                            //Query to update the product details into wordpress table.
                                                            string dataLoad_sql5 = "UPDATE wp_posts set post_title='" + productName + "', post_author= '" + wp_shop_id + "',post_excerpt='" + productDescription + "', post_modified='" + in_stock_date + "', post_modified_gmt='" + in_stock_date + "' WHERE ID = '" + wordpress_item_id + "';  UPDATE wp_postmeta SET meta_value='" + productPrice + "' WHERE post_id= '" + wordpress_item_id + "' and meta_key='_regular_price'; UPDATE wp_term_relationships SET term_taxonomy_id = '" + wp_category_id + "'  WHERE object_id = '" + wordpress_item_id + "';";
                                                            MySqlCommand data_command5 = new MySqlCommand(dataLoad_sql5, connection);
                                                            connection.Open();
                                                            data_command5.ExecuteNonQuery();
                                                            connection.Close();
                                                        }
                                                        catch
                                                        {
                                                            MessageBox.Show("Error updating the product details in the wordpress table. Try updating the product with different details.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            return;
                                                        }

                                                        if (salePrice != 0m)
                                                        {
                                                            try
                                                            {
                                                                //Queries to be inserted when sale price isnt equal to 0
                                                                string mysql3 = "UPDATE wp_postmeta SET meta_value = '" + salePrice + "' WHERE post_id = '" + wordpress_item_id + "' and meta_key = '_price'; UPDATE wp_postmeta SET meta_value = '" + salePrice + "' WHERE post_id = '" + wordpress_item_id + "' and meta_key = '_sale_price'; ";
                                                                MySqlConnection conn11 = new MySqlConnection(connectionString);
                                                                MySqlCommand command11 = new MySqlCommand(mysql3, conn11);
                                                                conn11.Open();
                                                                command11.ExecuteNonQuery();
                                                                conn11.Close();
                                                            }
                                                            catch
                                                            {
                                                                MessageBox.Show("Error updating the new price details in the wordpress table. Try updating the product with different details.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                return;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            try
                                                            {
                                                                //Queries to be inserted when sale price is equal to 0
                                                                string mysql3 = "UPDATE wp_postmeta SET meta_value = '" + productPrice + "' WHERE post_id = '" + wordpress_item_id + "' and meta_key = '_price'; DELETE from wp_postmeta WHERE post_id = '" + wordpress_item_id + "' and meta_key = '_sale_price';";
                                                                MySqlConnection conn11 = new MySqlConnection(connectionString);
                                                                MySqlCommand command11 = new MySqlCommand(mysql3, conn11);
                                                                conn11.Open();
                                                                command11.ExecuteNonQuery();
                                                                conn11.Close();
                                                            }
                                                            catch
                                                            {
                                                                MessageBox.Show("Error updating the new price details in the wordpress table. Try updating the product with different details.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                return;
                                                            }
                                                        }

                                                        MessageBox.Show("Records have been modified", "Modification confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                        this.Hide();

                                                        //Declaring a variable for WelcomeForm
                                                        WelcomeForm form2 = new WelcomeForm();

                                                        //Showing WelcomeForm
                                                        form2.ShowDialog();
                                                    }

                                                    else
                                                    {
                                                        //Code to select image names for the product and assign to the image list for processing.
                                                        byte[] img = new byte[ImageListBox.Items.Count];
                                                        List<string> myimages = new List<string>();
                                                        for (int i = 0; i < imageList.Count; i++)
                                                        {
                                                            MemoryStream ms = new MemoryStream();
                                                            img = File.ReadAllBytes(imageList[i].ToString());
                                                            string myimage = (ImageListBox.Items[i].ToString()).Replace("- Title Image", "");
                                                            myimages.Add(myimage);
                                                        }

                                                        try
                                                        {
                                                            //Query to update inventory table with updated product details.
                                                            string dataLoad_sql4 = "update INVENTORY set ITEM_NAME='" + ProductNameTextBox.Text + "', ITEM_DESCRIPTION='" + ProductDescriptionRichTextBox.Text + "', PRIZE='" + productPrice + "', SALE='" + salePrice + "', SIZE ='" + ProductSizeRichTextBox.Text + "', PICTURE = '" + img + "',SHOP_ID='" + db_shop_id + "',SUB_CATEGORY_ID='" + db_category_id + "' where ITEM_ID = '" + item_id + "';";
                                                            MySqlCommand data_command4 = new MySqlCommand(dataLoad_sql4, connection);
                                                            connection.Open();
                                                            data_command4.ExecuteNonQuery();
                                                            connection.Close();
                                                        }
                                                        catch
                                                        {
                                                            MessageBox.Show("Error updating the product details in inventory table. Try updating a product with different details.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            return;
                                                        }

                                                        try
                                                        {
                                                            //Selecting product id for the product from the database.
                                                            string sql4 = "select id from wp_posts where post_type = 'product' and post_title = '" + modifyProductName + "';";
                                                            MySqlCommand command4 = new MySqlCommand(sql4, connection);
                                                            connection.Open();
                                                            MySqlDataReader myreader2;
                                                            myreader2 = command4.ExecuteReader();
                                                            myreader2.Read();
                                                            wordpress_item_id = myreader2.GetInt32(0);
                                                            myreader2.Close();
                                                            connection.Close();
                                                        }
                                                        catch
                                                        {
                                                            MessageBox.Show("Error retrieving the product details from wordpress table. Try updating a product with different details.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            return;
                                                        }

                                                        try
                                                        {
                                                            //Query to update product details in the wp table.
                                                            string dataLoad_sql5 = "UPDATE wp_posts set post_title='" + productName + "', post_author= '" + wp_shop_id + "',post_excerpt='" + productDescription + "', post_modified='" + in_stock_date + "', post_modified_gmt='" + in_stock_date + "' WHERE ID = '" + wordpress_item_id + "';  UPDATE wp_postmeta SET meta_value='" + productPrice + "' WHERE post_id= '" + wordpress_item_id + "' and meta_key='_regular_price'; UPDATE wp_term_relationships SET term_taxonomy_id = '" + wp_category_id + "'  WHERE object_id = '" + wordpress_item_id + "';";
                                                            MySqlCommand data_command5 = new MySqlCommand(dataLoad_sql5, connection);
                                                            connection.Open();
                                                            data_command5.ExecuteNonQuery();
                                                            connection.Close();
                                                        }
                                                        catch
                                                        {
                                                            MessageBox.Show("Error updating the new product details in the wordpress table. Try updating the product with different details.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                            return;
                                                        }

                                                        if (salePrice != 0m)
                                                        {
                                                            try
                                                            {
                                                                //Queries to be updated when sale price isnt equal to 0
                                                                string mysql3 = "UPDATE wp_postmeta SET meta_value = '" + salePrice + "' WHERE post_id = '" + wordpress_item_id + "' and meta_key = '_price'; UPDATE wp_postmeta SET meta_value = '" + salePrice + "' WHERE post_id = '" + wordpress_item_id + "' and meta_key = '_sale_price'; ";
                                                                MySqlConnection conn11 = new MySqlConnection(connectionString);
                                                                MySqlCommand command11 = new MySqlCommand(mysql3, conn11);
                                                                conn11.Open();
                                                                command11.ExecuteNonQuery();
                                                                conn11.Close();
                                                            }
                                                            catch
                                                            {
                                                                MessageBox.Show("Error updating the new price details in the wordpress table. Try updating the product with different details.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                return;
                                                            }
                                                        }

                                                        else
                                                        {
                                                            try
                                                            {
                                                                //Queries to be updated when sale price is equal to 0
                                                                string mysql3 = "UPDATE wp_postmeta SET meta_value = '" + productPrice + "' WHERE post_id = '" + wordpress_item_id + "' and meta_key = '_price'; DELETE from wp_postmeta WHERE post_id = '" + wordpress_item_id + "' and meta_key = '_sale_price';";
                                                                MySqlConnection conn11 = new MySqlConnection(connectionString);
                                                                MySqlCommand command11 = new MySqlCommand(mysql3, conn11);
                                                                conn11.Open();
                                                                command11.ExecuteNonQuery();
                                                                conn11.Close();
                                                            }
                                                            catch
                                                            {
                                                                MessageBox.Show("Error updating the new price details in the wordpress table. Try updating the product with different details.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                return;
                                                            }
                                                        }
                                                        //Code to update images for the selected product.
                                                        if (flag == 1)
                                                        {
                                                            int count = 1;
                                                            foreach (string image in myimages)
                                                            {
                                                                string imageName = image.Replace(".jpg", "");//// String name1 = name.Trim().Replace(" ", "-");
                                                                string imageName1 = imageName.Trim().Replace(" ", "-");

                                                                try
                                                                {
                                                                    //Selecting id for the images if already inserted.                                              
                                                                    string mysql6 = "select id from wp_posts where post_type = 'attachment' and post_name = '" + imageName + "'  and post_parent='" + wordpress_item_id + "';";
                                                                    MySqlCommand command9 = new MySqlCommand(mysql6, connection);
                                                                    connection.Open();
                                                                    MySqlDataReader myreader4;
                                                                    myreader4 = command9.ExecuteReader();
                                                                    if (myreader4.Read())
                                                                    {
                                                                        int image_id1 = myreader4.GetInt32(0);

                                                                        //Query to delete existing image.
                                                                        string mysql7 = "DELETE FROM wp_posts Where id = '" + image_id1 + "'; DELETE FROM wp_postmeta Where meta_value = '" + image_id1 + "'; DELETE FROM wp_postmeta Where post_id = '" + image_id1 + "' ;";
                                                                        MySqlConnection conn10 = new MySqlConnection(connectionString);
                                                                        MySqlCommand command10 = new MySqlCommand(mysql7, conn10);
                                                                        conn10.Open();
                                                                        command10.ExecuteNonQuery();
                                                                        conn10.Close();
                                                                    }
                                                                    connection.Close();
                                                                }
                                                                catch
                                                                {
                                                                    MessageBox.Show("Error occured while adding image in the wordpress database. Try uploading a product with different image name.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                    return;
                                                                }

                                                                try
                                                                {
                                                                    //Inserting image details in the database. 
                                                                    string mysql5 = "INSERT INTO wp_posts (post_author, post_date, post_date_gmt, post_content,post_title, post_excerpt, post_status,comment_status, ping_status, post_password, post_name, to_ping, pinged, post_modified, post_modified_gmt,post_content_filtered, post_parent , guid, menu_order, post_type, post_mime_type, comment_count) VALUES('" + wp_shop_id + "', '" + in_stock_date + "', '" + in_stock_date + "', '', '" + imageName + "','','inherit', 'open', 'closed','', '" + imageName1 + "','','', '" + in_stock_date + "','" + in_stock_date + "','' , '" + wordpress_item_id + "', 'http://localhost/mysite/wordpress/wp-content/uploads/2020/03/" + imageName1 + ".jpg','0', 'attachment','image/jpeg', '0') ;";
                                                                    MySqlCommand command8 = new MySqlCommand(mysql5, connection);
                                                                    connection.Open();
                                                                    command8.ExecuteNonQuery();
                                                                    connection.Close();
                                                                }
                                                                catch
                                                                {
                                                                    MessageBox.Show("Error occured while adding image in the wordpress database. Try uploading a product with different image name.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                    return;
                                                                }
                                                                int image_id = 0;
                                                                try
                                                                {
                                                                    //Query to select the image id for the inserted image and assign to image_id.
                                                                    string mysql8 = "select id from wp_posts where post_type = 'attachment' and post_title = '" + imageName + "';";
                                                                    MySqlCommand command12 = new MySqlCommand(mysql8, connection);
                                                                    connection.Open();
                                                                    MySqlDataReader myreader3;
                                                                    myreader3 = command12.ExecuteReader();
                                                                    myreader3.Read();
                                                                    image_id = myreader3.GetInt32(0);
                                                                    myreader3.Close();
                                                                    connection.Close();
                                                                }
                                                                catch
                                                                {
                                                                    MessageBox.Show("Error occured while adding image details to the product the wordpress database. Try uploading a product with different image name.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                    return;
                                                                }

                                                                if (count == 1)
                                                                {
                                                                    try
                                                                    {
                                                                        //Assigning the image id to the respective product.
                                                                        string mysql7 = "INSERT INTO wp_postmeta (post_id,meta_key,meta_value) VALUES('" + wordpress_item_id + "', '_thumbnail_id', '" + image_id + "');INSERT INTO wp_postmeta (post_id,meta_key,meta_value) VALUES('" + image_id + "','_wp_attached_file','2020/03/" + imageName1 + ".jpg'); INSERT INTO wp_postmeta (post_id,meta_key,meta_value) VALUES('" + image_id + "','_wp_attachment_metadata','a:5:{s:5:\"width\";i:468;s:6:\"height\";i:801;s:4:\"file\";s:22:\"2020/03/" + imageName1 + ".jpg\";s:5:\"sizes\";a:6:{s:6:\"medium\";a:4:{s:4:\"file\";s:22:\"" + imageName1 + "-175x300.jpg\";s:5:\"width\";i:175;s:6:\"height\";i:300;s:9:\"mime-type\";s:10:\"image/jpeg\";}s:9:\"thumbnail\";a:4:{s:4:\"file\";s:22:\"" + imageName1 + "-150x150.jpg\";s:5:\"width\";i:150;s:6:\"height\";i:150;s:9:\"mime-type\";s:10:\"image/jpeg\";}s:21:\"woocommerce_thumbnail\";a:5:{s:4:\"file\";s:22:\"" + imageName1 + "-265x331.jpg\";s:5:\"width\";i:265;s:6:\"height\";i:331;s:9:\"mime-type\";s:10:\"image/jpeg\";s:9:\"uncropped\";b:0;}s:29:\"woocommerce_gallery_thumbnail\";a:4:{s:4:\"file\";s:22:\"" + imageName1 + "-100x100.jpg\";s:5:\"width\";i:100;s:6:\"height\";i:100;s:9:\"mime-type\";s:10:\"image/jpeg\";}s:12:\"shop_catalog\";a:4:{s:4:\"file\";s:22:\"" + imageName1 + "-265x331.jpg\";s:5:\"width\";i:265;s:6:\"height\";i:331;s:9:\"mime-type\";s:10:\"image/jpeg\";}s:14:\"shop_thumbnail\";a:4:{s:4:\"file\";s:22:\"" + imageName1 + "-100x100.jpg\";s:5:\"width\";i:100;s:6:\"height\";i:100;s:9:\"mime-type\";s:10:\"image/jpeg\";}}s:10:\"image_meta\";a:12:{s:8:\"aperture\";s:1:\"0\";s:6:\"credit\";s:15:\"Siddhant Kandoi\";s:6:\"camera\";s:0:\"\";s:7:\"caption\";s:0:\"\";s:17:\"created_timestamp\";s:10:\"1583371749\";s:9:\"copyright\";s:0:\"\";s:12:\"focal_length\";s:1:\"0\";s:3:\"iso\";s:1:\"0\";s:13:\"shutter_speed\";s:1:\"0\";s:5:\"title\";s:0:\"\";s:11:\"orientation\";s:1:\"0\";s:8:\"keywords\";a:0:{}}}');";
                                                                        MySqlCommand command10 = new MySqlCommand(mysql7, connection);
                                                                        connection.Open();
                                                                        command10.ExecuteNonQuery();
                                                                        connection.Close();
                                                                        count++;
                                                                        UploadImage();
                                                                    }
                                                                    catch
                                                                    {
                                                                        MessageBox.Show("Error occured while adding image details to the product the wordpress database. Try uploading a product with different image name.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                        return;
                                                                    }
                                                                }

                                                                else
                                                                {
                                                                    try
                                                                    {
                                                                        //Assigning the image id to the respective product.
                                                                        string mysql7 = "INSERT INTO wp_postmeta (post_id,meta_key,meta_value) VALUES('" + wordpress_item_id + "','_product_image_gallery','" + image_id + "');INSERT INTO wp_postmeta (post_id,meta_key,meta_value) VALUES('" + image_id + "','_wp_attached_file','2020/03/" + imageName1 + ".jpg'); INSERT INTO wp_postmeta (post_id,meta_key,meta_value) VALUES('" + image_id + "','_wp_attachment_metadata','a:5:{s:5:\"width\";i:468;s:6:\"height\";i:801;s:4:\"file\";s:22:\"2020/03/" + imageName1 + ".jpg\";s:5:\"sizes\";a:6:{s:6:\"medium\";a:4:{s:4:\"file\";s:22:\"" + imageName1 + "-175x300.jpg\";s:5:\"width\";i:175;s:6:\"height\";i:300;s:9:\"mime-type\";s:10:\"image/jpeg\";}s:9:\"thumbnail\";a:4:{s:4:\"file\";s:22:\"" + imageName1 + "-150x150.jpg\";s:5:\"width\";i:150;s:6:\"height\";i:150;s:9:\"mime-type\";s:10:\"image/jpeg\";}s:21:\"woocommerce_thumbnail\";a:5:{s:4:\"file\";s:22:\"" + imageName1 + "-265x331.jpg\";s:5:\"width\";i:265;s:6:\"height\";i:331;s:9:\"mime-type\";s:10:\"image/jpeg\";s:9:\"uncropped\";b:0;}s:29:\"woocommerce_gallery_thumbnail\";a:4:{s:4:\"file\";s:22:\"" + imageName1 + "-100x100.jpg\";s:5:\"width\";i:100;s:6:\"height\";i:100;s:9:\"mime-type\";s:10:\"image/jpeg\";}s:12:\"shop_catalog\";a:4:{s:4:\"file\";s:22:\"" + imageName1 + "-265x331.jpg\";s:5:\"width\";i:265;s:6:\"height\";i:331;s:9:\"mime-type\";s:10:\"image/jpeg\";}s:14:\"shop_thumbnail\";a:4:{s:4:\"file\";s:22:\"" + imageName1 + "-100x100.jpg\";s:5:\"width\";i:100;s:6:\"height\";i:100;s:9:\"mime-type\";s:10:\"image/jpeg\";}}s:10:\"image_meta\";a:12:{s:8:\"aperture\";s:1:\"0\";s:6:\"credit\";s:15:\"Siddhant Kandoi\";s:6:\"camera\";s:0:\"\";s:7:\"caption\";s:0:\"\";s:17:\"created_timestamp\";s:10:\"1583371749\";s:9:\"copyright\";s:0:\"\";s:12:\"focal_length\";s:1:\"0\";s:3:\"iso\";s:1:\"0\";s:13:\"shutter_speed\";s:1:\"0\";s:5:\"title\";s:0:\"\";s:11:\"orientation\";s:1:\"0\";s:8:\"keywords\";a:0:{}}}');";
                                                                        MySqlCommand command10 = new MySqlCommand(mysql7, connection);
                                                                        connection.Open();
                                                                        command10.ExecuteNonQuery();
                                                                        connection.Close();
                                                                        count++;
                                                                        UploadImage();
                                                                    }
                                                                    catch
                                                                    {
                                                                        MessageBox.Show("Error occured while adding image details to the product the wordpress database. Try uploading a product with different image name.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                                        return;
                                                                    }
                                                                }

                                                            }
                                                        }



                                                        MessageBox.Show("Records have been modified", "Modification confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                        this.Hide();

                                                        //Declaring a variable for WelcomeForm
                                                        WelcomeForm form2 = new WelcomeForm();

                                                        //Showing WelcomeForm
                                                        form2.ShowDialog();
                                                    }

                                                }
                                            }

                                            catch (Exception Ex)
                                            {
                                                MessageBox.Show("There is a problem with the database of this application (Error 7). Please contact online and media coordinator to resolve this error. " + Ex, "Database connection error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                Console.WriteLine(Ex);
                                            }

                                        }



                                    }
                                }
                            }
                        }


                    }
                }
            }




        }

        // Code to set the fucntionality of index change property of Imagelistbox
        private void ImageListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if(ImageListBox.SelectedIndex != -1)
                {
                    ImagePictureBox.ImageLocation = imageList[ImageListBox.SelectedIndex];
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is a problem with the database of this application (Error 8). Please contact online and media coordinator to resolve this error. " + ex,"Database connection error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex);
            }

        }

        // Text properties on entering productnametextbox field --> clear text boxes when user enters them and fill them with dummy in case user leaves the text box without entering a value
        private void ProductNameTextBox_Enter(object sender, EventArgs e)
        {
            if (ProductNameTextBox.Text == "What are you selling?")
            {
                ProductNameTextBox.Text = "";
            }
        }

        // Text properties on leaving productnametextbox field
        private void ProductNameTextBox_Leave(object sender, EventArgs e)
        {
            if (ProductNameTextBox.Text == "")
            {
                ProductNameTextBox.Text = "What are you selling?";
            }
        }


        // Text properties on entering productDescriptionRichtextbox field
        private void ProductDescriptionRichTextBox_Enter(object sender, EventArgs e)
        {
            if (ProductDescriptionRichTextBox.Text == "Describe what you are selling")
            {
                ProductDescriptionRichTextBox.Text = "";
            }
        }


        // Text properties on leaving productDescriptionRichtextbox field
        private void ProductDescriptionRichTextBox_Leave(object sender, EventArgs e)
        {
            if (ProductDescriptionRichTextBox.Text == "")
            {
                ProductDescriptionRichTextBox.Text = "Describe what you are selling";
            }
        }


        // Text properties on entering ProductPricetextbox field
        private void ProductPriceTextBox_Enter(object sender, EventArgs e)
        {
            if (ProductPriceTextBox.Text == "Product Price")
            {
                ProductPriceTextBox.Text = "";
            }
        }

        
        // Text properties on leaving ProductPricetextbox field
        private void ProductPriceTextBox_Leave(object sender, EventArgs e)
        {
            if (ProductPriceTextBox.Text == "")
            {
                ProductPriceTextBox.Text = "Product Price";
            }
        }

        // Text properties on entering SalePriceTextBox field
        private void SalePriceTextBox_Enter(object sender, EventArgs e)
        {
            if (SalePriceTextBox.Text == "Sale Price")
            {
                SalePriceTextBox.Text = "";
            }
        }

        // Text properties on leaving SalePriceTextBox field
        private void SalePriceTextBox_Leave(object sender, EventArgs e)
        {
            if (SalePriceTextBox.Text == "")
            {
                SalePriceTextBox.Text = "Sale Price";
            }
        }


        // Text properties on entering ProductSizeRichTextBox field
        private void ProductSizeRichTextBox_Enter(object sender, EventArgs e)
        {
            if (ProductSizeRichTextBox.Text == "if applicable")
            {
                ProductSizeRichTextBox.Text = "";
            }
        }


        // Text properties on leaving ProductSizeRichTextBox field
        private void ProductSizeRichTextBox_Leave(object sender, EventArgs e)
        {
            if (ProductSizeRichTextBox.Text == "")
            {
                ProductSizeRichTextBox.Text = "if applicable";
            }
        }


        // Closing the form
        private void UploadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }


        // Set functionality for ScrollUpPictureBox 
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (ImageListBox.SelectedIndex != -1)
            {

                if (ImageListBox.SelectedIndex != 0)
                {
                    string temp = imageList[ImageListBox.SelectedIndex];

                    imageList[ImageListBox.SelectedIndex] = imageList[ImageListBox.SelectedIndex - 1];
                    imageList[ImageListBox.SelectedIndex - 1] = temp;

                    ImageListBox.Items.Clear();
                    for (int i = 0; i < imageList.Count; i++)
                    {
                        if (i == 0)
                        {
                            ImageListBox.Items.Add(Path.GetFileName(imageList[i]) + " - Title Image");
                        }
                        else
                        {
                            ImageListBox.Items.Add(Path.GetFileName(imageList[i]));
                        }

                    }
                    ImageListBox.SelectedIndex = 0;

                }
               
                ImagePictureBox.ImageLocation = imageList[0];

            }
        }


        // Set functionality for ScrollDownPictureBox
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            if (ImageListBox.SelectedIndex != -1)
            {
                if (ImageListBox.SelectedIndex != ImageListBox.Items.Count - 1)
                {
                    string temp = imageList[ImageListBox.SelectedIndex];

                    imageList[ImageListBox.SelectedIndex] = imageList[ImageListBox.SelectedIndex + 1];
                    imageList[ImageListBox.SelectedIndex + 1] = temp;


                    ImageListBox.Items.Clear();
                    for (int i = 0; i < imageList.Count; i++)
                    {
                        if (i == 0)
                        {
                            ImageListBox.Items.Add(Path.GetFileName(imageList[i]) + " - Title Image");
                        }
                        else
                        {
                            ImageListBox.Items.Add(Path.GetFileName(imageList[i]));
                        }
                    }
                    ImageListBox.SelectedIndex = 0;
                }
                ImagePictureBox.ImageLocation = imageList[0];
        
            }
        }

        

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "OnlineHelp_VincentsOnlineStoreManager.chm");
        }

        private void ImagePictureBox_Click(object sender, EventArgs e)
        {

        }
    }
    }
    
