using Common.Entities;
using DataAccessLayer.AutoMapperConfig;
using DataAccessLayer.Uof;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PointBet.Services.BaseServices
{
    public class BaseFactory : IBaseFactory
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAutoMapperConfiguration _autoMapper;
        private readonly Dictionary<Type, object> _baseService = new Dictionary<Type, object>();

        public Dictionary<Type, object> CrudOperations
        {
            get { return _baseService; }
            set { CrudOperations = value; }
        }

        public BaseFactory(IUnitOfWork unitOfWork, IAutoMapperConfiguration autoMapper)
        {
            _unitOfWork = unitOfWork;
            _autoMapper = autoMapper;
        }

        public IBaseService<TEntity, TModel> GetBaseService<TEntity, TModel>()
            where TEntity : EntityBase where TModel : EntityBaseModel
        {
            if (CrudOperations.Keys.Contains(typeof(TEntity)))
            {
                return CrudOperations[typeof(TEntity)] as IBaseService<TEntity, TModel>;
            }

            IBaseService<TEntity, TModel> service = new BaseService<TEntity, TModel>(_unitOfWork, _autoMapper);
            CrudOperations.Add(typeof(TEntity), service);
            return service;
        }
    }
}
