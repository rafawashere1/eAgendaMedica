using AutoMapper;
using eAgendaMedica.Application.ActivityModule;
using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.WebApi.ViewModels.ActivityModule;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaMedica.WebApi.Controllers
{
    [Route("api/activities")]
    [ApiController]
    public class ActivityController : ApiControllerBase
    {
        private readonly ActivityAppService _activityService;
        private readonly IMapper _mapper;

        public ActivityController(ActivityAppService activityService, IMapper mapper)
        {
            _activityService = activityService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ActivityListViewModel>), 200)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> GetAll()
        {
            var activityResult = await _activityService.GetAllAsync();

            var viewModel = _mapper.Map<List<ActivityListViewModel>>(activityResult.Value);

            return Ok(viewModel);
        }

        [HttpGet("full-visualization/{id}")]
        [ProducesResponseType(typeof(ActivityDetailViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> GetFullVisualizationById(Guid id)
        {
            var selectedActivityResult = await _activityService.GetByIdAsync(id);

            if (selectedActivityResult.IsFailed)
                return NotFound(selectedActivityResult.Errors);

            var viewModel = _mapper.Map<ActivityDetailViewModel>(selectedActivityResult.Value);

            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ActivityListViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var selectedActivityResult = await _activityService.GetByIdAsync(id);

            if (selectedActivityResult.IsFailed)
                return NotFound(selectedActivityResult.Errors);

            var viewModel = _mapper.Map<ActivityListViewModel>(selectedActivityResult.Value);

            return Ok(viewModel);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ActivityFormsViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Add(ActivityFormsViewModel viewModel)
        {
            var activity = _mapper.Map<Activity>(viewModel);

            var activityResult = await _activityService.AddAsync(activity);

            if (activityResult.IsFailed)
                return BadRequest(activityResult.Errors);

            return Ok(viewModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ActivityFormsViewModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Update(Guid id, ActivityFormsViewModel viewModel)
        {
            var selectedActivityResult = await _activityService.GetByIdAsync(id);

            if (selectedActivityResult.IsFailed)
                return NotFound(selectedActivityResult.Errors);

            var activity = _mapper.Map(viewModel, selectedActivityResult.Value);

            var activityResult = await _activityService.UpdateAsync(activity);

            if (activityResult.IsFailed)
                return BadRequest(activityResult.Errors);

            return Ok(viewModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string[]), 404)]
        [ProducesResponseType(typeof(string[]), 500)]
        public async Task<IActionResult> Remove(Guid id)
        {
            var activityResult = await _activityService.RemoveAsync(id);

            if (activityResult.IsFailed)
                return NotFound(activityResult.Errors);

            return Ok();
        }
    }
}
