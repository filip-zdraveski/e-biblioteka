using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_biblioteka.Models
{
    public class Author
    {
        public long AuthorId { get; set; }
        public String Name { get; set; }
        public String DateOfBirth { get; set; }
        
        public String DateOfDeath { get; set; }
    }
}