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
            BaseUrl = ConfigSettingsHandler.ReadSetting(Constants.TaleevoBaseUrlApiKey);
            TaleevoCompanyId = new Guid(ConfigSettingsHandler.ReadSetting(Constants.TaleevoCompanyIdKey));

            _apiService = apiService;
        }

        public CareerPositionsDto GetJobPositions()
        {
            var apiUrl = string.Format(ConfigSettingsHandler.ReadSetting(Constants.TaleevoGetPositionsUrlKey), TaleevoCompanyId);

            var httpResponse = _apiService.GetResponse(BaseUrl, apiUrl);

            var jsonData = httpResponse.Content.ReadAsStringAsync().Result;
            var dto = JsonConvert.DeserializeObject<CareerPositionsDto>(jsonData);

            return dto;
        }
    }
}
