using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_biblioteka.Models
{
    public class Library
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public HashSet<Author> Authors { get; set; }
        public HashSet<Book> Books { get; set; }
        public HashSet<Member> Members { get; set; }
        public Dictionary<Author, HashSet<Book>> BooksByAuthor { get; set; }
        public Dictionary<Book, int> BooksInStock { get; set; }
    }
}