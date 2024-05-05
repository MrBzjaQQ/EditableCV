using EditableCV_backend.Models;
using System.Collections.Generic;

namespace EditableCV_backend.Data.ImageData
{
    interface IImageDataRepository: IRepository
  {
    void CreateImage(ImageModel image);
    void DeleteImage(ImageModel image);
    void UpdateImage(ImageModel image);
    ImageModel GetImageById(int id);
    IEnumerable<ImageModel> GetAllImages();
  }
}
