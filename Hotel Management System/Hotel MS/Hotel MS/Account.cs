using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_MS
{
    public partial class Account : Form
    {
       DatabaseHelper databaseHelper = new DatabaseHelper();
        
        public Account()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Account_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String query = "Select username, Password from Customer_Information where username='"+textBox1.Text+"' and Password = '"+textBox2.Text+"'";
            if (databaseHelper.loginForm(query)==1)
            {
                
                MessageBox.Show("Done");                // Put here the next form after login
                Home home = new Home();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Attention needed your input is incorect");
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            CreateNewAccount createNewAccount = new CreateNewAccount();
            createNewAccount.Show();
            this.Hide();
        }
    }
}
