using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_Managment_System_DAL.Models;
using Taxi_Managment_System_DAL.Generator;

namespace Taxi_Managment_System_DAL.Data.Configurations
{
    internal class CabRideStatusConfig : IEntityTypeConfiguration<CabRideStatus>
    {
        public void Configure(EntityTypeBuilder<CabRideStatus> builder)
        {
            builder.ToTable("cab_ride_status");
            builder.Property(p => p.Id).IsRequired();
            builder.HasData(DataGenerator.CabRideStatuses);

            builder.HasOne(s => s.Status)
                .WithMany(c => c.CabRideStatuses)
                .HasForeignKey(s => s.StatusId);

            builder.HasOne(s => s.CabRide)
            .WithMany(c => c.CabRideStatuses)
            .HasForeignKey(s => s.CabRideId);
        }
    }
}
