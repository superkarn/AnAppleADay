﻿using A3D.Library.Models;
using A3D.Library.Models.LookUp;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace A3D.Library.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityInstance> ActivityInstances { get; set; }
        public DbSet<ActivityNotification> ActivityNotifications { get; set; }

        public DbSet<ActivityPrivacy> ActivityPrivacies { get; set; }
        public DbSet<ActivityInstanceStatus> ActivityInstanceStatuses { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Make sure to call IdentityDbContext.OnModelCreating() so it can do its thing
            base.OnModelCreating(modelBuilder);

            #region Data tables
            modelBuilder.Entity<Activity>().HasIndex(x => new { x.CreatorId, x.Name }).IsUnique();
            modelBuilder.Entity<Activity>().Property(x => x.CreatorId).IsRequired();
            modelBuilder.Entity<Activity>().Property(x => x.IsActive).HasDefaultValue(true); // C# property is also defaulted to true
            modelBuilder.Entity<Activity>().Property(x => x.PrivacyId).HasDefaultValue(1);
            modelBuilder.Entity<Activity>().Property(x => x.Name).IsRequired();
            //modelBuilder.Entity<Activity>().Property(x => x.Description);
            //modelBuilder.Entity<Activity>().Property(x => x.ValueUnit);
            //modelBuilder.Entity<Activity>().Property(x => x.Schedule);
            modelBuilder.Entity<Activity>().Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<Activity>().Property(x => x.LastModifiedDate).HasDefaultValueSql("getutcdate()");
            //modelBuilder.Entity<Activity>().Property(x => x.LastCompletedDate);

            modelBuilder.Entity<ActivityInstance>().Property(x => x.ActivityId).HasDefaultValue(1);
            modelBuilder.Entity<ActivityInstance>().Property(x => x.CreatorId).IsRequired();
            modelBuilder.Entity<ActivityInstance>().Property(x => x.StatusId).HasDefaultValue(1);
            //modelBuilder.Entity<ActivityInstance>().Property(x => x.Value);
            //modelBuilder.Entity<ActivityInstance>().Property(x => x.Notes);
            modelBuilder.Entity<ActivityInstance>().Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()");
            modelBuilder.Entity<ActivityInstance>().Property(x => x.LastModifiedDate).HasDefaultValueSql("getutcdate()");

            modelBuilder.Entity<ActivityNotification>().HasKey(x => new { x.ActivityId, x.NotificationTypeId });
            modelBuilder.Entity<ActivityNotification>().Property(x => x.IsEnabled).HasDefaultValue(true); // C# property is also defaulted to true
            modelBuilder.Entity<ActivityNotification>().Property(x => x.Recipient).IsRequired();

            modelBuilder.Entity<ApplicationUser>().HasIndex(x => x.UserName).IsUnique();
            modelBuilder.Entity<ApplicationUser>().Property(x => x.UserName).IsRequired();
            modelBuilder.Entity<ApplicationUser>().Property(x => x.IsActive).HasDefaultValue(true); // C# property is also defaulted to true
            modelBuilder.Entity<ApplicationUser>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<ApplicationUser>().Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()");
            #endregion

            #region LookUp tables
            modelBuilder.Entity<ActivityPrivacy>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<ActivityPrivacy>().Property(x => x.Id).ValueGeneratedNever(); // LookUp tables do not have identity Ids

            modelBuilder.Entity<ActivityInstanceStatus>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<ActivityInstanceStatus>().Property(x => x.Id).ValueGeneratedNever(); // LookUp tables do not have identity Ids

            modelBuilder.Entity<NotificationType>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<NotificationType>().Property(x => x.Id).ValueGeneratedNever(); // LookUp tables do not have identity Ids
            #endregion

            #region Disable cascade delete
            // This is a workaround since EF 2.0 does not have a global setting to disable cascade delete.
            var cascadeFks = modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetForeignKeys())
                .Where(fk => fk.IsOwnership == false && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFks)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
            #endregion

            #region Seeding look up values.  Required by the application.
            modelBuilder.Entity<ActivityPrivacy>().HasData(new ActivityPrivacy { Id = 1, Name = "Private", Description = "Can be viewed only by owner" });
            modelBuilder.Entity<ActivityPrivacy>().HasData(new ActivityPrivacy { Id = 2, Name = "Public", Description = "Can be viewed by anybody" });

            modelBuilder.Entity<ActivityInstanceStatus>().HasData(new ActivityInstanceStatus { Id = 1, Name = "Skipped", Description = "Activity Instance was skipped (not completed)" });
            modelBuilder.Entity<ActivityInstanceStatus>().HasData(new ActivityInstanceStatus { Id = 2, Name = "Partial", Description = "Activity Instance was partially completed" });
            modelBuilder.Entity<ActivityInstanceStatus>().HasData(new ActivityInstanceStatus { Id = 3, Name = "Completed", Description = "Activity Instance was completed" });

            modelBuilder.Entity<NotificationType>().HasData(new NotificationType { Id = 1, Name = "Email", Description = "Send notification to an email address" });
            modelBuilder.Entity<NotificationType>().HasData(new NotificationType { Id = 2, Name = "Sms", Description = "Send notification to a Sms device" });
            modelBuilder.Entity<NotificationType>().HasData(new NotificationType { Id = 3, Name = "Browser", Description = "Send notification via Broser Notification" });
            #endregion

            #region Seeding test values
            var userId1 = "6761d1ea-06bb-4c3e-b24e-8a7865bf094b";
            var userId2 = "00000000-0000-0000-0000-000000000002";
            var userId3 = "00000000-0000-0000-0000-000000000003";

            // Password = Password1$
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser {
                Id = userId1,
                UserName = "superkarn@gmail.com",
                NormalizedUserName = "SUPERKARN@GMAIL.COM",
                Email = "superkarn@gmail.com",
                NormalizedEmail = "SUPERKARN@GMAIL.COM",
                PasswordHash = "AQAAAAEAACcQAAAAEKgE7GuPx6Xp3+6/itEA+GIYEVnxdMKCDMyuPFeXlH1sZiH1lZ+S2QO2fE2JYxOxpQ==",
                SecurityStamp = "BF6DFMXSJX3USJURBYD3EWOANZ4SUDDL",
                ConcurrencyStamp = "a9f508b7-ab66-4b2f-8d57-b73fd1ac898b"                
            });
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = userId2, UserName = "test", Email = "test@example.com" });
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = userId3, UserName = "test2", Email = "test2@example.com" });

            modelBuilder.Entity<Activity>().HasData(new Activity { Id = 1, CreatorId = userId1, Name = "Test Activity", Description = "Test activity...", ValueUnit = "Units" });
            modelBuilder.Entity<Activity>().HasData(new Activity { Id = 2, CreatorId = userId1, Name = "Exercise", Description = "Exercise description", PrivacyId = 2, ValueUnit = "Minutes" });
            modelBuilder.Entity<Activity>().HasData(new Activity { Id = 3, CreatorId = userId1, Name = "Read every day", Description = "Read read read", ValueUnit = "Pages" });
            modelBuilder.Entity<Activity>().HasData(new Activity { Id = 4, CreatorId = userId2, Name = "Test Activity" });
            modelBuilder.Entity<Activity>().HasData(new Activity { Id = 5, CreatorId = userId2, Name = "More test activities", PrivacyId = 2, ValueUnit = "Count" });

            modelBuilder.Entity<ActivityInstance>().HasData(new ActivityInstance { Id = 1, ActivityId = 1, CreatorId = 1, Value = "3" });
            modelBuilder.Entity<ActivityInstance>().HasData(new ActivityInstance { Id = 2, ActivityId = 1, CreatorId = 1, Value = "1", StatusId = 2 });
            modelBuilder.Entity<ActivityInstance>().HasData(new ActivityInstance { Id = 3, ActivityId = 1, CreatorId = 1, StatusId = 3 });

            modelBuilder.Entity<ActivityNotification>().HasData(new ActivityNotification { ActivityId = 1, NotificationTypeId = 1, IsEnabled = true, Recipient = "karn@example.com" });
            modelBuilder.Entity<ActivityNotification>().HasData(new ActivityNotification { ActivityId = 1, NotificationTypeId = 2, IsEnabled = false, Recipient = "111-111-1111" });
            modelBuilder.Entity<ActivityNotification>().HasData(new ActivityNotification { ActivityId = 2, NotificationTypeId = 1, IsEnabled = true, Recipient = "test@example.com" });
            modelBuilder.Entity<ActivityNotification>().HasData(new ActivityNotification { ActivityId = 2, NotificationTypeId = 2, IsEnabled = true, Recipient = "222-222-2222" });
            #endregion
        }
    }
}
