using AutoMapper;
using eAgendaMedica.Application.DoctorModule;
using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.WebApi.ViewModels.DoctorModule;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaMedica.WebApi.Controllers
{
    [Route("api/medicos")]
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
        public async Task<IActionResult> GetAll()
        {
            var doctorsResult = await _doctorService.GetAllAsync();

            var viewModel = _mapper.Map<List<DoctorListViewModel>>(doctorsResult.Value);

            return Ok(viewModel);
        }

        [HttpGet("full-visualization/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var doctorResult = await _doctorService.GetByIdAsync(id);

            var viewModel = _mapper.Map<DoctorDetailViewModel>(doctorResult.Value);

            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DoctorFormsViewModel viewModel)
        {
            var doctor = _mapper.Map<Doctor>(viewModel);

            await _doctorService.AddAsync(doctor);

            return Ok(viewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, DoctorFormsViewModel viewModel)
        {
            var doctorResult = await _doctorService.GetByIdAsync(id);

            var doctor = _mapper.Map(viewModel, doctorResult.Value);

            await _doctorService.UpdateAsync(doctor);

            return Ok(viewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _doctorService.RemoveAsync(id);
            return Ok();
        }
    }
}
