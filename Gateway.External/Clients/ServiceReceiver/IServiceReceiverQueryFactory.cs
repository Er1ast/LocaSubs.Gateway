using Gateway.Models.Common;

namespace Gateway.External.Clients.ServiceReceiver;

public interface IServiceReceiverQueryFactory
{
    string Companies(ServiceType serviceType);
    string NearbyCompanies(double coordinateLat, double coordinateLon, long radius, ServiceType serviceType);
    string NextSession(double coordinateLat, double coordinateLon, long radius, ServiceType serviceType);
    string Staff(long companyId);
}
