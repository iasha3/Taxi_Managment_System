using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_Managment_System_BLL.DTOs.DriverDTO;
using Taxi_Managment_System_BLL.DTOs.DriverDTO;
using Taxi_Managment_System_BLL.Services.Interfaces;
using Taxi_Managment_System_DAL.Models;
using Taxi_Managment_System_DAL.UnitOfWork;
using Taxi_Managment_System_DAL.UnitOfWork.Interfaces;

namespace Taxi_Managment_System_BLL.Services
{
    public class DriverService : IDriverService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DriverService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<DriverGetDTO> InsertEntityAsync(DriverCreateDTO entity)
        {
            var driver = await _unitOfWork.DriverRepository.InsertEntityAsync(_mapper.Map<DriverCreateDTO, Driver>(entity));
            return _mapper.Map<Driver, DriverGetDTO>(driver);
        }

        public async Task<IEnumerable<DriverGetDTO>> DeleteEntityByIdAsync(Guid id)
        {
            var drivers = await _unitOfWork.DriverRepository.DeleteEntityByIdAsync(id);
            return _mapper.Map<IEnumerable<Driver>, IEnumerable<DriverGetDTO>>(drivers);
        }

        public async Task<DriverGetDTO> GetEntityByIdAsync(Guid id)
        {
            var driver = await _unitOfWork.DriverRepository.GetEntityByIdAsync(id);
            return _mapper.Map<Driver, DriverGetDTO>(driver);
        }

        public async Task<IEnumerable<DriverGetDTO>> GetAllInformationOfEntitiesAsync()
        {
            var drivers = await _unitOfWork.DriverRepository.GetAllInformationOfEntitiesAsync();
            return _mapper.Map<IEnumerable<Driver>, IEnumerable<DriverGetDTO>>(drivers);
        }

        public async Task<DriverGetDTO> UpdateEntityByIdAsync(DriverUpdateDTO entity)
        {
            var driver = await _unitOfWork.DriverRepository.UpdateEntityByIdAsync(_mapper.Map<DriverUpdateDTO, Driver>(entity));
            return _mapper.Map<Driver, DriverGetDTO>(driver);
        }

        public async Task<IEnumerable<DriverGetDTO>> SortByNameAsync()
        {
            var drivers = await _unitOfWork.DriverRepository.SortByNameAsync();
            return _mapper.Map<IEnumerable<Driver>, IEnumerable<DriverGetDTO>>(drivers);
        }
    }
}
