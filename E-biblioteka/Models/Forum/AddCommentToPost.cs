using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_biblioteka.Models.Forum
{
    public class AddCommentToPost
    {
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public List<Comment> Comments { get; set; }
        public Post PostInstance { get; set; }

        public AddCommentToPost()
        {
            Comments = new List<Comment>();
            PostInstance = new Post();
        }
    }
}