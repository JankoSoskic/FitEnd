using FitEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.DataAccess.Configuration
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasIndex(x => x.Naziv).IsUnique();

            builder.Property(x => x.Naziv).IsRequired().HasMaxLength(30);
            builder.Property(x => x.AverageCalLost).IsRequired();

            builder.HasMany(x => x.PlanDetails).WithOne(x => x.Exercise).HasForeignKey(x => x.IdExercise).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.ExercisePics).WithOne(x => x.Exercise).HasForeignKey(x => x.IdExercise).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ExerciseType).WithMany(x => x.Exercises).HasForeignKey(x => x.IdType).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
