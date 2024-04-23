using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;
using Visma.Domain.Core.Validators;

namespace Visma.Domain.Core.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        [NotMapped]
        public bool IsValid { get; private set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }

        protected void Validate<E, V>(E entity, V validator) where E : class
                                                            where V : Validator<E>
        {
            ValidationResult = validator.Validate(entity);
            IsValid = ValidationResult.IsValid;
        }
    }
}
