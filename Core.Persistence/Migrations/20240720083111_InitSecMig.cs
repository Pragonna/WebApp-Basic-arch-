using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitSecMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 20, 12, 31, 9, 780, DateTimeKind.Local).AddTicks(7733), null, "Admin" },
                    { 2, new DateTime(2024, 7, 20, 12, 31, 9, 780, DateTimeKind.Local).AddTicks(7755), null, "SuperUser" },
                    { 3, new DateTime(2024, 7, 20, 12, 31, 9, 780, DateTimeKind.Local).AddTicks(7757), null, "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
