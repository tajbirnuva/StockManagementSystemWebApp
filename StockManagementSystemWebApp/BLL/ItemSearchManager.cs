using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Models.ViewModel;

namespace StockManagementSystemWebApp.BLL
{
    public class ItemSearchManager
    {
        ItemSearchGateway aItemSearchGateway=new ItemSearchGateway();

        public List<ItemViewModel> GetAllItemByCompanyIdandCategoryId(int companyId, int categoryId)
        {
            return aItemSearchGateway.GetAllItemByCompanyIdandCategoryId(companyId,categoryId);
        }



        public List<ItemViewModel> GetAllItemByCompanyId(int companyId)
        {
            return aItemSearchGateway.GetAllItemByCompanyId(companyId);
        }



        public List<ItemViewModel> GetAllItemByCategoryId(int categoryid)
        {
            return aItemSearchGateway.GetAllItemByCategoryId(categoryid);
        }




        



    }
}