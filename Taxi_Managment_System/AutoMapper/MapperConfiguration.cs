using AutoMapper;
using Taxi_Managment_System_BLL.DTOs.CabDTO;
using Taxi_Managment_System_BLL.DTOs.DriverDTO;
using Taxi_Managment_System_DAL.Models;

namespace Taxi_Managment_System.AutoMapper
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration() {
            CreateMap<DriverUpdateDTO, Driver>();
            CreateMap<DriverCreateDTO, Driver>();
            CreateMap<Driver, DriverGetDTO>();
            CreateMap<CabUpdateDTO, Cab>();
            CreateMap<CabCreateDTO, Cab>();
            CreateMap<Cab, CabGetDTO>();
        }
    }
}
