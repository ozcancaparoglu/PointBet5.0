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

namespace PointBet.Services.TeamServices
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAutoMapperConfiguration autoMapper;
        private readonly ICacheManager redisCache;

        private readonly IGenericRepository<Team> teamRepo;

        public TeamService(IUnitOfWork unitOfWork, IAutoMapperConfiguration autoMapper, ICacheManager redisCache)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
            this.redisCache = redisCache;

            teamRepo = this.unitOfWork.Repository<Team>();
        }

        public async Task<ICollection<TeamModel>> GetAllTeams()
        {
            if (!redisCache.IsCached(CacheStatics.Teams))
            {
                ICollection<Team> entities = await teamRepo.GetAllAsync();

                IEnumerable<TeamModel> models = autoMapper.MapCollection<Team, TeamModel>(entities);

                await redisCache.SetAsync(CacheStatics.Teams, models, CacheStatics.TeamsCacheTime);
            }

            return await redisCache.GetAsync<ICollection<TeamModel>>(CacheStatics.Teams);
        }

        public async Task<bool> TruncateTeamsTable()
        {
            try
            {
                ICollection<TeamModel> models = await GetAllTeams();

                bool truncateResult = teamRepo.ClearTable(autoMapper.MapCollection<TeamModel, Team>(models).ToList());

                if (!truncateResult)
                    teamRepo.ExecuteSqlCommand("DBCC CHECKIDENT('Teams', RESEED, 0)");

                return true;
            }
            catch (Exception ex)
            {
                //TODO: Log
                return false;
            }
        }

        public bool InsertTeams(ICollection<TeamModel> models)
        {
            try
            {
                List<Team> insertData = autoMapper.MapCollection<TeamModel, Team>(models).ToList();

                insertData.ForEach(x => { x.CreatedDate = DateTime.Now; x.State = (int)State.Active; });

                teamRepo.BulkInsert(insertData);

                return true;
            }
            catch (Exception ex)
            {
                //TODO: Log
                return false;
            }
        }

        public async Task<TeamModel> GetTeamWithApiId(int apiId)
        {
            var entity = await teamRepo.FindAsync(x => x.ApiId == apiId);

            return autoMapper.MapObject<Team, TeamModel>(entity);
        }
    }
}
