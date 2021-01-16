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

namespace PointBet.Services.OddServices
{
    public class BetsService : IBetsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAutoMapperConfiguration autoMapper;
        private readonly ICacheManager redisCache;

        private readonly IGenericRepository<Bets> betsRepo;
        public BetsService(IUnitOfWork unitOfWork, IAutoMapperConfiguration autoMapper, ICacheManager redisCache)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
            this.redisCache = redisCache;

            this.betsRepo = this.unitOfWork.Repository<Bets>(); ;
        }
        public async Task<ICollection<BetsModel>> GetAllBets()
        {
            if (!redisCache.IsCached(CacheStatics.Bets))
            {
                ICollection<Bets> entities = await betsRepo.GetAllAsync();

                IEnumerable<BetsModel> models = autoMapper.MapCollection<Bets, BetsModel>(entities);

                await redisCache.SetAsync(CacheStatics.Bets, models, CacheStatics.BetsTime);
            }

            return await redisCache.GetAsync<ICollection<BetsModel>>(CacheStatics.Bets);
        }

        public bool InsertBets(ICollection<BetsModel> models)
        {
            try
            {
                List<Bets> insertData = autoMapper.MapCollection<BetsModel, Bets>(models).ToList();

                insertData.ForEach(x => { x.CreatedDate = DateTime.Now; x.State = (int)State.Active; });

                betsRepo.BulkInsert(insertData);

                return true;
            }
            catch (Exception ex)
            {
                //TODO: Log
                return false;
            }
        }

        public async Task<bool> TruncateBetsTable()
        {
            try
            {
                ICollection<BetsModel> models = await GetAllBets();

                bool truncateResult = betsRepo.ClearTable(autoMapper.MapCollection<BetsModel, Bets>(models).ToList());

                if (!truncateResult)
                    betsRepo.ExecuteSqlCommand("DBCC CHECKIDENT('Bets', RESEED, 0)");

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
