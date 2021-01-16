using PointBet.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointBet.Services.OddServices
{
    public interface IBookMakersService
    {
        Task<ICollection<BookMakersModel>> GetAllBookMakers();
        bool InsertBookMakers(ICollection<BookMakersModel> models);
        Task<bool> TruncateBookMakersTable();
    }
}
