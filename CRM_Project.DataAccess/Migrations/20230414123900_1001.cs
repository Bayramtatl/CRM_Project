using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM_Project.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _1001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Number", "UpdatedDate" },
                values: new object[] { null, new DateTime(2023, 4, 14, 15, 39, 0, 91, DateTimeKind.Local).AddTicks(8462) });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedDate",
                value: new DateTime(2023, 4, 14, 15, 39, 0, 91, DateTimeKind.Local).AddTicks(8476));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Companies");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedDate",
                value: new DateTime(2023, 4, 9, 23, 52, 2, 664, DateTimeKind.Local).AddTicks(4481));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedDate",
                value: new DateTime(2023, 4, 9, 23, 52, 2, 664, DateTimeKind.Local).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedDate",
                value: new DateTime(2023, 4, 9, 23, 52, 2, 664, DateTimeKind.Local).AddTicks(4380));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedDate",
                value: new DateTime(2023, 4, 9, 23, 52, 2, 664, DateTimeKind.Local).AddTicks(4390));
        }
    }
}
