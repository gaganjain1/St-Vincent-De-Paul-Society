using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace St_Vincent_De_Paul_Society
{
    public partial class LogInForm : Form
    {

        const string PASSWORD = "vincent";
        int passwordCount = 4;

        public LogInForm()
        {
            InitializeComponent();
            // Hiding the characters of PasswordTextBox 
            PasswordTextBox.PasswordChar = '*';
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == "")
            {
                MessageBox.Show("Please enter the password and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            else if (PasswordTextBox.Text == PASSWORD)

            {

               
                this.Hide();

                //Declaring a variable for WelcomeForm
                WelcomeForm f2 = new WelcomeForm();

                //Showing WelcomeForm
                f2.ShowDialog();


            }

            // if the user enters an incorrect password, application displays an attention message box
            else if (passwordCount > 1)
            {
                passwordCount--;
                MessageBox.Show("Sorry! You have entered an incorrect password. \r\n" + "You are left with " + passwordCount + " attempts.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordTextBox.Clear();
                PasswordTextBox.Focus();

            }

            else
            {

                // if the user enters an incorrect password 4 times, this message box will appear
                MessageBox.Show(" Sorry! You have entered an incorrect password.\r\n You are blocked as no chances are left. \r\n Please try again after sometime.", "Blocked", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                // Application will close
                this.Close();

            }

            
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
