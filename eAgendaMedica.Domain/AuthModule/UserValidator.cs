using FluentValidation;

namespace eAgendaMedica.Domain.AuthModule
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }
}
