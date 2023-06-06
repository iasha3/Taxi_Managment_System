using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_Managment_System_DAL.Generic.Interfaces;
using Taxi_Managment_System_DAL.Models;
using Taxi_Managment_System_DAL.Repositories.Interfaces;

namespace Taxi_Managment_System_DAL.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ICabRepository CabRepository { get; }
        public IDriverRepository DriverRepository { get; }
        public Task<int> Save();
    }
}
