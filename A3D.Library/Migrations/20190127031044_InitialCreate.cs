using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace A3D.Library.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityPrivacy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityPrivacy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityState",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    Email = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatorId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true),
                    PrivacyId = table.Column<int>(nullable: false, defaultValue: 1),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ValueUnit = table.Column<string>(nullable: true),
                    Schedule = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    LastCompletedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_ApplicationUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activities_ActivityPrivacy_PrivacyId",
                        column: x => x.PrivacyId,
                        principalTable: "ActivityPrivacy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityInstances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityId = table.Column<int>(nullable: false, defaultValue: 1),
                    CreatorId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false, defaultValue: 1),
                    Value = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    LastModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityInstances_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityInstances_ApplicationUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityInstances_ActivityStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ActivityStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityNotification",
                columns: table => new
                {
                    ActivityId = table.Column<int>(nullable: false),
                    NotificationTypeId = table.Column<int>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false, defaultValue: true),
                    Recipient = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityNotification", x => new { x.ActivityId, x.NotificationTypeId });
                    table.ForeignKey(
                        name: "FK_ActivityNotification_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityNotification_NotificationType_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalTable: "NotificationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ActivityPrivacy",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Can be viewed only by owner", "Private" },
                    { 2, "Can be viewed by anybody", "Public" }
                });

            migrationBuilder.InsertData(
                table: "ActivityState",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Activity is active.  New ActivityInstances can be added.  Notifications will be sent on schedule.", "Active" },
                    { 2, "Activity is not active.  New ActivityInstances cannot be added.  Notifications will not be sent.", "Inactive" }
                });

            migrationBuilder.InsertData(
                table: "ActivityStatus",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Activity Instance was skipped (not completed)", "Skipped" },
                    { 2, "Activity Instance was partially completed", "Partial" },
                    { 3, "Activity Instance was completed", "Completed" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "Email", "IsActive", "Username" },
                values: new object[] { 1, "karn@example.com", true, "karn" });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "Email", "IsActive", "Username" },
                values: new object[] { 2, "test@example.com", true, "test" });

            migrationBuilder.InsertData(
                table: "ApplicationUsers",
                columns: new[] { "Id", "Email", "IsActive", "Username" },
                values: new object[] { 3, "test2@example.com", true, "test2" });

            migrationBuilder.InsertData(
                table: "NotificationType",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Send notification to an email address", "Email" },
                    { 2, "Send notification to a Sms device", "Sms" },
                    { 3, "Send notification via Broser Notification", "Browser" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "CreatorId", "Description", "IsActive", "LastCompletedDate", "Name", "Schedule", "ValueUnit" },
                values: new object[] { 1, 1, null, true, null, "Test Activity", null, null });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "CreatorId", "Description", "IsActive", "LastCompletedDate", "Name", "PrivacyId", "Schedule", "ValueUnit" },
                values: new object[] { 2, 1, null, true, null, "Exercise", 2, null, null });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "CreatorId", "Description", "IsActive", "LastCompletedDate", "Name", "Schedule", "ValueUnit" },
                values: new object[] { 3, 1, null, true, null, "Read every day", null, "Pages" });

            migrationBuilder.InsertData(
                table: "ActivityInstances",
                columns: new[] { "Id", "ActivityId", "CreatorId", "Notes", "Value" },
                values: new object[] { 1, 1, 1, null, "3" });

            migrationBuilder.InsertData(
                table: "ActivityInstances",
                columns: new[] { "Id", "ActivityId", "CreatorId", "Notes", "StatusId", "Value" },
                values: new object[] { 2, 1, 1, null, 2, "1" });

            migrationBuilder.InsertData(
                table: "ActivityInstances",
                columns: new[] { "Id", "ActivityId", "CreatorId", "Notes", "StatusId", "Value" },
                values: new object[] { 3, 1, 1, null, 3, null });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CreatorId",
                table: "Activities",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_Name",
                table: "Activities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_PrivacyId",
                table: "Activities",
                column: "PrivacyId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInstances_ActivityId",
                table: "ActivityInstances",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInstances_CreatorId",
                table: "ActivityInstances",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInstances_StatusId",
                table: "ActivityInstances",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityNotification_NotificationTypeId",
                table: "ActivityNotification",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityPrivacy_Name",
                table: "ActivityPrivacy",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityState_Name",
                table: "ActivityState",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityStatus_Name",
                table: "ActivityStatus",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_Username",
                table: "ApplicationUsers",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationType_Name",
                table: "NotificationType",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityInstances");

            migrationBuilder.DropTable(
                name: "ActivityNotification");

            migrationBuilder.DropTable(
                name: "ActivityState");

            migrationBuilder.DropTable(
                name: "ActivityStatus");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "NotificationType");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "ActivityPrivacy");
        }
    }
}
