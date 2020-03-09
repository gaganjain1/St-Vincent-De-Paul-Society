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
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {

        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            //Declaring a variable for LoginForm
            LogInForm f1 = new LogInForm();

            //Showing WelcomeForm
            f1.ShowDialog();
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {

            this.Hide();
            //Declaring a variable for LoginForm
            UploadForm f3 = new UploadForm();
           
            //Showing WelcomeForm
            f3.ShowDialog();

        }

        private void ModifyButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Declaring a variable for LoginForm
            ModifyScreen f4 = new ModifyScreen();

            //Showing ModifyScreen
            f4.ShowDialog();
        }
    }
}
