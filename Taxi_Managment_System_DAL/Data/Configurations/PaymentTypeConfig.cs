using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taxi_Managment_System_DAL.Models;
using Taxi_Managment_System_DAL.Generator;

namespace Taxi_Managment_System_DAL.Data.Configurations
{
    internal class PaymentTypeConfig :IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.ToTable("payment_type");
            builder.Property(p=>p.Id).IsRequired();
            builder.HasData(DataGenerator.PaymentTypes);

            builder.HasMany(c => c.CabRides)
                .WithOne(s => s.PaymentType)
                .HasForeignKey(s => s.PaymentTypeId);
        }
    }
}
