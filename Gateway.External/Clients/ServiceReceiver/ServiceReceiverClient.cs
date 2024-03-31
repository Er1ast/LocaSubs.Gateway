using Gateway.External.Clients.Common;
using Gateway.Models.Common;
using Gateway.Models.ServiceReceiver;
using Newtonsoft.Json;

namespace Gateway.External.Clients.ServiceReceiver;

public class ServiceReceiverClient : IServiceReceiverClient
{
    private readonly IServiceReceiverQueryFactory _serviceReceiverQueryFactory;
    private readonly IHttpClientFactory _httpClientFactory;

    public ServiceReceiverClient(
        IServiceReceiverQueryFactory serviceReceiverQueryFactory,
        IHttpClientFactory httpClientFactory)
    {
        _serviceReceiverQueryFactory = serviceReceiverQueryFactory;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IReadOnlyCollection<Company>> GetCompaniesAsync(ServiceType serviceType)
    {
        string query = _serviceReceiverQueryFactory
            .Companies(serviceType);
        using HttpClient client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync(query);

        List<Company> getCompaniesResponse = null!;
        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            getCompaniesResponse = JsonConvert.DeserializeObject<List<Company>>(data)!;
        }
        return getCompaniesResponse ?? new List<Company>();
    }

    public async Task<IReadOnlyCollection<CompanyDistance>> GetNearbyCompaniesAsync(
        double coordinateLat, 
        double coordinateLon, 
        long radius, 
        ServiceType serviceType)
    {
        string query = _serviceReceiverQueryFactory
            .NearbyCompanies(coordinateLat, coordinateLon, radius, serviceType);
        using HttpClient client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync(query);

        List<CompanyDistance> getNearbyCompaniesResponse = null!;
        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            getNearbyCompaniesResponse = JsonConvert.DeserializeObject<List<CompanyDistance>>(data)!;
        }
        return getNearbyCompaniesResponse ?? new List<CompanyDistance>();
    }

    public async Task<IReadOnlyCollection<NearbySeance>> GetNextSessionAsync(
            double coordinateLat,
            double coordinateLon,
            long radius,
            ServiceType serviceType)
    {
        string query = _serviceReceiverQueryFactory
            .NextSession(coordinateLat, coordinateLon, radius, serviceType);
        using HttpClient client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync(query);

        List<NearbySeance> getNextSessionResponse = null!;
        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            getNextSessionResponse = JsonConvert.DeserializeObject<List<NearbySeance>>(data)!;
        }
        return getNextSessionResponse ?? new List<NearbySeance>();
    }

    public async Task<IReadOnlyCollection<StaffMember>> GetStaffAsync(long companyId)
    {
        string query = _serviceReceiverQueryFactory
            .Staff(companyId);
        using HttpClient client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync(query);

        List<StaffMember> getStaffResponse = null!;
        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            getStaffResponse = JsonConvert.DeserializeObject<List<StaffMember>>(data)!;
        }
        return getStaffResponse ?? new List<StaffMember>();
    }
}