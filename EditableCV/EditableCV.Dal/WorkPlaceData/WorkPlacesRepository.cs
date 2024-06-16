using EditableCV.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EditableCV.Dal.WorkPlaceData
{
    public class WorkPlacesRepository : RepositoryBase, IWorkPlacesRepository
    {
        private readonly IResumeContext _context;

        public WorkPlacesRepository(IResumeContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<WorkPlace>> GetAllWorkPlacesAsync(CancellationToken cancellationToken)
        {
            return await _context.WorkPlaces.Include(x => x.Logo).ToListAsync(cancellationToken);
        }

        public async Task<WorkPlace?> GetWorkPlaceByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.WorkPlaces.Include(x => x.Logo).FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
        
        }

        public async Task CreateWorkPlaceAsync(WorkPlace place, CancellationToken cancellationToken)
        {
            if (place == null)
            {
                throw new ArgumentNullException(nameof(place));
            }

            await _context.WorkPlaces.AddAsync(place, cancellationToken);
        }

        public async Task DeleteWorkPlaceAsync(int id, CancellationToken cancellationToken)
        {
            var workPlace = await GetWorkPlaceByIdAsync(id, cancellationToken);
            if (workPlace != null)
            {
                _context.WorkPlaces.Remove(workPlace);
            }
        }
    }
}
