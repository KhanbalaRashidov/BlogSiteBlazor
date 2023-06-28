using BlogSite.Client.Utils.File;
using BlogSite.Shared.Identity.Account;
using Microsoft.AspNetCore.Components.Forms;

namespace BlogSite.Client.Utils.Models
{
    public class RegisterVM : RegisterModel
    {
        public string FileName { get; set; }

        public string File { get; set; }

        [ClientMaxFileSizeAttribute(0.5 * 1024 * 1024)]
        [FileValidation(new[] { ".png", ".jpg" })]
        public IBrowserFile Picture { get; set; }
    }
}
