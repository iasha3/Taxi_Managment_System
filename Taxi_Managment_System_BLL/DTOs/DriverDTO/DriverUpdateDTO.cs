using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_Managment_System_BLL.DTOs.DriverDTO
{
    public class DriverUpdateDTO : BaseEntityDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public string DrivingLicenceNumber { get; set; } = string.Empty;
        public DateOnly ExpiryDate { get; set; }
        public bool Working { get; set; }
    }
}
