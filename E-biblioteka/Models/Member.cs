using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_biblioteka.Models
{
    public class Member
    {
        public long MemberId { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String DateOfBirth { get; set; }
        public String SocialSecurityNumber { get; set; }
        public String SubscriptionStartDate { get; set; }
        public String SubscriptionEndDate { get; set; }

    }
}