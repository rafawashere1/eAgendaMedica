using FluentValidation;

namespace eAgendaMedica.Domain.ActivityModule
{
    public class ActivityValidator : AbstractValidator<Activity>
    {
        public ActivityValidator()
        {
            RuleFor(d => d.Title)
                .NotEmpty().WithMessage("O Título da atividade deve ser fornecido.");

            RuleFor(activity => activity.StartDay)
            .NotEmpty().WithMessage("O Dia de Início deve ser fornecido.");

            RuleFor(activity => activity.EndDay)
                .NotEmpty().WithMessage("O Dia de Térnino deve ser fornecido.")
                .GreaterThanOrEqualTo(activity => activity.StartDay)
                .WithMessage("O dia de término deve ser igual ou maior que o dia de início");

            RuleFor(a => a.StartTime)
                .NotEmpty().WithMessage("A hora de início da atividade deve ser fornecida.");

            RuleFor(a => a.EndTime)
                .NotEmpty().WithMessage("A hora de término da atividade deve ser fornecida.");

            RuleFor(a => a.StartTime)
                .LessThan(a => a.EndTime).WithMessage("A hora de início deve ser antes da hora de término.");

            RuleFor(a => a.Doctors)
                .NotEmpty().WithMessage("Pelo menos um médico deve estar associado à atividade.")
                .Must(doctors => doctors != null && doctors.Count > 0).WithMessage("Pelo menos um médico deve estar associado à atividade.");

            RuleFor(a => a.Type)
            .NotNull().WithMessage("O tipo de atividade deve ser fornecido.")
            .Must((activity, type) =>
            {
                if (type == TypeActivity.Appointment)
                    return activity.Doctors?.Count == 1;
                else if (type == TypeActivity.Surgery)
                    return true;
                return false;

            }).WithMessage("Para Consulta, apenas um médico pode ser selecionado.");
        }
    }
}
