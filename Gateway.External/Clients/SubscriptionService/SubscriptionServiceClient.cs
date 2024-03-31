using Gateway.External.Clients.Common;
using Gateway.Models.SubscriptionService;
using Newtonsoft.Json;

namespace Gateway.External.Clients.SubscriptionService;

public class SubscriptionServiceClient : ISubscriptionServiceClient
{
    private readonly ISubscriptionServiceQueryFactory _subscriptionServiceQueryFactory;
    private readonly IHttpClientFactory _httpClientFactory;

    public SubscriptionServiceClient(
        ISubscriptionServiceQueryFactory subscriptionServiceQueryFactory,
        IHttpClientFactory httpClientFactory)
    {
        _subscriptionServiceQueryFactory = subscriptionServiceQueryFactory;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IReadOnlyCollection<Subscription>> GetSubscriptionsAsync(string userLogin)
    {
        string query = _subscriptionServiceQueryFactory.Subscriptions();
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, query);
        requestMessage.Headers.Add("userLogin", userLogin);

        using HttpClient client = _httpClientFactory.CreateClient();
        var response = await client.SendAsync(requestMessage);

        List<Subscription> getSubscriptionsResponse = null!;
        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            getSubscriptionsResponse = JsonConvert.DeserializeObject<List<Subscription>>(data)!;
        }
        return getSubscriptionsResponse ?? new List<Subscription>();
    }

    public async Task SubscribeAsync(Subscription subscription, string userLogin)
    {
        string query = _subscriptionServiceQueryFactory.Subscribe();
        var requestMessage = new HttpRequestMessage(HttpMethod.Post, query);
        requestMessage.Headers.Add("userLogin", userLogin);

        using HttpClient client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Clear();
        var result = await client.SendAsync(requestMessage);
        return;
    }

    public async Task UnsubscribeAsync(long subscriptionId, string userLogin)
    {
        string query = _subscriptionServiceQueryFactory.Unsubscribe();
        var requestMessage = new HttpRequestMessage(HttpMethod.Delete, query);
        requestMessage.Headers.Add("userLogin", userLogin);

        using HttpClient client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Clear();
        var result = await client.SendAsync(requestMessage);
        return;
    }
}
