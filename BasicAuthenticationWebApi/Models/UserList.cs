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
            // hard-coded user list
            List<User> userList = new List<User>();
            userList.Add(new User()
            {
                ID = 101,
                UserName = "ManagerUser",
                Password = "123456",
                Roles = "Manager",
                Email = "Manager@a.com"
            });
            userList.Add(new User()
            {
                ID = 102,
                UserName = "BothUser",
                Password = "abcdef",
                Roles = "Manager,Admin",
                Email = "BothUser@a.com"
            });
            userList.Add(new User()
            {
                ID = 103,
                UserName = "AdminUser",
                Password = "Password@123",
                Roles = "Admin",
                Email = "Admin@a.com"
            });
            return userList;
        }
    }
}