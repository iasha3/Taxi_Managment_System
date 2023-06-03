using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_Managment_System_DAL.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public void Save();
        public void Dispose();
    }
}
