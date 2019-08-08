using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_biblioteka.Models
{
    public class Book
    {
        public long BookId { get; set; }
        public String Name { get; set; }
        public String Author { get; set; }
        public String Genre { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }
        public String Description { get; set; }
        public String ImageUrl { get; set; }
        public bool IsAvailable { get; set; }
    }
}