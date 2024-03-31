using Gateway.External.Clients.ServiceReceiver;
using Gateway.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers;

public class ServiceController : Controller
{
    private readonly IServiceReceiverClient _serviceReceiverClient;

    public ServiceController(IServiceReceiverClient serviceReceiverClient)
    {
        _serviceReceiverClient = serviceReceiverClient;
    }

    [HttpGet("companies")]
    public async Task<IActionResult> GetCompaniesAsync(ServiceType serviceType)
    {
        var result = await _serviceReceiverClient.GetCompaniesAsync(serviceType);
        return Ok(result);
    }

    [HttpGet("nearby-companies")]
    public async Task<IActionResult> GetNearbyCompaniesAsync(
        double coordinateLat,
        double coordinateLon,
        long radius,
        ServiceType serviceType)
    {
        var result = await _serviceReceiverClient.GetNearbyCompaniesAsync(coordinateLat, coordinateLon, radius, serviceType);
        return Ok(result);
    }

    [HttpGet("staff")]
    public async Task<IActionResult> GetStaffAsync(long companyId)
    {
        var result = await _serviceReceiverClient.GetStaffAsync(companyId);
        return Ok(result);
    }

    [HttpGet("next-session")]
    public async Task<IActionResult> GetNextSessionAsync(
        double coordinateLat,
        double coordinateLon,
        long radius,
        ServiceType serviceType)
    {
        var result = await _serviceReceiverClient.GetNextSessionAsync(coordinateLat, coordinateLon, radius, serviceType);

        return Ok(result);
    }
}
