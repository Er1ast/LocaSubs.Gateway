using Gateway.External.Clients.SubscriptionService;
using Gateway.Helpers;
using Gateway.Models.SubscriptionService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Gateway.Controllers;

public class SubscriptionController : Controller
{
    private readonly ISubscriptionServiceClient _subscriptionServiceClient;

    public SubscriptionController(ISubscriptionServiceClient subscriptionServiceClient)
    {
        _subscriptionServiceClient = subscriptionServiceClient;
    }

    [HttpPost("subscribe")]
    public async Task<IActionResult> SubscribeAsync(
        [FromBody][Required] SubscribeRequest request)
    {
        bool userLoginReceived = ClaimHelper.GetUserLogin(HttpContext, out var userLogin);
        if (!userLoginReceived) return BadRequest("Ошибка авторизации");

        var subscription = request.ToSubscription(userLogin);
        await _subscriptionServiceClient.SubscribeAsync(subscription, subscription.UserLogin);
        return Ok(subscription.Id);
    }

    [HttpDelete("unsubscribe")]
    public async Task<IActionResult> UnsubscribeAsync(
        [FromBody][Required] long subscriptionId)
    {
        bool userLoginReceived = ClaimHelper.GetUserLogin(HttpContext, out var userLogin);
        if (!userLoginReceived) return BadRequest("Ошибка авторизации");

        await _subscriptionServiceClient.UnsubscribeAsync(subscriptionId, userLogin);
        return Ok();
    }

    [HttpGet("subscriptions")]
    public async Task<IActionResult> GetUserSubscruptions()
    {
        bool userLoginReceived = ClaimHelper.GetUserLogin(HttpContext, out var userLogin);
        if (!userLoginReceived) return BadRequest("Ошибка авторизации");

        var subscriptions = await _subscriptionServiceClient.GetSubscriptionsAsync(userLogin);
        return Ok(subscriptions);
    }
}
