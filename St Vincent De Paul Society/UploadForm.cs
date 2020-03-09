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

namespace St_Vincent_De_Paul_Society
{
    public partial class UploadForm : Form
    {

        string productName;
        string productDescription;
        decimal productPrice = 0m;
        decimal salePrice = 0m;
        string productType;
        string productLocation;
        string productSize;
        List<String> imageList = new List<string>();
		int item_id;
        

        //string in_stock_date= DateTime.Now.ToString("yyyy-MM-dd");


        public UploadForm()
        {
            InitializeComponent();
			FillComboBox();
        }
		
		void FillComboBox()
        {
            try
            {
                //select Concat(c.category_name, ' ' ,s.sub_category_name) as 'Categories' from category c, sub_category s where c.CATEGORY_ID = s.CATEGORY_ID and c.CATEGORY_NAME not in ('Books', 'Others')
                string connectionString_dataload = "datasource=localhost;port=3308;username=root;password=";
                string dataLoad_sql = "select Concat(c.category_name, ' ' ,s.sub_category_name) as 'Categories'  from test_db.category c, test_db.sub_category s where c.CATEGORY_ID=s.CATEGORY_ID and c.CATEGORY_NAME not in ('Books', 'Others');";
                MySqlConnection connection = new MySqlConnection(connectionString_dataload);
                MySqlCommand data_command = new MySqlCommand(dataLoad_sql, connection);
                connection.Open();
                MySqlDataReader dataload;
                dataload = data_command.ExecuteReader();            
               
                while (dataload.Read())
                {

                    string categories = dataload.GetString(0);
                    ProductTypeComboBox.Items.Add(categories);
                }
                ProductTypeComboBox.Items.Add("Books");
                ProductTypeComboBox.Items.Add("Others");
                connection.Close();

               // SELECT shop_name FROM test_db.shop;
                string connectionString_dataload1 = "datasource=localhost;port=3308;username=root;password=";
                string dataLoad_sql1 = "SELECT shop_name FROM test_db.shop;";
                MySqlConnection connection1 = new MySqlConnection(connectionString_dataload1);
                MySqlCommand data_command1 = new MySqlCommand(dataLoad_sql1, connection1);
                connection1.Open();
                MySqlDataReader dataload1;
                dataload1 = data_command1.ExecuteReader();

                while (dataload1.Read())
                {

                    string shops = dataload1.GetString(0);
                    ProductLocationComboBox.Items.Add(shops);
                }
                connection1.Close();
            }

            catch (Exception Ex)
            {
                MessageBox.Show("There is a problem with data Load", "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine(Ex);
            }
        }

        private void ProductDescriptionRichTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            ProductDescriptionRichTextBox.Text = "";
        }

        private void ProductNameTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            ProductNameTextBox.Text = "";
        }

