using Gateway.Models.Common;

namespace Gateway.External.Clients.NotificationService;

public interface INotificationServiceQueryFactory
{
    string ReceiveNotification(double coordinateLat, double coordinateLon, ServiceType serviceType);
}
