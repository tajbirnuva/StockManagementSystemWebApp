using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Models;

namespace StockManagementSystemWebApp.BLL
{
    public class CategoryUpdateManager
    {
        CategoryUpdateGateway aCategoryUpdateGateway=new CategoryUpdateGateway();
        public Category GetCategoryById(int id)
        {
            return aCategoryUpdateGateway.GetCategoryById(id);
        }


        public string CategoryUpdateById(string newCategoryName, int id)
        {
            int rawAffect = aCategoryUpdateGateway.CategoryUpdateById(newCategoryName, id);
            if (rawAffect>0)
            {
                return "Save";
            }
            else
            {
                return "Fail";
            }
        }




    }
}