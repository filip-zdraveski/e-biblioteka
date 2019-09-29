using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_biblioteka.Models
{
    public class AddToRoleModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Select Role")]
        public string SelectedRole { get; set; }
        public List<string> Roles { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public AddToRoleModel()
        {
            Roles = new List<string>();
        }
    }
}