using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Models;

namespace StockManagementSystemWebApp.BLL
{
    public class CategoryManager
    {
        CategoryGateway aCategoryGateway=new CategoryGateway();
        public string Save(Category aCategory)
        {
            if (aCategoryGateway.CategoryExist(aCategory.CategoryName))
            {
                return "Already Exist";
            }
            else
            {
                int rowAffect = aCategoryGateway.Save(aCategory);
                if (rowAffect > 0)
                {
                    return "Save Successful";
                }
                else
                {
                    return "Operation Fail";
                }
            }

            
        }


        public List<Category> GetAllCategories()
        {
            return aCategoryGateway.GetAllCategories();

        }


       


    }
}