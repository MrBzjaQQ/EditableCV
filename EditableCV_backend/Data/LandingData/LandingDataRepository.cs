using EditableCV_backend.Models;
using System.Linq;

namespace EditableCV_backend.Data.LandingData
{
    public class LandingDataRepository : ILandingDataRepository
  {
    public LandingDataRepository(ResumeContext context)
    {
      _context = context;
    }
    public LandingDataModel GetLandingData()
    {
      return new LandingDataModel()
      {
        CommonInfo = _context.CommonInfos.FirstOrDefault(),
        ContactInfo = _context.ContactInfos.FirstOrDefault(),
        Education = _context.EducationalInstitutions.ToList(),
        Skills = _context.Skills.ToList(),
        WorkPlaces = _context.WorkPlaces.ToList(),
      };
    }

    private readonly ResumeContext _context;
  }
}
