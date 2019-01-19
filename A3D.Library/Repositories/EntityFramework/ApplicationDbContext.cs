using A3D.Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace A3D.Library.Repositories.EntityFramework
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityInstance> ActivityInstances { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Table properties
            modelBuilder.Entity<Activity>().HasIndex(x => x.Name).IsUnique();
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

            modelBuilder.Entity<ActivityPrivacy>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<ActivityState>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<ActivityStatus>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<ApplicationUser>().HasIndex(x => x.Username).IsUnique();
            modelBuilder.Entity<ApplicationUser>().Property(x => x.Username).IsRequired();
            modelBuilder.Entity<ApplicationUser>().Property(x => x.IsActive).HasDefaultValue(true); // C# property is also defaulted to true
            modelBuilder.Entity<ApplicationUser>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<ApplicationUser>().Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()");
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
            
            modelBuilder.Entity<ActivityState>().HasData(new ActivityState { Id = 1, Name = "Active", Description = "Activity is active.  New ActivityInstances can be added.  Notifications will be sent on schedule." });
            modelBuilder.Entity<ActivityState>().HasData(new ActivityState { Id = 2, Name = "Inactive", Description = "Activity is not active.  New ActivityInstances cannot be added.  Notifications will not be sent." });

            modelBuilder.Entity<ActivityStatus>().HasData(new ActivityStatus { Id = 1, Name = "Skipped", Description = "Activity Instance was skipped (not completed)" });
            modelBuilder.Entity<ActivityStatus>().HasData(new ActivityStatus { Id = 2, Name = "Partial", Description = "Activity Instance was partially completed" });
            modelBuilder.Entity<ActivityStatus>().HasData(new ActivityStatus { Id = 3, Name = "Completed", Description = "Activity Instance was completed" });

            modelBuilder.Entity<NotificationType>().HasData(new NotificationType { Id = 1, Name = "Email", Description = "Send notification to an email address" });
            modelBuilder.Entity<NotificationType>().HasData(new NotificationType { Id = 2, Name = "Sms", Description = "Send notification to a Sms device" });
            modelBuilder.Entity<NotificationType>().HasData(new NotificationType { Id = 3, Name = "Browser", Description = "Send notification via Broser Notification" });
            #endregion

            #region Seeding test values
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = 1, Username = "karn", Email = "karn@example.com" });
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = 2, Username = "test", Email = "test@example.com" });
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser { Id = 3, Username = "test2", Email = "test2@example.com" });

            modelBuilder.Entity<Activity>().HasData(new Activity { Id = 1, CreatorId = 1, Name = "Test Activity" });
            modelBuilder.Entity<Activity>().HasData(new Activity { Id = 2, CreatorId = 1, Name = "Exercise", PrivacyId = 2 });
            modelBuilder.Entity<Activity>().HasData(new Activity { Id = 3, CreatorId = 1, Name = "Read every day", ValueUnit = "Pages" });

            modelBuilder.Entity<ActivityInstance>().HasData(new ActivityInstance { Id = 1, ActivityId = 1, CreatorId = 1, Value = "3" });
            modelBuilder.Entity<ActivityInstance>().HasData(new ActivityInstance { Id = 2, ActivityId = 1, CreatorId = 1, Value = "1", StatusId = 2 });
            modelBuilder.Entity<ActivityInstance>().HasData(new ActivityInstance { Id = 3, ActivityId = 1, CreatorId = 1, StatusId = 3 });
            #endregion
        }
    }
}
