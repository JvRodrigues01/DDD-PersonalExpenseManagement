using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PEM.Domain.Entities;

namespace PEM.Infrastructure.Mappings
{
    public class NotificationMapping : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");

            builder.HasKey(u => u.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(n => n.Message)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(n => n.NotificationDate)
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

            builder.HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
