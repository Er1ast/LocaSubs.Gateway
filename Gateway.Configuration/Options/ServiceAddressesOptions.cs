namespace Gateway.Configuration.Options;

public class ServiceAddressesOptions
{
    public const string SectionName = "ServiceAddresses";
    public List<ServiceAddress> Services { get; set; }
}
