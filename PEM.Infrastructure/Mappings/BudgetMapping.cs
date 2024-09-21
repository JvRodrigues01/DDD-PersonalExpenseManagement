using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PEM.Domain.Entities;

namespace PEM.Infrastructure.Mappings
{
    public class RecurringExpenseMapping : IEntityTypeConfiguration<RecurringExpense>
    {
        public void Configure(EntityTypeBuilder<RecurringExpense> builder)
        {
            builder.ToTable("RecurringExpenses");

            builder.HasKey(u => u.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(re => re.Description)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(re => re.Amount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(re => re.StartDate)
                .IsRequired();

            builder.Property(re => re.EndDate);

            builder.Property(re => re.Frequency)
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
                .WithMany(u => u.RecurringExpenses)
                .HasForeignKey(re => re.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
