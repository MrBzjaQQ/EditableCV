using AutoMapper;
using EditableCV.Services.WorkPlaceDto;
using EditableCV.Services.WorkPlaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EditableCV_backend.Controllers
{
    [Route("api/workplaces")]
    [ApiController]
    public class WorkPlacesController : ControllerBase
    {
        private readonly IWorkPlacesService _service;
        private readonly IMapper _mapper;

        public WorkPlacesController(IWorkPlacesService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<WorkPlaceReadDto>> GetAllWorkPlacesAsync()
        {
            return await _service.GetAllWorkPlacesAsync(HttpContext.RequestAborted);
        }

        [HttpGet("{id}", Name = "GetWorkPlace")]
        public async Task<IActionResult> GetWorkPlace(int id)
        {
            var getResult = await _service.GetWorkPlaceByIdAsync(id, HttpContext.RequestAborted);
            if (!getResult.IsSuccess)
            {
                ModelState.AddModelError(Enum.GetName(getResult.StatusCode) ?? string.Empty, getResult.ErrorMessage);
                return StatusCode((int)getResult.StatusCode);
            }

            return Ok(getResult.Result);
        }

        [HttpPost]
        public async Task<IActionResult> PostWorkPlace(WorkPlaceCreateDto workPlaceDto)
        {
            var workPlace = await _service.AddWorkPlaceAsync(workPlaceDto, HttpContext.RequestAborted);
            return CreatedAtRoute(nameof(GetWorkPlace), new { Id = workPlace.Id }, workPlace);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkPlace(int id, WorkPlaceUpdateDto workPlaceDto)
        {
            var putResponse = await _service.EditWorkPlaceAsync(id, workPlaceDto, HttpContext.RequestAborted);
            if (!putResponse.IsSuccess)
            {
                ModelState.AddModelError(Enum.GetName(putResponse.StatusCode) ?? string.Empty, putResponse.ErrorMessage);
                return StatusCode((int)putResponse.StatusCode);
            }

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchWorkPlace(int id, JsonPatchDocument<WorkPlaceUpdateDto> patchDocument)
        {
            var workPlaceResponse = await _service.GetWorkPlaceByIdAsync(id, HttpContext.RequestAborted);
            if (!workPlaceResponse.IsSuccess)
            {
                ModelState.AddModelError(Enum.GetName(workPlaceResponse.StatusCode) ?? string.Empty, workPlaceResponse.ErrorMessage);
                return StatusCode((int)workPlaceResponse.StatusCode);
            }

            WorkPlaceUpdateDto workPlaceToPatch = _mapper.Map<WorkPlaceUpdateDto>(workPlaceResponse.Result);
            patchDocument.ApplyTo(workPlaceToPatch, logError =>
            {
                ModelState.AddModelError($"{logError.Operation.path}_{logError.Operation.op}", logError.ErrorMessage);
            });

            return await PutWorkPlace(id, workPlaceToPatch);
        }

        [HttpDelete("{id}")]
        public async Task DeleteWorkPlace(int id)
        {
            await _service.DeleteWorkPlaceAsync(id, HttpContext.RequestAborted);
        }
    }
}
