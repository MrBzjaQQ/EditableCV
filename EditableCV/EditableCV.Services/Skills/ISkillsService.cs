using EditableCV.Services.Shared;
using EditableCV.Services.SkillDto;

namespace EditableCV.Services.Skills;
public interface ISkillsService
{
    Task<Response<SkillReadDto>> GetSkillByIdAsync(int id, CancellationToken cancellationToken);
    Task<Response<SkillReadDto>> AddSkillAsync(SkillCreateDto createSkill, CancellationToken cancellationToken);
    Task<Response> EditSkillAsync(int id, SkillUpdateDto updateSkill, CancellationToken cancellationToken);
    Task DeleteSkillAsync(int id, CancellationToken cancellationToken);
    Task<IList<SkillReadDto>> GetSkillsAsync(CancellationToken cancellationToken);
}
