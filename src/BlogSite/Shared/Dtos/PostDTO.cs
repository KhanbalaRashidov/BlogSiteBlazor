using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Shared.Dtos
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public int Likes { get; set; }
        public int Visitors { get; set; }
        public DateTime Created { get; set; }
        public IEnumerable<TagDTO> Tags { get; set; } = new HashSet<TagDTO>();
    }
}
