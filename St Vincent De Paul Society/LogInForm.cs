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

        // Declaring variables globally
        const string PASSWORD = "vincent";
        int passwordCount = 3; // variable used to check no of remaining attempts for entering correct password

        public LogInForm()
        {
            InitializeComponent();
            // Hiding the characters of PasswordTextBox 
            PasswordTextBox.PasswordChar = '*';
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {

        }


        // Functionality on clicking LogInButton
        private void LogInButton_Click(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == "")
            {
                MessageBox.Show("Please enter the password and try again", "Password needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            else if (PasswordTextBox.Text == PASSWORD)

            {


                this.Hide();

                //Declaring a variable for WelcomeForm
                WelcomeForm form2 = new WelcomeForm();

                //Showing WelcomeForm
                form2.ShowDialog();


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

                // if the user enters an incorrect password 3 times, this message box will appear
                MessageBox.Show(" Sorry! You have entered an incorrect password.\r\n You are blocked as no chances are left. \r\n Please try again after sometime.", "Blocked", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                // Application will close
                this.Close();

            }


        }



       


    }
}
