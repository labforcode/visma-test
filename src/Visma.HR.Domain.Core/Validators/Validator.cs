using FluentValidation;

namespace Visma.HR.Domain.Core.Validators
{
    public abstract class Validator<T> : AbstractValidator<T> where T : class
    {
    }
}
