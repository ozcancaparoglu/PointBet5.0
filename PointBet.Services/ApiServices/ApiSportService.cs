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
            string response = await restClientHelper.GetAsync($"{apiUrl}/countries", apiHeaders);

            CountryApiModel obj = JsonConvert.DeserializeObject<CountryApiModel>(response);

            return obj.Countries;
        }

        public async Task<List<SeasonApiResponse>> GetSeasons(int currentSeason)
        {
            string response = await restClientHelper.GetAsync($"{apiUrl}/leagues?season={currentSeason}", apiHeaders);

            SeasonApiModel obj = JsonConvert.DeserializeObject<SeasonApiModel>(response);

            return obj.Response;
        }

        public async Task<List<TeamApiResponse>> GetTeams(int leagueId, int currentSeason)
        {
            string response = await restClientHelper.GetAsync($"{apiUrl}/teams?league={leagueId}&season={currentSeason}", apiHeaders);

            TeamApiModel obj = JsonConvert.DeserializeObject<TeamApiModel>(response);

            return obj.Response;
        }
    }
}
