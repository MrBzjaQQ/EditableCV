using System.ComponentModel.DataAnnotations;

namespace EditableCV.Services.WorkPlaceDto
{
    public class WorkPlaceUpdateDto
  {
    [Required]
    public string CompanyName { get; set; }
    [Required]
    public string Position { get; set; }
    public string Experience { get; set; }
    [Required]
    public DateTime StartWorkingDate { get; set; }
    public DateTime? EndWorkingDate { get; set; }
  }
}
