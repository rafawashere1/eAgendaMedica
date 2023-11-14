using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eAgendaMedica.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class InitialConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBActivity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBActivity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBDoctor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CRM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastActivity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBDoctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBActivity_TBDoctor",
                        column: x => x.CurrentActivityId,
                        principalTable: "TBActivity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActivityDoctor",
                columns: table => new
                {
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityDoctor", x => new { x.ActivityId, x.DoctorsId });
                    table.ForeignKey(
                        name: "FK_ActivityDoctor_TBActivity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "TBActivity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityDoctor_TBDoctor_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "TBDoctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityDoctor_DoctorsId",
                table: "ActivityDoctor",
                column: "DoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_TBDoctor_CurrentActivityId",
                table: "TBDoctor",
                column: "CurrentActivityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityDoctor");

            migrationBuilder.DropTable(
                name: "TBDoctor");

            migrationBuilder.DropTable(
                name: "TBActivity");
        }
    }
}
