using AkaBIWebSite.Contracts.Interfaces;
using System;
using AkaBIWebSite.Contracts.Dtos;
using AkaBIWebSite.Infrastructure;
using Newtonsoft.Json;

namespace AkaBIWebSite.Services
{
    public class TaleevoApiHandlerService : ITaleevoApiHandlerService
    {
        private string BaseUrl;
        private Guid TaleevoCompanyId;

        private readonly IApiService _apiService;
         
        public TaleevoApiHandlerService(IApiService apiService)
        {
            BaseUrl = ConfigSettingsHandler.ReadSetting("TaleevoBaseUrlApi");
            TaleevoCompanyId = new Guid(ConfigSettingsHandler.ReadSetting("TaleevoCompanyId"));

            _apiService = apiService;
        }

        public CareerPositionsDto GetJobPositions()
        {
            var apiUrl = string.Format("Post/OpenPosts/{0}", TaleevoCompanyId);

            var httpResponse = _apiService.GetResponse(BaseUrl, apiUrl);

            var jsonData = httpResponse.Content.ReadAsStringAsync().Result;
            var dto = JsonConvert.DeserializeObject<CareerPositionsDto>(jsonData);

            return dto;
        }
    }
}
