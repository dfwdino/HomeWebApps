using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeApps.Models
{
    public class UserViewModel : User
    {
        public UserViewModel() {
          
        }

        public string UsersRoles = string.Empty;

        public bool IsAdmin { get; set; } = false;
        //public string UsersSchema { get; set; } = null;
    }
}