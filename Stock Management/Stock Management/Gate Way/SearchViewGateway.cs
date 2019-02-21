using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Management.Gate_Way
{
    using System.Data.SqlClient;
    using System.Web.Configuration;

    using Stock_Management.Models;

    public class SearchViewGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["StockConnection"].ConnectionString;

        public List<SearchVM> ViewReportByCompany(int companyId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string querry =
                "select  I.Item_Name,co.Company_Name,ca.Category_Name,I.Available_Quantity,I.Reorder"
                + " from Item_tbl as I  "
                + "inner join Company_tbl as co "
                + "on co.Company_Id = I.Company_Id "
                + "inner join Category_tbl as ca " 
                + "on ca.Category_Id = I.Category_Id " 
                + "where I.Company_Id='"
                + companyId + "'";
            SqlCommand cmd = new SqlCommand(querry, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<SearchVM> report = new List<SearchVM>();
            while (reader.Read())
            {
                SearchVM aSearchVm = new SearchVM();
                //aItem.ItemId = (int)reader["Item_Id"];
                aSearchVm.ItemName = reader["Item_Name"].ToString();
                aSearchVm.CompanyName = reader["Company_Name"].ToString();
                aSearchVm.CategoryName = reader["Category_Name"].ToString();
                aSearchVm.AvailableQuantity = (int)reader["Available_Quantity"];
                aSearchVm.ReOrder = (int)reader["Reorder"];
                report.Add(aSearchVm);
            }
            reader.Close();
            connection.Close();
            return report;
        }

        public List<SearchVM> ViewReportByCategory(int categoryId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string querry =
                "select  I.Item_Name,co.Company_Name,ca.Category_Name,I.Available_Quantity,I.Reorder"
                + " from Item_tbl as I  "
                + "inner join Company_tbl as co "
                + "on co.Company_Id = I.Company_Id "
                + "inner join Category_tbl as ca "
                + "on ca.Category_Id = I.Category_Id "
                + "where I.Category_Id='"
                + categoryId + "'";
            SqlCommand cmd = new SqlCommand(querry, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<SearchVM> report = new List<SearchVM>();
            while (reader.Read())
            {
                SearchVM aSearchVm = new SearchVM();
                //aItem.ItemId = (int)reader["Item_Id"];
                aSearchVm.ItemName = reader["Item_Name"].ToString();
                aSearchVm.CompanyName = reader["Company_Name"].ToString();
                aSearchVm.CategoryName = reader["Category_Name"].ToString();
                aSearchVm.AvailableQuantity = (int)reader["Available_Quantity"];
                aSearchVm.ReOrder = (int)reader["Reorder"];
                report.Add(aSearchVm);
            }
            reader.Close();
            connection.Close();
            return report;
        }

        public List<SearchVM> ViewReportByCompanyAndCategory(int companyId,int categoryId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string querry =
                "select  I.Item_Name,co.Company_Name,ca.Category_Name,I.Available_Quantity,I.Reorder"
                + " from Item_tbl as I  "
                + "inner join Company_tbl as co "
                + "on co.Company_Id = I.Company_Id "
                + "inner join Category_tbl as ca " + "on ca.Category_Id = I.Category_Id " + "where I.Category_Id='"
                + categoryId + "' and I.Company_Id='" + companyId + "'";
            SqlCommand cmd = new SqlCommand(querry, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<SearchVM> report = new List<SearchVM>();
            while (reader.Read())
            {
                SearchVM aSearchVm = new SearchVM();
                //aItem.ItemId = (int)reader["Item_Id"];
                aSearchVm.ItemName = reader["Item_Name"].ToString();
                aSearchVm.CompanyName = reader["Company_Name"].ToString();
                aSearchVm.CategoryName = reader["Category_Name"].ToString();
                aSearchVm.AvailableQuantity = (int)reader["Available_Quantity"];
                aSearchVm.ReOrder = (int)reader["Reorder"];
                report.Add(aSearchVm);
            }
            reader.Close();
            connection.Close();
            return report;
        }
        public List<SearchVM> ViewAllReport()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string querry =
                "select  I.Item_Name,co.Company_Name,ca.Category_Name,I.Available_Quantity,I.Reorder "
                + "from Item_tbl as I "
                + "inner join Company_tbl as co"
                + " on co.Company_Id = I.Company_Id"
                + " inner join Category_tbl as ca" 
                + " on ca.Category_Id = I.Category_Id";

            SqlCommand cmd = new SqlCommand(querry, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<SearchVM> report = new List<SearchVM>();
            while (reader.Read())
            {
                SearchVM aSearchVm = new SearchVM();
                //aItem.ItemId = (int)reader["Item_Id"];
                aSearchVm.ItemName = reader["Item_Name"].ToString();
                aSearchVm.CompanyName = reader["Company_Name"].ToString();
                aSearchVm.CategoryName = reader["Category_Name"].ToString();
                aSearchVm.AvailableQuantity = (int)reader["Available_Quantity"];
                aSearchVm.ReOrder = (int)reader["Reorder"];
                report.Add(aSearchVm);
            }
            reader.Close();
            connection.Close();
            return report;
        }
    }
}