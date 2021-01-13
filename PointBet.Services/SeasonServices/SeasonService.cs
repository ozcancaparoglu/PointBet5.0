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

namespace PointBet.Services.SeasonServices
{
    public class SeasonService : ISeasonService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAutoMapperConfiguration autoMapper;
        private readonly ICacheManager redisCache;

        private readonly IGenericRepository<Season> seasonRepo;

        public SeasonService(IUnitOfWork unitOfWork, IAutoMapperConfiguration autoMapper, ICacheManager redisCache)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
            this.redisCache = redisCache;

            seasonRepo = this.unitOfWork.Repository<Season>();
        }

        public async Task<ICollection<SeasonModel>> GetAllSeasons()
        {
            if (!redisCache.IsCached(CacheStatics.Seasons))
            {
                ICollection<Season> entities = await seasonRepo.GetAllAsync();

                IEnumerable<SeasonModel> models = autoMapper.MapCollection<Season, SeasonModel>(entities);

                await redisCache.SetAsync(CacheStatics.Seasons, models, CacheStatics.SeasonsCacheTime);
            }

            return await redisCache.GetAsync<ICollection<SeasonModel>>(CacheStatics.Seasons);
        }

        public async Task<bool> TruncateSeasonsTable()
        {
            try
            {
                ICollection<SeasonModel> models = await GetAllSeasons();

                bool truncateResult = seasonRepo.ClearTable(autoMapper.MapCollection<SeasonModel, Season>(models).ToList());

                if (!truncateResult)
                    seasonRepo.ExecuteSqlCommand("DBCC CHECKIDENT('Seasons', RESEED, 0)");

                return true;
            }
            catch (Exception ex)
            {
                //TODO: Log
                return false;
            }
        }

        public bool InsertSeasons(ICollection<SeasonModel> models)
        {
            try
            {
                List<Season> insertData = autoMapper.MapCollection<SeasonModel, Season>(models).ToList();

                insertData.ForEach(x => { x.CreatedDate = DateTime.Now; x.State = (int)State.Active; });

                seasonRepo.BulkInsert(insertData);

                return true;
            }
            catch (Exception ex)
            {
                //TODO: Log
                return false;
            }
        }
    }
}
