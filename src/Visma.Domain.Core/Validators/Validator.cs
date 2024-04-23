using FluentValidation;

namespace Visma.Domain.Core.Validators
{
    public abstract class Validator<T> : AbstractValidator<T> where T : class
    {
    }
}
