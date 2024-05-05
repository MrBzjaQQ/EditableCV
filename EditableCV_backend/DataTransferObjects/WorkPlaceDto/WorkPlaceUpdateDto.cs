using System;
using System.ComponentModel.DataAnnotations;

namespace EditableCV_backend.DataTransferObjects.WorkPlaceDto
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
    [Required]
    public DateTime EndWorkingDate { get; set; }
  }
}
