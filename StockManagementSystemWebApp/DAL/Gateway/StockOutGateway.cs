using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Models;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class StockOutGateway : BaseGateway 
    {

        public int Save(Cart aCart)
        {
            string query = "INSERT INTO Cart(ItemID,ItemName,CompanyID,CompanyName,Quantity) VALUES (@itemId,@itemName,@companyID,@companyName,@quantity)";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@itemId", aCart.ItemId);
            Command.Parameters.AddWithValue("@itemName",aCart.ItemName);
            Command.Parameters.AddWithValue("@companyId",aCart.CompanyId);
            Command.Parameters.AddWithValue("@companyName",aCart.CompanyName);
            Command.Parameters.AddWithValue("@quantity",aCart.Quantity);

            Connection.Open();
            int rawAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rawAffect;

        }




        public List<Cart> GetAllCartItems()
        {
            string query = "SELECT * FROM Cart";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Cart> cartItemList = new List<Cart>();
            while (Reader.Read())
            {
                Cart aCart = new Cart();
                aCart.ItemId = Convert.ToInt32(Reader["ItemID"]);
                aCart.ItemName = Convert.ToString(Reader["ItemName"]);
                aCart.CompanyId = Convert.ToInt32(Reader["CompanyID"]);
                aCart.CompanyName = Convert.ToString(Reader["CompanyName"]);
                aCart.Quantity = Convert.ToInt32(Reader["Quantity"]);

                cartItemList.Add(aCart);
            }

            Connection.Close();

            return cartItemList;

        }


        public bool ItemExistinCart(int itemId)
        {
            string query = "SELECT * FROM Cart WHERE ItemID=@itemId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@itemId", itemId);

            Connection.Open();
            Reader = Command.ExecuteReader();
            bool exist = Reader.HasRows;
            Connection.Close();

            return exist;
        }



        public Cart GetItemFromCartById(int itemId)
        {
            string query = "SELECT * FROM Cart WHERE ItemID=@itemId ";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@itemId", itemId);
            Connection.Open();
            Reader = Command.ExecuteReader();

            Reader.Read();
            
                Cart aCart = new Cart();
                aCart.ItemId = Convert.ToInt32(Reader["ItemID"]);
                aCart.ItemName = Convert.ToString(Reader["ItemName"]);
                aCart.CompanyId = Convert.ToInt32(Reader["CompanyID"]);
                aCart.CompanyName = Convert.ToString(Reader["CompanyName"]);
                aCart.Quantity = Convert.ToInt32(Reader["Quantity"]);

            Connection.Close();

            return aCart;

        }



        public int UpdateItemQuantityInCart(int newQuantity, int itemId)
        {
            string query = "UPDATE Cart SET Quantity = @newQuantity WHERE ItemID=@itemId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@newQuantity", newQuantity);
            Command.Parameters.AddWithValue("@itemId", itemId);

            Connection.Open();
            int rawAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rawAffect;

        }


        public bool CartExist()
        {
            string query = "SELECT*FROM Cart";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            bool isExist = Reader.HasRows;
            Connection.Close();
            return isExist;
        }



        public int SaveInStockOut(StockOut aStockOut)
        {
            string query = "INSERT INTO StockOut(CompanyName,ItemName,Quantity,Status,Date) VALUES (@companyName,@itemName,@quantity,@status,@date)";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@companyName", aStockOut.CompanyName);
            Command.Parameters.AddWithValue("@itemName", aStockOut.ItemName);
            Command.Parameters.AddWithValue("@quantity", aStockOut.Quantity);
            Command.Parameters.AddWithValue("@status", aStockOut.Status);
            Command.Parameters.AddWithValue("@date", aStockOut.Date);
            

            Connection.Open();
            int rawAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rawAffect;

        }


        public void QuantityUpdate(Item aItem)
        {
            string query = "UPDATE Item SET AvailableQuantity = AvailableQuantity-@quantity WHERE ItemID=@itemId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@quantity", aItem.AvailableQuantity);
            Command.Parameters.AddWithValue("@itemId", aItem.Id);

            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();

        }


        public void DeleteCart()
        {
            string query = "DELETE FROM Cart";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }



    }
}