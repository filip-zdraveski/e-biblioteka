using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_biblioteka.Models
{
    public class Roles
    {
        public const string Administrator = "Administrator";
        public const string Employee = "Employee";
        public const string Moderator = "Moderator";
        public const string Member = "Member";

        public static List<string> ListRoles()
        {
            return new List<string> { Roles.Administrator, Roles.Employee, Roles.Moderator, Roles.Member };
        } 
    }
}