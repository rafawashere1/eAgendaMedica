using AutoMapper;
using eAgendaMedica.Application.DoctorModule;
using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.WebApi.Shared;
using eAgendaMedica.WebApi.ViewModels.DoctorModule;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaMedica.WebApi.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    [Authorize]
    public class DoctorController : ApiControllerBase
    {
        private readonly DoctorAppService _doctorService;
        private readonly IMapper _mapper;

        public DoctorController(DoctorAppService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<DoctorListViewModel>), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> GetAll()
        {
            var doctorsResult = await _doctorService.GetAllAsync();

            var viewModel = _mapper.Map<List<DoctorListViewModel>>(doctorsResult.Value);

            return Ok(viewModel);
        }

        [HttpGet("top-10-workers")]
        [ProducesResponseType(typeof(DoctorDetailViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> GetTop10Workers()
        {
            var doctorsResult = await _doctorService.GetAllAsync();

            var viewModel = _mapper.Map<List<DoctorListViewModel>>(doctorsResult.Value);

            return Ok(viewModel);
        }

        [HttpGet("full-visualization/{id}")]
        [ProducesResponseType(typeof(DoctorDetailViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> GetFullVisualizationById(Guid id)
        {
            var selectedDoctorResult = await _doctorService.GetByIdAsync(id);

            if (selectedDoctorResult.IsFailed)
                return NotFound(selectedDoctorResult.Errors);

            var viewModel = _mapper.Map<DoctorDetailViewModel>(selectedDoctorResult.Value);

            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DoctorListViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var selectedDoctorResult = await _doctorService.GetByIdAsync(id);

            if (selectedDoctorResult.IsFailed)
                return NotFound(selectedDoctorResult.Errors);

            var viewModel = _mapper.Map<DoctorListViewModel>(selectedDoctorResult.Value);

            return Ok(viewModel);
        }

        [HttpPost]
        [ProducesResponseType(typeof(DoctorFormsViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Add(DoctorFormsViewModel viewModel)
        {
            var doctor = _mapper.Map<Doctor>(viewModel);

            var doctorResult = await _doctorService.AddAsync(doctor);

            if (doctorResult.IsFailed)
                return BadRequest(doctorResult.Errors);

            return Ok(viewModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DoctorFormsViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Update(Guid id, DoctorFormsViewModel viewModel)
        {
            var selectedDoctorResult = await _doctorService.GetByIdAsync(id);

            if (selectedDoctorResult.IsFailed)
                return NotFound(selectedDoctorResult.Errors);

            var doctor = _mapper.Map(viewModel, selectedDoctorResult.Value);

            var doctorResult = await _doctorService.UpdateAsync(doctor);

            if (doctorResult.IsFailed)
                return BadRequest(doctorResult.Errors);

            return Ok(viewModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Remove(Guid id)
        {
            var doctorResult = await _doctorService.RemoveAsync(id);

            if (doctorResult.IsFailed)
                return NotFound(doctorResult.Errors);

            return Ok();
        }
    }
}
