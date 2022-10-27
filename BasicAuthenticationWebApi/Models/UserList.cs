using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuthenticationWebApi.Models
{
    public class UserList
    {
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            users.Add(new User()
            {
                ID = 101,
                UserName = "MaleUser",
                Password = "123456"
            });

            users.Add(new User()
            {
                ID = 102,
                UserName = "FemaleUser",
                Password = "abcdef"
            });

            return users;
        }
    }
}