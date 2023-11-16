using AutoMapper;
using eAgendaMedica.Application.ActivityModule;
using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.WebApi.ViewModels.ActivityModule;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaMedica.WebApi.Controllers
{
    [Route("api/atividades")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly ActivityAppService _activityService;
        private readonly IMapper _mapper;

        public ActivityController(ActivityAppService activityService, IMapper mapper)
        {
            _activityService = activityService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var activityResult = await _activityService.GetAllAsync();

            var viewModel = _mapper.Map<List<ActivityListViewModel>>(activityResult.Value);

            return Ok(viewModel);
        }

        [HttpGet("full-visualization/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var activityResult = await _activityService.GetByIdAsync(id);

            var viewModel = _mapper.Map<ActivityDetailViewModel>(activityResult.Value);

            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ActivityFormsViewModel viewModel)
        {
            var activity = _mapper.Map<Activity>(viewModel);

            await _activityService.AddAsync(activity);

            return Ok(viewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ActivityFormsViewModel viewModel)
        {
            var activityResult = await _activityService.GetByIdAsync(id);

            var activity = _mapper.Map(viewModel, activityResult.Value);

            await _activityService.UpdateAsync(activity);

            return Ok(viewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _activityService.RemoveAsync(id);
            return Ok();
        }
    }
}
