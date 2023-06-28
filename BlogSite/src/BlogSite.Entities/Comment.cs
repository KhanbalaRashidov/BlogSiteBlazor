using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Entities
{
    public class Comment:BaseEntity
    {
        public int? ReplyId { get; set; }
        public int? PostId { get; set; }
        public int UserId { get; set; }

        [StringLength(25)]
        public string UserName { get; set; }

        [Required]
        [StringLength(3000)]
        public string Content { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; }

        //navigation 

        [ForeignKey("PostId")]
        public Post Post { get; set; }

        [ForeignKey("ReplyId")]
        public Comment ParentComment { get; set; }
        public ICollection<Comment> Replies { get; set; }
      
    }
}
