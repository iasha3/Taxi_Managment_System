using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_Managment_System_DAL.Models;

namespace Taxi_Managment_System_DAL.Data.Configurations
{
    internal class CabRideConfig : IEntityTypeConfiguration<CabRide>
    {
        public void Configure(EntityTypeBuilder<CabRide> builder)
        {
            builder.ToTable("cab_ride");
            builder.Property(p => p.Id).IsRequired();
            builder.HasData(DataGenerator.CabRides);
        }
    }
}
