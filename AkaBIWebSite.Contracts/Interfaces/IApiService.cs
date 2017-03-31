using System.Net.Http;

namespace AkaBIWebSite.Contracts.Interfaces
{
    public interface IApiService
    {
        HttpResponseMessage GetResponse(string apiBaseUrlKey, string apiMethodUrl);
    }
}
