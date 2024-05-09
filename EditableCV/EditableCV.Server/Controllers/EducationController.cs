using AutoMapper;
using EditableCV.Services.Education;
using EditableCV.Services.EducationalInstitutionDto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EditableCV_backend.Controllers
{
    [Route("api/education")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _service;
        private readonly IMapper _mapper;

        public EducationController(IEducationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<InstitutionReadDto>> GetAllInstitutions()
        {
            return await _service.GetAllInstitutionsAsync(HttpContext.RequestAborted);
        }

        [HttpGet("{id}", Name = "GetInstitutionById")]
        public async Task<IActionResult> GetInstitutionById(int id)
        {
            var result = await _service.GetInstitutionByIdAsync(id, HttpContext.RequestAborted);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError(Enum.GetName(result.StatusCode) ?? string.Empty, result.ErrorMessage);
                return StatusCode((int)result.StatusCode);
            }

            return Ok(result.Result);
        }

        [HttpPost]
        public async Task<IActionResult> PostInstitution(InstitutionCreateDto createInstitution)
        {
            var result = await _service.AddInstitutionAsync(createInstitution, HttpContext.RequestAborted);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError(Enum.GetName(result.StatusCode) ?? string.Empty, result.ErrorMessage);
                return StatusCode((int)result.StatusCode);
            }

            return CreatedAtRoute(nameof(GetInstitutionById), new { Id = result.Result.Id }, result.Result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitution(int id, InstitutionUpdateDto updateInstitution)
        {
            var updateResult = await _service.EditInstitutionAsync(id, updateInstitution, HttpContext.RequestAborted);
            if (!updateResult.IsSuccess)
            {
                ModelState.AddModelError(Enum.GetName(updateResult.StatusCode) ?? string.Empty, updateResult.ErrorMessage);
                return StatusCode((int)updateResult.StatusCode);
            }
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchInstitution(int id, JsonPatchDocument<InstitutionUpdateDto> patchDocument)
        {
            var result = await _service.GetInstitutionByIdAsync(id, HttpContext.RequestAborted);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError(Enum.GetName(result.StatusCode) ?? string.Empty, result.ErrorMessage);
                return StatusCode((int)result.StatusCode);
            }

            var institutionToPatch = _mapper.Map<InstitutionUpdateDto>(result.Result);
            patchDocument.ApplyTo(institutionToPatch, logError =>
            {
                ModelState.AddModelError($"{logError.Operation.path}_{logError.Operation.op}", logError.ErrorMessage);
            });

            return await PutInstitution(id, institutionToPatch);
        }

        [HttpDelete("{id}")]
        public async Task DeleteInstitution(int id)
        {
            await _service.DeleteInstitutionAsync(id, HttpContext.RequestAborted);
        }
    }
}
