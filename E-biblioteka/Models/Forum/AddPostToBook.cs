using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_biblioteka.Models.Forum
{
    public class AddPostToBook
    {
        public Book Book { get; set; }
        public List<Post> Posts { get; set; }

        [Display(Name = "Book")]
        public long SelectedBookId { get; set; }

        [Display(Name = "Post Id")]
        public long SelectedPostId { get; set; }

        public AddPostToBook()
        {
            Book = new Book();
            Posts = new List<Post>();
        }
    }
}