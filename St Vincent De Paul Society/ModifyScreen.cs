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

        public HashSet<String> testc = new HashSet<string>();

        public ModifyScreen()
        {
            InitializeComponent();
			FillComboBox();
        }

		void FillComboBox()
        {
            try
            {
                // code to add items in categories Combobox
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
                    ProductCategoryComboBox.Items.Add(categories);
                }
                ProductCategoryComboBox.Items.Add("Books");
                ProductCategoryComboBox.Items.Add("Others");
                connection.Close();

                // code to add items in Location Combobox
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
                    ProductLocationModifyFormComboBox.Items.Add(shops);
                }
                connection1.Close();
            }

            catch (Exception Ex)
            {
                MessageBox.Show("There is a problem with data Load", "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine(Ex);
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

        private void ModifyButton_Click(object sender, EventArgs e)
        {
            if (ProductCategoryComboBox.SelectedIndex < 0)

            {
                MessageBox.Show("Please select a product category", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            else
            {
                if (ProductLocationModifyFormComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select the location", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
                else
                {
                    if (ChooseProductsModifyScreenListBox.SelectedIndex < 0 || ChooseProductsModifyScreenListBox.SelectedIndex ==0)
                    {
                        MessageBox.Show("Please choose a valid product from the list", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                    else
                    {
                        this.Hide();
                        //Declaring a variable for Modify form
                        UploadForm f3 = new UploadForm();
                        f3.productCategoryModifySet = ProductCategoryComboBox.SelectedIndex;
                        f3.productLocationLocationSet = ProductLocationModifyFormComboBox.SelectedIndex;
						f3.selectedProduct = ChooseProductsModifyScreenListBox.SelectedItem.ToString();
                        //Showing WelcomeForm
                        f3.ShowDialog();

                    }

                }


            }
        }

        private void ProductCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProductCategoryComboBox.SelectedIndex != -1)
            {
                testc.Clear();
                ChooseProductsModifyScreenListBox.Items.Clear();

                ProductLocationModifyFormComboBox.Enabled = true;
                //ChooseProductsModifyScreenListBox.Items.Add(ProductCategoryComboBox.SelectedItem + " " + ProductLocationModifyFormComboBox.SelectedItem);

                foreach (String item in ChooseProductsModifyScreenListBox.Items)
                {
                    testc.Add(item);
                }
                //ChooseProductsModifyScreenListBox.Items.Add("SELECT * FROM ITEMS WHERE PRODUCTCATEGORY = '" + ProductCategoryComboBox.SelectedItem + "'");
            }
        }

        private void ProductLocationModifyFormComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProductCategoryComboBox.SelectedIndex != -1 && ProductLocationModifyFormComboBox.SelectedIndex != -1)
            {
                testc.Clear();
                ChooseProductsModifyScreenListBox.Items.Clear();
                //ChooseProductsModifyScreenListBox.Items.Add(ProductCategoryComboBox.SelectedItem + " " + ProductLocationModifyFormComboBox.SelectedItem);
                // ChooseProductsModifyScreenListBox.Items.Add("SELECT * FROM ITEMS WHERE PRODUCTCATEGORY = '" + ProductCategoryComboBox.SelectedItem + "' AND PRODUCTLOCATIO = " +ProductLocationModifyFormComboBox.SelectedItem + "'" );
				try
                {
                    string product_type = ProductCategoryComboBox.SelectedItem.ToString();
                    string shop_location = ProductLocationModifyFormComboBox.SelectedItem.ToString();
                    string trimmed_productType = product_type.Replace("Collectable ", "").Replace("Accessories ", "").Replace("Living ", "").Replace("Clothing ", "").Replace("Hobbies ", "").Replace("Expensive ", "");
                    string trimmed_productLocation = shop_location.Replace("Merchant's", "").Replace("Vincent's", "");
                    //string in_stock_date = DateTime.Now.ToString("yyyy-MM-dd");
                    string connectionString = "datasource=localhost;port=3308;username=root;password=";
                    string sql = "SELECT SUB_CATEGORY_ID FROM test_db.SUB_CATEGORY WHERE SUB_CATEGORY_NAME LIKE '%" + trimmed_productType + "%';";
                    string sql1 = "SELECT SHOP_ID FROM test_db.SHOP WHERE SHOP_NAME LIKE '%" + trimmed_productLocation + "%';";

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
                    //MessageBox.Show(db_category_id.ToString());
                    int db_shop_id = mydata.GetInt32(0);
                    //MessageBox.Show(db_shop_id.ToString());
                    myreader.Close();
                    mydata.Close();
                    conn.Close();
                    conn1.Close();

                    string connectionString_dataload2 = "datasource=localhost;port=3308;username=root;password=";
                    //string dataLoad_sql2 = "select ITEM_ID, ITEM_NAME, PRIZE, SIZE from test_db.inventory where shop_id = '"+ db_category_id + "' and sub_category_id = '" + db_shop_id + "';";
                    string dataLoad_sql2 = "select ITEM_ID, ITEM_NAME, PRIZE, SALE, SIZE from test_db.inventory where shop_id = '"+ db_shop_id + "' and sub_category_id = '" + db_category_id + "';"; 
                    MySqlConnection connection2 = new MySqlConnection(connectionString_dataload2);
                    MySqlCommand data_command2 = new MySqlCommand(dataLoad_sql2, connection2);
                    connection2.Open();
                    MySqlDataReader dataload2;
                    dataload2 = data_command2.ExecuteReader();
                    //string display_products = String.Format("{0,10} {1,20} {2,10} {3,10} {4,10}","Item ID","Item Name","Price","Sale","Size");
                    string display_products = "Item ID" + "" + "Item Name" + "   " + "Price"  + "   " + "Sale" + "   " + "Size";
                    ChooseProductsModifyScreenListBox.Items.Add(display_products);
                 
                    while (dataload2.Read())
                    {
                        string item_id = dataload2.GetString(0);
                        string item_name = dataload2.GetString(1);
                        string prize = dataload2.GetString(2);
                        string sale = dataload2.GetString(3);
                        string size = dataload2.GetString(4);
                        //string display_products1 = String.Format("{0,15} {1,15} {2,10} {3,10} {4,10}",item_id,item_name,prize,sale,size);
                        string display_products1 = item_id + "" + item_name + "   " + prize + "  	" +  sale  + "   " + size;
                        ChooseProductsModifyScreenListBox.Items.Add(display_products1);
                    }
                    connection2.Close();
                }

                catch (Exception Ex)
                {
                    MessageBox.Show("There is a problem with data Load", "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Console.WriteLine(Ex);
                }
            
            
			}
            

            foreach (String item in ChooseProductsModifyScreenListBox.Items)
            {
                testc.Add(item);
            }


        }

        private void ModifyScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

            
            string SEARCHSTRING = SearchTextBox.Text;

            if (!String.IsNullOrEmpty(SEARCHSTRING))
            {
                ChooseProductsModifyScreenListBox.Items.Clear();
                foreach (String item in testc)
                {
                    //string listString = testc[i].ToString();
                    if (item.ToLower().Contains(SEARCHSTRING.ToLower()))
                    {
                        ChooseProductsModifyScreenListBox.Items.Add(item);

                    }
                }
            }
            else
            {
                ChooseProductsModifyScreenListBox.Items.Clear();
                foreach (String item in testc)
                {
                    ChooseProductsModifyScreenListBox.Items.Add(item);
                }
            }


        }

        private void SearchTextBox_Enter(object sender, EventArgs e)
        {
            SearchTextBox.Text = "";
        }

        private void SearchTextBox_Leave(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == "")
            {
                SearchTextBox.Text = "Type anything to search";
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            DialogResult resultBack = MessageBox.Show("Do you wish to go back??", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

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
    }
}
