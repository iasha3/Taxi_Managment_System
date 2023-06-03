using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taxi_Managment_System_DAL.Models;

namespace Taxi_Managment_System_DAL.Data.Configurations
{
    internal class PaymentTypeConfig :IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.ToTable("payment_type");
            builder.Property(p=>p.Id).IsRequired();
            builder.HasData(DataGenerator.PaymentTypes);
        }
    }
}
