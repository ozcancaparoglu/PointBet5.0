using PointBet.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointBet.Services.OddServices
{
    public interface IBetsService
    {
        Task<ICollection<BetsModel>> GetAllBets();
        bool InsertBets(ICollection<BetsModel> models);
        Task<bool> TruncateBetsTable();
    }
}
