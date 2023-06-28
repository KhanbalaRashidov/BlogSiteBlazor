using BlogSite.Client.Utils.File;
using BlogSite.Shared.Dtos;
using BlogSite.Shared.Features.File;
using Microsoft.AspNetCore.Components.Forms;

namespace BlogSite.Client.Utils.Models
{
    public class AddPostVM : AddPostDTO
    {
        public string FileName { get; set; }

        [MaxFileSize(0.5 * 1024 * 1024)]
        [FileValidation(new[] { ".png", ".jpg" })]
        public IBrowserFile Picture { get; set; }
    }

    public class EditPostVM : EditPostDTO
    {
        public string FileName { get; set; }

        [MaxFileSize(0.5 * 1024 * 1024)]
        [FileValidation(new[] { ".png", ".jpg" })]
        public IBrowserFile Picture { get; set; }
    }
}
