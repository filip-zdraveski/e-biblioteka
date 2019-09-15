using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_biblioteka.Models
{
    public class Book
    {
        [Key]
        [Display(Name = "Book Id")]
        public long BookId { get; set; }
        [Required]
        [StringLength(128, ErrorMessage = "Book Title must not exceed 128 characters!")]
        public string Name { get; set; }
        [Required]
        [StringLength(64, ErrorMessage = "Genre name must not exceed 64 characters!")]
        public string Genre { get; set; }
        [Required]
        public int Year { get; set; }
        [Range(1,5, ErrorMessage = "Rating must be between 1 and 5")]
        public double Rating { get; set; }
        public string Description { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        public Author Author { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "In Stock value must be non-negative number!")]
        [Display(Name = "In Stock")]
        public int InStock { get; set; }
    }
}