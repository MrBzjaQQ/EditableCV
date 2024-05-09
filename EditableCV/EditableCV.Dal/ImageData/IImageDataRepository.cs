using EditableCV.Domain.Models;

namespace EditableCV.Dal.ImageData
{
    interface IImageDataRepository : IRepository
    {
        void CreateImage(ImageModel image);
        void DeleteImage(ImageModel image);
        void UpdateImage(ImageModel image);
        ImageModel GetImageById(int id);
        IEnumerable<ImageModel> GetAllImages();
    }
}
