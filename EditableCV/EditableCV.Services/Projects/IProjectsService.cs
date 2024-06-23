using EditableCV.Services.DataTransferObjects.ProjectDto;
using EditableCV.Services.Shared;

namespace EditableCV.Services.Projects;

public interface IProjectsService
{
    Task<IList<ProjectReadDto>> GetAllProjectsAsync(string fileControllerUrl, CancellationToken cancellationToken);
    Task<Response<ProjectReadDto>> GetProjectByIdAsync(int id, string fileControllerUrl, CancellationToken cancellationToken);
    Task<ProjectReadDto> AddProjectAsync(ProjectCreateDto projectCreateDto, string fileControllerUrl, CancellationToken cancellationToken);
    Task<Response> EditProjectAsync(int id, ProjectUpdateDto projectUpdateDto, CancellationToken cancellationToken);
    Task DeleteProjectAsync(int id, CancellationToken cancellationToken);
}