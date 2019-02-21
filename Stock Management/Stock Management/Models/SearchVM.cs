using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Management.Models
{
    public class SearchVM
    {
        public int  ItemId { get; set; }
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }


        public string ItemName { get; set; }
        public string CompanyName { get; set; }
        public string CategoryName { get; set; }

        public int AvailableQuantity { get; set; }
        public int ReOrder { get; set; }
    }
}