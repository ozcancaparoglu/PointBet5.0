using Common.Entities;
using Repository.Repositories;
using System.Threading.Tasks;

namespace Repository.Uof
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>() where T : EntityBase;
        int Commit();
        Task<int> CommitAsync();
        void Rollback();
    }
}