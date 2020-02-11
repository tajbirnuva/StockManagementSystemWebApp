using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystemWebApp.DAL.Models;

namespace StockManagementSystemWebApp.DAL.Gateway
{
    public class LoginGateway : BaseGateway
    {

        //public User GetUser(string username, string password)
        //{
        //    string query = "SELECT * FROM Administrator WHERE Username=@username AND Password=@password";
        //    Command = new SqlCommand(query, Connection);
        //    Command.Parameters.AddWithValue("@username", username);
        //    Command.Parameters.AddWithValue("@password", password);
        //    Connection.Open();
        //    Reader = Command.ExecuteReader();

        //    Reader.Read();
        //        User aUser=null;
        //    if (Reader.HasRows)
        //    {
        //        aUser=new User();
        //        aUser.Username = Reader["Username"].ToString();
        //        aUser.Password = Reader["Password"].ToString();
                

        //    }
            
                
            

        //    Connection.Close();

        //    return aUser;
        //}


    }
}