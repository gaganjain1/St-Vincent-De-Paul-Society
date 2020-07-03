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
            LogInForm form1 = new LogInForm();

            //Showing LoginForm
            form1.ShowDialog();
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {

            this.Hide();
            //Declaring a variable for UploadForm
            UploadForm form3 = new UploadForm();
            form3.isModifyOrDeleteSet = false;
            form3.isUploadSet = true;
            //Showing UploadForm
            form3.ShowDialog();

        }

        private void ModifyButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Declaring a variable for ModifyForm
            ModifyScreen form4 = new ModifyScreen();
            form4.setIsDelete = false;
            form4.setIsModify = true;
            //Showing ModifyScreen
            form4.ShowDialog();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Declaring a variable for ModifyForm
            ModifyScreen form4 = new ModifyScreen();
            form4.setIsDelete = true;
            form4.setIsModify = false;
            //Showing ModifyScreen
            form4.ShowDialog();

        }

        // To display HTML manual on application
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "OnlineHelp_VincentsOnlineStoreManager.chm");
        }


        // Closing the application if form gets closed
        private void WelcomeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
