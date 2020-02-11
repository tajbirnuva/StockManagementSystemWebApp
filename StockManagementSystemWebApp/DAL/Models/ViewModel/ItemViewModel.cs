using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemWebApp.DAL.Models.ViewModel
{
    public class ItemViewModel
    {
        
        public string ItemName { get; set; }
        public string CompanyName { get; set; }
        public int AvailableQuantity { get; set; }
        public int ReorderLevel { get; set; }

    }
}