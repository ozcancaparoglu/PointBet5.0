using Common.Entities;
using DataAccessLayer.Repositories;
using System.Threading.Tasks;

namespace DataAccessLayer.Uof
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>() where T : EntityBase;
        int Commit();
        Task<int> CommitAsync();
        void Rollback();
    }
}