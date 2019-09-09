using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace E_biblioteka.Models
{
    public class Author
    {
        [Display(Name = "Author Id")]
        public long AuthorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}