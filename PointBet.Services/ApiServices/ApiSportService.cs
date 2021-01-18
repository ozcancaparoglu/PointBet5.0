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

        public async Task<List<string>> GetRounds(int league, int season, bool current)
        {
            string _current = current ? "true" : "false";
            string response = await restClientHelper.GetAsync($"{apiUrl}/fixtures/rounds?league={league}&season={season}&current={_current}", apiHeaders);
            RoundsModel obj = JsonConvert.DeserializeObject<RoundsModel>(response);
            return obj.Response;
        }

        public async Task<List<FixturesModel>> GetFixtures(int? id, string live, string date, int? league,int? season,int? team, string round, string status)
        {
            string response = string.Empty;
           
            if(id != null)
                response = await restClientHelper.GetAsync($"{apiUrl}/fixtures/?id={id}", apiHeaders);
            else if(!string.IsNullOrEmpty(live)) // "all" "id-id"
                response = await restClientHelper.GetAsync($"{apiUrl}/fixtures/?live={live}", apiHeaders);
            else if(!string.IsNullOrEmpty(date)) // YYYY-MM-DD
                response = await restClientHelper.GetAsync($"{apiUrl}/fixtures/?date={date}", apiHeaders);
            else if(league != null && league>0 && season > 0)
                response = await restClientHelper.GetAsync($"{apiUrl}/fixtures/?league={league}&season={season}", apiHeaders);
            else if (team != null && team > 0 && season > 0)
                response = await restClientHelper.GetAsync($"{apiUrl}/fixtures/?team={team}&season={season}", apiHeaders);
            else if (!string.IsNullOrEmpty(round)) 
                response = await restClientHelper.GetAsync($"{apiUrl}/fixtures/?round={round}", apiHeaders);
            else if (!string.IsNullOrEmpty(status) && league > 0 && season > 0)
                response = await restClientHelper.GetAsync($"{apiUrl}/fixtures/?status={status}&league={league}&season={season}", apiHeaders);


            FixturesApiModel obj = JsonConvert.DeserializeObject<FixturesApiModel>(response);
            return obj.Fixtures;
        }
    }
}