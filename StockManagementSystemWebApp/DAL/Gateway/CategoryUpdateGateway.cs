using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Models;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class CategoryUpdateGateway : BaseGateway
    {
        public Category GetCategoryById(int id)
        {
            string query = "SELECT * FROM Category WHERE CategoryID=@id";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@id", id);


            Connection.Open();
            Reader = Command.ExecuteReader();

            Reader.Read();
            Category aCategory = null;
            if (Reader.HasRows)
            {
                aCategory = new Category();
                aCategory.Id = Convert.ToInt32(Reader["CategoryID"]);
                aCategory.CategoryName = Convert.ToString(Reader["Category"]);
            }
            Connection.Close();
            return aCategory;
        }




        public int CategoryUpdateById(string newCategoryName,int id)
        {
            string query = "UPDATE Category SET Category=@category WHERE CategoryID=@id";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@Category", newCategoryName);
            Command.Parameters.AddWithValue("@id", id);
            Connection.Open();
            int rawAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rawAffect;
        }

    }
}