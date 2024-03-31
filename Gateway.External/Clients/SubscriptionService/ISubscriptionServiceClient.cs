using Gateway.Models.SubscriptionService;

namespace Gateway.External.Clients.SubscriptionService;

public interface ISubscriptionServiceClient
{
    Task SubscribeAsync(Subscription subscription, string userLogin);
    Task<IReadOnlyCollection<Subscription>> GetSubscriptionsAsync(string userLogin);
    Task UnsubscribeAsync(long subscriptionId, string userLogin);
}
