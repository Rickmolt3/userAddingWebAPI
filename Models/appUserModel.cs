using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace userAddingWebAPI.Models
{
    public class appUserModel
    {
        public string appUserEmail { get; set; }

        public string appUserPassword { get; set; }

        public string appUserFirstName { get; set; }

        public string appUserLastName { get; set; }

        public int appUserAge { get; set; }


    }
}