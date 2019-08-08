using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_biblioteka.Models
{
    public class Member
    {
        public long MemberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string SubscriptionStartDate { get; set; }
        public string SubscriptionEndDate { get; set; }

    }
}