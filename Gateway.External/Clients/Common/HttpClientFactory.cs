using System.Net.Http.Headers;

namespace Gateway.External.Clients.Common;

public class HttpClientFactory : IHttpClientFactory
{
    private const string MediaType = "application/json";

    public HttpClient CreateClient()
    {
        HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue(MediaType));
        return client;
    }
}
