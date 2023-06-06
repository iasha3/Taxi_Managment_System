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
    internal class StatusConfig : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("status");
            builder.Property(p => p.Id).IsRequired();
            builder.HasData(DataGenerator.Statuses);

            builder.HasMany(c => c.CabRideStatuses)
            .WithOne(s => s.Status)
            .HasForeignKey(s => s.StatusId);
        }
    }
}
