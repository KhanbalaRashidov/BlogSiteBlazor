using System.ComponentModel.DataAnnotations;

namespace BlogSite.Shared.Dtos
{
    public class AddPostDTO
    {
        [Required]
        [MinLength(25)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MinLength(1000)]
        [MaxLength(10000)]
        public string Content { get; set; }

        /// <summary>
        /// Response image path
        /// </summary>
        public string Image { get; set; }

        [Required]
        public string AddTags { get; set; }
    }
}
