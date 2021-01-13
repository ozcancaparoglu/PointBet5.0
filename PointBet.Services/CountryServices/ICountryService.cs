using PointBet.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointBet.Services.CountryServices
{
    public interface ICountryService
    {
        Task<ICollection<CountryModel>> GetAllCountries();
        bool InsertCountries(ICollection<CountryModel> models);
        Task<bool> TruncateCountriesTable();
    }
}