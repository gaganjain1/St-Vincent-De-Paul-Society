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

namespace St_Vincent_De_Paul_Society
{
    public partial class ModifyScreen : Form
    {
        //Variable declaration
        public Boolean isModify = false;
        public Boolean isDelete = false;
      

        //Database variables for connection
        static string connectionString = "SERVER=mysql4299.cp.blacknight.com; PORT=3306; DATABASE=db1399990_sa179849_main; UID=u_sa179849; PASSWORD=Y1JCUFZ8mVGlzuYf";
        MySqlConnection connection = new MySqlConnection(connectionString);

        public ModifyScreen()
        {
            InitializeComponent();
            //Calling FillComboBox() to fill the comboboxes.
            FillComboBox();
        }
        
        public Boolean setIsModify
        {
            set
            {
                isModify = value;
            }
        }

        public Boolean setIsDelete
        {
            set
            {
                isDelete = value;
            }
        }



        // Code to add functionality on loading ModifyScreen
        private void ModifyScreen_Load(object sender, EventArgs e)
        {
            if (isDelete == true)
            {
                ModifyButton.Visible = false;
              //  DeleteButton.Visible = true; // This button will be used for future enhancement reasons
                OutOfStockButton.Visible = true;
            }

            if (isModify == true)
            {
                ModifyButton.Visible = true;
                DeleteButton.Visible = false;
                OutOfStockButton.Visible = false;
            }


            if (isDelete == false)
            {
                OutOfStockButton.Visible = false;

            }

            
           

        }

