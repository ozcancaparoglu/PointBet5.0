using Common.Cache;
using Common.Enums;
using DataAccessLayer.AutoMapperConfig;
using DataAccessLayer.Repositories;
using DataAccessLayer.Uof;
using PointBet.Data.Domains;
using PointBet.Data.Models;
using PointBet.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointBet.Services.VenueServices
{
    public class VenueService : IVenueService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAutoMapperConfiguration autoMapper;
        private readonly ICacheManager redisCache;

        private readonly IGenericRepository<Venue> venueRepo;

        public VenueService(IUnitOfWork unitOfWork, IAutoMapperConfiguration autoMapper, ICacheManager redisCache)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
            this.redisCache = redisCache;

            venueRepo = this.unitOfWork.Repository<Venue>();
        }

        public async Task<ICollection<VenueModel>> GetAllVenues()
        {
            if (!redisCache.IsCached(CacheStatics.Venues))
            {
                ICollection<Venue> entities = await venueRepo.GetAllAsync();

                IEnumerable<VenueModel> models = autoMapper.MapCollection<Venue, VenueModel>(entities);

                await redisCache.SetAsync(CacheStatics.Venues, models, CacheStatics.VenuesCacheTime);
            }

            return await redisCache.GetAsync<ICollection<VenueModel>>(CacheStatics.Venues);
        }

        public async Task<bool> TruncateVenuesTable()
        {
            try
            {
                ICollection<VenueModel> models = await GetAllVenues();

                bool truncateResult = venueRepo.ClearTable(autoMapper.MapCollection<VenueModel, Venue>(models).ToList());

                if (!truncateResult)
                    venueRepo.ExecuteSqlCommand("DBCC CHECKIDENT('Venues', RESEED, 0)");

                return true;
            }
            catch (Exception ex)
            {
                //TODO: Log
                return false;
            }
        }

        public bool InsertVenues(ICollection<VenueModel> models)
        {
            try
            {
                List<Venue> insertData = autoMapper.MapCollection<VenueModel, Venue>(models).ToList();

                insertData.ForEach(x => { x.CreatedDate = DateTime.Now; x.State = (int)State.Active; });

                venueRepo.BulkInsert(insertData);

                return true;
            }
            catch (Exception ex)
            {
                //TODO: Log
                return false;
            }
        }

        public async Task<VenueModel> GetVenueWithApiId(int apiId)
        {
            var entity = await venueRepo.FindAsync(x => x.ApiId == apiId);

            return autoMapper.MapObject<Venue, VenueModel>(entity);
        }
    }
}
