using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PEM.Domain.Entities;

namespace PEM.Infrastructure.Mappings
{
    public class ExpenseMapping : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("Expenses");

            builder.HasKey(u => u.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Description)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Amount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(e => e.IsMonthly)
                .IsRequired();

            builder.Property(e => e.Category)
                .IsRequired();

            builder.Property(e => e.IsPaid)
                .IsRequired();

            builder.Property(e => e.PaymentDate);

            builder.Property(e => e.InstallmentCount)
                .IsRequired();

            builder.Property(e => e.CurrentInstallment)
                .IsRequired();

            builder.Property(e => e.EndDate)
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

            builder.HasOne(e => e.User)
                .WithMany(u => u.Expenses)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
