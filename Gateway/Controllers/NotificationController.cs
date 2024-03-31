using Gateway.External.Clients.ServiceReceiver;
using Gateway.External.Clients.SubscriptionService;
using Gateway.Helpers;
using Gateway.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers;

[Authorize]
public class NotificationController : Controller
{
    private readonly ISubscriptionServiceClient _subscriptionServiceClient;
    private readonly IServiceReceiverClient _serviceReceiverClient;

    public NotificationController(
        ISubscriptionServiceClient subscriptionServiceClient,
        IServiceReceiverClient serviceReceiverClient)
    {
        _subscriptionServiceClient = subscriptionServiceClient;
        _serviceReceiverClient = serviceReceiverClient;
    }

    [HttpGet("receive-notification")]
    public async Task<IActionResult> ReceiveNotification(double coordinateLat, double coordinateLon, ServiceType serviceType)
    {
        bool userLoginReceived = ClaimHelper.GetUserLogin(HttpContext, out var userLogin);
        if (!userLoginReceived) return BadRequest("Ошибка авторизации");

        var subscriptions = await _subscriptionServiceClient.GetSubscriptionsAsync(userLogin);
        var targetSubscription = subscriptions.FirstOrDefault(subscription => subscription.ServiceType == serviceType);

        if (targetSubscription is null) return NotFound();

        var nextSession = await _serviceReceiverClient
            .GetNextSessionAsync(coordinateLat, coordinateLon, targetSubscription.Range, serviceType);

        return Ok(nextSession);
    }
}
