using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddVitalSign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VitalSign",
                columns: table => new
                {
                    VitalSignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NurseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temp = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Heart = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BloodPres = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Noted = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitalSign", x => x.VitalSignId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VitalSign");
        }
    }
}
