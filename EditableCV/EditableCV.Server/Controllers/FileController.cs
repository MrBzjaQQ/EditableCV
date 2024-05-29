using EditableCV.Services.Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EditableCV.Server.Controllers;

[Route(FileControllerUrl)]
public class FileController: ControllerBase
{
    internal const string FileControllerUrl = "api/file";
    private readonly IFilesService _service;

    public FileController(IFilesService service)
    {
        _service = service;
    }

    [HttpGet("{filename}", Name = nameof(GetFileAsync))]
    [AllowAnonymous]
    public async Task<IActionResult> GetFileAsync(string filename)
    {
        var result = await _service.GetFileAsync(filename, HttpContext.RequestAborted);
        if (!result.IsSuccess)
        {
            ModelState.AddModelError(Enum.GetName(result.StatusCode) ?? string.Empty, result.ErrorMessage);
            return StatusCode((int)result.StatusCode);
        }

        return File(result.Result, "application/octet-stream", fileDownloadName: filename);
    }

    [HttpPost]
    public async Task<IActionResult> PostFileAsync(IFormFile file)
    {
        var result = await _service.AddFileAsync(file.FileName, file.OpenReadStream(), HttpContext.RequestAborted);
        if (!result.IsSuccess)
        {
            ModelState.AddModelError(Enum.GetName(result.StatusCode) ?? string.Empty, result.ErrorMessage);
            return StatusCode((int)result.StatusCode);
        }

        return CreatedAtRoute(nameof(GetFileAsync), new { fileName = result.Result.FileName }, result.Result);
    }

    [HttpDelete("{filename}")]
    public async Task<IActionResult> DeleteFileAsync(string filename)
    {
        var result = await _service.DeleteFileAsync(filename, HttpContext.RequestAborted);
        return StatusCode((int)result.StatusCode);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFilesAsync()
    {
        var result = await _service.GetAllFilesAsync(HttpContext.RequestAborted);
        return Ok(result);
    }
}
