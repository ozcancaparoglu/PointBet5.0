using System.Threading.Tasks;

namespace PointBet.Services.ApiServices
{
    public interface IApiDbService
    {
        Task<bool> InsertCountries();
        Task<bool> InsertSeasons(int currentSeason);
        Task<bool> InsertTeams(int leagueId, int currentSeason);
        Task<bool> InsertBookMakers();
        Task<bool> InsertBets();
        //Task<bool> InsertFixtures();
    }
}