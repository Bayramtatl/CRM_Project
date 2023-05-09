using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM_Project.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _1000 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvgPoint = table.Column<double>(type: "float", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceStatus = table.Column<int>(type: "int", nullable: false),
                    Request = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    MoneySpent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceSteps_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceSteps_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CompanyName", "Email", "Number", "Password", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Kablonet", "k@k.com", null, "123", new DateTime(2023, 5, 5, 19, 12, 11, 722, DateTimeKind.Local).AddTicks(4591) },
                    { 2, "Uludağ Üniversitesi", "u@u.com", null, "123", new DateTime(2023, 5, 5, 19, 12, 11, 722, DateTimeKind.Local).AddTicks(4592) }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "AvgPoint", "Email", "Name", "Password", "Role", "Surname", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, "b@b.com", "Bayram", "123", 0, "Tatlı", new DateTime(2023, 5, 5, 19, 12, 11, 722, DateTimeKind.Local).AddTicks(4510) },
                    { 2, null, "b@c.com", "Firma", "123", 0, "Talebi", new DateTime(2023, 5, 5, 19, 12, 11, 722, DateTimeKind.Local).AddTicks(4519) },
                    { 3, null, "s@s.com", "Suat", "123", 1, "Bıçakçı", new DateTime(2023, 5, 5, 19, 12, 11, 722, DateTimeKind.Local).AddTicks(4521) }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CompanyId", "LastDate", "MoneySpent", "Request", "ServiceStatus", "UpdatedDate" },
                values: new object[] { 1, 1, new DateTime(2023, 5, 5, 19, 12, 11, 722, DateTimeKind.Local).AddTicks(4607), 6100m, "Deneme için destek talebi", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ServiceSteps",
                columns: new[] { "Id", "Description", "Point", "Price", "ServiceId", "ServiceType", "StaffId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Sunucularımızda ısınma sorunu var.", 0, 0m, 1, 2, 2, new DateTime(2023, 5, 5, 19, 12, 11, 722, DateTimeKind.Local).AddTicks(4621) },
                    { 2, "Sunuculara yazılım güncellemesi yapıldı.", 4, 100m, 1, 1, 1, new DateTime(2023, 5, 5, 19, 12, 11, 722, DateTimeKind.Local).AddTicks(4633) },
                    { 3, "Sunucuların işlemcisi değiştirildi.", 5, 6000m, 1, 0, 3, new DateTime(2023, 5, 5, 19, 12, 11, 722, DateTimeKind.Local).AddTicks(4634) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_CompanyId",
                table: "Services",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSteps_ServiceId",
                table: "ServiceSteps",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSteps_StaffId",
                table: "ServiceSteps",
                column: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceSteps");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
