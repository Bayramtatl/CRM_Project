using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRM_Project.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _1002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AvgPoint",
                table: "Staffs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Point",
                table: "ServiceSteps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedDate",
                value: new DateTime(2023, 4, 29, 18, 45, 40, 93, DateTimeKind.Local).AddTicks(8558));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CompanyName", "Email", "Number", "Password", "UpdatedDate" },
                values: new object[] { 2, "Uludağ Üniversitesi", "u@u.com", null, "123", new DateTime(2023, 4, 29, 18, 45, 40, 93, DateTimeKind.Local).AddTicks(8559) });

            migrationBuilder.InsertData(
                table: "ServiceSteps",
                columns: new[] { "Id", "Description", "Point", "Price", "ServiceId", "ServiceType", "StaffId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Sunucularımızda ısınma sorunu var.", 0, null, 1, 2, 2, new DateTime(2023, 4, 29, 18, 45, 40, 93, DateTimeKind.Local).AddTicks(8584) },
                    { 2, "Sunuculara yazılım güncellemesi yapıldı.", 4, null, 1, 1, 1, new DateTime(2023, 4, 29, 18, 45, 40, 93, DateTimeKind.Local).AddTicks(8596) }
                });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ServiceStatus", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2023, 4, 29, 18, 45, 40, 93, DateTimeKind.Local).AddTicks(8572) });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvgPoint", "UpdatedDate" },
                values: new object[] { null, new DateTime(2023, 4, 29, 18, 45, 40, 93, DateTimeKind.Local).AddTicks(8478) });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvgPoint", "UpdatedDate" },
                values: new object[] { null, new DateTime(2023, 4, 29, 18, 45, 40, 93, DateTimeKind.Local).AddTicks(8486) });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "AvgPoint", "Email", "Name", "Password", "Role", "Surname", "UpdatedDate" },
                values: new object[] { 3, null, "s@s.com", "Suat", "123", 1, "Bıçakçı", new DateTime(2023, 4, 29, 18, 45, 40, 93, DateTimeKind.Local).AddTicks(8488) });

            migrationBuilder.InsertData(
                table: "ServiceSteps",
                columns: new[] { "Id", "Description", "Point", "Price", "ServiceId", "ServiceType", "StaffId", "UpdatedDate" },
                values: new object[] { 3, "Sunucuların işlemcisi değiştirildi.", 5, null, 1, 0, 3, new DateTime(2023, 4, 29, 18, 45, 40, 93, DateTimeKind.Local).AddTicks(8597) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceSteps",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceSteps",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceSteps",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "AvgPoint",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Point",
                table: "ServiceSteps");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedDate",
                value: new DateTime(2023, 4, 14, 15, 39, 0, 91, DateTimeKind.Local).AddTicks(8462));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ServiceStatus", "UpdatedDate" },
                values: new object[] { 0, new DateTime(2023, 4, 14, 15, 39, 0, 91, DateTimeKind.Local).AddTicks(8476) });

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedDate",
                value: new DateTime(2023, 4, 14, 15, 39, 0, 91, DateTimeKind.Local).AddTicks(8376));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedDate",
                value: new DateTime(2023, 4, 14, 15, 39, 0, 91, DateTimeKind.Local).AddTicks(8385));
        }
    }
}
