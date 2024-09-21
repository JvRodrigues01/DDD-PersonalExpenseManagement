using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PEM.Domain.Entities;

namespace PEM.Infrastructure.Mappings
{
    public class PaymentMethodMapping : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("PaymentMethods");

            builder.HasKey(u => u.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(re => re.Description)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(pm => pm.Description)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.Active)
                .IsRequired()
                .HasColumnType("tinyint"); 

            builder.Property(u => u.CreatedDate)
                .IsRequired()
                .HasColumnName("CreatedDate")
                .HasColumnType("SMALLDATETIME");

            builder.Property(u => u.LastUpdate)
                .IsRequired()
                .HasColumnName("LastUpdate")
                .HasColumnType("SMALLDATETIME");
        }
    }
}
