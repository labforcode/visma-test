using FluentValidation.Results;
using Visma.HR.Domain.Core.Events;

namespace Visma.HR.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
