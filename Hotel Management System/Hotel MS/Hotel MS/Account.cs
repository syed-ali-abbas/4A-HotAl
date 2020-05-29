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
       DatabaseHelper databaseHelper;
        MessageAlert messageAlert;
        public Account()
        {
            databaseHelper = new DatabaseHelper();
            messageAlert = new MessageAlert();
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
            if ((textBox1.Text=="")||(textBox2.Text==""))
            {
                messageAlert.UserDefinedErrorMessage("Any Field is Empty");
                textBox1.BackColor = Color.Red;
                textBox2.BackColor = Color.Red;
            }
            else
            {
                String query = "Select username, Password from Customer_Information where username='" + textBox1.Text + "' and Password = '" + textBox2.Text + "'";
                if (databaseHelper.loginForm(query) == 1)
                {
                    messageAlert.UserDefinedSuccessMessage("Logged In");
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                else
                {
                    textBox1.BackColor = Color.Red;
                    textBox2.BackColor = Color.Red;
                    messageAlert.UserDefinedErrorMessage("Invalid credentials");

                }
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
