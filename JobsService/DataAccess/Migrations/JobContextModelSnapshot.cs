﻿// <auto-generated />
using System;
using DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(JobContext))]
    partial class JobContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Argon")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.EntityFramework.Models.Action", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Actions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Approve"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Create"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Delete"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Import"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Issue"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Reject"
                        },
                        new
                        {
                            Id = 7,
                            Name = "RequestApproval"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Update"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Rollback"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Upload"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Download"
                        },
                        new
                        {
                            Id = 12,
                            Name = "BackendStateUpdate"
                        });
                });

            modelBuilder.Entity("DataAccess.EntityFramework.Models.ActionState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ActionDateTime");

                    b.Property<int>("ActionId");

                    b.Property<int>("EIN");

                    b.Property<int>("JobId");

                    b.Property<string>("Notes");

                    b.Property<int>("StatusId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("JobId");

                    b.HasIndex("StatusId");

                    b.ToTable("ActionStates");
                });

            modelBuilder.Entity("DataAccess.EntityFramework.Models.JobDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("EffectiveStartDate");

                    b.Property<string>("Identifier");

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("Type");

                    b.ToTable("JobDetails");
                });

            modelBuilder.Entity("DataAccess.EntityFramework.Models.JobIdentifierSequence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("JobIdentiferSequences");
                });

            modelBuilder.Entity("DataAccess.EntityFramework.Models.JobType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("JobTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "DISCOUNT_OFFER"
                        });
                });

            modelBuilder.Entity("DataAccess.EntityFramework.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "NEW"
                        },
                        new
                        {
                            Id = 2,
                            Name = "DRAFT"
                        },
                        new
                        {
                            Id = 3,
                            Name = "APPROVED"
                        },
                        new
                        {
                            Id = 4,
                            Name = "SUBMITTED"
                        },
                        new
                        {
                            Id = 5,
                            Name = "REJECTED"
                        },
                        new
                        {
                            Id = 6,
                            Name = "ISSUED"
                        },
                        new
                        {
                            Id = 7,
                            Name = "IMPORTED"
                        },
                        new
                        {
                            Id = 8,
                            Name = "PREPARING_TO_ISSUE"
                        },
                        new
                        {
                            Id = 9,
                            Name = "ARGON_PROCESSING_FAILED"
                        },
                        new
                        {
                            Id = 10,
                            Name = "DELETED"
                        },
                        new
                        {
                            Id = 11,
                            Name = "EXPIRED"
                        },
                        new
                        {
                            Id = 12,
                            Name = "SUPERSEDED"
                        });
                });

            modelBuilder.Entity("DataAccess.EntityFramework.Models.ActionState", b =>
                {
                    b.HasOne("DataAccess.EntityFramework.Models.Action", "Action")
                        .WithMany("ActionState")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.EntityFramework.Models.JobDetail", "JobDetail")
                        .WithMany("ActionStates")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.EntityFramework.Models.Status", "Status")
                        .WithMany("ActionState")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.EntityFramework.Models.JobDetail", b =>
                {
                    b.HasOne("DataAccess.EntityFramework.Models.JobType", "JobType")
                        .WithMany("JobDetails")
                        .HasForeignKey("Type")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
