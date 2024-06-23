using System.Net;
using AutoMapper;
using EditableCV.Dal.FileData;
using EditableCV.Dal.ProjectData;
using EditableCV.Domain.Models;
using EditableCV.Resources;
using EditableCV.Services.DataTransferObjects.ProjectDto;
using EditableCV.Services.Shared;

namespace EditableCV.Services.Projects;

public sealed class ProjectsService: IProjectsService
{
    private readonly IProjectsRepository _repository;
    private readonly IFileRepository _fileRepository;
    private readonly IMapper _mapper;

    public ProjectsService(IProjectsRepository repository, IFileRepository fileRepository, IMapper mapper)
    {
        _repository = repository;
        _fileRepository = fileRepository;
        _mapper = mapper;
    }
    
    public async Task<IList<ProjectReadDto>> GetAllProjectsAsync(string fileControllerUrl, CancellationToken cancellationToken)
    {
        var projects = await _repository.GetAllProjectsAsync(cancellationToken);
        var result = new List<ProjectReadDto>(projects.Count);
        foreach (var project in projects)
        {
            var resultItem = _mapper.Map<ProjectReadDto>(project);
            if (project.Image != null)
            {
                result.Add(resultItem with { ProjectUrl = FileUrlHelper.GetFileUrl(fileControllerUrl, project.Image.FileName)});
                continue;
            }
            
            result.Add(resultItem);
        }

        return result;
    }

    public async Task<Response<ProjectReadDto>> GetProjectByIdAsync(int id, string fileControllerUrl, CancellationToken cancellationToken)
    {
        var project = await _repository.GetProjectByIdAsync(id, cancellationToken);
        if (project == null)
        {
            return Response<ProjectReadDto>.CreateFailed(HttpStatusCode.NotFound, string.Format(ErrorStrings.NotFoundByIdTemplate, id));
        }

        var result = _mapper.Map<ProjectReadDto>(project);
        if (project.Image != null)
        {
            return Response<ProjectReadDto>.CreateSuccess(result with
            {
                ProjectUrl = FileUrlHelper.GetFileUrl(fileControllerUrl, project.Image.FileName)
            });
        }
        
        return Response<ProjectReadDto>.CreateSuccess(result);
    }

    public async Task<ProjectReadDto> AddProjectAsync(ProjectCreateDto projectCreateDto, string fileControllerUrl, CancellationToken cancellationToken)
    {
        var project = _mapper.Map<Project>(projectCreateDto);
        if (string.IsNullOrEmpty(projectCreateDto.ImageName))
        {
            await _repository.CreateProjectAsync(project, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ProjectReadDto>(project);
        }

        var file = await _fileRepository.GetFileByNameAsync(projectCreateDto.ImageName, cancellationToken);
        if (file == null)
        {
            await _repository.CreateProjectAsync(project, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ProjectReadDto>(project);
        }

        project.SetImage(file);
        await _repository.CreateProjectAsync(project, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<ProjectReadDto>(project) with
        {
            ImageUrl = FileUrlHelper.GetFileUrl(fileControllerUrl, file.FileName)
        };
    }

    public async Task<Response> EditProjectAsync(int id, ProjectUpdateDto projectUpdateDto, CancellationToken cancellationToken)
    {
        var project = await _repository.GetProjectByIdAsync(id, cancellationToken);
        if (project == null)
        {
            return Response.CreateFailed(System.Net.HttpStatusCode.NotFound, string.Format(ErrorStrings.NotFoundByIdTemplate, id));
        }

        _mapper.Map(projectUpdateDto, project);
        var result = Response.CreateSuccess(System.Net.HttpStatusCode.NoContent);
        if (string.IsNullOrEmpty(projectUpdateDto.ImageName))
        {
            await _repository.SaveChangesAsync(cancellationToken);
            return result;
        }

        var file = await _fileRepository.GetFileByNameAsync(projectUpdateDto.ImageName, cancellationToken);
        if (file == null)
        {
            await _repository.SaveChangesAsync(cancellationToken);
            return result;
        }

        project.SetImage(file);
        await _repository.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task DeleteProjectAsync(int id, CancellationToken cancellationToken)
    {
        await _repository.DeleteProjectAsync(id, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }
}