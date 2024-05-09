using EditableCV.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EditableCV.Dal.SkillsData
{
    public class SkillsRepository : RepositoryBase, ISkillsRepository
    {
        private readonly IResumeContext _context;

        public SkillsRepository(IResumeContext context): base(context)
        {
            _context = context;
        }

        public async Task CreateSkillAsync(Skill skill, CancellationToken cancellationToken)
        {
            await _context.Skills.AddAsync(skill, cancellationToken);
        }

        public async Task DeleteSkillAsync(int id, CancellationToken cancellationToken)
        {
            var skill = await GetSkillByIdAsync(id, cancellationToken);
            if (skill != null)
            {
                _context.Skills.Remove(skill);
            }
        }

        public async Task<IList<Skill>> GetAllSkillsAsync(CancellationToken cancellationToken)
        {
            return await _context.Skills.ToListAsync(cancellationToken);
        }

        public async Task<Skill?> GetSkillByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Skills.FirstOrDefaultAsync(skill => skill.Id == id, cancellationToken);
        }
    }
}
