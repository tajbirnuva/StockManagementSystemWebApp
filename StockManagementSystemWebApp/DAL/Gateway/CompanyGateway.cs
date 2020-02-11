using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementSystemWebApp.DAL.Models;

namespace StockManagementSystemWebApp.DAL.Gateway
{


    public class CompanyGateway : BaseGateway
    {
       
        public int Save(Company aCompany)
        {
            
            string query = "INSERT INTO Company(Company) VALUES (@companyName)";
            
            Command=new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@companyName", aCompany.CompanyName);

            Connection.Open();
            int rowAffect=Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffect;

        }

        public bool CompanyExist(string companyName)
        {
            string query = "SELECT * FROM Company WHERE Company=@CompanyName";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@CompanyName", companyName);


            Connection.Open();
            Reader = Command.ExecuteReader();
            bool exist=Reader.HasRows;
            Connection.Close();

            return exist;
        }



        public List<Company> GetAllCompanies()
        {
            string query = "SELECT * FROM Company ORDER BY Company";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Company> CompanyList = new List<Company>();
            while (Reader.Read())
            {
                Company aCompany = new Company();
                aCompany.Id = Convert.ToInt32(Reader["CompanyID"]);
                aCompany.CompanyName = Convert.ToString(Reader["Company"]);
                CompanyList.Add(aCompany);
            }

            Connection.Close();

            return CompanyList;

        } 
    }
}