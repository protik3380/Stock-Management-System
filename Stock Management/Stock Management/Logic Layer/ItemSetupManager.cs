using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Management.Logic_Layer
{
    using Stock_Management.Gate_Way;
    using Stock_Management.Models;

    public class ItemSetupManager
    {
        ItemSetupGateway aItemSetupGateway = new ItemSetupGateway();

        public bool IsExist(string itemName)
        {
            return aItemSetupGateway.IsExist(itemName);
        }

        public string SaveItem(Item aItem)
        {
            if (IsExist(aItem.ItemName))
            {
                return "Item is Already Exist.";
            }

            int rowAffected = this.aItemSetupGateway.SaveItem(aItem);
            if (rowAffected > 0)
                return "Saved";
            else
            {
                return "Failed";
            }
        }

        public string UpdateAvailableQuantity(int stockIn, int itemId)
        {
            int rowAffected = this.aItemSetupGateway.UpdateAvailableQuantity(stockIn,itemId);
            if (rowAffected > 0)
                return "Product stocked in sucessfully";
            else
            {
                return "Failed";
            }
        }

        public List<Item> GetAllItemsByCompanyId(int companyId)
        {
            return this.aItemSetupGateway.GetAllItemsByCompanyId(companyId);
        }

        public Item GetReOrderAndQuantiti(int itemId)
        {
            return this.aItemSetupGateway.GetReOrderAndQuantiti(itemId);
        }
    }
}