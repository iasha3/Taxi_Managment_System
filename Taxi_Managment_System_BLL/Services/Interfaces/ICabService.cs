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
        public Task<IEnumerable<CabGetDTO>> Get_all_Information();
        public Task<CabGetDTO> Get(Guid id);
        public Task<IEnumerable<CabGetDTO>> Delete(Guid id);
        public Task<CabGetDTO> Update(Guid id, CabUpdateDTO entity);
        public Task<CabGetDTO> Create(CabCreateDTO entity);
    }
}
