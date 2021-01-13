using PointBet.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointBet.Services.SeasonServices
{
    public interface ISeasonService
    {
        Task<ICollection<SeasonModel>> GetAllSeasons();
        bool InsertSeasons(ICollection<SeasonModel> models);
        Task<bool> TruncateSeasonsTable();
    }
}