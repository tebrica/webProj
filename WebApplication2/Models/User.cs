using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class User
    {
        public string name;
        public string password;

        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
    }
}