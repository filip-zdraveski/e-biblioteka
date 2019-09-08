using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_biblioteka.Models
{
    public class AddToRoleModel
    {
        public string Email { get; set; }
        public string SelectedRole { get; set; }
        public List<string> Roles { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public AddToRoleModel()
        {
            Roles = new List<string>();
        }
    }
}