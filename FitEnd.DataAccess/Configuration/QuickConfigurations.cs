using FitEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.DataAccess.Configuration
{
    public class UseCaseConfiguration : IEntityTypeConfiguration<UseCase>
    {
        public void Configure(EntityTypeBuilder<UseCase> builder)
        {

            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.HasMany(x => x.AllowedUseCases).WithOne(x => x.UseCase).HasForeignKey(x => x.IdUseCase).OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {

            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.HasMany(x => x.AllowedUseCase).WithOne(x => x.Uloga).HasForeignKey(x => x.IdRole).OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class TypeExerciseConfiguration : IEntityTypeConfiguration<ExerciseType>
    {
        public void Configure(EntityTypeBuilder<ExerciseType> builder)
        {

            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
    public class WeightsUserConfiguration : IEntityTypeConfiguration<UserWeights>
    {
        public void Configure(EntityTypeBuilder<UserWeights> builder)
        {
            builder.Property(x => x.Weight).IsRequired().HasMaxLength(10);
        }
    }
    public class PlanDetailsConfiguration : IEntityTypeConfiguration<PlanDetail>
    {
        public void Configure(EntityTypeBuilder<PlanDetail> builder)
        {
            builder.Property(x => x.Repetitions).IsRequired();
            builder.Property(x => x.WhenWorking).IsRequired();
        }
    }
   
    public class ExercisePicsConfiguration : IEntityTypeConfiguration<ExercisePictures>
    {
        public void Configure(EntityTypeBuilder<ExercisePictures> builder)
        {
            builder.Property(x => x.Src).IsRequired();
            builder.Property(x => x.Alt).IsRequired();
        }
    }
}
