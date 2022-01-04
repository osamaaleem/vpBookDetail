using System;
using System.Drawing;
using System.Windows.Forms;

namespace vpBookDetail
{
    public partial class frmAddBook : Form
    {
        public frmAddBook()
        {
            InitializeComponent();
        }
        private Book ValidateData()
        {
            Book book = new Book();
            lblAddMsg.ForeColor = Color.Red;
            if (txtBookId == null)
            {
                lblAddMsg.Text = "Insert Id";
                txtBookId.Focus();
            }
            else if (txtBookTitle.Text == null)
            {
                lblAddMsg.Text = "Insert Title";
                txtBookTitle.Focus();
            }
            else if (txtAuthor.Text == null)
            {
                lblAddMsg.Text = "Insert Author";
                txtAuthor.Focus();
            }
            else if (txtCatagory.Text == null)
            {
                lblAddMsg.Text = "Insert Catagory";
                txtCatagory.Focus();
            }
            else
            {
                book.id = txtBookId.Text;
                book.Title = txtBookTitle.Text;
                book.Author = txtAuthor.Text;
                book.Catagory = txtCatagory.Text;
            }
            return book;
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            Hide();
            frmMenu menu = new frmMenu();
            menu.ShowDialog();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            DataHandler data = new DataHandler();
            int bookAdded = data.AddBook(ValidateData());
            if (bookAdded > 0)
            {
                lblAddMsg.ForeColor = Color.Green;
                lblAddMsg.Text = $"{bookAdded} book added";
            }
            else
            {
                lblAddMsg.ForeColor=Color.Red;
                lblAddMsg.Text = "Id already exists! book not added";
            }
            
        }
    }
}
