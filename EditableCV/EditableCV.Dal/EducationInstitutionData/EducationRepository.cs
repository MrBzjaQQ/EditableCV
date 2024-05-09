using EditableCV.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EditableCV.Dal.EducationInstitutionData
{
    public class EducationRepository : RepositoryBase, IEducationRepository
    {
        private readonly IResumeContext _context;

        public EducationRepository(IResumeContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task CreateInstitutionAsync(EducationalInstitution institution, CancellationToken cancellationToken)
        {
            if (institution == null)
            {
                throw new ArgumentNullException(nameof(institution));
            }

            await _context.EducationalInstitutions.AddAsync(institution, cancellationToken);
        }

        public async Task DeleteInstitutionAsync(int id, CancellationToken cancellationToken)
        {
            var institution = await GetInstitutionByIdAsync(id, cancellationToken);
            if (institution != null)
            {
                _context.EducationalInstitutions.Remove(institution);
            }
        }

        public async Task<IList<EducationalInstitution>> GetAllInstitutionsAsync(CancellationToken cancellationToken)
        {
            return await _context.EducationalInstitutions.ToListAsync(cancellationToken);
        }

        public async Task<EducationalInstitution> GetInstitutionByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.EducationalInstitutions.FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
        }
    }
}
