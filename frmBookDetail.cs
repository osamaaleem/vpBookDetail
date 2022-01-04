using System;
using System.Data;
using System.Windows.Forms;

namespace vpBookDetail
{
    public partial class frmBookDetail : Form
    {
        public frmBookDetail()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            Hide();
            menu.ShowDialog();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            // dgvBookDetail.Rows.Clear();
            DataHandler data = new DataHandler();
            dgvBookDetail.DataSource = data.GetData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataHandler data = new DataHandler();
            //dgvBookDetail.Rows.Clear();
            DataTable dt = new DataTable();
            dt = data.SearchBook(txtSearchId.Text);
            if (dt.Rows.Count > 0)
            {
                dgvBookDetail.DataSource = dt;
            }
            else
            {
                lblSearchMsg.Text = "No item found";
            }
        }
    }
}
