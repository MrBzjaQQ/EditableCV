using EditableCV.Services.Landing;
using EditableCV.Services.LandingDto;
using Microsoft.AspNetCore.Mvc;

namespace EditableCV_backend.Controllers
{
    [Route("api/landing")]
    [ApiController]
    public class LandingController : ControllerBase
    {
        private readonly ILandingService _service;

        public LandingController(ILandingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<LandingReadDto> GetLandingData()
        {
            return await _service.GetLandingDataAsync(HttpContext.RequestAborted);
        }
    }
}
