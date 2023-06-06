using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Taxi_Managment_System_DAL.Models.Base;

namespace Taxi_Managment_System_DAL.Models
{
    public class PaymentType:BaseEntity
    {
        public string NameType { get; set; } = string.Empty;
        public ICollection<CabRide> CabRides { get; set; } = null!;

       
    }
}
