using Gateway.Models.SubscriptionService;

namespace Gateway.External.Clients.SubscriptionService;

public interface ISubscriptionServiceQueryFactory
{
    string Subscriptions();
    string Subscribe();
    string Unsubscribe();
}
