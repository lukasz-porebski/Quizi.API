using RestSharp;
using RestSharp.Authenticators;

namespace Common.Infrastructure.Integration;

public abstract class BaseApi
{
    protected BaseApi(string baseUrl, IAuthenticator? authenticator = null)
    {
        var options = new RestClientOptions(baseUrl)
        {
            Authenticator = authenticator
        };
        Client = new RestClient(options);
    }

    protected RestClient Client { get; }
}