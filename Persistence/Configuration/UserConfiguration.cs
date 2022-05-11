using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(e => e.UserId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(e => e.Name)
                .HasMaxLength(256)
                .IsRequired()
                .HasColumnType("varchar(256)");

            builder.Property(e => e.Email)
                .HasMaxLength(256)
                .IsRequired()
                .HasColumnType("varchar(256)");

            builder.Property(e => e.Password)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(e => e.State)
                .HasMaxLength(2)
                .IsRequired()
                .HasColumnType("varchar(2)");
        }
    }
}