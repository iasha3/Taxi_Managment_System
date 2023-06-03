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
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
