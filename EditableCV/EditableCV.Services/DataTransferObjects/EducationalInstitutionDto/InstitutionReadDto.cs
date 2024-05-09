using System;

namespace EditableCV.Services.EducationalInstitutionDto
{
    public class InstitutionReadDto
  {
    public int Id { get; set; }
    public string Institution { get; set; }
    public string Faculty { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Progress { get; set; }
    public bool IsCurrentlyStudying
    {
      get
      {
        return DateTime.Compare(EndDate, DateTime.Now) > 0;
      }
    }
  }
}
