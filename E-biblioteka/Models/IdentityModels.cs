using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using E_biblioteka.Models.Forum;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace E_biblioteka.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(64, ErrorMessage = "Name must not exceed 64 characters!")]
        public string Name { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "Surname must not exceed 64 characters!")]
        public string Surname { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        [Display(Name = "Subscription Start Date")]
        public DateTime? SubscriptionStartDate { get; set; }

        [Display(Name = "Subscription End Date")]
        public DateTime? SubscriptionEndDate { get; set; }

        [Display(Name = "Subscription Duration in Months")]
        public int? SubscriptionDurationInMonths { get; set; }

        public bool? IsMember { get; set; }

        public ICollection<Post> Posts { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Post> Posts { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}