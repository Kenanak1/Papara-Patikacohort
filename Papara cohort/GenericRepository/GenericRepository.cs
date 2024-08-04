using Microsoft.EntityFrameworkCore;
using Papara_cohort.Base;
using Papara_cohort.Context;
using Papara_cohort.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papara_cohort
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly PaparacohortDbContext dbContext;
        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(PaparacohortDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public async Task Delete(int Id)
        {
            var entity = await dbSet.FirstOrDefaultAsync(x => x.Id == Id);
            if (entity != null)
            {
                dbSet.Remove(entity);

            }
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }


        public async Task<TEntity> GetById(int Id)
        {
            return await dbSet.FindAsync(Id); 
        }

        public async Task Insert(TEntity entity)
        {
            await dbSet.AddAsync(entity);

        }

        public async Task Save()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }
    }
}
