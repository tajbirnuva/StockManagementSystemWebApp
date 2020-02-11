using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementSystemWebApp.DAL.Models;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class CategoryGateway : BaseGateway
    {
        
        public int Save(Category aCategory)
        { 
            string query = "INSERT INTO Category(Category) VALUES (@Category)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@Category", aCategory.CategoryName);

            Connection.Open();
            int rawAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rawAffect;
        }

        public bool CategoryExist(string categoryName)
        {
            string query = "SELECT * FROM Category WHERE Category=@CategoryName";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@CategoryName",categoryName);

            Connection.Open();
            Reader = Command.ExecuteReader();
            bool exist = Reader.HasRows;
            Connection.Close();

            return exist;
        }

        public List<Category> GetAllCategories()
        {
            string query = "SELECT * FROM Category ORDER BY  Category";
            Command=new SqlCommand(query,Connection);
            Connection.Open();
            Reader=Command.ExecuteReader();
            List<Category> categoryList=new List<Category>();
            while (Reader.Read())
            {
                Category aCategory=new Category();
                aCategory.Id = Convert.ToInt32(Reader["CategoryID"]);
                aCategory.CategoryName = Convert.ToString(Reader["Category"]);
                categoryList.Add(aCategory);
            }
            
            Connection.Close();

            return categoryList;

        }



       


    }
}