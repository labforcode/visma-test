using FluentValidation.Results;
using Visma.Domain.Core.Events;

namespace Visma.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValida();
    }
}
