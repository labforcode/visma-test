using FluentValidation.Results;
using Visma.Core.Infra.CrossCutting.Common.Constants;
using Visma.Core.Infra.CrossCutting.Common.Enums;
using Visma.HR.Domain.Core.Interfaces.UoW;
using Visma.HR.Domain.Core.Notifications;

namespace Visma.HR.Domain.Commands
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly NotificationContext _notificationContext;

        public CommandHandler(IUnitOfWork uow,
                              NotificationContext notificationContext)
        {
            _uow = uow;
            _notificationContext = notificationContext;
        }

        protected bool Commit()
        {
            if (_notificationContext.HasNotifications) return false;
            if (_uow.Commit()) return true;

            ExceptionNotify();
            return false;
        }

        public void SuccessNotify(string message = "")
        {
            if (string.IsNullOrEmpty(message)) message = DefaultMessages.Success;

            _notificationContext.Notify(NotificationType.Success, message);
        }

        public void FailNotify(string failure = "")
        {
            if (string.IsNullOrEmpty(failure)) failure = DefaultMessages.Failure;

            _notificationContext.Notify(NotificationType.Failure, failure);
        }

        public void FailNotify(ValidationResult errors)
        {
            _notificationContext.Notify(errors);
        }

        public void ExceptionNotify()
        {
            var error = DefaultMessages.Exception;
            _notificationContext.Notify(NotificationType.Exception, error);
        }
    }
}
