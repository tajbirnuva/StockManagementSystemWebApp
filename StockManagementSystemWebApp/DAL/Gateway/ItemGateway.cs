using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Models;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class ItemGateway : BaseGateway
    {
        public int Save(Item aItem)
        {
            string query = "INSERT INTO Item(ItemName,ReorderLevel,CategoryID,CompanyID,AvailableQuantity) VALUES (@itemName,@reorderLevel,@categoryID,@companyID,0)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@itemName", aItem.ItemName);
            Command.Parameters.AddWithValue("@reorderLevel", aItem.ReorderLevel);
            Command.Parameters.AddWithValue("@categoryID", aItem.CategoryId);
            Command.Parameters.AddWithValue("@companyID", aItem.CompanyId);

            Connection.Open();
            int rawAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rawAffect;

        }



        public bool ItemExist(Item aItem)
        {
            string query = "SELECT * FROM Item WHERE ItemName=@itemName AND CategoryID=@categoryId AND CompanyID=@companyId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@itemName",aItem.ItemName );
            Command.Parameters.AddWithValue("@categoryId", aItem.CategoryId);
            Command.Parameters.AddWithValue("@companyId", aItem.CompanyId);


            Connection.Open();
            Reader = Command.ExecuteReader();
            bool exist = Reader.HasRows;
            Connection.Close();

            return exist;
        }


        public List<Item> GetAlltems(int companyId)
        {
            string query = "SELECT * FROM Item WHERE CompanyID=@companyId ORDER BY ItemName";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@companyId", companyId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Item> itemList = new List<Item>();
            while (Reader.Read())
            {
                Item aItem = new Item();
                aItem.Id = Convert.ToInt32(Reader["ItemID"]);
                aItem.ItemName = Convert.ToString(Reader["ItemName"]);
                aItem.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                itemList.Add(aItem);
            }

            Connection.Close();

            return itemList;

        }


        public Item GetltemById(int itemId)
        {
            string query = "SELECT * FROM Item WHERE ItemID=@itemId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@itemId", itemId);
            Connection.Open();
            Reader = Command.ExecuteReader();

            Reader.Read();
            
                Item aItem = new Item();
                aItem.Id = Convert.ToInt32(Reader["ItemID"]);
                aItem.ItemName = Convert.ToString(Reader["ItemName"]);
                aItem.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                aItem.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);

            Connection.Close();

            return aItem;
        }





        public int UpdateItemQuantity(int stockIn, int itemId)
        {
            string query = "UPDATE Item SET AvailableQuantity = @stockIn WHERE ItemID=@itemId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@stockIn", stockIn);
            Command.Parameters.AddWithValue("@itemId",itemId);
  
            Connection.Open();
            int rawAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rawAffect;

        }






    }
}