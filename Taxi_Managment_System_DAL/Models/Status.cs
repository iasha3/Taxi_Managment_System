﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Taxi_Managment_System_DAL.Models.Base;

namespace Taxi_Managment_System_DAL.Models
{
    public class Status:BaseEntity
    {
        public string StatusName { get; set; } = string.Empty;

        public ICollection<CabRideStatus> CabRideStatuses { get; set; } = null!; 
               
    }
}
