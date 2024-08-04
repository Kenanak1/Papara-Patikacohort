using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Papara_cohort.Base;

namespace Papara_cohort.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int Id);
        Task Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task Delete(int Id);
        Task Save();
    }
}
