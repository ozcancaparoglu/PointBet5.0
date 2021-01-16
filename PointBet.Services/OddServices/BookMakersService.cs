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
    public class BookMakersService : IBookMakersService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAutoMapperConfiguration autoMapper;
        private readonly ICacheManager redisCache;

        private readonly IGenericRepository<BookMakers> bookmakersRepo;
        public BookMakersService(IUnitOfWork unitOfWork, IAutoMapperConfiguration autoMapper, ICacheManager redisCache)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
            this.redisCache = redisCache;
            bookmakersRepo = this.unitOfWork.Repository<BookMakers>();
        }
        public async Task<ICollection<BookMakersModel>> GetAllBookMakers()
        {
            if (!redisCache.IsCached(CacheStatics.Countries))
            {
                ICollection<BookMakers> entities = await bookmakersRepo.GetAllAsync();

                IEnumerable<BookMakersModel> models = autoMapper.MapCollection<BookMakers, BookMakersModel>(entities);

                await redisCache.SetAsync(CacheStatics.Countries, models, CacheStatics.BookMakersTime);
            }

            return await redisCache.GetAsync<ICollection<BookMakersModel>>(CacheStatics.BookMakers);
        }

        public bool InsertBookMakers(ICollection<BookMakersModel> models)
        {
            try
            {
                List<BookMakers> insertData = autoMapper.MapCollection<BookMakersModel, BookMakers>(models).ToList();

                insertData.ForEach(x => { x.CreatedDate = DateTime.Now; x.State = (int)State.Active; });

                bookmakersRepo.BulkInsert(insertData);

                return true;
            }
            catch (Exception ex)
            {
                //TODO: Log
                return false;
            }
        }

        public async Task<bool> TruncateBookMakersTable()
        {
            try
            {
                ICollection<BookMakersModel> models = await GetAllBookMakers();

                bool truncateResult = bookmakersRepo.ClearTable(autoMapper.MapCollection<BookMakersModel, BookMakers>(models).ToList());

                if (!truncateResult)
                    bookmakersRepo.ExecuteSqlCommand("DBCC CHECKIDENT('BookMakers', RESEED, 0)");

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
