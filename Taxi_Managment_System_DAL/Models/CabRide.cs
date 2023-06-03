using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Taxi_Managment_System_DAL.Models.Base;

namespace Taxi_Managment_System_DAL.Models
{
    public class CabRide : BaseEntity
    {
        public Guid ShiftId { get; set; }
        public Guid PaymentTypeId { get; set; }
        public string AddressStartingPoint { get; set; } = string.Empty;
        public string AddressDestination { get; set; } = string.Empty;
        public DateTime RideStartTime { get; set; }
        public DateTime RideEndTime { get; set; }
        public decimal Price { get; set; }
        public bool Canceled { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
