﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuthenticationWebApi.Models
{
    public class UserValidate
    {
        //This method is used to check the user credentials
        public static bool Login(string username, string password)
        {
            UserList users = new UserList();
            var UserLists = users.GetUsers();
            return UserLists.Any(user =>
                user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
                && user.Password == password);
        }
    }
}