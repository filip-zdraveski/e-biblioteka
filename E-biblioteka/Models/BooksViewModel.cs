using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_biblioteka.Models
{
    public class BooksViewModel
    {
        public IPagedList<Book> Books { get; set; }
        public List<string> Genres { get; set; }
        public string BookGenre { get; set; }
    }
}