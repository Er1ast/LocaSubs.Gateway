using Gateway.Configuration.Options;
using Gateway.External.Clients.Constants;
using Microsoft.Extensions.Options;

namespace Gateway.External.Clients.SubscriptionService;

public class SubscriptionServiceQueryFactory : ISubscriptionServiceQueryFactory
{
    private readonly ServiceAddressesOptions _options;

    public SubscriptionServiceQueryFactory(IOptions<ServiceAddressesOptions> options)
    {
        _options = options.Value;
    }

    public string Subscribe()
    {
        const string method = "subscribe";

        var subscriptionServiceOptions = _options.Services.FirstOrDefault(s => s.Service == ServiceNames.SubscriptionService);

        string uri = $"https://{subscriptionServiceOptions.Host}:{subscriptionServiceOptions.Port}/{method}";

        return uri;
    }

    public string Subscriptions()
    {
        const string method = "subscriptions";

        var subscriptionServiceOptions = _options.Services.FirstOrDefault(s => s.Service == ServiceNames.SubscriptionService);

        string uri = $"https://{subscriptionServiceOptions.Host}:{subscriptionServiceOptions.Port}/{method}";

        return uri;
    }

    public string Unsubscribe()
    {
        const string method = "unsubscribe";

        var subscriptionServiceOptions = _options.Services.FirstOrDefault(s => s.Service == ServiceNames.SubscriptionService);

        string uri = $"https://{subscriptionServiceOptions.Host}:{subscriptionServiceOptions.Port}/{method}";

        return uri;
    }
}
