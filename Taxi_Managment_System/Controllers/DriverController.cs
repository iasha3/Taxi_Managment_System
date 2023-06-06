using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taxi_Managment_System_BLL.DTOs.DriverDTO;
using Taxi_Managment_System_BLL.DTOs.DriverDTO;
using Taxi_Managment_System_BLL.Services;
using Taxi_Managment_System_BLL.Services.Interfaces;

namespace Taxi_Managment_System.Controllers
{
    [Route("api/drivers")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }
        [HttpGet, Route("Get_all")]
        public async Task<ActionResult<IEnumerable<DriverGetDTO>>> GetAllAsync()
        {
            try
            {
                var result = await _driverService.GetAllInformationOfEntitiesAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Errors!", ex);
            }
        }

        [HttpGet, Route("GetById/{id}")]
        public async Task<ActionResult<DriverGetDTO>> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _driverService.GetEntityByIdAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Errors!", ex);
            }
        }

        [HttpPost, Route("Insert")]
        public async Task<ActionResult<DriverGetDTO>> InsertAsync(DriverCreateDTO driverDTO)
        {
            try
            {
                var result = await _driverService.InsertEntityAsync(driverDTO);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Errors!", ex);
            }
        }

        [HttpPut, Route("Update")]
        public async Task<ActionResult<DriverGetDTO>> UpdateEmployeeAsync(DriverUpdateDTO driverDTO)
        {
            try
            {
                var result = await _driverService.UpdateEntityByIdAsync(driverDTO);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Errors!", ex);
            }
        }

        [HttpDelete, Route("DeleteById")]
        public async Task<ActionResult<IEnumerable<DriverGetDTO>>> DeleteEmployeeByIdAsync(Guid Id)
        {
            try
            {
                var result = await _driverService.DeleteEntityByIdAsync(Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Errors!", ex);
            }
        }
        [HttpGet, Route("Get_All_Information_Sort_By_Name")]
        public async Task<ActionResult<IEnumerable<DriverGetDTO>>> SortByNameAsync()
        {
            try
            {
                var result = await _driverService.SortByNameAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Errors!", ex);
            }

        }

    }
}
