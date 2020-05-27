using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRole1.Models
{
    public class User
    {
        public string Username { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

    }

    public enum EnumUserType
    {
        Guest = 0,
        Admin = 1,
        Registered = 2
    }
}