        private void ProductPriceTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            ProductPriceTextBox.Text = "";
        }

        private void ProductSizeRichTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            ProductSizeRichTextBox.Text = "";
        }

        //private string productNameInput;
        private int productCategoryModify = -1;
        private int productLocationModify = -1; 
		private string selectedProductDetails;

        public int productCategoryModifySet {
            set
            {
                productCategoryModify = value;
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



        private void LogOutButton_Click(object sender, EventArgs e)
        {
            DialogResult resultLogout = MessageBox.Show("Do you wish to Log out??", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DialogResult.Yes == resultLogout)
            {
                  this.Hide();

                //Declaring a variable for LoginForm
                   LogInForm f1 = new LogInForm();

                //Showing WelcomeForm
                 f1.ShowDialog();

            }

            else
            {


            }

        }

        private void UploadButton_Click(object sender, EventArgs e)
        {



            if (ProductNameTextBox.Text == "" || ProductNameTextBox.Text == "What are you selling?")
            {
                MessageBox.Show("Please Enter a valid Product name", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                productName = ProductNameTextBox.Text;

                if (ProductDescriptionRichTextBox.Text == "" || ProductDescriptionRichTextBox.Text == "Describe what you are selling")
                {
                    MessageBox.Show("Please Enter valid Product description", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    productDescription = ProductDescriptionRichTextBox.Text;

                    //if (ProductPriceTextBox.Text == "" || ProductPriceTextBox.Text == "Price")
                    //{
                    //    MessageBox.Show("Please Enter a valid Product Price", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}
                    //else
                    //{


                    if (decimal.TryParse(ProductPriceTextBox.Text, out productPrice))
                    {
                        if (decimal.TryParse(SalePriceTextBox.Text, out salePrice))
                        { }
                        else
                        {
                            MessageBox.Show("Price has to be a number, e.g. 19.90", "Wrong data type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Price has to be a number, e.g. 19.90", "Wrong data type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    

                    if (ProductTypeComboBox.SelectedIndex < 0)
                    {
                        MessageBox.Show("Please select a product type", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        productType = ProductTypeComboBox.Text;

                        if (ProductLocationComboBox.SelectedIndex < 0)

                        {
                            MessageBox.Show("Please select a location", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            productLocation = ProductLocationComboBox.Text;

                            if ((ProductTypeComboBox.SelectedIndex == 11 || ProductTypeComboBox.SelectedIndex == 12 || ProductTypeComboBox.SelectedIndex == 13 || ProductTypeComboBox.SelectedIndex == 14) && ProductSizeRichTextBox.Text == "")
                            {

                                MessageBox.Show("Please enter the size", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if (ImagePictureBox.ImageLocation is null)
                            {
                                MessageBox.Show("Please Upload at least 1 image to continue.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                // picture box
                                try
                                {
                                    /*
                                        MemoryStream ms = new MemoryStream();
                                        ImagePictureBox.Image.Save(ms, ImagePictureBox.Image.RawFormat);
                                        byte[] img = ms.ToArray();
                                        */
                                    //}
                                    //catch(Exception ex)
                                    //{
                                    //   MessageBox.Show(ex.Message);
                                    //}

                                    //try { 
                                    byte[] img = new byte[ImageListBox.Items.Count];
                                    for (int i = 0; i < imageList.Count; i++)
                                    {
                                        MemoryStream ms = new MemoryStream();
                                        // ms.Write(HttpContext.Current.Server.MapPath(ImageListBox.Items[i].ToString()),0, ImageListBox.Items.Count);
                                        //ImagePictureBox.Image.Save(ms, ImagePictureBox.Image.RawFormat);
                                        //img = ms.ToArray();
                                        img = File.ReadAllBytes(imageList[i].ToString());
                                    }



                                    string trimmed_productType = productType.Replace("Collectables ", "").Replace("Accessories ", "").Replace("Living ", "").Replace("Clothing ", "").Replace("Hobbies ", "").Replace("Expensive ", "");
                                    string trimmed_productLocation = productLocation.Replace("Vincent's", "");
                                    string in_stock_date = DateTime.Now.ToString("yyyy-MM-dd");
                                    string connectionString = "datasource=localhost;port=3308;username=root;password=";
                                    string sql = "SELECT SUB_CATEGORY_ID FROM test_db.SUB_CATEGORY WHERE SUB_CATEGORY_NAME LIKE '%" + trimmed_productType + "%';";
                                    string sql1 = "SELECT SHOP_ID FROM test_db.SHOP WHERE SHOP_NAME LIKE '%" + trimmed_productLocation + "%';";

                                    if (ProductSizeRichTextBox.Text != "")
                                    {

                                        productSize = ProductSizeRichTextBox.Text;
                                    }



                                    //Code for database connection for select statements.
                                    MySqlConnection conn = new MySqlConnection(connectionString);
                                    MySqlConnection conn1 = new MySqlConnection(connectionString);
                                    MySqlCommand command = new MySqlCommand(sql, conn);
                                    MySqlCommand command1 = new MySqlCommand(sql1, conn1);
                                    conn.Open();
                                    conn1.Open();
                                    MySqlDataReader myreader, mydata;
                                    myreader = command.ExecuteReader();
                                    mydata = command1.ExecuteReader();
                                    myreader.Read();
                                    mydata.Read();
                                    int db_category_id = myreader.GetInt32(0);
                                    int db_shop_id = mydata.GetInt32(0);
                                    mydata.Close();
                                    conn.Close();
                                    conn1.Close();

                                    //Code for database connection for insert statements.
                                    string mysql = "INSERT INTO test_db.INVENTORY (ITEM_NAME, ITEM_DESCRIPTION, SUB_CATEGORY_ID,PRIZE, SALE, SIZE, PICTURE, IN_STOCK_DATE,ITEM_STATUS,SHOP_ID,SEASON_ID) VALUES('"
                                        + productName + "', '" + productDescription + "', '" + db_category_id + "','" + productPrice + "','" + salePrice + "','" + productSize + "', '" + img + "' ,'" + in_stock_date + "', 'In Stock','" + db_shop_id + "', '1');";
                                    MySqlConnection conn3 = new MySqlConnection(connectionString);
                                    MySqlCommand command2 = new MySqlCommand(mysql, conn3);
                                    conn3.Open();
                                    command2.ExecuteNonQuery();
                                    conn3.Close();

                                    //Woocommerce
                                    string mysql1 = "INSERT INTO test_db.wp_posts (post_author, post_date, post_date_gmt, post_content, post_title, post_excerpt, post_status,comment_status, ping_status, post_password, post_name, to_ping, pinged, post_modified, post_modified_gmt,post_content_filtered, post_parent , guid, menu_order, post_type, post_mime_type, comment_count) VALUES('1', '"
                                      + in_stock_date + "','" + in_stock_date + "', '" + productDescription + "','"
                                     + productName + "','Pick up from " + trimmed_productLocation + " shop only.','publish', 'closed', 'closed','', '" + productName + "','','', '" + in_stock_date + "','" + in_stock_date + "','' , '0', '','0', 'product','', '0') ; ";
                                    MySqlConnection conn4 = new MySqlConnection(connectionString);
                                    MySqlCommand command3 = new MySqlCommand(mysql1, conn4);
                                    conn4.Open();
                                    command3.ExecuteNonQuery();
                                    conn4.Close();

                                    //wp_post_meta query to be ADDED.
                                    MessageBox.Show("New product has been uploaded", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ProductNameTextBox.Text = "What are you selling?";
                                    ProductDescriptionRichTextBox.Text = "Describe what you are selling";
                                    ProductPriceTextBox.Text = "if applicable";
                                    ProductPriceTextBox.Text = "Price";
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


                                }

                                catch (Exception Ex)
                                {
                                    MessageBox.Show("There is a problem with the database connection", "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    Console.WriteLine(Ex);
                                }

                            }

                        }



                    }
                
                }


            }



         }

            private void BackButton_Click(object sender, EventArgs e)
            {

            DialogResult resultBack = MessageBox.Show("Are you sure you want to go back? Unsaved records will be lost.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (DialogResult.Yes == resultBack)
            {
                this.Hide();

                //Declarrng a variable for WelcomeForm
                WelcomeForm f2 = new WelcomeForm();

                //Showing WelcomeForm
                f2.ShowDialog();

            }

            else
            {


            }

            
        }

            private void AddPhotosButton_Click(object sender, EventArgs e)
            {

                string imageLocation = "";
                try
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                    if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        imageLocation = dialog.FileName;
                        ImagePictureBox.ImageLocation = imageLocation;
                        imageList.Add(imageLocation);
                        ImageListBox.Items.Add(Path.GetFileName(imageLocation) +"- Title Image");
                        DeletePictureButton.Visible = true;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("You didn't select a picture. Do you want to proceed without a picture?", "Missing picture", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                }
            if  (! (ImagePictureBox.ImageLocation is null))
            {
                AddMorePicturesButton.Visible = true;
                ImageLabel.Visible = false;
            }

        }

        private void UploadForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, this.Size.Height);

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
                        
                        item_id = int.Parse(selectedProductDetails.Substring(0, 2));
                        //MessageBox.Show(item_id.ToString());
                        string connectionString_dataload3 = "datasource=localhost;port=3308;username=root;password=";
                        string dataLoad_sql3 = "select  ITEM_NAME, ITEM_DESCRIPTION, PRIZE,SALE, SIZE from test_db.inventory where item_id = '" + item_id + "' ;";
                        MySqlConnection connection3 = new MySqlConnection(connectionString_dataload3);
                        MySqlCommand data_command3 = new MySqlCommand(dataLoad_sql3, connection3);
                        connection3.Open();
                        MySqlDataReader dataload3;
                        dataload3 = data_command3.ExecuteReader();
                        dataload3.Read();
                        ProductNameTextBox.Text = dataload3.GetString(0);
                        ProductDescriptionRichTextBox.Text = dataload3.GetString(1);
                        ProductPriceTextBox.Text = dataload3.GetString(2);
                        SalePriceTextBox.Text = dataload3.GetString(3);
                        ProductSizeRichTextBox.Text = dataload3.GetString(4);
                        dataload3.Close();
                        connection3.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("There some problem with database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else
                {
                    ModifyUploadPageButton.Visible = false;
                    UploadButton.Visible = true;
                }




            }
        }
        private void ProductDescriptionRichTextBox_Enter(object sender, EventArgs e)
        {
            if (ProductDescriptionRichTextBox.Text == "Describe what you are selling") {
                ProductDescriptionRichTextBox.Text = "";
            }
            
            
        }

        private void ProductDescriptionRichTextBox_Leave(object sender, EventArgs e)
        {
            if (ProductDescriptionRichTextBox.Text == "")
            {
                ProductDescriptionRichTextBox.Text = "Describe what you are selling";
            }
        }

        private void ProductNameTextBox_Leave(object sender, EventArgs e)
        {
            if (ProductNameTextBox.Text == "")
            {
                ProductNameTextBox.Text = "What are you selling?";
            }
        }

        private void ProductSizeRichTextBox_Leave(object sender, EventArgs e)
        {
            if (ProductSizeRichTextBox.Text == "")
            {
                ProductSizeRichTextBox.Text = "if applicable";
            }
        }

        private void ProductPriceTextBox_Enter(object sender, EventArgs e)
        {
            ProductPriceTextBox.Text = "";
        }



        private void ProductPriceTextBox_Leave(object sender, EventArgs e)
        {
            if (ProductPriceTextBox.Text == "")
            {
                ProductPriceTextBox.Text = "Product Price";
            }
        }

        private void ProductDescriptionRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddMorePicturesButton_Click(object sender, EventArgs e)
        {
            

            String imageLocation = "";

            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    imageList.Add(imageLocation);
                    ImageListBox.Items.Add(Path.GetFileName(imageLocation));
                    ImageListBox.Visible = true;
                    //ImagePictureBox.Visible = false;
                    AddMorePicturesButton.Visible = false;
                    AddMorePicturesButton.Visible = true;
                    ImageListBox.SelectedIndex = 0;
                    ScrollUpButton.Visible = true;
                    ScrollDownButton.Visible = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You didn't select a picture. Do you want to proceed without a picture?", "Missing picture", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            }


            /*
            int count = 1;

            if (count != 5)
            {
                string imageLocation = "";
                try
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                    if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        imageLocation = dialog.FileName;
                       // ImagePictureBox.ImageLocation = imageLocation;

                    }

                    PictureBox picture = new PictureBox
                    {
                        Name = "ImagePictureBox" + count,
                        Size = new Size(93, 104),
                        Location = new Point(ImagePictureBox.Location.X + 104 + (count * 5), ImagePictureBox.Location.Y),
                        ImageLocation = imageLocation,
                    };
                    panel1.Controls.Add(picture);
                }
                catch (Exception)
                {
                    MessageBox.Show("You didn't select a picture. Do you want to proceed without a picture?", "Missing picture", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                }*/
        }

        private void AddPhotosPictureBox_Click(object sender, EventArgs e)
        {
            AddPhotosButton.PerformClick();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            try
            {
                if (ImageListBox.SelectedIndex != -1 || ImageListBox.Visible == false )
                {


                if(imageList.Count == 1)
                {
                     dr =  MessageBox.Show("Are you sure you want to delete the Image " + ImageListBox.Items[0], "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else if(imageList.Count > 1 && ImageListBox.SelectedIndex != -1)
                {
                    dr =   MessageBox.Show("Are you sure you want to delete the Image " + ImageListBox.SelectedItem, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                    if (DialogResult.Yes == dr)
                    {

                        if (ImageListBox.SelectedIndex != -1 && imageList.Count != 1)
                        {
                            if (imageList.Count != 0 && imageList.Count > 1)
                            {
                                imageList.RemoveAt(ImageListBox.SelectedIndex);
                                ImageListBox.Items.RemoveAt(ImageListBox.SelectedIndex);
                                if (imageList.Count == 1)
                                {
                                    ImagePictureBox.Visible = true;
                                    ImageListBox.Visible = false;
                                    ScrollUpButton.Visible = false;
                                    ScrollDownButton.Visible = false;
                                    ImagePictureBox.ImageLocation = imageList[0];
                                    ImageListBox.SelectedIndex = 0;
                                    ImageListBox.Items[0] = Path.GetFileName(imageList[0]) + "- Title Image";
                                }
                                else
                                {
                                    ImagePictureBox.Visible = true;
                                    ImageListBox.Visible = true;
                                    ImagePictureBox.ImageLocation = imageList[0];
                                    ImageListBox.SelectedIndex = 0;
                                    ImageListBox.Items[0] = Path.GetFileName(imageList[0]) + "- Title Image";
                                }
                            }

                        }
                        else if (imageList.Count == 1)
                        {
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
                    MessageBox.Show("Please select a image from list box to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show("Error has Occured while deleting a Picture, Please Contact your adminstrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error has occured while deleting a picture"+Ex);
            }


        }

        private void ModifyUploadPageButton_Click(object sender, EventArgs e)
        {
			if (ProductNameTextBox.Text == "" || ProductNameTextBox.Text == "What are you selling?")
            {
                MessageBox.Show("Please Enter a valid Product name", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                productName = ProductNameTextBox.Text;

                if (ProductDescriptionRichTextBox.Text == "" || ProductDescriptionRichTextBox.Text == "Describe what you are selling")
                {
                    MessageBox.Show("Please Enter valid Product description", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    productDescription = ProductDescriptionRichTextBox.Text;
                             
                        if (decimal.TryParse(ProductPriceTextBox.Text, out productPrice))
                        { }
                        else
                        { 
                            MessageBox.Show("Price has to be a number, e.g. 19.90", "Wrong data type", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }
                    if (decimal.TryParse(SalePriceTextBox.Text, out salePrice))
                    { }
                    else
                    {
                        MessageBox.Show("Price has to be a number, e.g. 19.90", "Wrong data type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    if (ProductTypeComboBox.SelectedIndex < 0)
                        {
                            MessageBox.Show("Please select a product type", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        else
                        {
                            productType = ProductTypeComboBox.SelectedItem.ToString();

                            if (ProductLocationComboBox.SelectedIndex < 0)

                            {
                                MessageBox.Show("Please select a location", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                            else
                            {
                                productLocation = ProductLocationComboBox.SelectedItem.ToString();

                                if ((ProductTypeComboBox.SelectedIndex == 11 || ProductTypeComboBox.SelectedIndex == 12 || ProductTypeComboBox.SelectedIndex == 13 || ProductTypeComboBox.SelectedIndex == 14 || ProductSizeRichTextBox.Text == "if applicable") && ProductSizeRichTextBox.Text == "")
                                {

                                    MessageBox.Show("Please enter the size", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    // picture box
                                    try
                                    {
                                        /*MemoryStream ms = new MemoryStream();
                                        ImagePictureBox.Image.Save(ms, ImagePictureBox.Image.RawFormat);
                                        byte[] img = ms.ToArray();*/

                                    
                                    if (ProductSizeRichTextBox.Text != "")
                                    {

                                        productSize = ProductSizeRichTextBox.Text;
                                    }

                                    //Modify Code
                                    if(ImagePictureBox.Image == null)
                                    { 
										string connectionString_dataload4 = "datasource=localhost;port=3308;username=root;password=";
										string dataLoad_sql4 = "update test_db.inventory set ITEM_NAME='" + ProductNameTextBox.Text + "', ITEM_DESCRIPTION='" + ProductDescriptionRichTextBox.Text + "', PRIZE='" + productPrice + "', SALE='" + salePrice + "' , SIZE ='" + ProductSizeRichTextBox.Text + "' where ITEM_ID = '" + item_id + "';";
										MySqlConnection connection4 = new MySqlConnection(connectionString_dataload4);
										MySqlCommand data_command4 = new MySqlCommand(dataLoad_sql4, connection4);
										connection4.Open();
										data_command4.ExecuteNonQuery();
										connection4.Close();
										MessageBox.Show("Records have been modified", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
									}
                                    else
                                    {

                                        MemoryStream ms = new MemoryStream();
                                        ImagePictureBox.Image.Save(ms, ImagePictureBox.Image.RawFormat);
                                        byte[] img = ms.ToArray();
                                        string connectionString_dataload4 = "datasource=localhost;port=3308;username=root;password=";
                                        string dataLoad_sql4 = "update test_db.inventory set ITEM_NAME='" + ProductNameTextBox.Text + "', ITEM_DESCRIPTION='" + ProductDescriptionRichTextBox.Text + "', PRIZE='" + productPrice + "', SALE='" + salePrice + "', SIZE ='" + ProductSizeRichTextBox.Text + "', PICTURE = '" +img+ "' where ITEM_ID = '" + item_id + "';";
                                        MySqlConnection connection4 = new MySqlConnection(connectionString_dataload4);
                                        MySqlCommand data_command4 = new MySqlCommand(dataLoad_sql4, connection4);
                                        connection4.Open();
                                        data_command4.ExecuteNonQuery();
                                        connection4.Close();
                                        MessageBox.Show("Records have been modified", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                }

                                catch (Exception Ex)
                                    {
                                        MessageBox.Show("There is a problem with the database connection", "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        Console.WriteLine(Ex);
                                    }

                                }

                            }

                        
                    }
                }

            }




        }

        private void ImageListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


            if (ImageListBox.SelectedIndex != -1) {
                ImagePictureBox.ImageLocation = imageList[ImageListBox.SelectedIndex];
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Something went wrong, Please contact admin with code IMG001", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex);
            }



        }

        private void ScrollUpButton_Click(object sender, EventArgs e)
        {
            if(ImageListBox.SelectedIndex != -1)
            {

                if(ImageListBox.SelectedIndex != 0)
                {
                    string temp = imageList[ImageListBox.SelectedIndex];
                   
                    imageList[ImageListBox.SelectedIndex] = imageList[ImageListBox.SelectedIndex - 1];
                    imageList[ImageListBox.SelectedIndex - 1] = temp;
                    
                    ImageListBox.Items.Clear();
                    for(int i = 0; i < imageList.Count; i++)
                    {
                        if (i == 0)
                        {
                            ImageListBox.Items.Add(Path.GetFileName(imageList[i])+" - Title Image");
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

        private void ScrollDownButton_Click(object sender, EventArgs e)
        {
            if(ImageListBox.SelectedIndex != -1)
            {
                if(ImageListBox.SelectedIndex != ImageListBox.Items.Count - 1)
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

        private void SalePriceTextBox_Enter(object sender, EventArgs e)
        {
            SalePriceTextBox.Text = "";
        }

        private void SalePriceTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            SalePriceTextBox.Text = "";
        }

        private void SalePriceTextBox_Leave(object sender, EventArgs e)
        {
            if (SalePriceTextBox.Text == "")
            {
                SalePriceTextBox.Text = "Sale Price";
            }
        }
    }
    }
    
