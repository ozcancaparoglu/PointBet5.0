using Common.Entities;

namespace PointBet.Services.BaseServices
{
    public interface IBaseFactory
    {
        IBaseService<TEntity, TModel> GetBaseService<TEntity, TModel>()
            where TEntity : EntityBase where TModel : EntityBaseModel;
    }
}