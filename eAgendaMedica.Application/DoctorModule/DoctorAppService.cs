using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.Domain.Shared;
using FluentResults;

namespace eAgendaMedica.Application.DoctorModule
{
    public class DoctorAppService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IActivityRepository _activityRepository;
        private readonly IPersistenceContext _persistenceContext;

        public DoctorAppService(IDoctorRepository doctorRepository, IActivityRepository activityRepository, IPersistenceContext persistenceContext)
        {
            _doctorRepository = doctorRepository;
            _activityRepository = activityRepository;
            _persistenceContext = persistenceContext;
        }

        public async Task<Result<Doctor>> AddAsync(Doctor doctor)
        {
            var validationResult = ValidateDoctor(doctor);

            if (validationResult.IsFailed)
                return Result.Fail(validationResult.Errors);

            await _doctorRepository.AddAsync(doctor);

            await _persistenceContext.SaveAsync();

            return Result.Ok(doctor);
        }

        public async Task<Result<Doctor>> UpdateAsync(Doctor doctor)
        {
            var validationResult = ValidateDoctor(doctor);

            if (validationResult.IsFailed)
                return Result.Fail(validationResult.Errors);

            _doctorRepository.Update(doctor);

            await _persistenceContext.SaveAsync();

            return Result.Ok(doctor);
        }

        public async Task<Result> RemoveAsync(Guid id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);

            if (doctor == null)
                return Result.Fail($"Médico {id} não encontrado");

            if (VerifyRelationshipWithActivities(doctor, _activityRepository.GetAll()))
                return Result.Fail($"Médico {doctor.Name} está com uma atividade agendada.");

            _doctorRepository.Remove(doctor);

            await _persistenceContext.SaveAsync();

            return Result.Ok();
        }

        public async Task<Result<List<Doctor>>> GetAllAsync()
        {
            var doctors = await _doctorRepository.GetAllAsync();

            return Result.Ok(Doctor.CalculateHoursWorked(doctors));
        }

        public async Task<Result<Doctor>> GetByIdAsync(Guid id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);

            return Result.Ok(doctor);
        }

        private Result ValidateDoctor(Doctor doctor)
        {
            var validator = new DoctorValidator();

            var validationResult = validator.Validate(doctor);

            List<Error> errors = new();

            foreach (var error in validationResult.Errors)
                errors.Add(new Error(error.ErrorMessage));

            if (_doctorRepository.Exist(doctor))
                errors.Add(new Error("Este médico já existe"));

            if (errors.Any())
                return Result.Fail(errors);

            return Result.Ok();
        }

        public bool VerifyRelationshipWithActivities(Doctor doctor, List<Activity> activities)
        {
            return activities.Any(a => a.Doctors.Contains(doctor));
        }
    }
}
