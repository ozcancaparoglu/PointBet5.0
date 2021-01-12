using Common.Entities;
using Common.Enums;
using DataAccessLayer.AutoMapperConfig;
using DataAccessLayer.Repositories;
using DataAccessLayer.Uof;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PointBet.Services.BaseServices
{
    public class BaseService<TEntity, TModel> : IBaseService<TEntity, TModel> where TEntity : EntityBase where TModel : EntityBaseModel
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAutoMapperConfiguration autoMapper;

        private readonly IGenericRepository<TEntity> repo;

        public BaseService(IUnitOfWork unitOfWork, IAutoMapperConfiguration autoMapper)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;

            repo = this.unitOfWork.Repository<TEntity>();
        }

        #region Crud Methods

        public IQueryable<TEntity> Table()
        {
            return repo.Table();
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return repo.ExecuteSqlCommand(sql, parameters);
        }

        public TModel GetById(int id)
        {
            return autoMapper.MapObject<TEntity, TModel>(repo.GetById(id));
        }

        public ICollection<TModel> GetAllActive()
        {
            return autoMapper.MapCollection<TEntity, TModel>(repo.FindAll(x => x.State == (int)State.Active)).ToList();
        }

        public ICollection<TModel> GetAll()
        {
            return autoMapper.MapCollection<TEntity, TModel>(repo.Filter(null, null, "")).ToList();
        }

        public ICollection<TModel> GetWithFilter(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int? page = null, int? pageSize = null)
        {
            return autoMapper.MapCollection<TEntity, TModel>(repo.Filter(filter, orderBy, includeProperties, page, pageSize)).ToList();
        }

        public TModel Create(TModel model)
        {
            var entity = autoMapper.MapObject<TModel, TEntity>(model);

            var savedEntity = repo.Add(entity);

            return autoMapper.MapObject<TEntity, TModel>(savedEntity);
        }

        public void CreateList(ICollection<TModel> modelList)
        {
            try
            {
                var entities = autoMapper.MapCollection<TModel, TEntity>(modelList);

                repo.BulkInsert(entities.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CreateRangeUof(ICollection<TModel> modelList)
        {
            try
            {
                var entities = autoMapper.MapCollection<TModel, TEntity>(modelList);

                repo.AddRange(entities.ToList());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TModel Edit(TModel model)
        {
            var entity = autoMapper.MapObject<TModel, TEntity>(model);

            var savedEntity = repo.Update(entity);

            return autoMapper.MapObject<TEntity, TModel>(savedEntity);
        }

        public void EditList(ICollection<TModel> modelList)
        {
            try
            {
                var entities = autoMapper.MapCollection<TModel, TEntity>(modelList);

                repo.BulkUpdate(entities.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EditOrInsertList(ICollection<TModel> modelList)
        {
            try
            {
                var entities = autoMapper.MapCollection<TModel, TEntity>(modelList);

                repo.BulkInsertOrUpdate(entities.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TModel Delete(int id)
        {
            var entity = repo.GetById(id);

            entity.State = (int)State.Deleted;

            return autoMapper.MapObject<TEntity, TModel>(repo.Update(entity));
        }

        public void DeleteList(ICollection<TModel> modelList)
        {
            try
            {
                var entities = autoMapper.MapCollection<TModel, TEntity>(modelList);

                repo.BulkDelete(entities.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ChangeState(int objectId)
        {
            var entity = repo.GetById(objectId);

            if (entity.State == (int)State.Active)
                entity.State = (int)State.Passive;

            else
                entity.State = (int)State.Active;

            repo.Update(entity);
        }

        #endregion


    }
}
