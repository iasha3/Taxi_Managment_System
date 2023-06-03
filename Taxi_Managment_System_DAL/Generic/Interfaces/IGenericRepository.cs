using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_Managment_System_DAL.Models.Base;

namespace Taxi_Managment_System_DAL.Generic.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<IEnumerable<TEntity>> Get_all_Information();
        public Task<TEntity> Get(Guid id);
        public Task<IEnumerable<TEntity>> Delete(Guid id);
        public Task<TEntity> Update(Guid id, TEntity entity);
        public Task<TEntity> Create(TEntity entity);
    }
}
