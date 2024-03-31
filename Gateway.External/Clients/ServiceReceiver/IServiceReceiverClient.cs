using Gateway.Models.Common;
using Gateway.Models.ServiceReceiver;

namespace Gateway.External.Clients.ServiceReceiver;

public interface IServiceReceiverClient
{
    Task<IReadOnlyCollection<Company>> GetCompaniesAsync(ServiceType serviceType);
    Task<IReadOnlyCollection<StaffMember>> GetStaffAsync(long companyId);
    Task<IReadOnlyCollection<CompanyDistance>> GetNearbyCompaniesAsync(
        double coordinateLat,
        double coordinateLon,
        long radius,
        ServiceType serviceType);
    Task<IReadOnlyCollection<NearbySeance>> GetNextSessionAsync(
        double coordinateLat,
        double coordinateLon,
            long radius,
            ServiceType serviceType);
}
