using System.Collections.Generic;

namespace EditableCV_backend.Models
{
    public class LandingDataModel
  {
    public CommonInfo CommonInfo { get; set; }
    public ContactInfo ContactInfo { get; set; }
    public IEnumerable<WorkPlace> WorkPlaces { get; set; }
    public IEnumerable<EducationalInstitution> Education { get; set; }
    public IEnumerable<Skill> Skills { get; set; }
  }
}
