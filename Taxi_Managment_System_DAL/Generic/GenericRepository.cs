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
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> 
        where TEntity : BaseEntity
    {

        private DataContext _context;
        private DbSet<TEntity> _dbSet;
        public GenericRepository(DataContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task<TEntity> InsertEntityAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> DeleteEntityByIdAsync(Guid id)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                throw new Exception("Oops, not found");
            }
            _dbSet.Remove(result);
            await _context.SaveChangesAsync();
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetEntityByIdAsync(Guid id)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                throw new Exception("Oops, not found");
            }
            return result;
        }

        public async Task<IEnumerable<TEntity>> GetAllInformationOfEntitiesAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();

        }

        public async Task<TEntity> UpdateEntityByIdAsync(TEntity entity)
        {
            var result = await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (result == null)
            {
                throw new Exception("Oops, not found");
            }
            _dbSet.Entry(result).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
