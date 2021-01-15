using PointBet.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointBet.Services.TeamServices
{
    public interface ITeamService
    {
        Task<ICollection<TeamModel>> GetAllTeams();
        Task<TeamModel> GetTeamWithApiId(int apiId);
        bool InsertTeams(ICollection<TeamModel> models);
        Task<bool> TruncateTeamsTable();
    }
}