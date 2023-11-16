using AutoMapper;
using eAgendaMedica.Application.DoctorModule;
using eAgendaMedica.WebApi.ViewModels.DoctorModule;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaMedica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorAppService _doctorService;
        private readonly IMapper _mapper;

        public DoctorController(DoctorAppService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var doctors = await _doctorService.GetAllAsync();

            var viewModel = _mapper.Map<List<DoctorListViewModel>>(doctors.Value);

            return Ok(viewModel);
        }
    }
}
