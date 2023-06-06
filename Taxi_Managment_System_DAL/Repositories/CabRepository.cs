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
    public class CabRepository : GenericRepository<Cab>, ICabRepository
    {
        private DataContext _context;
        private DbSet<Cab> _cabs;

        public CabRepository(DataContext context)
            : base(context)
        {
            _context = context;
            _cabs = _context.Set<Cab>();
        }

        public async Task<IEnumerable<Cab>> SortByNameAsync()
        {
            return await _cabs
                .OrderBy(x => x.CarModel)
                .AsNoTracking().ToListAsync();
        }
    }
}
