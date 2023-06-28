using System.Collections.ObjectModel;

namespace BlogSite.Shared.Dtos
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public int? CourseId { get; set; }
        public int? ReplyId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public Collection<ReplyDTO> Replies { get; set; }
    }
}
