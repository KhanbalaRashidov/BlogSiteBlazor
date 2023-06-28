using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogSite.Shared.Features.File
{
    public class UploadModel
    {
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Upload)]
        [MaxFileSize(0.5 * 1024 * 1024)]
        [AllowedFileExtensions(new[] { ".jpg", ".png" })]
        public IFormFile Image { get; set; }
    }
}
