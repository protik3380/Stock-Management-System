using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Management.Logic_Layer
{
    using Stock_Management.Gate_Way;
    using Stock_Management.Models;

    public class InventoryManager
    {
        
         InventoryGateway aInventoryGateway = new InventoryGateway();

        public bool IsExist(string companyName,string itemName)
        {
            return this.aInventoryGateway.IsExist(companyName, itemName);
        }
        public bool IsExistForReport(string companyName, string itemName,string type)
        {
            return this.aInventoryGateway.IsExistForReport(companyName, itemName,type);
        }
        public String SaveStockOut(Inventory aInventory)
        {
            if (IsExist(aInventory.CompanyName,aInventory.ItemName))
            {
               int rowCount= aInventoryGateway.UpdateQuantity(aInventory.CompanyName,aInventory.ItemName,aInventory.StockOut);
               if (rowCount > 0)
                {
                    return "Update Quantity";
                }
                else
                {
                    return "Failed";
                }
            }
            int row = this.aInventoryGateway.SaveStockOut(aInventory);
            if (row > 0)
            {
                return "Add to gridView";
            }
            else
            {
                return "Failed";
            }
        }
        public List<Inventory> GetReport()
        {
            return this.aInventoryGateway.GetReport();
        }
        public void SaveStockOutQuantity(Inventory aInventory,string type)
        {

            if (IsExistForReport(aInventory.CompanyName, aInventory.ItemName, type))
            {
                aInventoryGateway.UpdateQuantityForReport(aInventory,type);
            }
            else
            {
                this.aInventoryGateway.SaveStockOutQuantity(aInventory, type);
            }
           
            
        }

        public void DeleteStockOutTable()
        {
            this.aInventoryGateway.DeleteStockOutTable();
        }
    }
}