using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_biblioteka.Models.Forum
{
    public class NewPost
    {
        public List<Book> Books { get; set; }
        public string UserId { get; set; }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public NewPost()
        {
            Books = new List<Book>();
        }
    }
}