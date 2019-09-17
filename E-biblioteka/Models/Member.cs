using E_biblioteka.Models.Forum;
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
        [Key]
        public long MemberId { get; set; }
        [Required]
        [StringLength(64, ErrorMessage = "Your name must not exceed 64 characters")]
        public string Name { get; set; }
        [Required]
        [StringLength(64, ErrorMessage = "Your surname must not exceed 64 characters")]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        public string DateOfBirth { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Subscription Start Date")]
        public string SubscriptionStartDate { get; set; }
        [Display(Name = "Subscription End Date")]
        public string SubscriptionEndDate { get; set; }

        public virtual ICollection<Post> Posts{ get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}