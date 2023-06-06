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
    internal class CabRideConfig : IEntityTypeConfiguration<CabRide>
    {
        public void Configure(EntityTypeBuilder<CabRide> builder)
        {
            builder.ToTable("cab_ride");
            builder.Property(p => p.Id).IsRequired();
            builder.HasData(DataGenerator.CabRides);
            builder.Property(c => c.Price).HasColumnType("decimal(10,2)");

            builder.HasOne(s => s.Shift)
            .WithMany(c => c.CabRides)
            .HasForeignKey(s => s.ShiftId);

            builder.HasOne(s => s.PaymentType)
            .WithMany(c => c.CabRides)
            .HasForeignKey(s => s.PaymentTypeId);

            builder.HasMany(c => c.CabRideStatuses)
            .WithOne(s => s.CabRide)
            .HasForeignKey(s => s.CabRideId);
        }
    }
}
