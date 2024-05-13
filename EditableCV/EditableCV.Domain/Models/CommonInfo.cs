using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EditableCV.Domain.Models
{
    public record CommonInfo
    {
        public CommonInfo() { }
        public CommonInfo(CommonInfo info)
        {
            Id = info.Id;
            FirstName = info.FirstName;
            LastName = info.LastName;
            PatronymicName = info.PatronymicName;
            DateOfBirth = info.DateOfBirth;
            Photo = info.Photo;
        }
        [Key]
        public int Id { get; private set; }
        [Required]
        public string FirstName { get; private set; }
        [Required]
        public string LastName { get; private set; }
        public string PatronymicName { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        [ForeignKey("FileId")]
        public FileModel? Photo { get; private set; }

        public void SetPhoto(FileModel? photo)
        {
            Photo = photo;
        }
    }
}
