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
    internal class ShiftConfig : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.ToTable("shift");
            builder.Property(p => p.Id).IsRequired();
            builder.HasData(DataGenerator.Shifts);

            builder.HasOne(s => s.Cab) 
            .WithMany(c => c.Shifts) 
            .HasForeignKey(s => s.CabId);

            builder.HasOne(s => s.Driver)
           .WithMany(c => c.Shifts)
           .HasForeignKey(s => s.DriverId);

            builder.HasMany(c => c.CabRides)
            .WithOne(s => s.Shift)
            .HasForeignKey(s => s.ShiftId);

        }
    }
}
