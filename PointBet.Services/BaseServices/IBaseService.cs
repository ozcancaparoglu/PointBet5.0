using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PointBet.Services.BaseServices
{
    public interface IBaseService<TEntity, TModel>
       where TEntity : EntityBase where TModel : EntityBaseModel
    {
        #region Crud Methods

        TModel GetById(int id);

        ICollection<TModel> GetAllActive();

        ICollection<TModel> GetAll();

        ICollection<TModel> GetWithFilter(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int? page = null, int? pageSize = null);

        TModel Create(TModel model);

        TModel Edit(TModel model);

        int ExecuteSqlCommand(string sql, params object[] parameters);

        TModel Delete(int id);

        void ChangeState(int objectId);

        void CreateList(ICollection<TModel> modelList);

        void EditList(ICollection<TModel> modelList);

        void EditOrInsertList(ICollection<TModel> modelList);

        void DeleteList(ICollection<TModel> modelList);

        void CreateRangeUof(ICollection<TModel> modelList);

        #endregion
    }
}