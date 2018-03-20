using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainTicketSeller.Database;

namespace TrainTicketSeller.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String password = txtPassword.Text;

            if (username.Equals(""))
            {
                MessageBox.Show("Please enter a username.", "Error");
            }
            else if(password.Equals("")){
                MessageBox.Show("Please enter a password.", "Error");
            }
            else
            {
                bool found = UserCommands.AdminLogin(username, password);
                if (!found)
                {
                    lblInfo.Text = "Incorrect Password";
                    txtPassword.Text = "";
                    txtPassword.Focus();
                }
                else
                {
                    AddTrain addTrain = new AddTrain();
                    this.Hide();
                    addTrain.ShowDialog();
                    this.Close();
                }
            }
        }
    }
}
