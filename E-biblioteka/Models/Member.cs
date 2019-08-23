using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_biblioteka.Models
{
    public class Member
    {
        [Display(Name = "Member Id")]
        public long MemberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name = "Date of Birth")]
        public string DateOfBirth { get; set; }
        [Display(Name = "Social Security Number")]
        public string SocialSecurityNumber { get; set; }
        [Display(Name = "Subscription Start Date")]
        public string SubscriptionStartDate { get; set; }
        [Display(Name = "Subscription End Date")]
        public string SubscriptionEndDate { get; set; }

    }
}