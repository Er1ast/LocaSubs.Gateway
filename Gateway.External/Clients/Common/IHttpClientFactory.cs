namespace Gateway.External.Clients.Common;

public interface IHttpClientFactory
{
    HttpClient CreateClient();
}
