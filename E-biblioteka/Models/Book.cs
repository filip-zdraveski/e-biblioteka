using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_biblioteka.Models
{
    public class Book
    {
        public long BookId { get; set; }
        public string Name { get; set; }
        public Author Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}