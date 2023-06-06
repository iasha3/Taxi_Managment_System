using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_Managment_System_DAL.Data;
using Taxi_Managment_System_DAL.Generic;
using Taxi_Managment_System_DAL.Generic.Interfaces;
using Taxi_Managment_System_DAL.Models;
using Taxi_Managment_System_DAL.Repositories;
using Taxi_Managment_System_DAL.Repositories.Interfaces;
using Taxi_Managment_System_DAL.UnitOfWork.Interfaces;

namespace Taxi_Managment_System_DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context) {
            _context = context;
            CabRepository = new CabRepository(_context);
            DriverRepository = new DriverRepository(_context);
        }
        public ICabRepository CabRepository { get; private set; }

        public IDriverRepository DriverRepository { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
