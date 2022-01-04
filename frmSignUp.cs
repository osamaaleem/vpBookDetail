using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vpBookDetail
{
    public partial class frmSignUp : Form
    {
        public frmSignUp()
        {
            InitializeComponent();
        }
        private Register ValidateData()
        {
            Register reg = new Register();
            lblRegisterMsg.ForeColor = Color.Red;
            if (txtUsername == null)
            {
                lblRegisterMsg.Text = "Insert Username";
                txtUsername.Focus();
            }
            else if (txtFirstName.Text == null)
            {
                lblRegisterMsg.Text = "Insert First Name";
                txtFirstName.Focus();
            }
            else if (txtLastName.Text == null)
            {
                lblRegisterMsg.Text = "Insert Last Name";
                txtLastName.Focus();
            }
            else if (txtEmail.Text == null)
            {
                lblRegisterMsg.Text = "Insert Email";
                txtEmail.Focus();
            }
            else if (txtPassword.Text == null)
            {
                lblRegisterMsg.Text = "Insert Password";
                txtEmail.Focus();
            }
            else
            {
                reg.username = txtUsername.Text;
                reg.firstName = txtFirstName.Text;
                reg.lastName = txtLastName.Text;
                reg.email = txtEmail.Text;
                reg.password = txtPassword.Text;
            }
            return reg;
        }
            private void btnLogin_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            Hide();
            login.ShowDialog();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            User user = new User();
            int userAdded = user.RegisterUser(ValidateData());
            if (userAdded > 0)
            {
                lblRegisterMsg.ForeColor = Color.Green;
                lblRegisterMsg.Text = "User Added";
            }
            else
            {
                lblRegisterMsg.ForeColor = Color.Red;
                lblRegisterMsg.Text = "Username already exists";
            }
        }
    }
}
