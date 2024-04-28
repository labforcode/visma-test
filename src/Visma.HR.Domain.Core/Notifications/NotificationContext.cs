using FluentValidation.Results;
using Visma.Core.Infra.CrossCutting.Common.Enums;

namespace Visma.HR.Domain.Core.Notifications
{
    public class NotificationContext
    {
        public NotificationContext()
        {
            _notifications = new List<Notification>();
        }

        private readonly List<Notification> _notifications;

        public IReadOnlyCollection<Notification> Notifications => _notifications;

        public bool HasNotifications => _notifications.Any();

        public NotificationType GetTypeNotifications() => Notifications.FirstOrDefault().Type;

        public List<string> GetNotification() => Notifications.Select(s => s.Message).ToList();

        public void ClearNotifications() => _notifications.Clear();

        public void Notify(NotificationType type, string message)
        {
            ClearNotifications();
            _notifications.Add(new Notification(type, message));
        }

        public void Notify(ValidationResult errors)
        {
            ClearNotifications();
            var failure = errors.Errors.FirstOrDefault().ErrorMessage;
            _notifications.Add(new Notification(NotificationType.Failure, failure));
        }
    }
}
