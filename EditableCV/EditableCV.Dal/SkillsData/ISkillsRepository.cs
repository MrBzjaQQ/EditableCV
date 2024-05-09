using EditableCV.Domain.Models;

namespace EditableCV.Dal.SkillsData
{
    public interface ISkillsRepository : IRepository
    {
        Task CreateSkillAsync(Skill skill, CancellationToken cancellationToken);
        Task DeleteSkillAsync(int id, CancellationToken cancellationToken);
        Task<IList<Skill>> GetAllSkillsAsync(CancellationToken cancellationToken);
        Task<Skill?> GetSkillByIdAsync(int id, CancellationToken cancellationToken);
    }
}
