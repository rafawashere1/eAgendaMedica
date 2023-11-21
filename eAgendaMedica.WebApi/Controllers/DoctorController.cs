using AutoMapper;
using eAgendaMedica.Application.DoctorModule;
using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.WebApi.ViewModels.DoctorModule;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaMedica.WebApi.Controllers
{
    [Route("api/doctors")]
    [ApiController]
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
        public async Task<IActionResult> GetAll(int page = 1, int itemsPerPage = 10)
        {
            var doctorsResult = await _doctorService.GetAllAsync();

            var totalItems = doctorsResult.Value.Count;
            var totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);

            if (page < 1 || page > totalPages)
            {
                return BadRequest("Invalid page number.");
            }

            var pagedDoctors = doctorsResult.Value
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage);

            var viewModel = _mapper.Map<List<DoctorListViewModel>>(pagedDoctors);

            var paginationInfo = new
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                Page = page,
                ItemsPerPage = itemsPerPage
            };

            return StatusCode(200, new
            {
                Success = true,
                Data = viewModel,
                Pagination = paginationInfo
            });
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
        [ProducesResponseType(typeof(DoctorFormsViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var selectedDoctorResult = await _doctorService.GetByIdAsync(id);

            if (selectedDoctorResult.IsFailed)
                return NotFound(selectedDoctorResult.Errors);

            var viewModel = _mapper.Map<DoctorFormsViewModel>(selectedDoctorResult.Value);

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
