using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuthenticationWebApi.Models
{
    public class ValidateUser
    {
        //This method is used to check the user credentials
        public UserMaster CheckUserCredentials(string username, string password)
        {
            // SECURIRT_DBEntities it is your context class
            using (var context = new SECURIRT_DBEntities())
            {
                return context.UserMasters.FirstOrDefault(user =>
                user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
                && user.UserPassword == password);
            }
        }
    }
}