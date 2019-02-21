using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Management.Gate_Way
{
    using System.Data.SqlClient;
    using System.Web.Configuration;

    using Stock_Management.Models;

    public class CompanyGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["StockConnection"].ConnectionString;

        public int SaveCompany(Company aCompany)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "insert into Company_tbl(Company_Name) values('" + aCompany.CompanyName + "')";
            SqlCommand cmd = new SqlCommand(querry, connection);
            int rowCount = cmd.ExecuteNonQuery();
            connection.Close();
            return rowCount;

        }
        public bool IsExist(string companyName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "SELECT * FROM Company_tbl  WHERE Company_Name ='" + companyName + "'";
            SqlCommand cmd = new SqlCommand(querry, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            return false;
        }
        public List<Company> GetAllCompany()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "SELECT * FROM Company_tbl";
            SqlCommand cmd = new SqlCommand(querry, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Company> companies = new List<Company>();
            while (reader.Read())
            {
                Company aCompany = new Company();
                aCompany.CompanyId = (int)reader["Company_Id"];
                aCompany.CompanyName = reader["Company_Name"].ToString();
                companies.Add(aCompany);
            }
            reader.Close();
            connection.Close();
            return companies;
        }
    }
}