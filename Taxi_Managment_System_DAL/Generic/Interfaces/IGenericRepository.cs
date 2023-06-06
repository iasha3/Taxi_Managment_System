using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_Managment_System_DAL.Models.Base;

namespace Taxi_Managment_System_DAL.Generic.Interfaces
{
    public interface IGenericRepository<TEntity> 
        where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllInformationOfEntitiesAsync();
        Task<TEntity> GetEntityByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> DeleteEntityByIdAsync(Guid id);
        Task<TEntity> UpdateEntityByIdAsync(TEntity entity);
        Task<TEntity> InsertEntityAsync(TEntity entity);
    }
}
