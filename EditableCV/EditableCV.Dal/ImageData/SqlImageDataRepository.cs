using EditableCV.Domain.Models;

namespace EditableCV.Dal.ImageData
{
    public class SqlImageDataRepository
    {
        private IResumeContext _context;

        public SqlImageDataRepository(IResumeContext context)
        {
            _context = context;
        }
        public void CreateImage(ImageModel image)
        {
            _context.Images.Add(image);
        }

        public void DeleteImage(ImageModel image)
        {
            _context.Images.Remove(image);
        }

        public IEnumerable<ImageModel> GetAllImages()
        {
            return _context.Images.ToList();
        }

        public ImageModel GetImageById(int id)
        {
            return _context.Images.FirstOrDefault(img => img.Id == id);
        }
    }
}
