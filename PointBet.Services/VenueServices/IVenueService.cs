using PointBet.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointBet.Services.VenueServices
{
    public interface IVenueService
    {
        Task<ICollection<VenueModel>> GetAllVenues();
        Task<VenueModel> GetVenueWithApiId(int apiId);
        bool InsertVenues(ICollection<VenueModel> models);
        Task<bool> TruncateVenuesTable();
    }
}