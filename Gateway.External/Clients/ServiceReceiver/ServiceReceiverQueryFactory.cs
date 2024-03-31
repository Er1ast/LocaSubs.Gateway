using Gateway.Configuration.Options;
using Gateway.External.Clients.Constants;
using Gateway.Models.Common;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;

namespace Gateway.External.Clients.ServiceReceiver;

public class ServiceReceiverQueryFactory : IServiceReceiverQueryFactory
{
    private readonly ServiceAddressesOptions _options;

    public ServiceReceiverQueryFactory(IOptions<ServiceAddressesOptions> options)
    {
        _options = options.Value;
    }

    public string Companies(ServiceType serviceType)
    {
        const string method = "companies";

        const string serviceTypeQueryParam = "serviceType";

        var serviceReceiverOptions = _options.Services.FirstOrDefault(s => s.Service == ServiceNames.ServiceReceiver);

        string uri = $"https://{serviceReceiverOptions.Host}:{serviceReceiverOptions.Port}/{method}";

        Dictionary<string, string?> queryParams = new()
        {
            { serviceTypeQueryParam, ((int)serviceType).ToString() }
        };
        var resultQuery = QueryHelpers.AddQueryString(uri, queryParams);

        return resultQuery;
    }

    public string NearbyCompanies(double coordinateLat, double coordinateLon, long radius, ServiceType serviceType)
    {
        const string method = "nearby-companies";

        const string coordinateLatQueryParam = "coordinateLat";
        const string coordinateLonQueryParam = "coordinateLon";
        const string radiusQueryParam = "radius";
        const string serviceTypeQueryParam = "serviceType";

        var serviceReceiverOptions = _options.Services.FirstOrDefault(s => s.Service == ServiceNames.ServiceReceiver);

        string uri = $"https://{serviceReceiverOptions.Host}:{serviceReceiverOptions.Port}/{method}";

        Dictionary<string, string?> queryParams = new()
        {
            { coordinateLatQueryParam, coordinateLat.ToString() },
            { coordinateLonQueryParam, coordinateLon.ToString() },
            { radiusQueryParam, radius.ToString() },
            { serviceTypeQueryParam, ((int)serviceType).ToString() }
        };
        var resultQuery = QueryHelpers.AddQueryString(uri, queryParams);

        return resultQuery;
    }

    public string NextSession(double coordinateLat, double coordinateLon, long radius, ServiceType serviceType)
    {
        const string method = "next-session";

        const string coordinateLatQueryParam = "coordinateLat";
        const string coordinateLonQueryParam = "coordinateLon";
        const string radiusQueryParam = "radius";
        const string serviceTypeQueryParam = "serviceType";

        var serviceReceiverOptions = _options.Services.FirstOrDefault(s => s.Service == ServiceNames.ServiceReceiver);

        string uri = $"https://{serviceReceiverOptions.Host}:{serviceReceiverOptions.Port}/{method}";

        Dictionary<string, string?> queryParams = new()
        {
            { coordinateLatQueryParam, coordinateLat.ToString() },
            { coordinateLonQueryParam, coordinateLon.ToString() },
            { radiusQueryParam, radius.ToString() },
            { serviceTypeQueryParam, ((int)serviceType).ToString() }
        };
        var resultQuery = QueryHelpers.AddQueryString(uri, queryParams);

        return resultQuery;
    }

    public string Staff(long companyId)
    {
        const string method = "next-session";

        const string companyIdQueryParam = "coordinateLat";

        var serviceReceiverOptions = _options.Services.FirstOrDefault(s => s.Service == ServiceNames.ServiceReceiver);

        string uri = $"https://{serviceReceiverOptions.Host}:{serviceReceiverOptions.Port}/{method}";

        Dictionary<string, string?> queryParams = new()
        {
            { companyIdQueryParam, companyId.ToString() }
        };
        var resultQuery = QueryHelpers.AddQueryString(uri, queryParams);

        return resultQuery;
    }
}
