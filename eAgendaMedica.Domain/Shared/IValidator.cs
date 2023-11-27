using FluentValidation.Results;

namespace eAgendaMedica.Domain.Shared
{
    public interface IValidator<T>
    {
        ValidationResult Validate(T instance);
    }
}
