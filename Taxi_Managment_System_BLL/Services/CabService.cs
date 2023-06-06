using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_Managment_System_BLL.DTOs.CabDTO;
using Taxi_Managment_System_BLL.Services.Interfaces;
using Taxi_Managment_System_DAL.Models;
using Taxi_Managment_System_DAL.UnitOfWork;
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
        public async Task<CabGetDTO> InsertEntityAsync(CabCreateDTO entity)
        {
            var cab = await _unitOfWork.CabRepository.InsertEntityAsync(_mapper.Map<CabCreateDTO, Cab>(entity));
            return _mapper.Map<Cab, CabGetDTO>(cab);
        }

        public async Task<IEnumerable<CabGetDTO>> DeleteEntityByIdAsync(Guid id)
        {
            var cabs = await _unitOfWork.CabRepository.DeleteEntityByIdAsync(id);
            return _mapper.Map<IEnumerable<Cab>, IEnumerable<CabGetDTO>>(cabs);
        }

        public async Task<CabGetDTO> GetEntityByIdAsync(Guid id)
        {
            var cab = await _unitOfWork.CabRepository.GetEntityByIdAsync(id);
            return _mapper.Map<Cab, CabGetDTO>(cab);
        }

        public async Task<IEnumerable<CabGetDTO>> GetAllInformationOfEntitiesAsync()
        {
            var cabs = await _unitOfWork.CabRepository.GetAllInformationOfEntitiesAsync();
            return _mapper.Map<IEnumerable<Cab>, IEnumerable<CabGetDTO>>(cabs);
        }

        public async Task<CabGetDTO> UpdateEntityByIdAsync(CabUpdateDTO entity)
        {
            var cab = await _unitOfWork.CabRepository.UpdateEntityByIdAsync(_mapper.Map<CabUpdateDTO, Cab>(entity));
            return _mapper.Map<Cab, CabGetDTO>(cab);
        }

        public async Task<IEnumerable<CabGetDTO>> SortByNameAsync()
        {
            var cabs = await _unitOfWork.CabRepository.SortByNameAsync();
            return _mapper.Map<IEnumerable<Cab>, IEnumerable<CabGetDTO>>(cabs);
        }
    }
}
