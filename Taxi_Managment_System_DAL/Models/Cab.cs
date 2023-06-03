using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Taxi_Managment_System_DAL.Models.Base;

namespace Taxi_Managment_System_DAL.Models
{
    public class Cab: BaseEntity
    {
        public string LicensePlate { get; set; } = string.Empty;
        public int Manufacture_year { get; set; }
        public bool Active { get; set; }
        public string CarModel { get; set; } = string.Empty;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
