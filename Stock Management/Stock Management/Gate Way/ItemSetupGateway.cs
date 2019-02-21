using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Management.Gate_Way
{
    using System.Data.SqlClient;
    using System.Web.Configuration;

    using Stock_Management.Models;

    public class ItemSetupGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["StockConnection"].ConnectionString;
        public int SaveItem(Item aItem)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "INSERT INTO Item_tbl(Category_Id,Company_Id,Item_Name,Reorder,Available_Quantity) Values('" + aItem.CategoryId
                                                                                                      + "','" + aItem
                                                                                                          .CompanyId
                                                                                                      + "','" + aItem
                                                                                                          .ItemName
                                                                                                      + "','" + aItem
                                                                                                          .ReOrder
                                                                                                      + "','"+aItem.AvaiableQuantity+"')";
            SqlCommand cmd = new SqlCommand(querry, connection);
            int rowCount = cmd.ExecuteNonQuery();
            connection.Close();
            return rowCount;
        }
        public bool IsExist(string itemName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "SELECT * FROM Item_tbl  WHERE Item_Name ='" + itemName + "'";
            SqlCommand cmd = new SqlCommand(querry, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            return false;
        }

        public List<Item> GetAllItemsByCompanyId(int companyId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "SELECT * FROM Item_tbl where Company_Id='"+companyId+"'";
            SqlCommand cmd = new SqlCommand(querry, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Item> items = new List<Item>();
            while (reader.Read())
            {
                Item aItem = new Item();
                aItem.ItemId = (int)reader["Item_Id"];
                aItem.ItemName = reader["Item_Name"].ToString();
                items.Add(aItem);
            }
            reader.Close();
            connection.Close();
            return items;
        }

       public Item GetReOrderAndQuantiti(int itemId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "SELECT Reorder,Available_Quantity FROM Item_tbl where Item_Id='" + itemId + "'";
            SqlCommand cmd = new SqlCommand(querry, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            Item aItem = null;
            if (reader.HasRows)
            {
                reader.Read();
                aItem = new Item();
                aItem.ReOrder = (int)reader["Reorder"];
                aItem.AvaiableQuantity = (int)reader["Available_Quantity"];
            }
            return aItem;
        }

        public int UpdateAvailableQuantity(int stockIn, int itemId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string querry = "UPDATE Item_tbl SET Available_Quantity=(select sum(Available_Quantity+'" + stockIn + "')from Item_tbl where Item_Id = '"+itemId+"') WHERE Item_Id='"+itemId+"'";
            SqlCommand cmd = new SqlCommand(querry, connection);
            int rowCount = cmd.ExecuteNonQuery();
            connection.Close();
            return rowCount;
        }
    }
}