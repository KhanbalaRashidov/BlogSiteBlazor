using BlogSite.Client.Pagination;
using BlogSite.Shared.Dtos;
using BlogSite.Shared.Features.Pagination;

namespace BlogSite.Client.Infrastructure.Services.Abstracts
{
    public interface IPostService
    {
        Task<PagingResponse<PostDTO>> GetPostsByTag(PostParameters postParameters, string name);
        Task<PagingResponse<PostDTO>> GetPosts(PostParameters postParameters, string name);
        Task<PostDTO> GetPostsByById(int id, string slug);
    }
}
