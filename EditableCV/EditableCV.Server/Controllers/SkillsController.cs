using AutoMapper;
using EditableCV.Services.SkillDto;
using EditableCV.Services.Skills;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EditableCV_backend.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillsService _service;
        private readonly IMapper _mapper;

        public SkillsController(ISkillsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<SkillReadDto>> GetAllSkillsAsync()
        {
            return await _service.GetSkillsAsync(HttpContext.RequestAborted);
        }

        [HttpGet("{id}", Name = "GetSkillById")]
        public async Task<IActionResult> GetSkillByIdAsync(int id)
        {
            var skillResponse = await _service.GetSkillByIdAsync(id, HttpContext.RequestAborted);
            if (!skillResponse.IsSuccess)
            {
                ModelState.AddModelError(Enum.GetName(skillResponse.StatusCode) ?? string.Empty, skillResponse.ErrorMessage);
                return StatusCode((int)skillResponse.StatusCode);
            }

            return Ok(skillResponse.Result);
        }

        [HttpPost]
        public async Task<IActionResult> PostSkillAsync(SkillCreateDto skillCreateDto)
        {
            var skillResponse = await _service.AddSkillAsync(skillCreateDto, HttpContext.RequestAborted);
            if (!skillResponse.IsSuccess)
            {
                ModelState.AddModelError(Enum.GetName(skillResponse.StatusCode) ?? string.Empty, skillResponse.ErrorMessage);
                return StatusCode((int)skillResponse.StatusCode);
            }

            return CreatedAtRoute(nameof(GetSkillByIdAsync), new { skillResponse.Result.Id }, skillResponse.Result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkillAsync(int id, SkillUpdateDto skillUpdateDto)
        {
            var putResult = await _service.EditSkillAsync(id, skillUpdateDto, HttpContext.RequestAborted);
            if (!putResult.IsSuccess)
            {
                ModelState.AddModelError(Enum.GetName(putResult.StatusCode) ?? string.Empty, putResult.ErrorMessage);
                return StatusCode((int)putResult.StatusCode);
            }

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchSkillAsync(int id, JsonPatchDocument<SkillUpdateDto> patchDocument)
        {
            var result = await _service.GetSkillByIdAsync(id, HttpContext.RequestAborted);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError(Enum.GetName(result.StatusCode) ?? string.Empty, result.ErrorMessage);
                return StatusCode((int)result.StatusCode);
            }

            var skillToPatch = _mapper.Map<SkillUpdateDto>(result.Result);
            patchDocument.ApplyTo(skillToPatch, logError =>
            {
                ModelState.AddModelError($"{logError.Operation.path}_{logError.Operation.op}", logError.ErrorMessage);
            });

            return await PutSkillAsync(id, skillToPatch);
        }

        [HttpDelete("{id}")]
        public async Task DeleteSkillAsync(int id)
        {
            await _service.DeleteSkillAsync(id, HttpContext.RequestAborted);
        }
    }
}
