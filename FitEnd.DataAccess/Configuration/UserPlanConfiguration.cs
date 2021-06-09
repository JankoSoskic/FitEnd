using FitEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.DataAccess.Configuration
{
    public class UserPlanConfiguration : IEntityTypeConfiguration<UserPlan>
    {
        public void Configure(EntityTypeBuilder<UserPlan> builder)
        {
            builder.Property(x => x.WeightGoal).IsRequired().HasMaxLength(10);
            builder.Property(x => x.TillWhen).IsRequired();
            builder.HasMany(x => x.Details).WithOne(x => x.PlanUser).HasForeignKey(x => x.IdPlan).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
