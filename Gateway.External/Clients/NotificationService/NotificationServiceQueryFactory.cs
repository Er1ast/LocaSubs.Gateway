using Gateway.Configuration.Options;
using Gateway.External.Clients.Constants;
using Gateway.Models.Common;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;

namespace Gateway.External.Clients.NotificationService;

public class NotificationServiceQueryFactory : INotificationServiceQueryFactory
{
    private readonly ServiceAddressesOptions _options;

    public NotificationServiceQueryFactory(IOptions<ServiceAddressesOptions> options)
    {
        _options = options.Value;
    }

    public string ReceiveNotification(double coordinateLat, double coordinateLon, ServiceType serviceType)
    {
        const string method = "receive-notification";

        const string CoordinateLat = "coordinateLat";
        const string CoordinateLon = "coordinateLon";
        const string ServiceType = "serviceType";

        var notificationServiceOptions = _options.Services.FirstOrDefault(s => s.Service == ServiceNames.NotificationService);

        string uri = $"https://{notificationServiceOptions.Host}:{notificationServiceOptions.Port}/{method}";

        Dictionary<string, string?> queryParams = new()
        {
            { CoordinateLat, coordinateLat.ToString() },
            { CoordinateLon, coordinateLon.ToString() },
            { ServiceType, ((int)serviceType).ToString() }
        };
        var resultQuery = QueryHelpers.AddQueryString(uri, queryParams);

        return uri;
    }
}
