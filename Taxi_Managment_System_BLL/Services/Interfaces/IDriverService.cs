using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_Managment_System_BLL.DTOs.DriverDTO;

namespace Taxi_Managment_System_BLL.Services.Interfaces
{
    public interface IDriverService
    {
        public Task<IEnumerable<DriverGetDTO>> Get_all_Information();
        public Task<DriverGetDTO> Get(Guid id);
        public Task<IEnumerable<DriverGetDTO>> Delete(Guid id);
        public Task<DriverGetDTO> Update(Guid id, DriverUpdateDTO entity);
        public Task<DriverGetDTO> Create(DriverCreateDTO entity);
    }
}
