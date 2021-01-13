using PointBet.Data.Models;
using PointBet.Services.CountryServices;
using PointBet.Services.LeagueServices;
using PointBet.Services.SeasonServices;
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

        public ApiDbService(IApiSportService apiSportService,
            ICountryService countryService,
            ISeasonService seasonService,
            ILeagueService leagueService)
        {
            this.apiSportService = apiSportService;

            this.seasonService = seasonService;
            this.countryService = countryService;
            this.leagueService = leagueService;

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

        public async Task<bool> InsertSeasons()
        {
            try
            {
                bool isTruncated = await leagueService.TruncateLeaguesTable();

                isTruncated = await seasonService.TruncateSeasonsTable();

                if (!isTruncated)
                    return false;

                List<SeasonApiResponse> models = await apiSportService.GetSeasons();

                models.ForEach(x => x.Seasons.FirstOrDefault().CustomApiId = x.League.ApiId);

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
    }
}