        // Code added for Database
        // method to automatically fill combo boxes (product category and product location) from database 
        void FillComboBox()
        {
            try
            {
                // code to add items in categories Combobox
                // Selecting the list of categories and sub-categories from the database.
                string dataLoad_sql = "select Concat(c.category_name, ' ' ,s.sub_category_name) as 'Categories'  from CATEGORY c, SUB_CATEGORY s where c.CATEGORY_ID=s.CATEGORY_ID;";
                MySqlCommand data_command = new MySqlCommand(dataLoad_sql, connection);
                connection.Open();
                MySqlDataReader dataload;
                dataload = data_command.ExecuteReader();

                while (dataload.Read())
                {

                    string categories = dataload.GetString(0);
                    ProductCategoryComboBox.Items.Add(categories);
                }
                
                connection.Close();

                // code to add items in Location Combobox
                // Selecting shop names from the database.
                string dataLoad_sql1 = "SELECT shop_name FROM SHOP;";
                MySqlCommand data_command1 = new MySqlCommand(dataLoad_sql1, connection);
                connection.Open();
                MySqlDataReader dataload1;
                dataload1 = data_command1.ExecuteReader();

                while (dataload1.Read())
                {

                    string shops = dataload1.GetString(0);
                    ProductLocationModifyFormComboBox.Items.Add(shops);
                }
                connection.Close();
            }

            catch (Exception Ex)
            {
                MessageBox.Show("There is a problem with the database of this application (Error 9). Please contact online and media coordinator to resolve this error. ", "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine(Ex);
            }
        }
        

        // Code to add Log out functionality
        private void LogOutButton_Click(object sender, EventArgs e)
        {
            DialogResult resultLogout = MessageBox.Show("Do you wish to Log out??", "Log out confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (resultLogout == DialogResult.Yes)
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

        // Code to add functionality for Modify button
        private void ModifyButton_Click(object sender, EventArgs e)
        {
            // Check whether user has selected product category
            if (ProductCategoryComboBox.SelectedIndex < 0)

            {
                MessageBox.Show("Please select a product category", "Input needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            else
            {
                // check whether user selected a shop location
                if (ProductLocationModifyFormComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select the location", "Input needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }

                else
                {
                    // Check whether user selected a product from the list
                    if (ProductDisplayDataGridView.SelectedRows.Count <= 0 && ProductDisplayDataGridView.SelectedCells.Count <= 0)
                    {
                        MessageBox.Show("Please choose a valid product from the list", "Selection needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                    else
                    {
                        // Case A: User selected a row 
                        if (ProductDisplayDataGridView.SelectedRows.Count > 0)
                        {
                            
                            DataGridViewRow row = this.ProductDisplayDataGridView.SelectedRows[0];
                            this.Hide();
                            //Declaring a variable for Upload form
                            UploadForm form3 = new UploadForm();
                            form3.productCategoryModifySet = ProductCategoryComboBox.SelectedIndex;
                            form3.productLocationLocationSet = ProductLocationModifyFormComboBox.SelectedIndex;
                            form3.selectedProduct = row.Cells["ITEM_ID"].Value.ToString();
                            form3.selectedProduct_Name = row.Cells["ITEM_NAME"].Value.ToString();
                            form3.isModifyOrDeleteSet = true;
                            form3.isUploadSet = false;
                            //Showing UploadForm
                            form3.ShowDialog();

                        }

                        // Case B: User selected a cell and not a row
                        else if (ProductDisplayDataGridView.SelectedCells.Count > 0 && ProductDisplayDataGridView.SelectedRows.Count == 0)
                        {
                            
                            int selectedrowindex = ProductDisplayDataGridView.SelectedCells[0].RowIndex;
                            DataGridViewRow row = this.ProductDisplayDataGridView.Rows[selectedrowindex];
                            
                            this.Hide();
                            //Declaring a variable for Upload form
                            UploadForm form3 = new UploadForm();
                            form3.productCategoryModifySet = ProductCategoryComboBox.SelectedIndex;
                            form3.productLocationLocationSet = ProductLocationModifyFormComboBox.SelectedIndex;
                            form3.selectedProduct = row.Cells["ITEM_ID"].Value.ToString();
                            form3.selectedProduct_Name = row.Cells["ITEM_NAME"].Value.ToString();
                            //Showing UploadForm
                            form3.isModifyOrDeleteSet = true;
                            form3.isUploadSet = false;
                            form3.ShowDialog();
                        }

                    }
                }


            }
        }


        // Code to set functionality for index change for ProductCategoryComboBox
        private void ProductCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ProductCategoryComboBox.SelectedIndex != -1)
            {
                ProductLocationModifyFormComboBox.Enabled = true;
            }

            // When user selects a category and a shop, the list of products on the website matching the criteria will be shown
            if (ProductCategoryComboBox.SelectedIndex != -1 && ProductLocationModifyFormComboBox.SelectedIndex != -1)
            {
            
                ProductDisplayDataGridView.DataSource = null;
                displayDataInDataGridView();

            }
        }


        // Code to set functionality for index change for ProductLocationModifyFormComboBox
        private void ProductLocationModifyFormComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           // When user selects a category and a shop, the list of products on the website matching the criteria will be shown
            if (ProductCategoryComboBox.SelectedIndex != -1 && ProductLocationModifyFormComboBox.SelectedIndex != -1)
            {
                
                ProductDisplayDataGridView.DataSource = null;
                displayDataInDataGridView();

            }

        }

        // Code to add functionality for BackButton
        private void BackButton_Click(object sender, EventArgs e)
        {
            DialogResult resultBack = MessageBox.Show("Do you wish to go back??", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (resultBack == DialogResult.Yes)
            {
                this.Hide();

                //Declarrng a variable for WelcomeForm
                WelcomeForm form2 = new WelcomeForm();

                //Showing WelcomeForm
                form2.ShowDialog();

            }

           
        }

        // Method to display data in ProductDisplayDataGridView 
        private void displayDataInDataGridView()
        {
            try
            {
                // Code for sql connection
                string product_type = ProductCategoryComboBox.SelectedItem.ToString();
                string[] categories = product_type.Split();
                string shop_location = ProductLocationModifyFormComboBox.SelectedItem.ToString();
                string trimmed_productLocation = shop_location.Replace("Vincent's", "");
                string in_stock_date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                int category_id = 0;
                string str1 = categories[0];
                string str2 = categories[1];

                //Selecting category id from the database and assign to category_id.
                String sql0 = "SELECT CATEGORY_ID FROM CATEGORY WHERE CATEGORY_NAME LIKE '%" + str1 + "%';";
                MySqlCommand command0 = new MySqlCommand(sql0, connection);
                connection.Open();
                MySqlDataReader myreader0;
                myreader0 = command0.ExecuteReader();
                myreader0.Read();
                category_id = myreader0.GetInt32(0);
                myreader0.Close();
                connection.Close();

                //Selecting sub category id from the database and assign to db_category_id.
                string sql = "SELECT SUB_CATEGORY_ID FROM SUB_CATEGORY WHERE SUB_CATEGORY_NAME LIKE '%" + str2 + "%' and CATEGORY_ID = '" + category_id + "';";
                MySqlCommand command = new MySqlCommand(sql, connection);
                connection.Open();               
                MySqlDataReader myreader, mydata;
                myreader = command.ExecuteReader();
                myreader.Read();
                int db_category_id = myreader.GetInt32(0);
                myreader.Close();                      
                connection.Close();

                //Selecting shop id from the database and assign to db_shop_id.
                string sql1 = "SELECT SHOP_ID FROM SHOP WHERE SHOP_NAME LIKE '%" + trimmed_productLocation + "%';";
                MySqlCommand command1 = new MySqlCommand(sql1, connection);
                connection.Open();
                mydata = command1.ExecuteReader();
                mydata.Read();
                int db_shop_id = mydata.GetInt32(0);
                mydata.Close();
                connection.Close();

                //Selecting the items which fall under the selected category and selected shop and display them in the data grid view.
                string dataLoad_sql2 = "select ITEM_ID, ITEM_NAME, PRIZE, SIZE from INVENTORY where shop_id = '" + db_shop_id + "' and sub_category_id = '" + db_category_id + "' and ITEM_STATUS = 'In Stock';";
                MySqlCommand data_command2 = new MySqlCommand(dataLoad_sql2, connection);
                connection.Open();
                MySqlDataAdapter dtb = new MySqlDataAdapter(data_command2);
                
                DataTable dt = new DataTable();
                dtb.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    ProductDisplayDataGridView.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No Data found for the category. Please select another category to Proceed", "No Matching results", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ProductCategoryComboBox.Focus();
                    // Disable buttons since no product can be selected for modification/deletion
                    ModifyButton.Enabled = false;
                    DeleteButton.Enabled = false;
                    OutOfStockButton.Enabled = false;
                }

                connection.Close();
                dtb.Dispose();

            }

            catch (Exception Ex)
            {
                MessageBox.Show("There is a problem with the database of this application (Error 10). Please contact online and media coordinator to resolve this error. ", "Database connection error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine(Ex);
            }
        }

        // Code to add functionality for DeleteButton
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                // checking rows count in ProductDisplayDataGridView
                if (ProductDisplayDataGridView.SelectedRows.Count > 0)
                {
                    // Determining which row the user has selected
                        DataGridViewRow row = ProductDisplayDataGridView.SelectedRows[0];       
                        int item_id = int.Parse(row.Cells["ITEM_ID"].Value.ToString());         
                        string item_name = row.Cells["ITEM_NAME"].Value.ToString();   
                        DialogResult deleteConfirmation = MessageBox.Show("Are you sure you want to delete the Item with Item Name - " + item_name + " and Item Id - " + item_id + " ?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    if (deleteConfirmation == DialogResult.Yes)
                    {
                        //Code added for Database
                        //Query for deleting product from SVP table.
                        string dataLoad_sql4 = "DELETE FROM INVENTORY WHERE ITEM_ID = '" + item_id + "';";
                        MySqlCommand data_command4 = new MySqlCommand(dataLoad_sql4, connection);
                        connection.Open();
                        data_command4.ExecuteNonQuery();
                        connection.Close();

                        // Wordpress query for deletion and remove product from website
                        // Selecting the product id from the wp table for the selected product.
                        string sql = "select id from wp_posts where post_type = 'product' and post_title = '" + item_name + "';";
                        MySqlCommand command = new MySqlCommand(sql, connection);
                        connection.Open();
                        MySqlDataReader myreader;
                        myreader = command.ExecuteReader();
                        myreader.Read();
                        int wordpress_item_id = myreader.GetInt32(0);
                        myreader.Close();
                        connection.Close();

                        // Deleting the product from database
                        string dataLoad_sql5 = "DELETE FROM wp_term_relationships WHERE object_id= '" + wordpress_item_id + "';DELETE FROM wp_postmeta WHERE post_id= '" + wordpress_item_id + "'; DELETE FROM wp_posts WHERE ID = '" + wordpress_item_id + "'; DELETE FROM wp_postmeta WHERE post_id= '" + wordpress_item_id + "'; DELETE FROM wp_posts WHERE post_parent = '" + wordpress_item_id + "'; ";
                        MySqlCommand data_command5 = new MySqlCommand(dataLoad_sql5, connection);
                        connection.Open();
                        data_command5.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Records has been deleted.", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (ProductDisplayDataGridView.Rows.Count == 1)
                        {
                            ProductCategoryComboBox.SelectedIndex = -1;
                            ProductLocationModifyFormComboBox.SelectedIndex = -1;
                            ProductDisplayDataGridView.DataSource = null;
                            ProductLocationModifyFormComboBox.Enabled = false;
                        }

                        else
                        {
                            ProductDisplayDataGridView.DataSource = null;
                            displayDataInDataGridView();
                        }
                    }

                }

               // Checking cells and rows count in ProductDisplayDataGridView 
            else if(ProductDisplayDataGridView.SelectedCells.Count > 0 && ProductDisplayDataGridView.SelectedRows.Count == 0)
            {
                    // Determining which cells the user has selected
                    int selectedrowindex = ProductDisplayDataGridView.SelectedCells[0].RowIndex;
                    DataGridViewRow row = this.ProductDisplayDataGridView.Rows[selectedrowindex];
                    int item_id = int.Parse(row.Cells["ITEM_ID"].Value.ToString());                 
                    string item_name = row.Cells["ITEM_NAME"].Value.ToString();  

                    DialogResult deleteConfirmation = MessageBox.Show("Are you sure you want to delete the Item with Item Name - " + item_name + " and Item Id - " + item_id + " ?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                   
                    if(deleteConfirmation == DialogResult.Yes) 
                    
                    {
                        // Code added for Database
                        //Query for deleting product from SVP table.
                        string dataLoad_sql4 = "DELETE FROM INVENTORY WHERE ITEM_ID = '" + item_id + "';";
                        MySqlCommand data_command4 = new MySqlCommand(dataLoad_sql4, connection);
                        connection.Open();
                        data_command4.ExecuteNonQuery();
                        connection.Close();

                        // Wordpress query for deletion and remove product from website
                        // Selecting the product id from the wp table for the selected product.
                        string sql = "select id from wp_posts where post_type = 'product' and post_title = '" + item_name + "';";
                        MySqlCommand command = new MySqlCommand(sql, connection);
                        connection.Open();
                        MySqlDataReader myreader;
                        myreader = command.ExecuteReader();
                        myreader.Read();
                        int wordpress_item_id = myreader.GetInt32(0);
                        myreader.Close();
                        connection.Close();

                        // Deleting the product from database
                        string dataLoad_sql5 = "DELETE FROM wp_term_relationships WHERE object_id= '" + wordpress_item_id + "';DELETE FROM wp_postmeta WHERE post_id= '" + wordpress_item_id + "'; DELETE FROM wp_posts WHERE ID = '" + wordpress_item_id + "'; DELETE FROM wp_postmeta WHERE post_id= '" + wordpress_item_id + "'; DELETE FROM wp_posts WHERE post_parent = '" + wordpress_item_id + "'; ";
                        MySqlCommand data_command5 = new MySqlCommand(dataLoad_sql5, connection);
                        connection.Open();
                        data_command5.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Records has been deleted.", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (ProductDisplayDataGridView.Rows.Count == 1)
                        {
                            ProductCategoryComboBox.SelectedIndex = -1;
                            ProductLocationModifyFormComboBox.SelectedIndex = -1;
                            ProductDisplayDataGridView.DataSource = null;
                            ProductLocationModifyFormComboBox.Enabled = false;
                        }

                        else
                        {
                            ProductDisplayDataGridView.DataSource = null;
                            displayDataInDataGridView();
                        }
                    }

                }

                else
                {
                MessageBox.Show("Please select a product to delete", "Selection needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
        

            }
                
            catch (Exception Ex)
            {
                MessageBox.Show("There is a problem with the database of this application (Error 11). Please contact online and media coordinator to resolve this error. " + Ex, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine(Ex);
            }

        }


        private void ProductDisplayDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            ModifyButton.Enabled = true;
            DeleteButton.Enabled = true;
            OutOfStockButton.Enabled = true;
        }


        private void ModifyScreen_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }


        private void OutOfStockButton_Click(object sender, EventArgs e)
        {
            try
            {
                // checking rows count in ProductDisplayDataGridView
                if (ProductDisplayDataGridView.SelectedRows.Count > 0)
                {
                    // Determining which row the user has selected
                    DataGridViewRow row = ProductDisplayDataGridView.SelectedRows[0];
                    int item_id = int.Parse(row.Cells["ITEM_ID"].Value.ToString());
                    string item_name = row.Cells["ITEM_NAME"].Value.ToString();
                    DialogResult deleteConfirmation = MessageBox.Show("Are you sure you want to mark this item as 'Out of Stock' and delete the Item with Item Name - " + item_name + " and Item Id - " + item_id + " from the website?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    if (deleteConfirmation == DialogResult.Yes)
                    {
                        // Code added for Database
                        //Query for updating product status in the inventory table.
                        string dataLoad_sql4 = "update INVENTORY set ITEM_STATUS = 'Out of Stock' where ITEM_ID = '" + item_id + "';";
                        MySqlCommand data_command4 = new MySqlCommand(dataLoad_sql4, connection);
                        connection.Open();
                        data_command4.ExecuteNonQuery();
                        connection.Close();

                        // Wordpress query for deletion and remove product from website
                        // Selecting the product id from the wp table for the selected product.
                        string sql = "select id from wp_posts where post_type = 'product' and post_title = '" + item_name + "';";
                        MySqlCommand command = new MySqlCommand(sql, connection);
                        connection.Open();
                        MySqlDataReader myreader;
                        myreader = command.ExecuteReader();
                        myreader.Read();
                        int wordpress_item_id = myreader.GetInt32(0);
                        myreader.Close();
                        connection.Close();

                        // Deleting the product from database
                        string dataLoad_sql5 = "DELETE FROM wp_term_relationships WHERE object_id= '" + wordpress_item_id + "';DELETE FROM wp_postmeta WHERE post_id= '" + wordpress_item_id + "'; DELETE FROM wp_posts WHERE ID = '" + wordpress_item_id + "'; DELETE FROM wp_postmeta WHERE post_id= '" + wordpress_item_id + "'; DELETE FROM wp_posts WHERE post_parent = '" + wordpress_item_id + "'; ";
                        MySqlCommand data_command5 = new MySqlCommand(dataLoad_sql5, connection);
                        connection.Open();
                        data_command5.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Item has been marked as Out of stock.", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (ProductDisplayDataGridView.Rows.Count == 1)
                        {
                            ProductCategoryComboBox.SelectedIndex = -1;
                            ProductLocationModifyFormComboBox.SelectedIndex = -1;
                            ProductDisplayDataGridView.DataSource = null;
                            ProductLocationModifyFormComboBox.Enabled = false;
                        }

                        else
                        {
                            ProductDisplayDataGridView.DataSource = null;
                            displayDataInDataGridView();
                        }
                    }

                }

                // Checking cells and rows count in ProductDisplayDataGridView 
                else if (ProductDisplayDataGridView.SelectedCells.Count > 0 && ProductDisplayDataGridView.SelectedRows.Count == 0)
                {
                    // Determining which cells the user has selected
                    int selectedrowindex = ProductDisplayDataGridView.SelectedCells[0].RowIndex;
                    DataGridViewRow row = this.ProductDisplayDataGridView.Rows[selectedrowindex];
                    int item_id = int.Parse(row.Cells["ITEM_ID"].Value.ToString());
                    string item_name = row.Cells["ITEM_NAME"].Value.ToString();

                    DialogResult deleteConfirmation = MessageBox.Show("Are you sure you want to mark this item as 'Out of Stock' and delete the Item with Item Name - " + item_name + " and Item Id - " + item_id + " from the website?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (deleteConfirmation == DialogResult.Yes)

                    {
                        // Code added for Database
                        //Query for updating product status in the inventory table.
                        string dataLoad_sql4 = "update INVENTORY set ITEM_STATUS = 'Out of Stock' where ITEM_ID = '" + item_id + "';";
                        MySqlCommand data_command4 = new MySqlCommand(dataLoad_sql4, connection);
                        connection.Open();
                        data_command4.ExecuteNonQuery();
                        connection.Close();

                        // Wordpress query for deletion and remove product from website
                        // Selecting the product id from the wp table for the selected product.
                        string sql = "select id from wp_posts where post_type = 'product' and post_title = '" + item_name + "';";
                        MySqlCommand command = new MySqlCommand(sql, connection);
                        connection.Open();
                        MySqlDataReader myreader;
                        myreader = command.ExecuteReader();
                        myreader.Read();
                        int wordpress_item_id = myreader.GetInt32(0);
                        myreader.Close();
                        connection.Close();

                        // Deleting the product from database
                        string dataLoad_sql5 = "DELETE FROM wp_term_relationships WHERE object_id= '" + wordpress_item_id + "';DELETE FROM wp_postmeta WHERE post_id= '" + wordpress_item_id + "'; DELETE FROM wp_posts WHERE ID = '" + wordpress_item_id + "'; DELETE FROM wp_postmeta WHERE post_id= '" + wordpress_item_id + "'; DELETE FROM wp_posts WHERE post_parent = '" + wordpress_item_id + "'; ";
                        MySqlCommand data_command5 = new MySqlCommand(dataLoad_sql5, connection);
                        connection.Open();
                        data_command5.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Item has been marked as Out of stock.", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (ProductDisplayDataGridView.Rows.Count == 1)
                        {
                            ProductCategoryComboBox.SelectedIndex = -1;
                            ProductLocationModifyFormComboBox.SelectedIndex = -1;
                            ProductDisplayDataGridView.DataSource = null;
                            ProductLocationModifyFormComboBox.Enabled = false;
                        }

                        else
                        {
                            ProductDisplayDataGridView.DataSource = null;
                            displayDataInDataGridView();
                        }
                    }

                }

                else
                {
                    MessageBox.Show("Please select a product to delete", "Selection needed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }

            catch (Exception Ex)
            {
                MessageBox.Show("There is a problem with the database of this application (Error 12). Please contact online and media coordinator to resolve this error. " + Ex, "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine(Ex);
            }

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "OnlineHelp_VincentsOnlineStoreManager.chm");
        }
    }

}
    

