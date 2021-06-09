using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FitEnd.Domain.Entities;
using FitEnd.DataAccess.Configuration;

namespace FitEnd.DataAccess
{
    public class Context : DbContext
    {
        public DbSet<AllowedUseCase> AllowedUseCases { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExercisePictures> ExercisePictures { get; set; }
        public DbSet<ExerciseType> ExerciseTypes { get; set; }
        public DbSet<PlanDetail> PlanDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UseCase> UseCases { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPlan> UserPlans { get; set; }
        public DbSet<UserWeights> UserWeights { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=Localhost;Initial Catalog=FitEndDB;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserPlanConfiguration());
            modelBuilder.ApplyConfiguration(new UseCaseConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new TypeExerciseConfiguration());
            modelBuilder.ApplyConfiguration(new WeightsUserConfiguration());
            modelBuilder.ApplyConfiguration(new PlanDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new ExercisePicsConfiguration());


            modelBuilder.Entity<Exercise>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<ExercisePictures>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<ExerciseType>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<PlanDetail>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<UserPlan>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<UserWeights>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<AllowedUseCase>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<UseCase>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Role>().HasQueryFilter(x => !x.IsDeleted);

        }
        public override int SaveChanges()
        {
            foreach(var obj in ChangeTracker.Entries())
            {
                if (obj.Entity is Entity entitet)
                {
                    switch (obj.State)
                    {
                        case EntityState.Added:
                            entitet.DeletedAt = null;
                            entitet.CreatedAt = DateTime.UtcNow;
                            entitet.IsDeleted = false;
                            entitet.ModifiedAt = null;
                        break;
                        case EntityState.Modified:
                            entitet.ModifiedAt = DateTime.UtcNow;
                        break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
