using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using userAddingWebAPI.Models;
using userAddingWebAPI.DataControllers;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Web.Configuration;


namespace userAddingWebAPI.Controllers
{
    public class appUserController : ApiController
    {
        //add a default connection string
        public static SqlDatabase db;

        public appUserController()
        {
            if (db == null)
            {
                db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            }
        }
        
        //this method takes all the users from the database and displays them in the xml format
        // /api/appUser
        [HttpGet]
        public IEnumerable<appUserModel> Get()
        {
            //refernce data controller that gets all users here
            appUserDataController audc = new appUserDataController();

            List<appUserModel> AllUsers = audc.getAllUsers();

            
            return AllUsers; 
        }

        //this method takes the parameters from the http url post and sends it the the data controller which sends it to the database and stores it
        public void Get(string userEmail, string userPassword, string userFirstName, string userLastName, int userAge)
        {
            appUserDataController audc = new appUserDataController();

            //List<appUserModel> = set equal to code below

            audc.createUser(userEmail, userPassword, userFirstName, userLastName, userAge);

        }

    }
}
