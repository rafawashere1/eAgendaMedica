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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    StartDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBDoctor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBDoctor_TBActivity",
                columns: table => new
                {
                    ActivitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBDoctor_TBActivity", x => new { x.ActivitiesId, x.DoctorsId });
                    table.ForeignKey(
                        name: "FK_TBDoctor_TBActivity_TBActivity_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "TBActivity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBDoctor_TBActivity_TBDoctor_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "TBDoctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBDoctor_TBActivity_DoctorsId",
                table: "TBDoctor_TBActivity",
                column: "DoctorsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBDoctor_TBActivity");

            migrationBuilder.DropTable(
                name: "TBActivity");

            migrationBuilder.DropTable(
                name: "TBDoctor");
        }
    }
}
