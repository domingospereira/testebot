using FluentValidation.Results;
using System.Collections.Generic;
using Wiz.TesteWiz.Domain.Notifications;

namespace Wiz.TesteWiz.Domain.Interfaces.Notifications
{
    public interface IDomainNotification
    {
        IReadOnlyCollection<NotificationMessage> Notifications { get; }
        bool HasNotifications { get; }
        void AddNotification(string key, string message);
        void AddNotifications(IEnumerable<NotificationMessage> notifications);
        void AddNotifications(ValidationResult validationResult);
    }
}
