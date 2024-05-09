using EditableCV.Services.EducationalInstitutionDto;
using EditableCV.Services.Shared;

namespace EditableCV.Services.Education;
public interface IEducationService
{
    Task<IList<InstitutionReadDto>> GetAllInstitutionsAsync(CancellationToken cancellationToken);
    Task<Response<InstitutionReadDto>> GetInstitutionByIdAsync(int id, CancellationToken cancellationToken);
    Task<Response<InstitutionReadDto>> AddInstitutionAsync(InstitutionCreateDto createInstitution, CancellationToken cancellationToken);
    Task<Response> EditInstitutionAsync(int id, InstitutionUpdateDto updateInstitution, CancellationToken cancellationToken);
    Task DeleteInstitutionAsync(int id, CancellationToken cancellationToken);
}
