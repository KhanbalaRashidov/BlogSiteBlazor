using BlogSite.Shared.Dtos;
using BlogSite.Shared.Features.Pagination;

namespace BlogSite.Service.Abstract
{
    public interface IPostService
    {
        Task<PagedList<PostDTO>> GetPosts(PostParameters postParameters);
        Task<PagedList<PostDTO>> GetPostsByTag(PostParameters postParameters, string name);
        Task<PostDTO> GetPostById(int id);
        Task AddPost(AddPostDTO postDTO);
        Task UpdatePost(EditPostDTO postDTO);
        Task DeletePost(int id);
        bool PostItemExists(int id);
    }
}
