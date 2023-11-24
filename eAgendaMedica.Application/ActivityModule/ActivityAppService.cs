using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.Domain.Shared;
using FluentResults;

namespace eAgendaMedica.Application.ActivityModule
{
    public class ActivityAppService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IPersistenceContext _persistenceContext;

        public ActivityAppService(IActivityRepository activityRepository, IPersistenceContext persistenceContext)
        {
            _activityRepository = activityRepository;
            _persistenceContext = persistenceContext;
        }

        public async Task<Result<Activity>> AddAsync(Activity activity)
        {
            var validationResult = ValidateActivity(activity);

            if (validationResult.IsFailed)
                return Result.Fail(validationResult.Errors);


            await _activityRepository.AddAsync(activity);

            await _persistenceContext.SaveAsync();

            return Result.Ok(activity);
        }

        public async Task<Result<Activity>> UpdateAsync(Activity activity)
        {
            var validationResult = ValidateActivity(activity);

            if (validationResult.IsFailed)
                return Result.Fail(validationResult.Errors);

            _activityRepository.Update(activity);

            await _persistenceContext.SaveAsync();

            return Result.Ok(activity);
        }

        public async Task<Result<Activity>> RemoveAsync(Guid id)
        {
            var activity = await _activityRepository.GetByIdAsync(id);

            if (activity == null)
                return Result.Fail($"Atividade {id} não encontrada");

            _activityRepository.Remove(activity);

            await _persistenceContext.SaveAsync();

            return Result.Ok();
        }

        public async Task<Result<Activity>> GetByIdAsync(Guid id)
        {
            var activities = await _activityRepository.GetByIdAsync(id);

            return Result.Ok(activities);
        }

        public async Task<Result<List<Activity>>> GetAllAsync()
        {
            var activities = await _activityRepository.GetAllAsync();

            return Result.Ok(activities);
        }

        private Result ValidateActivity(Activity activity)
        {
            var validator = new ActivityValidator();

            var validationResult = validator.Validate(activity);

            Activity.SetDays(activity);

            List<Error> errors = new();

            foreach (var error in validationResult.Errors)
                errors.Add(new Error(error.ErrorMessage));

            if (!Doctor.CanDoActivity(activity))
                errors.Add(new Error("Tempo de descanso insuficiente ou conflito de agenda"));

            if (errors.Any())
                return Result.Fail(errors);

            return Result.Ok();
        }
    }
}
