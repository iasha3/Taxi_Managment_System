using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taxi_Managment_System_BLL.DTOs.CabDTO;
using Taxi_Managment_System_BLL.Services.Interfaces;

namespace Taxi_Managment_System.Controllers
{
    [Route("api/cabs")]
    [ApiController]
    public class CabController : ControllerBase
    {
        private readonly ICabService _cabService;

        public CabController(ICabService cabService)
        {
            _cabService = cabService;
        }
        [HttpGet, Route("Get_all")]
        public async Task<ActionResult<IEnumerable<CabGetDTO>>> GetAllAsync()
        {
            try
            {
                var result = await _cabService.GetAllInformationOfEntitiesAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Errors!", ex);
            }
        }

        [HttpGet, Route("GetById/{id}")]
        public async Task<ActionResult<CabGetDTO>> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _cabService.GetEntityByIdAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Errors!", ex);
            }
        }

        [HttpPost, Route("Insert")]
        public async Task<ActionResult<CabGetDTO>> InsertAsync(CabCreateDTO cabDTO)
        {
            try
            {
                var result = await _cabService.InsertEntityAsync(cabDTO);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Errors!", ex);
            }
        }

        [HttpPut, Route("Update")]
        public async Task<ActionResult<CabGetDTO>> UpdateEmployeeAsync(CabUpdateDTO cabDTO)
        {
            try
            {
                var result = await _cabService.UpdateEntityByIdAsync(cabDTO);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Errors!", ex);
            }
        }

        [HttpDelete, Route("DeleteById")]
        public async Task<ActionResult<IEnumerable<CabGetDTO>>> DeleteEmployeeByIdAsync(Guid Id)
        {
            try
            {
                var result = await _cabService.DeleteEntityByIdAsync(Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Errors!", ex);
            }
        }
        [HttpGet, Route("Get_All_Information_Sort_By_Name")]
        public async Task<ActionResult<IEnumerable<CabGetDTO>>> SortByNameAsync()
        {
            try
            {
                var result = await _cabService.SortByNameAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Errors!", ex);
            }

        }

    }
}
