using EditableCV.Services.ContactInfoDto;
using EditableCV.Services.ContactInfo;
using Microsoft.AspNetCore.Mvc;
using EditableCV.Services.DataTransferObjects.ContactInfoDto;
using Microsoft.AspNetCore.JsonPatch;
using AutoMapper;

namespace EditableCV_backend.Controllers
{
    [Route("api/contact-info")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoService _service;
        private readonly IMapper _mapper;

        public ContactInfoController(IContactInfoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<ContactInfoReadDto>> GetAllContactInfosAsync()
        {
            return await _service.GetAllContactInfosAsync(HttpContext.RequestAborted);
        }

        [HttpGet("{id}", Name = "GetContactInfoAsync")]
        public async Task<IActionResult> GetContactInfoAsync(int id)
        {
            var getResult = await _service.GetContactInfoByIdAsync(id, HttpContext.RequestAborted);
            if (!getResult.IsSuccess)
            {
                ModelState.AddModelError(Enum.GetName(getResult.StatusCode) ?? string.Empty, getResult.ErrorMessage);
                return StatusCode((int)getResult.StatusCode);
            }

            return Ok(getResult.Result);
        }

        [HttpPost]
        public async Task<IActionResult> PostContactInfo(ContactInfoCreateDto createDto)
        {
            var contactInfo = await _service.AddContactInfoAsync(createDto, HttpContext.RequestAborted);
            return CreatedAtRoute(nameof(GetContactInfoAsync), new { Id = contactInfo.Id }, contactInfo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactInfoAsync(int id, ContactInfoUpdateDto updateDto)
        {
            var putResponse = await _service.EditContactInfoAsync(id, updateDto, HttpContext.RequestAborted);
            if (!putResponse.IsSuccess)
            {
                ModelState.AddModelError(Enum.GetName(putResponse.StatusCode) ?? string.Empty, putResponse.ErrorMessage);
                return StatusCode((int)putResponse.StatusCode);
            }

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchContactInfoAsync(int id, JsonPatchDocument<ContactInfoUpdateDto> patchDocument)
        {
            var contactInfoResponse = await _service.GetContactInfoByIdAsync(id, HttpContext.RequestAborted);
            if (!contactInfoResponse.IsSuccess)
            {
                ModelState.AddModelError(Enum.GetName(contactInfoResponse.StatusCode) ?? string.Empty, contactInfoResponse.ErrorMessage);
                return StatusCode((int)contactInfoResponse.StatusCode);
            }

            var contactInfoToPatch = _mapper.Map<ContactInfoUpdateDto>(contactInfoResponse.Result);
            patchDocument.ApplyTo(contactInfoToPatch, logError =>
            {
                ModelState.AddModelError($"{logError.Operation.path}_{logError.Operation.op}", logError.ErrorMessage);
            });

            return await PutContactInfoAsync(id, contactInfoToPatch);
        }

        [HttpDelete("{id}")]
        public async Task DeleteWorkPlaceAsync(int id)
        {
            await _service.DeleteContactInfoAsync(id, HttpContext.RequestAborted);
        }
    }
}
