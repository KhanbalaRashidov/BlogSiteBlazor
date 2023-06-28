using BlogSite.Shared.Features.Pagination;

namespace BlogSite.Components.Pagination
{
    public class PagingResponse<T> where T : class
    {
        public List<T> Items { get; set; }
        public Paging Paging { get; set; }
    }
}
