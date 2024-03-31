using Gateway.Models.Common;

namespace Gateway.Models.SubscriptionService;

public record Subscription
{
    public long Id { get; set; }
    public string? UserLogin { get; set; }
    public long Range { get; set; }
    public ServiceType ServiceType { get; set; }
}
