using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Models;

namespace StockManagementSystemWebApp.BLL
{
    public class ItemManager
    {
       ItemGateway aItemGateway=new ItemGateway();

        public string Save(Item aItem)
        {
            if (aItemGateway.ItemExist(aItem))
            {
                return "Already Exist";
            }
            else
            {
                int rowAffect = aItemGateway.Save(aItem);

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


        public List<Item> GetAlltems(int companyId)
        {
            return aItemGateway.GetAlltems(companyId);

        }


        public Item GetltemById(int itemId)
        {
            return aItemGateway.GetltemById(itemId);
        }




        public string UpdateItemQuantity(int stockIn, int itemId)
        {
                int rowAffect = aItemGateway.UpdateItemQuantity(stockIn,itemId);

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
}
