using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCourier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServiceStatus",
                table: "Pharmacies",
                newName: "OnDuty");

            migrationBuilder.RenameColumn(
                name: "OnServiceTime",
                table: "Pharmacies",
                newName: "OnDutyTime");

            migrationBuilder.RenameColumn(
                name: "OffServiceTime",
                table: "Pharmacies",
                newName: "OffDutyTime");

            migrationBuilder.AddColumn<bool>(
                name: "OffDuty",
                table: "Pharmacies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Couriers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnDuty = table.Column<bool>(type: "bit", nullable: false),
                    OffDuty = table.Column<bool>(type: "bit", nullable: false),
                    OnDutyTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OffDutyTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couriers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Couriers");

            migrationBuilder.DropColumn(
                name: "OffDuty",
                table: "Pharmacies");

            migrationBuilder.RenameColumn(
                name: "OnDutyTime",
                table: "Pharmacies",
                newName: "OnServiceTime");

            migrationBuilder.RenameColumn(
                name: "OnDuty",
                table: "Pharmacies",
                newName: "ServiceStatus");

            migrationBuilder.RenameColumn(
                name: "OffDutyTime",
                table: "Pharmacies",
                newName: "OffServiceTime");
        }
    }
}
