using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Management.Models
{
    [Serializable]
    public class Inventory
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int StockOut { get; set; }

        //public string quantityType { get; set; }

        public int CompanyId { set; get; }
        public string CompanyName { set; get; }     
        public int availableQuantity { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime date { get; set; }
    }
}