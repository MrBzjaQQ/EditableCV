using System;
using System.ComponentModel.DataAnnotations;

namespace EditableCV_backend.DataTransferObjects.EducationalInstitutionDto
{
    public class InstitutionCreateDto
  {
    [Required]
    public string Institution { get; set; }
    public string Faculty { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    public string Progress { get; set; }
  }
}
