using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_Managment_System_DAL.Data;
using Taxi_Managment_System_DAL.Generic;
using Taxi_Managment_System_DAL.Models;
using Taxi_Managment_System_DAL.Repositories.Interfaces;

namespace Taxi_Managment_System_DAL.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        private DataContext _context;
        private DbSet<Driver> _drivers;

        public DriverRepository(DataContext context)
            : base(context)
        {
            _context = context;
            _drivers = _context.Set<Driver>();
        }

        public async Task<IEnumerable<Driver>> SortByNameAsync()
        {
            return await _drivers
                .OrderBy(x => x.FirstName)
                .AsNoTracking().ToListAsync();
        }
    }
}
