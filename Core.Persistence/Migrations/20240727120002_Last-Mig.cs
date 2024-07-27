using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LastMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "OrderDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 27, 16, 0, 1, 719, DateTimeKind.Local).AddTicks(4431));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 27, 16, 0, 1, 719, DateTimeKind.Local).AddTicks(4450));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 27, 16, 0, 1, 719, DateTimeKind.Local).AddTicks(4451));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "OperationClaimId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 27, 16, 0, 1, 719, DateTimeKind.Local).AddTicks(6670), null, 1, 1 },
                    { 2, new DateTime(2024, 7, 27, 16, 0, 1, 719, DateTimeKind.Local).AddTicks(6673), null, 2, 1 },
                    { 3, new DateTime(2024, 7, 27, 16, 0, 1, 719, DateTimeKind.Local).AddTicks(6674), null, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Country", "CreatedDate", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { 1, "admin-address", "admin-country", new DateTime(2024, 7, 27, 16, 0, 1, 719, DateTimeKind.Local).AddTicks(6545), new DateTime(2024, 7, 27, 0, 0, 0, 0, DateTimeKind.Local), "admin@admin.com", "admin-first-name", 1, "admin-last-name", null, new byte[] { 4, 154, 2, 137, 25, 14, 14, 104, 76, 189, 103, 223, 245, 239, 61, 226, 253, 217, 215, 226, 10, 193, 198, 37, 70, 140, 253, 190, 112, 170, 42, 251, 124, 105, 32, 217, 148, 102, 140, 78, 19, 6, 16, 138, 182, 132, 190, 202, 205, 19, 2, 80, 178, 63, 177, 125, 7, 41, 244, 224, 47, 28, 210, 102 }, new byte[] { 75, 144, 127, 235, 84, 11, 42, 30, 69, 165, 204, 21, 142, 250, 146, 145, 5, 27, 125, 161, 24, 226, 28, 117, 202, 166, 41, 163, 141, 19, 31, 144, 189, 189, 137, 165, 78, 42, 27, 255, 139, 204, 128, 107, 239, 129, 64, 217, 242, 213, 17, 15, 183, 152, 28, 210, 195, 114, 107, 254, 99, 121, 1, 201, 144, 206, 229, 143, 143, 3, 224, 217, 239, 213, 37, 224, 66, 25, 21, 249, 0, 163, 144, 125, 218, 1, 157, 146, 198, 11, 169, 193, 211, 68, 176, 70, 30, 83, 87, 46, 152, 224, 188, 243, 211, 239, 47, 60, 63, 58, 100, 250, 198, 53, 245, 137, 175, 64, 117, 112, 245, 72, 139, 5, 101, 197, 79, 137 }, false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 20, 12, 31, 9, 780, DateTimeKind.Local).AddTicks(7733));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 20, 12, 31, 9, 780, DateTimeKind.Local).AddTicks(7755));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 20, 12, 31, 9, 780, DateTimeKind.Local).AddTicks(7757));

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
