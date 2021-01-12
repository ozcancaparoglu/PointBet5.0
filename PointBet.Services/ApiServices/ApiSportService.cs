using ApiClient;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PointBet.Data.Models;
using PointBet.Services.ApiServices.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointBet.Services.ApiServices
{
    public class ApiSportService : IApiSportService
    {
        private readonly IOptions<ApiSportSection> apiSportSection;
        private readonly IRestClientHelper restClientHelper;
        private readonly string apiUrl;
        private readonly Dictionary<string, string> apiHeaders;

        public ApiSportService(IOptions<ApiSportSection> apiSportSection, IRestClientHelper restClientHelper)
        {
            this.apiSportSection = apiSportSection;
            this.restClientHelper = restClientHelper;
            apiUrl = apiSportSection.Value.Host;
            apiHeaders = new Dictionary<string, string>
            {
                { "x-rapidapi-key", apiSportSection.Value.Key },
                { "x-rapidapi-host", apiSportSection.Value.RapidApiHost }
            };
        }

        public async Task<List<CountryModel>> GetCountries()
        {
            var response = await restClientHelper.GetAsync($"{apiUrl}/countries", apiHeaders);
            
            var obj = JsonConvert.DeserializeObject<CountryApiModel>(response);

            return obj.Countries;
        }

        public async Task<List<SeasonModel>> GetSeasons()
        {
            var response = await restClientHelper.GetAsync($"{apiUrl}/leagues?season=2019", apiHeaders);

            return new List<SeasonModel>();
        }

    }
}
