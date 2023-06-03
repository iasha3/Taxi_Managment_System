using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_Managment_System_DAL.Data;
using Taxi_Managment_System_DAL.Generic.Interfaces;
using Taxi_Managment_System_DAL.Models.Base;

namespace Taxi_Managment_System_DAL.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {

        private DataContext _db;
        private DbSet<TEntity> _dbSet;
        public GenericRepository(DataContext context)
        {
            _db = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task<TEntity> Create(TEntity entity)
        {
            _dbSet.Add(entity);
            _db.SaveChanges();
            var createEntity = await _dbSet.FindAsync(entity.Id);
            return createEntity;
        }

        public async Task<IEnumerable<TEntity>> Delete(Guid id)
        {
            var entity2 = _dbSet.Find(id);
            _dbSet.Remove(entity2);
            await _db.SaveChangesAsync();
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> Get(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> Get_all_Information()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> Update(Guid id, TEntity entity)
        {
            var updateEntity = await _dbSet.FindAsync(id);
            _db.Entry(updateEntity).CurrentValues.SetValues(entity);
            _db.SaveChanges();
            return updateEntity;
        }
    }
}
