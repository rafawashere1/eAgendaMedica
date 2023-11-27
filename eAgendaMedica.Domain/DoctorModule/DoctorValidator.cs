using FluentValidation;

namespace eAgendaMedica.Domain.DoctorModule
{
    public class DoctorValidator : AbstractValidator<Doctor>, IDoctorValidator
    {
        public DoctorValidator()
        {
            RuleFor(d => d.CRM)
           .NotEmpty().WithMessage("O CRM do médico deve ser fornecido.")
           .Matches(@"^\d{5}-[A-Z]{2}$").WithMessage("O CRM deve ter cinco dígitos seguidos pela sigla do estado (por exemplo, 12345-SP).");

            RuleFor(d => d.Name)
                .MinimumLength(3).WithMessage(@"'Nome' deve ser maior ou igual a 3 caracteres.")
                .Matches(@"^[\p{L}\p{M}'\s-\d]+$")
                .NotEmpty();
        }
    }
}
