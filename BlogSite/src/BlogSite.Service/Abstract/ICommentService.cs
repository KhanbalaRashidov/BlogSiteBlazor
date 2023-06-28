using BlogSite.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Abstract
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDTO>> GetCommentsByPostId(int postId);
        Task<CommentDTO> GetCommentById(int id);
        Task AddComment(AddCommentDTO postDTO);
        Task AddReply(AddReplyDTO replyDTO, int parentId);
        Task UpdateComment(int id, EditCommentDTO commentDTO);
        Task DeleteComment(int id);
        bool CommentItemExists(int id);
    }
}
