using System.ComponentModel.DataAnnotations;

namespace EditableCV.Services.CommonInfoDto
{
    public class CommonInfoCreateDto
  {
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string PatronymicName { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }
    // public ImageModel Photo { get; set; }
  }
}
