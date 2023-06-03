using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_Managment_System_BLL.DTOs.DriverDTO;
using Taxi_Managment_System_BLL.Services.Interfaces;

namespace Taxi_Managment_System_BLL.Services
{
    public class DriverService : IDriverService
    {
        public Task<DriverGetDTO> Create(DriverCreateDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DriverGetDTO>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<DriverGetDTO> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DriverGetDTO>> Get_all_Information()
        {
            throw new NotImplementedException();
        }

        public Task<DriverGetDTO> Update(Guid id, DriverUpdateDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
