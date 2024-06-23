using AutoMapper;
using EditableCV.Services.DataTransferObjects.ProjectDto;
using EditableCV.Services.Projects;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EditableCV.Server.Controllers;

[Microsoft.AspNetCore.Components.Route("api/controller")]
[ApiController]
public class ProjectsController: ControllerBase
{
    private readonly IProjectsService _service;
    private readonly IMapper _mapper;

    public ProjectsController(IProjectsService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IList<ProjectReadDto>> GetAllProjectsAsync()
    {
        return await _service.GetAllProjectsAsync(FileController.FileControllerUrl, HttpContext.RequestAborted);
    }

    [HttpGet("{id})", Name = "GetProjectAsync")]
    public async Task<IActionResult> GetProjectAsync(int id)
    {
        var getResult = await _service.GetProjectByIdAsync(id, FileController.FileControllerUrl, HttpContext.RequestAborted);
        if (!getResult.IsSuccess)
        {
            ModelState.AddModelError(Enum.GetName(getResult.StatusCode) ?? string.Empty, getResult.ErrorMessage);
            return StatusCode((int)getResult.StatusCode);
        }

        return Ok(getResult.Result);
    }

    [HttpPost]
    public async Task<IActionResult> PostProjectAsync(ProjectCreateDto projectCreateDto)
    {
        var project = await _service.AddProjectAsync(projectCreateDto, FileController.FileControllerUrl, HttpContext.RequestAborted);
        return CreatedAtRoute(nameof(GetProjectAsync), new { Id = project.Id }, project);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProjectAsync(int id, ProjectUpdateDto updateDto)
    {
        var putResponse = await _service.EditProjectAsync(id, updateDto, HttpContext.RequestAborted);
        if (!putResponse.IsSuccess)
        {
            ModelState.AddModelError(Enum.GetName(putResponse.StatusCode) ?? string.Empty, putResponse.ErrorMessage);
            return StatusCode((int)putResponse.StatusCode);
        }

        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchProjectAsync(int id, JsonPatchDocument<ProjectUpdateDto> patchDocument)
    {
        var projectResponse = await _service.GetProjectByIdAsync(id, FileController.FileControllerUrl, HttpContext.RequestAborted);
        if (!projectResponse.IsSuccess)
        {
            ModelState.AddModelError(Enum.GetName(projectResponse.StatusCode) ?? string.Empty, projectResponse.ErrorMessage);
            return StatusCode((int)projectResponse.StatusCode);
        }

        var projectToPatch = _mapper.Map<ProjectUpdateDto>(projectResponse.Result);
        patchDocument.ApplyTo(projectToPatch, logError =>
        {
            ModelState.AddModelError($"{logError.Operation.path}_{logError.Operation.op}", logError.ErrorMessage);
        });

        return await PutProjectAsync(id, projectToPatch);
    }

    [HttpDelete("{id}")]
    public async Task DeleteProjectAsync(int id)
    {
        await _service.DeleteProjectAsync(id, HttpContext.RequestAborted);
    }
}