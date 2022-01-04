using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace vpBookDetail
{
    class DataHandler
    {
        public DataHandler()
        {
            connection = new SqlConnection(connectionString);
        }
        private string connectionString = ConfigurationManager.ConnectionStrings["DataDb"].ConnectionString;
        private SqlConnection connection;
        private string query;
        private SqlCommand command;
        private SqlDataReader reader;
        private SqlDataAdapter adapter;
        private SqlCommandBuilder builder;
        public DataTable GetData()
        {
            DataSet ds = new DataSet();
            query = "SELECT * FROM books";
            command = new SqlCommand(query, connection);
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds, "books");
            return ds.Tables["books"];
        }
        public int AddBook(Book book)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            query = "SELECT * FROM books";
            command = new SqlCommand(query, connection);
            adapter = new SqlDataAdapter(command);
            builder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds, "books");
            dt = ds.Tables["books"];
            DataRow dr = dt.NewRow();
            dr["id"] = book.id;
            dr["title"] = book.Title;
            dr["catagory"] = book.Catagory;
            dr["author"] = book.Author;
            dt.Rows.Add(dr);
            return adapter.Update(dt);
        }
        public DataTable SearchBook(string serachItem)
        {
            query = $"SELECT * FROM books WHERE id LIKE '%{serachItem}%' OR title LIKE '%{serachItem}%'";
            DataSet ds = new DataSet();
            command = new SqlCommand(query, connection);
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds, "books");
            return ds.Tables["books"];
        }
    }
}
