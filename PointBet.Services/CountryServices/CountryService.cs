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

namespace PointBet.Services.CountryServices
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAutoMapperConfiguration autoMapper;
        private readonly ICacheManager redisCache;

        private readonly IGenericRepository<Country> countryRepo;

        public CountryService(IUnitOfWork unitOfWork, IAutoMapperConfiguration autoMapper, ICacheManager redisCache)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
            this.redisCache = redisCache;

            countryRepo = this.unitOfWork.Repository<Country>();
        }

        public async Task<ICollection<CountryModel>> GetAllCountries()
        {
            if (!redisCache.IsCached(CacheStatics.Countries))
            {
                ICollection<Country> entities = await countryRepo.GetAllAsync();

                IEnumerable<CountryModel> models = autoMapper.MapCollection<Country, CountryModel>(entities);

                await redisCache.SetAsync(CacheStatics.Countries, models, CacheStatics.CountriesCacheTime);
            }

            return await redisCache.GetAsync<ICollection<CountryModel>>(CacheStatics.Countries);
        }

        public async Task<bool> TruncateCountriesTable()
        {
            try
            {
                ICollection<CountryModel> models = await GetAllCountries();

                bool truncateResult = countryRepo.ClearTable(autoMapper.MapCollection<CountryModel, Country>(models).ToList());

                if (!truncateResult)
                    countryRepo.ExecuteSqlCommand("DBCC CHECKIDENT('Countries', RESEED, 0)");

                return true;
            }
            catch (Exception ex)
            {
                //TODO: Log
                return false;
            }
        }

        public bool InsertCountries(ICollection<CountryModel> models)
        {
            try
            {
                List<Country> insertData = autoMapper.MapCollection<CountryModel, Country>(models).ToList();

                insertData.ForEach(x => { x.CreatedDate = DateTime.Now; x.State = (int)State.Active; });

                countryRepo.BulkInsert(insertData);

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
