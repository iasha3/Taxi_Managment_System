using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Taxi_Managment_System_DAL.Models.Base;

namespace Taxi_Managment_System_DAL.Models
{
    public class Shift:BaseEntity
    {
        public Guid DriverId { get; set; }
        public Guid CabId { get; set; }
        public DateTime ShiftStartTime { get; set; }
        public DateTime ShiftEndTime { get; set; }

        public Driver Driver { get; set; } = null!;
        public Cab Cab { get; set; } = null!;
        public ICollection<CabRide> CabRides { get; set; } = null!; 
        
    }
}
