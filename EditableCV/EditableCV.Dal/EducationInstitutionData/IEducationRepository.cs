using EditableCV.Domain.Models;

namespace EditableCV.Dal.EducationInstitutionData
{
    public interface IEducationRepository : IRepository
    {
        Task CreateInstitutionAsync(EducationalInstitution institution, CancellationToken cancellationToken);
        Task DeleteInstitutionAsync(int id, CancellationToken cancellationToken);
        Task<IList<EducationalInstitution>> GetAllInstitutionsAsync(CancellationToken cancellationToken);
        Task<EducationalInstitution?> GetInstitutionByIdAsync(int id, CancellationToken cancellationToken);
    }
}
