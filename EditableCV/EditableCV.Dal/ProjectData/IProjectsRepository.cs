using EditableCV.Domain.Models;

namespace EditableCV.Dal.ProjectData;

public interface IProjectsRepository: IRepository
{
    Task CreateProjectAsync(Project project, CancellationToken cancellationToken);
    Task DeleteProjectAsync(int id, CancellationToken cancellationToken);
    Task<IList<Project>> GetAllProjectsAsync(CancellationToken cancellationToken);
    Task<Project?> GetProjectByIdAsync(int id, CancellationToken cancellationToken);
}