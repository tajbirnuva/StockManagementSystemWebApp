using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Models;

namespace StockManagementSystemWebApp.BLL
{
    public class SalesManager
    {
        SalesGateway aSalesGateway=new SalesGateway();

        public List<StockOut> GetSalesBetweenTwoDates(string dateFrom, string dateTo)
        {
                return aSalesGateway.GetSalesBetweenTwoDates(dateFrom, dateTo);   
        }

        public bool IsRowsExist(string dateFrom, string dateTo)
        {
            return aSalesGateway.IsRowsExist(dateFrom, dateTo);
        }

    }
}