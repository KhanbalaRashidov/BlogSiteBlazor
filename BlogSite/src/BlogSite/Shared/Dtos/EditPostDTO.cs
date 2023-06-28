using System.ComponentModel.DataAnnotations;

namespace BlogSite.Shared.Dtos
{
    public class EditPostDTO
    {
        public int Id { get; set; }

        [Required]
        [MinLength(25)]
        [MaxLength(80)]
        public string Title { get; set; }

        [Required]
        [MinLength(1000)]
        [MaxLength(10000)]
        public string Content { get; set; }

        /// <summary>
        /// Response image path
        /// </summary>
        public string Image { get; set; }

        public IEnumerable<int> AddTags { get; set; } = new List<int>();
        public IEnumerable<int> RemoveTags { get; set; } = new List<int>();
    }
}
