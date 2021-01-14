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
    }
}