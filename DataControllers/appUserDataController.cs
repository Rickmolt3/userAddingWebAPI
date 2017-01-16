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

namespace userAddingWebAPI.DataControllers
{
    public class appUserDataController : ApiController
    {
        public static SqlDatabase db;

        public appUserDataController()
        {
            if (db == null)
            {
                db = new SqlDatabase(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
            }
        }

        public List<appUserModel> getAllUsers()
        {
            DbCommand GetUsers = db.GetStoredProcCommand("spGetAllUsers");

            // Executes stored proc to return values into a DataSet.
            DataSet ds = db.ExecuteDataSet(GetUsers);

            var users = (from drRow in ds.Tables[0].AsEnumerable()
                          select new appUserModel()
                          {

                              appUserEmail = drRow.Field<string>("appUserEmail"),
                              appUserFirstName = drRow.Field<string>("appUserFirstName"),
                              appUserLastName = drRow.Field<string>("appUserLastName"),
                              appUserAge= drRow.Field<int>("appUserAge")

                          }).ToList();

            return users;
        }

        //List<appUserModel> instead of void below
        public void createUser(string userEmail,string userPassword,string userFirstName,string userLastName,int userAge)
        {
            DbCommand makeUser = db.GetStoredProcCommand("spAddUser");

            db.AddInParameter(makeUser, "@appUserEmail", DbType.String, userEmail);
            db.AddInParameter(makeUser, "@appUserPassword", DbType.String, userPassword);
            db.AddInParameter(makeUser, "@appUserFirstName", DbType.String, userFirstName);
            db.AddInParameter(makeUser, "@appUserLastName", DbType.String, userLastName);
            db.AddInParameter(makeUser, "@appUserAge", DbType.Int32, userAge);

            // Executes stored proc to return values into a DataSet.
            DataSet ds = db.ExecuteDataSet(makeUser);

            //var users = (from drRow in ds.Tables[0].AsEnumerable()
            //             select new appUserModel()
            //             {

            //                 appUserEmail = userEmail,
            //                 appUserPassword = userPassword,
            //                 appUserFirstName = userFirstName,
            //                 appUserLastName = userLastName,
            //                 appUserAge = userAge

            //             }).ToList();

            //return users;
        }
        
    }
}
