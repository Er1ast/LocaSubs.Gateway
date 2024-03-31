using Gateway.External.Clients.Common;
using Gateway.Models.Common;
using Gateway.Models.ServiceReceiver;
using Newtonsoft.Json;

namespace Gateway.External.Clients.NotificationService;

public class NotificationServiceClient : INotificationServiceClient
{
    private readonly INotificationServiceQueryFactory _notificationServiceQueryFactory;
    private readonly IHttpClientFactory _httpClientFactory;

    public NotificationServiceClient(
        INotificationServiceQueryFactory notificationServiceQueryFactory,
        IHttpClientFactory httpClientFactory)
    {
        _notificationServiceQueryFactory = notificationServiceQueryFactory;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IReadOnlyCollection<NearbySeance>> ReceiveNotification(
        double coordinateLat, 
        double coordinateLon, 
        ServiceType serviceType, 
        string userLogin)
    {
        string query = _notificationServiceQueryFactory.ReceiveNotification(coordinateLat, coordinateLon, serviceType);
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, query);
        requestMessage.Headers.Add("userLogin", userLogin);

        using HttpClient client = _httpClientFactory.CreateClient();
        var response = await client.SendAsync(requestMessage);

        List<NearbySeance> receiveNotificationResponse = null!;
        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            receiveNotificationResponse = JsonConvert.DeserializeObject<List<NearbySeance>>(data)!;
        }
        return receiveNotificationResponse ?? new List<NearbySeance>();
    }
}