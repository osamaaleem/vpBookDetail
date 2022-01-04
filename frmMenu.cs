using System;
using System.Windows.Forms;

namespace vpBookDetail
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            frmAddBook frmAdd = new frmAddBook();
            Hide();
            frmAdd.ShowDialog();
        }

        private void btnBookDetail_Click(object sender, EventArgs e)
        {
            frmBookDetail frmDetail = new frmBookDetail();
            Hide();
            frmDetail.ShowDialog();
        }
    }
}
