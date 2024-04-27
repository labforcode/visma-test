using FluentValidation.Results;
using Visma.HR.Domain.Core.Interfaces.UoW;
using Visma.HR.Domain.Core.Notifications;
using Visma.HR.Infra.CrossCutting.Common.Constants;
using Visma.HR.Infra.CrossCutting.Common.Enums;

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

            NotificacaoExcecao();
            return false;
        }

        public void NotificacaoSucesso(string message = "")
        {
            if (string.IsNullOrEmpty(message)) message = DefaultMessages.Success;

            _notificationContext.Notify(NotificationType.Success, message);
        }

        public void NotificacaoFalha(string failure = "")
        {
            if (string.IsNullOrEmpty(failure)) failure = DefaultMessages.Failure;

            _notificationContext.Notify(NotificationType.Failure, failure);
        }

        public void NotificacaoFalha(ValidationResult errors)
        {
            _notificationContext.Notify(errors);
        }

        public void NotificacaoExcecao()
        {
            var error = DefaultMessages.Exception;
            _notificationContext.Notify(NotificationType.Exception, error);
        }
    }
}
