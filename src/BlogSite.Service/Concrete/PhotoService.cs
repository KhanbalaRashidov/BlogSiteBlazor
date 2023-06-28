using BlogSite.Service.Abstract;
using BlogSite.Shared.Extensions;
using BlogSite.Shared.Features.File;
using SixLabors.ImageSharp.Formats.Jpeg;
using static System.Net.Mime.MediaTypeNames;
using Image = SixLabors.ImageSharp.Image;

namespace BlogSite.Service.Concrete
{
    public class PhotoService : IPhotoService
    {
        public string AddAvatar(UploadModel file)
        {
            string extension = Path.GetExtension(file.Image.FileName);
            string newFileName = $"{Guid.NewGuid()}{extension}";

            string floderDate = DateTime.Now.ToString("yyyy/") + DateTime.Now.ToString("MM");
            var folderName = Path.Combine("wwwroot/", "images/profile/", floderDate);
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            string dbPath = folderName + "/" + newFileName;

            if (file.Image.Length > 0)
            {

                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), folderName, newFileName);
                using var image = Image.Load(file.Image.OpenReadStream());
                image.Mutate(x => x.Resize(150, 150));
                //Encode here for quality
                var encoder = new JpegEncoder()
                {
                    Quality = 30 //Use variable to set between 5-30 based on your requirements
                };

                image.Save(fullPath, encoder);
            }
            return dbPath;
        }

        public string AddImagePost(UploadModel file)
        {
            string title = StringExtension.FriendlyUrl(file.Name);
            string extension = Path.GetExtension(file.Image.FileName);
            string newFileName = $"{title}{extension}";

            string floderDate = DateTime.Now.ToString("yyyy/") + DateTime.Now.ToString("MM");
            var folderName = Path.Combine("wwwroot/", "images/posts/", floderDate);
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            string dbPath = folderName + "/" + newFileName;

            if (file.Image.Length > 0)
            {
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), folderName, newFileName);
                using var image = Image.Load(file.Image.OpenReadStream());
                image.Mutate(x => x.Resize(300, 200));
                //Encode here for quality
                var encoder = new JpegEncoder()
                {
                    Quality = 30 //Use variable to set between 5-30 based on your requirements
                };

                image.Save(fullPath, encoder);
            }
            return dbPath;
        }
    }
}
