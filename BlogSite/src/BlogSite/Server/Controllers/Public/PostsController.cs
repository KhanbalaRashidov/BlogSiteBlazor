﻿using BlogSite.Server.Controllers.Base;
using BlogSite.Service.Abstract;
using BlogSite.Shared.Dtos;
using BlogSite.Shared.Extensions;
using BlogSite.Shared.Features.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BlogSite.Server.Controllers.Public
{
    public class PostsController : ApiControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        /// <summary>
        ///  Get all posts
        /// </summary>
        /// <param name="postParameters"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PostDTO>> Posts([FromQuery] PostParameters postParameters)
        {
            var posts = await _postService.GetPosts(postParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(posts.Paging));
            return Ok(posts);
        }

        /// <summary>
        /// Get posts by their tag
        /// </summary>
        /// <param name="postParameters"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public async Task<ActionResult<PostDTO>> PostsByTag([FromQuery] PostParameters postParameters,
                                                                                string name)
        {
            var posts = await _postService.GetPostsByTag(postParameters, name);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(posts.Paging));
            return Ok(posts);

        }

        /// <summary>
        /// Get post by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="slug"></param>
        /// <returns></returns>
        [HttpGet(Id + "/{slug}")]
        public async Task<ActionResult<PostDTO>> Post(int id, string slug)
        {
            var post = await _postService.GetPostById(id);
            // Get the actual friendly version of the title.
            var friendlyUrl = StringExtension.FriendlyUrl(post.Title);
            if (slug != friendlyUrl) throw new InvalidOperationException($"Slug format not matched. slug={slug}");

            return Ok(post);
        }

        /// <summary>
        /// Add post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Policy = Policies.IsAdmin)]
        public async Task<ActionResult<AddPostDTO>> AddPost(AddPostDTO post)
        {
            await _postService.AddPost(post);
            return Ok();
        }

        /// <summary>
        /// Edit post
        /// </summary>
        /// <param name="id"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpPut(Id)]
        //[Authorize(Policy = Policies.IsAdmin)]
        public async Task<ActionResult<EditPostDTO>> EditPost(int id, EditPostDTO post)
        {
            if (id != post.Id) return BadRequest();

            try
            {
                await _postService.UpdatePost(post);
            }
            catch (DbUpdateConcurrencyException) when (!_postService.PostItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete(Id)]
        //[Authorize(Policy = Policies.IsAdmin)]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _postService.DeletePost(id);
            return NoContent();
        }
    }
}
