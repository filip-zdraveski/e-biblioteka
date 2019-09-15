using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_biblioteka.Models
{
    public class Request
    {
        [Display(Name = "Request ID")]
        [Key]
        public long RequestId { get; set; }
        [Required]
        [StringLength(128, ErrorMessage = "Book Title must not exceed 128 characters!")]
        public string Title { get; set; }
        [Required]
        [StringLength(64, ErrorMessage = "Author's Name must not exceed 64 characters!")]
        [Display(Name = "Author's Name")]
        public string AuthorsName { get; set; }
        public string Comment { get; set; }
    }
}