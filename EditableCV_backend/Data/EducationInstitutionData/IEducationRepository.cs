using EditableCV_backend.Models;
using System.Collections.Generic;

namespace EditableCV_backend.Data.EducationInstitutionData
{
    public interface IEducationRepository: IRepository
  {
    IEnumerable<EducationalInstitution> GetAllInstitutions();
    EducationalInstitution GetInstitutionById(int id);
    void CreateInstitution(EducationalInstitution institution);
    void UpdateInstitution(EducationalInstitution institution);
    void DeleteInstitution(EducationalInstitution institution);
  }
}
