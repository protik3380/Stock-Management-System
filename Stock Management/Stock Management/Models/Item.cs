using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Management.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        public int CategoryId { get; set; }

        public int CompanyId { get; set; }

        public string ItemName { get; set; }

        public int ReOrder { get; set; }

        public int AvaiableQuantity { get; set; }
    }
}