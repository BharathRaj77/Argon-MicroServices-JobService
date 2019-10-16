using DataAccess.EntityFramework.Models;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Action = DataAccess.EntityFramework.Models.Action;

namespace DataAccess.EntityFramework
{
    public class JobContext : DbContext
    {        
        public JobContext(DbContextOptions<JobContext> options)
            : base(options)
        {
        }
        public DbSet<JobDetail> JobDetails { get; set; }
        public DbSet<ActionState> ActionStates { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<JobIdentifierSequence> JobIdentifierSequences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedEnumValues<Action, ActionTypeEnum>(e => e);
            modelBuilder.SeedEnumValues<Status, StatusTypeEnum>(e => e);
            modelBuilder.SeedEnumValues<JobType, JobTypeEnum>(e => e);
            modelBuilder.HasDefaultSchema("Argon");
            modelBuilder.Entity<JobDetail>()
                .ToTable("JobDetails");

            modelBuilder.Entity<ActionState>()
                .ToTable("ActionStates");

            modelBuilder.Entity<Action>()
                .ToTable("Actions");

            modelBuilder.Entity<JobType>()
                .ToTable("JobTypes");

            modelBuilder.Entity<Status>()
                .ToTable("Statuses");

            modelBuilder.Entity<JobIdentifierSequence>()
                .ToTable("JobIdentiferSequences");
        }
    }
}
