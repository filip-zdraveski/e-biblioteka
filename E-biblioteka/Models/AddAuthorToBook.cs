using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_biblioteka.Models
{
    public class AddAuthorToBook
    {
        public Book Book { get; set; }
        public List<Author> Authors { get; set; }
        [Display(Name = "Book")]
        public long SelectedBookId { get; set; }
        [Display(Name = "Author Id")]
        public long SelectedAuthorId { get; set; }

        public AddAuthorToBook()
        {
            Book = new Book();
            Authors = new List<Author>();
        }
    }
}