using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MutlubievAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CleaningStaffs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StaffName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    PersonalDPTApproval = table.Column<bool>(nullable: false),
                    IsActiveStaff = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ModificationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningStaffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ServiceName = table.Column<string>(nullable: true),
                    ServiceDescription = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ModificationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CleaningStaffs");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
