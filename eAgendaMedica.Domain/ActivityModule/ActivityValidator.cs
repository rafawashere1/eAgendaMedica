using FluentValidation;

namespace eAgendaMedica.Domain.ActivityModule
{
    public class ActivityValidator : AbstractValidator<Activity>
    {
        public ActivityValidator()
        {
            RuleFor(a => a.Type)
                .NotNull().WithMessage("O tipo de atividade deve ser fornecido.");

            RuleFor(a => a.StartTime)
                .NotEmpty().WithMessage("A hora de início da atividade deve ser fornecida.");

            RuleFor(a => a.EndTime)
                .NotEmpty().WithMessage("A hora de término da atividade deve ser fornecida.");

            RuleFor(a => a.StartTime)
                .LessThan(a => a.EndTime).WithMessage("A hora de início deve ser antes da hora de término.");

            RuleFor(a => a.Doctors)
                .NotEmpty().WithMessage("Pelo menos um médico deve estar associado à atividade.")
                .Must(doctors => doctors != null && doctors.Count > 0).WithMessage("Pelo menos um médico deve estar associado à atividade.");
        }
    }
}
