using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemWebApp.DAL.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int ReorderLevel { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public int AvailableQuantity { get; set; }

    }
}