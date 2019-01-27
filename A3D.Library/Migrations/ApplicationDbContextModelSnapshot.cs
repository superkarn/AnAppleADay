﻿// <auto-generated />
using System;
using A3D.Library.Repositories.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace A3D.Library.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("A3D.Library.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<int>("CreatorId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("LastCompletedDate");

                    b.Property<DateTime>("LastModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("PrivacyId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<string>("Schedule");

                    b.Property<string>("ValueUnit");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("PrivacyId");

                    b.ToTable("Activities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatorId = 1,
                            IsActive = true,
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Test Activity",
                            PrivacyId = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatorId = 1,
                            IsActive = true,
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Exercise",
                            PrivacyId = 2
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatorId = 1,
                            IsActive = true,
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Read every day",
                            PrivacyId = 0,
                            ValueUnit = "Pages"
                        });
                });

            modelBuilder.Entity("A3D.Library.Models.ActivityInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<int>("CreatorId");

                    b.Property<DateTime>("LastModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Notes");

                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("StatusId");

                    b.ToTable("ActivityInstances");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ActivityId = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatorId = 1,
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StatusId = 0,
                            Value = "3"
                        },
                        new
                        {
                            Id = 2,
                            ActivityId = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatorId = 1,
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StatusId = 2,
                            Value = "1"
                        },
                        new
                        {
                            Id = 3,
                            ActivityId = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatorId = 1,
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StatusId = 3
                        });
                });

            modelBuilder.Entity("A3D.Library.Models.ActivityNotification", b =>
                {
                    b.Property<int>("ActivityId");

                    b.Property<int>("NotificationTypeId");

                    b.Property<bool>("IsEnabled")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Recipient")
                        .IsRequired();

                    b.HasKey("ActivityId", "NotificationTypeId");

                    b.HasIndex("NotificationTypeId");

                    b.ToTable("ActivityNotification");
                });

            modelBuilder.Entity("A3D.Library.Models.ActivityPrivacy", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("ActivityPrivacy");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Can be viewed only by owner",
                            Name = "Private"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Can be viewed by anybody",
                            Name = "Public"
                        });
                });

            modelBuilder.Entity("A3D.Library.Models.ActivityState", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("ActivityState");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Activity is active.  New ActivityInstances can be added.  Notifications will be sent on schedule.",
                            Name = "Active"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Activity is not active.  New ActivityInstances cannot be added.  Notifications will not be sent.",
                            Name = "Inactive"
                        });
                });

            modelBuilder.Entity("A3D.Library.Models.ActivityStatus", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("ActivityStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Activity Instance was skipped (not completed)",
                            Name = "Skipped"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Activity Instance was partially completed",
                            Name = "Partial"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Activity Instance was completed",
                            Name = "Completed"
                        });
                });

            modelBuilder.Entity("A3D.Library.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("ApplicationUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "karn@example.com",
                            IsActive = true,
                            Username = "karn"
                        },
                        new
                        {
                            Id = 2,
                            Email = "test@example.com",
                            IsActive = true,
                            Username = "test"
                        },
                        new
                        {
                            Id = 3,
                            Email = "test2@example.com",
                            IsActive = true,
                            Username = "test2"
                        });
                });

            modelBuilder.Entity("A3D.Library.Models.NotificationType", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("NotificationType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Send notification to an email address",
                            Name = "Email"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Send notification to a Sms device",
                            Name = "Sms"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Send notification via Broser Notification",
                            Name = "Browser"
                        });
                });

            modelBuilder.Entity("A3D.Library.Models.Activity", b =>
                {
                    b.HasOne("A3D.Library.Models.ApplicationUser", "Creator")
                        .WithMany("Activities")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("A3D.Library.Models.ActivityPrivacy", "Privacy")
                        .WithMany()
                        .HasForeignKey("PrivacyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("A3D.Library.Models.ActivityInstance", b =>
                {
                    b.HasOne("A3D.Library.Models.Activity", "Activity")
                        .WithMany("ActivityInstances")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("A3D.Library.Models.ApplicationUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("A3D.Library.Models.ActivityStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("A3D.Library.Models.ActivityNotification", b =>
                {
                    b.HasOne("A3D.Library.Models.Activity", "Activity")
                        .WithMany("ActivityNotifications")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("A3D.Library.Models.NotificationType", "NotificationType")
                        .WithMany()
                        .HasForeignKey("NotificationTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
