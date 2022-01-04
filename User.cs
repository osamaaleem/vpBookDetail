using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace vpBookDetail
{
    class User
    {
        public User()
        {
            connection = new SqlConnection(connectionString);
        }
        private string connectionString = ConfigurationManager.ConnectionStrings["DataDb"].ToString();
        private SqlConnection connection;
        private string query;
        private SqlCommand command;
        private SqlDataReader reader;
        public bool isValidUser(String username, String password)
        {
            bool isValid = false;
            query = $"SELECT * FROM Users WHERE username LIKE '{username}' AND password LIKE '{password}'";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                isValid = true;
            }
            connection.Close();
            return isValid;
        }
        public int RegisterUser(Register reg)
        {
            int result = 0;
            query = $"INSERT INTO Users VALUES('{reg.username}','{reg.firstName}','{reg.lastName}','{reg.email}','{reg.password}')";
            command = new SqlCommand(query, connection);
            connection.Open();
            try
            {
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = 0;
            }
            connection.Close();
            return result;
        }
    }
}
