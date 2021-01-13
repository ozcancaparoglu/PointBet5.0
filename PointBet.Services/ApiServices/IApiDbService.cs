using System.Threading.Tasks;

namespace PointBet.Services.ApiServices
{
    public interface IApiDbService
    {
        Task<bool> InsertCountries();
        Task<bool> InsertSeasons();
    }
}