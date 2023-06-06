using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_Managment_System_DAL.Generic.Interfaces;
using Taxi_Managment_System_DAL.Models;

namespace Taxi_Managment_System_DAL.Repositories.Interfaces
{
    public interface IDriverRepository : IGenericRepository<Driver>
    {
        Task<IEnumerable<Driver>> SortByNameAsync();
    }
}
