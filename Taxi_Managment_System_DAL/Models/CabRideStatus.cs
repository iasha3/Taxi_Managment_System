using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Taxi_Managment_System_DAL.Models.Base;

namespace Taxi_Managment_System_DAL.Models
{
    public class CabRideStatus :BaseEntity
    {
        public DateTime StatusTime { get; set; }
        public Guid CabRideId { get; set; }
        public Guid StatusCabRideId { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
