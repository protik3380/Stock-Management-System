using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Management.Gate_Way
{
    using System.Data.SqlClient;
    using System.Web.Configuration;
    using Stock_Management.Models;

    public class InventoryGateway
    {

        private string connectionString =
            WebConfigurationManager.ConnectionStrings["StockConnection"].ConnectionString;

        public int SaveStockOut(Inventory aInventory)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "insert into Stock_tbl(Company_Name,Item_Name,Quantity,Item_Id) values('"
                            + aInventory.CompanyName + "','" + aInventory.ItemName + "','" + aInventory.StockOut + "','"
                            + aInventory.ItemId + "')";
            SqlCommand cmd = new SqlCommand(querry, connection);
            int rowCount = cmd.ExecuteNonQuery();
            connection.Close();
            return rowCount;

        }
        public bool IsExist(string companyName,string itemName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "SELECT * FROM Stock_tbl  WHERE Company_Name ='" + companyName + "'and Item_Name='" + itemName + "' ";
            SqlCommand cmd = new SqlCommand(querry, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            return false;
        }
        public bool IsExistForReport(string companyName, string itemName,string type)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "SELECT * FROM StockOut_tbl  WHERE Company_Name ='" + companyName + "'and Item_Name='"
                            + itemName + "' and StockOut_type='" + type + "' ";
            SqlCommand cmd = new SqlCommand(querry, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            return false;
        }
        public int UpdateQuantity(string companyName, string itemName,int quantity)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "UPDATE Stock_tbl SET Quantity=(select sum(Quantity+'" + quantity + "')from Stock_tbl where Item_Name = '" + itemName + "' and Company_Name='" + companyName + "') where Item_Name = '" + itemName + "' and Company_Name='" + companyName + "'";
            SqlCommand cmd = new SqlCommand(querry, connection);
            int rowCount = cmd.ExecuteNonQuery();
            connection.Close();
            return rowCount;
        }
        public void UpdateQuantityForReport(Inventory aInventory,string type)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "UPDATE StockOut_tbl SET Quantity=(select sum(Quantity+'" + aInventory.StockOut + "')from StockOut_tbl where Item_Name = '" + aInventory.ItemName + "' and Company_Name='" + aInventory.CompanyName + "' and StockOut_type='" + type + "') where Item_Name = '" + aInventory.ItemName + "' and Company_Name='" + aInventory.CompanyName + "' and StockOut_type='" + type + "'";
            SqlCommand cmd = new SqlCommand(querry, connection);
            int rowCount = cmd.ExecuteNonQuery();

            string querry1 = "UPDATE Item_tbl SET Available_Quantity=(select sum(Available_Quantity-'" + aInventory.StockOut + "')from Item_tbl where Item_Id = '" + aInventory.ItemId + "') WHERE Item_Id='" + aInventory.ItemId + "'";
            SqlCommand cmd1 = new SqlCommand(querry1, connection);
            int rowCount1 = cmd1.ExecuteNonQuery();
            connection.Close();
           // return rowCount;
        }

        public List<Inventory> GetReport()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "SELECT * FROM Stock_tbl";
            SqlCommand cmd = new SqlCommand(querry, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Inventory> inventories = new List<Inventory>();
            while (reader.Read())
            {
                Inventory aInventory = new Inventory();
                aInventory.ItemId = (int)reader["Item_Id"];
                aInventory.ItemName = reader["Item_Name"].ToString();
                aInventory.CompanyName = reader["Company_Name"].ToString();
                aInventory.StockOut = (int)reader["Quantity"];
                inventories.Add(aInventory);
            }
            reader.Close();
            connection.Close();
            return inventories;
        }

        public void SaveStockOutQuantity(Inventory aInventory,string type)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "UPDATE Item_tbl SET Available_Quantity=(select sum(Available_Quantity-'" + aInventory.StockOut + "')from Item_tbl where Item_Id = '" + aInventory.ItemId + "') WHERE Item_Id='" + aInventory.ItemId + "'";
            SqlCommand cmd = new SqlCommand(querry, connection);
            int rowCount = cmd.ExecuteNonQuery();

            string querry1 = "insert into StockOut_tbl(Item_Id,Item_Name,Company_Name,Quantity,Date,StockOut_type) values('" + aInventory.ItemId + "','" + aInventory.ItemName + "','" + aInventory.CompanyName + "','" + aInventory.StockOut + "','" + aInventory.date + "','"+type+"')";
            SqlCommand cmd1 = new SqlCommand(querry1, connection);
            int rowCount1 = cmd1.ExecuteNonQuery();

        }

        public void DeleteStockOutTable()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "DELETE FROM Stock_tbl";
            SqlCommand cmd = new SqlCommand(querry, connection);
            int rowCount = cmd.ExecuteNonQuery();

        }
    }
}