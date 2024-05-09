using EditableCV.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EditableCV.Dal.LandingData
{
    internal sealed class LandingDataRepository : ILandingDataRepository
    {
        private readonly IResumeContext _context;

        public LandingDataRepository(IResumeContext context)
        {
            _context = context;
        }

        public async Task<LandingDataModel> GetLandingDataAsync(CancellationToken cancellationToken)
        {
            return new LandingDataModel()
            {
                CommonInfo = await _context.CommonInfos.FirstOrDefaultAsync(cancellationToken),
                ContactInfo = await _context.ContactInfos.FirstOrDefaultAsync(cancellationToken),
                Education = await _context.EducationalInstitutions.ToListAsync(cancellationToken),
                Skills = await _context.Skills.ToListAsync(cancellationToken),
                WorkPlaces = await _context.WorkPlaces.ToListAsync(cancellationToken),
            };
        }
    }
}
