using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Taxi_Managment_System_DAL.Models.Base;

namespace Taxi_Managment_System_DAL.Models
{
    public class Driver:BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string DrivingLicenceNumber { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set;  }
        public bool Working { get; set; }


        public ICollection<Shift> Shifts { get; set; } = null!;

        
    }
}
