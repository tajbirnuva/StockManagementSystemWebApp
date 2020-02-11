using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Models;

namespace StockManagementSystemWebApp.BLL
{
    public class StockOutManager
    {
        StockOutGateway aStockOutGateway=new StockOutGateway();
        private DateTime currentDate = DateTime.Now.Date;
        public string Save(Cart aCart)
        {

            int rowAffect = aStockOutGateway.Save(aCart);
                if (rowAffect > 0)
                {
                    return "Save To Cart";
                }
                else
                {
                    return "Operation Fail";
                }
        }



        public List<Cart> GetAllCartItems()
        {
            return aStockOutGateway.GetAllCartItems();

        }


        public String ItemExistinCart(int itemId)
        {
            if (aStockOutGateway.ItemExistinCart(itemId))
            {
                return "Exist";
            }
            else
            {
                return "NotExist";
            }
        }

        public Cart GetItemFromCartById(int itemId)
        {
            return aStockOutGateway.GetItemFromCartById(itemId);
        }



        public string UpdateItemQuantityInCart(int newQuantity, int itemId)
        {
            int rowAffect = aStockOutGateway.UpdateItemQuantityInCart(newQuantity, itemId);

            if (rowAffect > 0)
            {
                return "Update";
            }
            else
            {
                return "Operation Fail";
            }
        }



        public bool CartExist()
        {
            return aStockOutGateway.CartExist();
        }




        public string SaveInStockOut(List<Cart> cartList,string status)
        {
            int rowAffect = 0;
            foreach (Cart c in cartList)
            {
                StockOut aStockOut=new StockOut();
                aStockOut.CompanyName = c.CompanyName;
                aStockOut.ItemName = c.ItemName;
                aStockOut.Quantity = c.Quantity;
                aStockOut.Status = status;
                aStockOut.Date = currentDate.ToString("yyyy-MM-dd");
               rowAffect= aStockOutGateway.SaveInStockOut(aStockOut);

               Item aItem = new Item();
               aItem.Id = c.ItemId;
               aItem.AvailableQuantity = c.Quantity;
                aStockOutGateway.QuantityUpdate(aItem);
            }
            if (rowAffect>0)
            {
                return "Save Successfull";
            }

            else
            {
                 return "Operation fail";
            }

            
        }



        public void DeleteCart()
        {
            aStockOutGateway.DeleteCart();
        }



    }
}