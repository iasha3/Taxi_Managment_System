using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_Managment_System_BLL.DTOs.CabDTO;

namespace Taxi_Managment_System_BLL.Services.Interfaces
{
    public interface ICabService
    {
        Task<IEnumerable<CabGetDTO>> GetAllInformationOfEntitiesAsync();
        Task<CabGetDTO> GetEntityByIdAsync(Guid id);
        Task<IEnumerable<CabGetDTO>> DeleteEntityByIdAsync(Guid id);
        Task<CabGetDTO> UpdateEntityByIdAsync(CabUpdateDTO entity);
        Task<CabGetDTO> InsertEntityAsync(CabCreateDTO entity);
        Task<IEnumerable<CabGetDTO>> SortByNameAsync();
    }
}
