using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PEM.Domain.Entities;

namespace PEM.Infrastructure.Mappings
{
    public class BudgetMapping : IEntityTypeConfiguration<Budget>
    {
        public void Configure(EntityTypeBuilder<Budget> builder)
        {
            builder.ToTable("Budgets");

            builder.HasKey(u => u.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Amount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(b => b.Period)
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

            builder.HasOne(re => re.User)
                .WithMany(u => u.Budgets)
                .HasForeignKey(re => re.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
