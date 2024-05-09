using EditableCV.Services.ContactInfoDto;
using EditableCV.Services.ContactInfo;
using Microsoft.AspNetCore.Mvc;

namespace EditableCV_backend.Controllers
{
    [Route("api/contact-info")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoService _service;
        public ContactInfoController(IContactInfoService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<ContactInfoReadDto>> GetContactInfo()
        {
            var info = await _service.GetContactInfoAsync(HttpContext.RequestAborted);
            if (info == null)
            {
                return NotFound();
            }
            return Ok(info);
        }

        [HttpPut]
        public async Task<NoContentResult> PutContactInfo(ContactInfoUpdateDto updateInfoDto)
        {
            await _service.PutContactInfoAsync(updateInfoDto, HttpContext.RequestAborted);
            return NoContent();
        }
    }
}
