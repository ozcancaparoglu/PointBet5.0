using PointBet.Data.Models;
using PointBet.Services.CountryServices;
using PointBet.Services.LeagueServices;
using PointBet.Services.SeasonServices;
using PointBet.Services.TeamServices;
using PointBet.Services.VenueServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointBet.Services.ApiServices
{
    public class ApiDbService : IApiDbService
    {
        private readonly IApiSportService apiSportService;

        private readonly ISeasonService seasonService;
        private readonly ICountryService countryService;
        private readonly ILeagueService leagueService;
        private readonly ITeamService teamService;
        private readonly IVenueService venueService;

        public ApiDbService(IApiSportService apiSportService,
            ICountryService countryService,
            ISeasonService seasonService,
            ILeagueService leagueService,
            ITeamService teamService,
            IVenueService venueService)
        {
            this.apiSportService = apiSportService;

            this.seasonService = seasonService;
            this.countryService = countryService;
            this.leagueService = leagueService;
            this.teamService = teamService;
            this.venueService = venueService;
        }

        public async Task<bool> InsertCountries()
        {
            try
            {
                bool isTruncated = await countryService.TruncateCountriesTable();

                if (!isTruncated)
                    return false;

                List<CountryModel> models = await apiSportService.GetCountries();

                return countryService.InsertCountries(models);

            }
            catch (Exception ex)
            {
                //TODO: Log
                return false;
            }
        }

        public async Task<bool> InsertSeasons(int currentSeason)
        {
            try
            {
                bool isTruncated = await leagueService.TruncateLeaguesTable();

                isTruncated = await seasonService.TruncateSeasonsTable();

                if (!isTruncated)
                    return false;

                List<SeasonModel> seasons = models.Select(x => x.Seasons.FirstOrDefault()).ToList();

                seasonService.InsertSeasons(seasons);

                var seasonEntities = await seasonService.GetAllSeasons();

                var countryEntities = await countryService.GetAllCountries();

                foreach (var season in seasonEntities)
                {
                    try
                    {
                        models.FirstOrDefault(x => x.League.ApiId == season.CustomApiId).League.SeasonId = season.Id;
                    }
                    catch { continue; }
                }

                var leaguesModel = new List<LeagueModel>();

                foreach (var country in countryEntities)
                {
                    try
                    {
                        var leagueCountries = models.Where(x => x.Country.Code == country.Code).ToList();
                        leagueCountries.ForEach(x => x.League.CountryId = country.Id);
                        leaguesModel.AddRange(leagueCountries.Select(x => x.League));
                    }
                    catch { continue; }
                }

                leagueService.InsertLeagues(leaguesModel);

                return true;
            }
            catch (Exception ex)
            {
                //TODO: Log
                return false;
            }
        }

        public async Task<bool> InsertTeams(int leagueId, int currentSeason)
        {
            int? countryId = leagueService.GetLeagueWithApiId(leagueId).Result.CountryId;

            List<TeamApiResponse> models = await apiSportService.GetTeams(leagueId, currentSeason);

            models.ForEach(x => { x.Venue.CustomApiId = x.Team.ApiId; x.Venue.CountryId = countryId; x.Team.LeagueId = leagueId; });

            List<VenueModel> venues = models.Select(x => x.Venue).ToList();

            //TODO: Delete records with teamIds
            venueService.InsertVenues(venues);

            var venueEntities = await venueService.GetAllVenues();

            foreach (var venue in venueEntities)
            {
                models.FirstOrDefault(x => x.Team.ApiId == venue.CustomApiId).Team.VenueId = venue.Id;
            }

            //TODO: Do not truncate table just delete league teams
            var teams = models.Select(x => x.Team).ToList();

            teamService.InsertTeams(teams);

            return true;

        }
    }
}
