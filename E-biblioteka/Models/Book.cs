using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_biblioteka.Models
{
    public class Book
    {
        [Display(Name = "Book Id")]
        public long BookId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public int Year { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        public Author Author { get; set; }
    }
}