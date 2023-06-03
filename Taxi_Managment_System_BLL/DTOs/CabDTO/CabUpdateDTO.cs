using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_Managment_System_BLL.DTOs.CabDTO
{
    public  class CabUpdateDTO :  BaseEntityDTO
    {
        public string LicensePlate { get; set; } = string.Empty;
        public int Manufacture_year { get; set; }
        public bool Active { get; set; }
        public string CarModel { get; set; } = string.Empty;

    }
}
