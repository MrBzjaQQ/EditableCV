using EditableCV.Services.CommonInfoDto;
using EditableCV.Services.CommonInfo;
using Microsoft.AspNetCore.Mvc;
using EditableCV.Server.Controllers;

namespace EditableCV_backend.Controllers
{
    [Route("api/common-info")]
    [ApiController]
    public class CommonInfoController : ControllerBase
    {
        private readonly ICommonInfoService _service;
        public CommonInfoController(ICommonInfoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<CommonInfoReadDto>> GetCommonInfoAsync()
        {
            var commonInfo = await _service.GetCommonInfoAsync(FileController.FileControllerUrl, HttpContext.RequestAborted);
            if (commonInfo == null)
            {
                return NotFound();
            }
            return Ok(commonInfo);
        }

        [HttpPut]
        public async Task<NoContentResult> PutCommonInfoAsync(CommonInfoCreateDto info)
        {
            await _service.PutCommonInfoAsync(info, HttpContext.RequestAborted);
            return NoContent();
        }
    }
}
