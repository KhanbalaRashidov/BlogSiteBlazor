using BlogSite.Server.Controllers.Base;
using BlogSite.Service.Abstract;
using BlogSite.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Server.Controllers.Public
{
    [ApiController]
    [Route("api/comments")]
    public class CommentsController : ApiControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// Get comments by postId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(Id)]
        public async Task<ActionResult<CommentDTO>> CommentsByPost(int id)
        {
            var postComments = await _commentService.GetCommentsByPostId(id);
            return Ok(postComments);
        }

        /// <summary>
        /// Get comment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getById/" + Id)]
        public async Task<ActionResult<CommentDTO>> Comment(int id)
        {
            var comment = await _commentService.GetCommentById(id);
            return Ok(comment);
        }

        /// <summary>
        /// Add comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<AddCommentDTO>> AddComment(AddCommentDTO comment)
        {
            await _commentService.AddComment(comment);

            return Ok();
        }

        /// <summary>
        /// Add reply with parent comment id
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPost("{parentId}")]
        public async Task<ActionResult<AddReplyDTO>> AddReply(int parentId, AddReplyDTO comment)
        {
            await _commentService.AddReply(comment, parentId);

            return Ok();
        }

        /// <summary>
        /// Edit comment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPut(Id)]
        //[Authorize(Policy = Policies.IsAdmin)]
        public async Task<ActionResult<EditCommentDTO>> EditComment(int id, EditCommentDTO comment)
        {
            if (id != comment.Id) return BadRequest();

            try
            {
                await _commentService.UpdateComment(id, comment);
            }
            catch (DbUpdateConcurrencyException) when (!_commentService.CommentItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete(Id)]
        //[Authorize(Policy = Policies.IsAdmin)]
        public async Task<ActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteComment(id);
            return NoContent();
        }
    }
}
