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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    Id = table.Column<int>(nullable: false),
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
