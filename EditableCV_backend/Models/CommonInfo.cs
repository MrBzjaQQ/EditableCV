using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EditableCV_backend.Models
{
    public class CommonInfo
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
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string PatronymicName { get; set; }
    public DateTime DateOfBirth { get; set; }
    [ForeignKey("PhotoId")]
    public ImageModel Photo { get; set; }

  }
}
