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
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ServiceSteps",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 22, 42, 49, 268, DateTimeKind.Local).AddTicks(297));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 22, 42, 49, 268, DateTimeKind.Local).AddTicks(298));

            migrationBuilder.UpdateData(
                table: "ServiceSteps",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 22, 42, 49, 268, DateTimeKind.Local).AddTicks(327));

            migrationBuilder.UpdateData(
                table: "ServiceSteps",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 22, 42, 49, 268, DateTimeKind.Local).AddTicks(338));

            migrationBuilder.UpdateData(
                table: "ServiceSteps",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 22, 42, 49, 268, DateTimeKind.Local).AddTicks(339));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2023, 5, 5, 22, 42, 49, 268, DateTimeKind.Local).AddTicks(313));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 22, 42, 49, 268, DateTimeKind.Local).AddTicks(214));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 22, 42, 49, 268, DateTimeKind.Local).AddTicks(222));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 22, 42, 49, 268, DateTimeKind.Local).AddTicks(223));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ServiceSteps",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 19, 12, 11, 722, DateTimeKind.Local).AddTicks(4591));

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 19, 12, 11, 722, DateTimeKind.Local).AddTicks(4592));

            migrationBuilder.UpdateData(
                table: "ServiceSteps",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 19, 12, 11, 722, DateTimeKind.Local).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "ServiceSteps",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 19, 12, 11, 722, DateTimeKind.Local).AddTicks(4633));

            migrationBuilder.UpdateData(
                table: "ServiceSteps",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 19, 12, 11, 722, DateTimeKind.Local).AddTicks(4634));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2023, 5, 5, 19, 12, 11, 722, DateTimeKind.Local).AddTicks(4607));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 19, 12, 11, 722, DateTimeKind.Local).AddTicks(4510));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 19, 12, 11, 722, DateTimeKind.Local).AddTicks(4519));

            migrationBuilder.UpdateData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedDate",
                value: new DateTime(2023, 5, 5, 19, 12, 11, 722, DateTimeKind.Local).AddTicks(4521));
        }
    }
}
