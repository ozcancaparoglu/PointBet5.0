﻿using PointBet.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointBet.Services.ApiServices
{
    public interface IApiSportService
    {
        Task<List<CountryModel>> GetCountries();
        Task<List<SeasonApiResponse>> GetSeasons(int currentSeason);
        Task<List<TeamApiResponse>> GetTeams(int leagueId, int currentSeason);
        Task<List<VenueModel>> GetVenues(string name, string city, string country, string search,int? id);
        Task<StandingsApiModel> GetStandings(int leagueid, int season, int? team);
        Task<List<BookMakersModel>> GetBookmakers();
        Task<List<BetsModel>> GetBets();
        Task<List<MappingModel>> GetMapping(int page = 1);
        Task<List<string>> GetRounds(int league,int season,bool current);
        Task<List<FixturesModel>> GetFixtures(int? id,string live,string date,int?  league, int? season, int? team,string round,string status);
    }
}