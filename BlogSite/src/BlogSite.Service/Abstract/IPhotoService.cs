using BlogSite.Shared.Features.File;

namespace BlogSite.Service.Abstract
{
    public interface IPhotoService
    {
        string AddImagePost(UploadModel file);
        string AddAvatar(UploadModel file);
    }
}
