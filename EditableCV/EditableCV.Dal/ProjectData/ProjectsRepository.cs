using EditableCV.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EditableCV.Dal.ProjectData;

public sealed class ProjectsRepository : RepositoryBase, IProjectsRepository
{
    private readonly IResumeContext _context;

    public ProjectsRepository(IResumeContext context) : base(context)
    {
        _context = context;
    }

    public async Task CreateProjectAsync(Project project, CancellationToken cancellationToken)
    {
        await _context.Projects.AddAsync(project, cancellationToken);
    }

    public async Task DeleteProjectAsync(int id, CancellationToken cancellationToken)
    {
        var project = await GetProjectByIdAsync(id, cancellationToken);
        if (project != null)
        {
            _context.Projects.Remove(project);
        }
    }

    public async Task<IList<Project>> GetAllProjectsAsync(CancellationToken cancellationToken)
    {
        return await _context.Projects.Include(x => x.Image).ToListAsync(cancellationToken);
    }

    public async Task<Project?> GetProjectByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Projects.Include(x => x.Image).FirstOrDefaultAsync(project => project.Id == id, cancellationToken);
    }
}