using BlogSite.Shared.Features.File;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace BlogSite.Client.Utils.File
{
    public class BrowserFileModel
    {
        public string FileName { get; set; }

        [Required(ErrorMessage = "Image is empty!")]
        [MaxFileSize(0.5 * 1024 * 1024)]
        [FileValidation(new[] { ".png", ".jpg" })]
        public IBrowserFile Picture { get; set; }
    }
}
