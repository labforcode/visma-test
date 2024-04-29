using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;
using Visma.HR.Domain.Core.Validators;

namespace Visma.HR.Domain.Core.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        [NotMapped]
        public bool IsValid { get; protected set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; protected set; }

        [NotMapped]
        public int TotalRecords { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        protected void Validate<E, V>(E entity, V validator) where E : class
                                                            where V : Validator<E>
        {
            ValidationResult = validator.Validate(entity);
            IsValid = ValidationResult.IsValid;
        }
    }
}
