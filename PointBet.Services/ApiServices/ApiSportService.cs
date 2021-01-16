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

        public async Task<List<VenueModel>> GetVenues(string name,string city,string country,string search,int? id = 0)
        {
            string response = string.Empty;
            
                if(id>0) response = await restClientHelper.GetAsync($"{apiUrl}/venues?id={id}", apiHeaders);
                else if(!string.IsNullOrEmpty(name)) response = await restClientHelper.GetAsync($"{apiUrl}/venues?name={name}", apiHeaders);
                else if(!string.IsNullOrEmpty(city)) response = await restClientHelper.GetAsync($"{apiUrl}/venues?city={name}", apiHeaders);
                else if (!string.IsNullOrEmpty(country)) response = await restClientHelper.GetAsync($"{apiUrl}/venues?country={country}", apiHeaders);
                else if (!string.IsNullOrEmpty(country)) response = await restClientHelper.GetAsync($"{apiUrl}/venues?search={search}", apiHeaders);

            VenueApiModel obj = JsonConvert.DeserializeObject<VenueApiModel>(response);
            return obj.Venues;
        }
        public async Task<StandingsApiModel> GetStandings(int leagueid, int season, int? team=0)
        {
            string response = string.Empty;
            if (team > 0)
                response = response = await restClientHelper.GetAsync($"{apiUrl}/standings?league={leagueid}&season={season}&team={team}", apiHeaders);
            else
                response = response = await restClientHelper.GetAsync($"{apiUrl}/standings?league={leagueid}&season={season}", apiHeaders);
            StandingsApiModel obj = JsonConvert.DeserializeObject<StandingsApiModel>(response);
            return obj;
        }

        public async Task<List<BookMakersModel>> GetBookmakers()
        {
            string response = await restClientHelper.GetAsync($"{apiUrl}/odds/bookmakers", apiHeaders);
            BookMakersApiModel obj = JsonConvert.DeserializeObject<BookMakersApiModel>(response);
            return obj.BookMakers;
        }

        public async Task<List<BetsModel>> GetBets()
        {
            string response = await restClientHelper.GetAsync($"{apiUrl}/odds/bets", apiHeaders);
            BetsApiModel obj = JsonConvert.DeserializeObject<BetsApiModel>(response);
            return obj.Bets;
        }
        public async Task<List<MappingModel>> GetMapping(int page=1)
        {
            string response = await restClientHelper.GetAsync($"{apiUrl}/odds/mapping?page={page}", apiHeaders);
            MappingApiModel obj = JsonConvert.DeserializeObject<MappingApiModel>(response);
            return obj.Mapping;
        }
    }
}