using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Gateway;
using StockManagementSystemWebApp.DAL.Models;

namespace StockManagementSystemWebApp.BLL
{
    
    public class CompanyManager
    {
        CompanyGateway gateway=new CompanyGateway();
        public string Save(Company aCompany)
        {
            if (gateway.CompanyExist(aCompany.CompanyName))
            {
                return "Already Exist";
            }

            else
            {
                int rowAffect = gateway.Save(aCompany);

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


        public List<Company> GetAllCompanies()
        {
            return gateway.GetAllCompanies();

        }


    }
}