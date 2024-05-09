using System.ComponentModel.DataAnnotations;

namespace EditableCV.Domain.Models
{
    public record ContactInfo
    {
        public ContactInfo() { }
        public ContactInfo(ContactInfo info)
        {
            Id = info.Id;
            Phone = info.Phone;
            VK = info.VK;
            Skype = info.Skype;
            Instagram = info.Instagram;
            YouTube = info.YouTube;
            LinkedIn = info.LinkedIn;
            Facebook = info.Facebook;
        }
        [Key]
        public int Id { get; init; }
        public string? Phone { get; init; }
        public string? VK { get; init; }
        public string? Skype { get; init; }
        public string? Instagram { get; init; }
        public string? YouTube { get; init; }
        public string? LinkedIn { get; init; }
        public string? Facebook { get; init; }
    }
}
