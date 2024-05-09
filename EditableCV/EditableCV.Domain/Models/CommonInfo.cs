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
        public int Id { get; init; }
        [Required]
        public string FirstName { get; init; }
        [Required]
        public string LastName { get; init; }
        public string PatronymicName { get; init; }
        public DateTime DateOfBirth { get; init; }
        [ForeignKey("PhotoId")]
        public ImageModel? Photo { get; init; }

    }
}
