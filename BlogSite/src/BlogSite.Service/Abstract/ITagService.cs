using BlogSite.Shared.Dtos;

namespace BlogSite.Service.Abstract
{
    public interface ITagService
    {
        Task<IEnumerable<TagDTO>> GetTags();
        Task AddTag(AddTagDTO tagDTO);
        Task UpdateTag(UpdateTagDTO tagDTO);
        Task<IEnumerable<TagDTO>> GetUnselectedTags(int postId);
    }
}
