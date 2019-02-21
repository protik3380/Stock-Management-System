using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Management.Gate_Way
{
    using System.Data.SqlClient;
    using System.Web.Configuration;

    using Stock_Management.Models;

    public class CategoryGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["StockConnection"].ConnectionString;

        public int SaveCategory(Category aCategory)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "insert into Category_tbl(Category_Name) values('" + aCategory.CategoryName + "')";
            SqlCommand cmd = new SqlCommand(querry, connection);
            int rowCount = cmd.ExecuteNonQuery();
            connection.Close();
            return rowCount;

        }
        public bool IsExist(string categoryName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "SELECT * FROM Category_tbl  WHERE Category_Name ='" + categoryName + "'";
            SqlCommand cmd = new SqlCommand(querry, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            return false;
        }
        public List<Category> GetAllCategories()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "SELECT * FROM Category_tbl";
            SqlCommand cmd = new SqlCommand(querry, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Category> categories = new List<Category>();
            while (reader.Read())
            {
                Category aCategory = new Category();
                aCategory.CategoryId = (int)reader["Category_Id"];
                aCategory.CategoryName = reader["Category_Name"].ToString();
                categories.Add(aCategory);
            }
            reader.Close();
            connection.Close();
            return categories;
        }
        public Category GetCategoryById(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "SELECT * FROM Category_tbl  WHERE Category_Id ='" + id + "'";
            SqlCommand cmd = new SqlCommand(querry, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            Category category = null;
            if (reader.HasRows)
            {
                reader.Read();
                category = new Category();
               // category.CategoryId = (int)reader["Category_Id"];
                category.CategoryName = reader["Category_Name"].ToString();
                
            }
            return category;
        }
        public int Update(Category category,int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "UPDATE Category_tbl SET Category_Name='" + category.CategoryName + "' WHERE Category_Id ='" + id + "'";
            SqlCommand cmd = new SqlCommand(querry, connection);
            int rowCount = cmd.ExecuteNonQuery();
            connection.Close();
            return rowCount;
        }

    }
}