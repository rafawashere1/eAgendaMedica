using eAgendaMedica.Application.DoctorModule;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorAppService _doctorService;

        public DoctorController(DoctorAppService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var doctors = await _doctorService.GetAllAsync();

            return Ok(doctors);
        }
    }
}
