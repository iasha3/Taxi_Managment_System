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

        public Shift Shift { get; set; } = null!;
        public PaymentType PaymentType { get; set; } = null!;

        public ICollection<CabRideStatus> CabRideStatuses { get; set; } = null!;
        
    }
}
