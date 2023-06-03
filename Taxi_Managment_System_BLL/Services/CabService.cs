using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_Managment_System_BLL.DTOs.CabDTO;
using Taxi_Managment_System_BLL.Services.Interfaces;
using Taxi_Managment_System_DAL.UnitOfWork.Interfaces;

namespace Taxi_Managment_System_BLL.Services
{
    public class CabService : ICabService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CabService(IMapper mapper, IUnitOfWork unitOfWork) { 
            _mapper = mapper; 
            _unitOfWork = unitOfWork;
        }
        public Task<CabGetDTO> Create(CabCreateDTO entity)
        {
        }

        public async Task<IEnumerable<CabGetDTO>> Delete(Guid id)
        {
            var cab = await _unitOfWork.
        }

        public Task<CabGetDTO> Get(Guid id)
        {
        }

        public Task<IEnumerable<CabGetDTO>> Get_all_Information()
        {
        }

        public Task<CabGetDTO> Update(Guid id, CabUpdateDTO entity)
        {
        }
    }
}
