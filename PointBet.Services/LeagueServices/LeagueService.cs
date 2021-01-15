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
using System.Text;
using System.Threading.Tasks;

namespace PointBet.Services.LeagueServices
{
    public class LeagueService : ILeagueService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAutoMapperConfiguration autoMapper;
        private readonly ICacheManager redisCache;

        private readonly IGenericRepository<League> leagueRepo;

        public LeagueService(IUnitOfWork unitOfWork, IAutoMapperConfiguration autoMapper, ICacheManager redisCache)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
            this.redisCache = redisCache;

            leagueRepo = this.unitOfWork.Repository<League>();
        }

        public async Task<ICollection<LeagueModel>> GetAllLeagues()
        {
            if (!redisCache.IsCached(CacheStatics.Leagues))
            {
                ICollection<League> entities = await leagueRepo.GetAllAsync();

                IEnumerable<LeagueModel> models = autoMapper.MapCollection<League, LeagueModel>(entities);

                await redisCache.SetAsync(CacheStatics.Leagues, models, CacheStatics.LeaguesCacheTime);
            }

            return await redisCache.GetAsync<ICollection<LeagueModel>>(CacheStatics.Leagues);
        }

        public async Task<bool> TruncateLeaguesTable()
        {
            try
            {
                ICollection<LeagueModel> models = await GetAllLeagues();

                bool truncateResult = leagueRepo.ClearTable(autoMapper.MapCollection<LeagueModel, League>(models).ToList());

                if (!truncateResult)
                    leagueRepo.ExecuteSqlCommand("DBCC CHECKIDENT('Leagues', RESEED, 0)");

                return true;
            }
            catch (Exception ex)
            {
                //TODO: Log
                return false;
            }
        }

        public bool InsertLeagues(ICollection<LeagueModel> models)
        {
            try
            {
                List<League> insertData = autoMapper.MapCollection<LeagueModel, League>(models).ToList();

                insertData.ForEach(x => { x.CreatedDate = DateTime.Now; x.State = (int)State.Active; });

                leagueRepo.BulkInsert(insertData);

                return true;
            }
            catch (Exception ex)
            {
                //TODO: Log
                return false;
            }
        }

        public async Task<LeagueModel> GetLeagueWithApiId(int apiId)
        {
            var entity = await leagueRepo.FindAsync(x => x.ApiId == apiId);

            return autoMapper.MapObject<League, LeagueModel>(entity);
        }
    }
}
