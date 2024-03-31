using Gateway.Models.Common;
using Gateway.Models.ServiceReceiver;

namespace Gateway.External.Clients.NotificationService;

public interface INotificationServiceClient
{
    Task<IReadOnlyCollection<NearbySeance>> ReceiveNotification(
        double coordinateLat,
        double coordinateLon,
        ServiceType serviceType,
        string userLogin);
}
