using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Models;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class SalesGateway : BaseGateway
    {

        public bool IsRowsExist(string dateFrom, string dateTo)
        {
            string query = "SELECT * FROM StockOut WHERE Status='Sold'AND Date BETWEEN @dateFrom AND @dateTo";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@dateFrom", dateFrom);
            Command.Parameters.AddWithValue("@dateTo", dateTo);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExists = Reader.HasRows;
            Connection.Close();
            return isExists;
        }




        public List<StockOut> GetSalesBetweenTwoDates(string dateFrom, string dateTo)
        {
            string query = "SELECT * FROM StockOut WHERE Status='Sold'AND Date BETWEEN @dateFrom AND @dateTo";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@dateFrom", dateFrom);
            Command.Parameters.AddWithValue("@dateTo", dateTo);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<StockOut> sales = new List<StockOut>();
            while (Reader.Read())
            {
                StockOut aStockOut=new StockOut();
                aStockOut.ItemName = Reader["ItemName"].ToString();
                aStockOut.CompanyName = Reader["CompanyName"].ToString();
                aStockOut.Quantity = Convert.ToInt32(Reader["Quantity"]);
                sales.Add(aStockOut);
            }
            Connection.Close();
            return sales;
        }





    }
}