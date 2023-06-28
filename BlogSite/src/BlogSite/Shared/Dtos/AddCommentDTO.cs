using System.ComponentModel.DataAnnotations;

namespace BlogSite.Shared.Dtos
{
    public class AddCommentDTO
    {
        public int? PostId { get; set; }
        public int? CourseId { get; set; }
        [StringLength(25)]
        public string UserName { get; set; }
        [Required]
        [StringLength(3000)]
        public string Content { get; set; }
    }
}
