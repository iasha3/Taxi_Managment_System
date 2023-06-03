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
    internal class CabConfig : IEntityTypeConfiguration<Cab>
    {
        public void Configure(EntityTypeBuilder<Cab> builder)
        {
            builder.ToTable("cab");
            builder.Property(p => p.Id).IsRequired();
            builder.HasData(DataGenerator.Cabs);
        }
    }
}
