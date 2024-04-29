using Visma.Core.Infra.CrossCutting.Common.Enums;

namespace Visma.HR.Domain.Core.Notifications
{
    public class Notification
    {
        public Notification(NotificationType type,
                            string message)
        {
            Type = type;
            Message = message;
        }

        public NotificationType Type { get; private set; }

        public string Message { get; private set; }
    }
}
