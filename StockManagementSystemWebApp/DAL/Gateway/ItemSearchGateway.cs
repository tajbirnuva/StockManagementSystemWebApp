using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Models.ViewModel;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class ItemSearchGateway : BaseGateway
    {
        public List<ItemViewModel> GetAllItemByCompanyIdandCategoryId(int companyId,int categoryId)
        {
            string query = "EXEC SelectAllItemByCompanyIdandCategoryId @CompanyId=@companyId,@CategoryId=@categoryId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@companyId", companyId);
            Command.Parameters.AddWithValue("@categoryid", categoryId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ItemViewModel> ItemViewModelList = new List<ItemViewModel>();
            while (Reader.Read())
            {
                ItemViewModel aItemViewModel = new ItemViewModel();

                aItemViewModel.ItemName = Reader["ItemName"].ToString();
                aItemViewModel.CompanyName = Reader["Company"].ToString();
                aItemViewModel.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                aItemViewModel.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);

                ItemViewModelList.Add(aItemViewModel);
            }

            Connection.Close();

            return ItemViewModelList;

        }








        public List<ItemViewModel> GetAllItemByCompanyId(int companyId)
        {
            string query = "EXEC SelectAllItemByCompanyId @CompanyId=@companyId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@companyId", companyId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ItemViewModel> ItemViewModelList = new List<ItemViewModel>();
            while (Reader.Read())
            {
                ItemViewModel aItemViewModel = new ItemViewModel();

                aItemViewModel.ItemName = Reader["ItemName"].ToString();
                aItemViewModel.CompanyName = Reader["Company"].ToString();
                aItemViewModel.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                aItemViewModel.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);

                ItemViewModelList.Add(aItemViewModel);
            }

            Connection.Close();

            return ItemViewModelList;

        }





        public List<ItemViewModel> GetAllItemByCategoryId(int categoryid)
        {
            string query = "EXEC SelectAllItemByCategoryId @CategoryId=@categoryid";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@categoryid", categoryid);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ItemViewModel> ItemViewModelList = new List<ItemViewModel>();
            while (Reader.Read())
            {
                ItemViewModel aItemViewModel = new ItemViewModel();

                aItemViewModel.ItemName = Reader["ItemName"].ToString();
                aItemViewModel.CompanyName = Reader["Company"].ToString();
                aItemViewModel.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                aItemViewModel.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);

                ItemViewModelList.Add(aItemViewModel);
            }

            Connection.Close();

            return ItemViewModelList;

        }














    }
}