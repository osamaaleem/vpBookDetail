using System;
using System.Windows.Forms;

namespace vpBookDetail
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private string username, password;
        private void ValidateData()
        {
            lblLoginMessage.ForeColor = System.Drawing.Color.Red;
            if (txtLogInId.Text == null)
            {
                lblLoginMessage.Text = "Enter username";
            }
            else if (txtPassword.Text == null)
            {
                lblLoginMessage.Text = "Enter password";
            }
            else
            {
                username = txtLogInId.Text;
                password = txtPassword.Text;
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            frmSignUp sign = new frmSignUp();
            Hide();
            sign.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ValidateData();
            User user = new User();
            if (user.isValidUser(username, password))
            {
                Hide();
                frmMenu menufrm = new frmMenu();
                menufrm.ShowDialog();
            }
            else
            {
                lblLoginMessage.Text = "User not found";
            }
        }
    }
}
