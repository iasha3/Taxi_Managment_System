using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_Managment_System_BLL.DTOs.DriverDTO;
using Taxi_Managment_System_BLL.DTOs.DriverDTO;

namespace Taxi_Managment_System_BLL.Services.Interfaces
{
    public interface IDriverService
    {
        Task<IEnumerable<DriverGetDTO>> GetAllInformationOfEntitiesAsync();
        Task<DriverGetDTO> GetEntityByIdAsync(Guid id);
        Task<IEnumerable<DriverGetDTO>> DeleteEntityByIdAsync(Guid id);
        Task<DriverGetDTO> UpdateEntityByIdAsync(DriverUpdateDTO entity);
        Task<DriverGetDTO> InsertEntityAsync(DriverCreateDTO entity);
        Task<IEnumerable<DriverGetDTO>> SortByNameAsync();
    }
}
