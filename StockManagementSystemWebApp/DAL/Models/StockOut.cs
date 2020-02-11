using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemWebApp.DAL.Models
{
    public class StockOut
    {
        public int StockOutId { get; set; }
        public string CompanyName { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }

    }
}