using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_biblioteka.Models.Forum
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(500, ErrorMessage ="Comment must not exceed 500 characters")]
        public string Content { get; set; }

    }
}