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
        public long RequestId { get; set; }
        [Required]
        [StringLength(128)]
        public string Title { get; set; }
        [Required]
        [StringLength(128)]
        [Display(Name = "Author's Name")]
        public string AuthorsName { get; set; }
        public string Comment { get; set; }
    }
}