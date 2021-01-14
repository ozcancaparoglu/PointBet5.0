using PointBet.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointBet.Services.LeagueServices
{
    public interface ILeagueService
    {
        Task<ICollection<LeagueModel>> GetAllLeagues();
        Task<LeagueModel> GetLeagueWithApiId(int apiId);
        bool InsertLeagues(ICollection<LeagueModel> models);
        Task<bool> TruncateLeaguesTable();
    }
}