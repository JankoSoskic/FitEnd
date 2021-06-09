using FitEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.Username).IsUnique();
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Ime).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Prezime).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(50);

            builder.HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.IdUloge);
            builder.HasMany(x => x.Plans).WithOne(x => x.User).HasForeignKey(x => x.IdUser);
            builder.HasMany(x => x.Weights).WithOne(x => x.User).HasForeignKey(x => x.IdUser);
        }
    }
}
