using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eAgendaMedica.Infra.Orm.Migrations
{
    public partial class InitialConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBActivity_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBDoctor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CRM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBDoctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBDoctor_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBDoctor_TBActivity",
                columns: table => new
                {
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBDoctor_TBActivity", x => new { x.ActivityId, x.DoctorId });
                    table.ForeignKey(
                        name: "FK_TBDoctor_TBActivity_TBActivity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "TBActivity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBDoctor_TBActivity_TBDoctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "TBDoctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e7944276-5214-46c7-2755-08dbede3db7d"), 0, "6f07bdcf-9ff3-43da-9f8b-5e27808f81ab", "teste@gmail.com", true, false, null, "Teste", "TESTE@GMAIL.COM", "TESTE@GMAIL.COM", "AQAAAAIAAYagAAAAEEpbfL1sGZGAQmfY11et9nzZ5tdMmLv5uVMiv4xXugJLxfksPyB7aJgai6Yym57vFQ==", null, false, "NQY5DMARMJNDQ7CUQJP3U4O7SYXLNANC", false, "teste@gmail.com" });

            migrationBuilder.InsertData(
                table: "TBActivity",
                columns: new[] { "Id", "EndDay", "EndTime", "StartDay", "StartTime", "Theme", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("52c39088-1fb2-4b77-a99d-9cce46250435"), new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 30, 0, 0), new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), "primary", "Exame de Sangue", 1, new Guid("e7944276-5214-46c7-2755-08dbede3db7d") },
                    { new Guid("53c58b57-22a6-4df7-b824-5850b621f694"), new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 11, 30, 0, 0), new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 11, 0, 0, 0), "primary", "Checkup", 1, new Guid("e7944276-5214-46c7-2755-08dbede3db7d") },
                    { new Guid("a0d0323d-88a7-4cfe-ac8d-a022a4a344c1"), new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 11, 30, 0, 0), new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 11, 0, 0, 0), "accent", "Cirurgia Cardíaca", 1, new Guid("e7944276-5214-46c7-2755-08dbede3db7d") },
                    { new Guid("c48c5134-cb2b-4b05-8a4f-3a163068a3c3"), new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 11, 30, 0, 0), new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 11, 0, 0, 0), "warn", "Cirurgia de Emergência", 1, new Guid("e7944276-5214-46c7-2755-08dbede3db7d") },
                    { new Guid("ed18f0f2-b77f-4334-8afd-f3285372afb5"), new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 30, 0, 0), new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), "primary", "Consulta Geral", 1, new Guid("e7944276-5214-46c7-2755-08dbede3db7d") }
                });

            migrationBuilder.InsertData(
                table: "TBDoctor",
                columns: new[] { "Id", "CRM", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("1cc3bb32-627c-4e79-9f4a-3fbff06bbbdf"), "23456-SC", "João", new Guid("e7944276-5214-46c7-2755-08dbede3db7d") },
                    { new Guid("6275b95e-03e9-4213-9303-f0745608f706"), "82460-SC", "Rech", new Guid("e7944276-5214-46c7-2755-08dbede3db7d") },
                    { new Guid("6f095f41-5503-42a2-8412-8d2bb95c0042"), "04474-RS", "Rafael", new Guid("e7944276-5214-46c7-2755-08dbede3db7d") },
                    { new Guid("ad42d17f-9f8d-4f5b-983e-6ad44906b347"), "02457-SP", "Matheus", new Guid("e7944276-5214-46c7-2755-08dbede3db7d") },
                    { new Guid("c20e745a-da4c-4f8f-9f8f-7d5c74cafb6f"), "61458-SC", "Tiago", new Guid("e7944276-5214-46c7-2755-08dbede3db7d") }
                });

            migrationBuilder.InsertData(
                table: "TBDoctor_TBActivity",
                columns: new[] { "ActivityId", "DoctorId" },
                values: new object[,]
                {
                    { new Guid("52c39088-1fb2-4b77-a99d-9cce46250435"), new Guid("6275b95e-03e9-4213-9303-f0745608f706") },
                    { new Guid("53c58b57-22a6-4df7-b824-5850b621f694"), new Guid("1cc3bb32-627c-4e79-9f4a-3fbff06bbbdf") },
                    { new Guid("a0d0323d-88a7-4cfe-ac8d-a022a4a344c1"), new Guid("c20e745a-da4c-4f8f-9f8f-7d5c74cafb6f") },
                    { new Guid("c48c5134-cb2b-4b05-8a4f-3a163068a3c3"), new Guid("ad42d17f-9f8d-4f5b-983e-6ad44906b347") },
                    { new Guid("ed18f0f2-b77f-4334-8afd-f3285372afb5"), new Guid("6f095f41-5503-42a2-8412-8d2bb95c0042") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TBActivity_UserId",
                table: "TBActivity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBDoctor_UserId",
                table: "TBDoctor",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBDoctor_TBActivity_DoctorId",
                table: "TBDoctor_TBActivity",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TBDoctor_TBActivity");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TBActivity");

            migrationBuilder.DropTable(
                name: "TBDoctor");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
