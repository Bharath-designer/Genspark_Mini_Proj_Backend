using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class PaymentUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethod",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "UserCredentialId",
                keyValue: 1,
                columns: new[] { "HashKey", "HashedPassword" },
                values: new object[] { new byte[] { 38, 15, 209, 59, 177, 150, 165, 54, 138, 114, 22, 239, 216, 136, 219, 15, 41, 179, 140, 121, 174, 253, 52, 40, 213, 191, 186, 133, 35, 156, 162, 142, 81, 92, 181, 32, 220, 20, 90, 39, 121, 138, 186, 217, 53, 97, 96, 193, 26, 37, 177, 168, 69, 42, 242, 67, 222, 6, 148, 159, 112, 180, 187, 116, 71, 178, 70, 202, 171, 194, 67, 56, 162, 252, 71, 71, 59, 51, 184, 190, 252, 111, 83, 87, 239, 242, 140, 47, 22, 105, 27, 183, 34, 71, 6, 70, 9, 12, 88, 220, 253, 90, 127, 37, 161, 72, 82, 104, 22, 52, 210, 176, 123, 244, 71, 221, 179, 40, 196, 101, 162, 57, 66, 128, 246, 192, 86, 123 }, new byte[] { 132, 172, 138, 107, 65, 221, 207, 33, 98, 143, 240, 199, 245, 60, 39, 198, 23, 20, 44, 134, 197, 113, 180, 6, 171, 11, 232, 37, 141, 48, 80, 93, 159, 180, 45, 118, 0, 200, 112, 40, 202, 222, 252, 122, 101, 97, 9, 228, 181, 182, 191, 103, 94, 37, 164, 142, 76, 99, 110, 22, 145, 111, 222, 4 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 7, 30, 37, 899, DateTimeKind.Local).AddTicks(938));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethod",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "UserCredentialId",
                keyValue: 1,
                columns: new[] { "HashKey", "HashedPassword" },
                values: new object[] { new byte[] { 195, 208, 95, 32, 94, 143, 206, 151, 208, 110, 42, 238, 102, 151, 194, 56, 148, 192, 188, 89, 233, 191, 191, 183, 239, 191, 111, 202, 59, 155, 238, 67, 164, 218, 140, 37, 83, 96, 128, 105, 7, 124, 25, 79, 123, 221, 39, 65, 56, 194, 17, 213, 169, 77, 50, 231, 90, 39, 83, 29, 189, 128, 151, 246, 119, 146, 70, 92, 143, 177, 219, 119, 62, 163, 245, 165, 132, 177, 184, 28, 100, 145, 203, 57, 191, 122, 249, 235, 196, 246, 107, 213, 198, 195, 104, 89, 215, 200, 60, 187, 42, 151, 66, 80, 72, 45, 1, 27, 102, 218, 120, 133, 110, 163, 179, 157, 38, 82, 149, 108, 204, 167, 48, 194, 190, 204, 32, 124 }, new byte[] { 45, 116, 149, 207, 144, 8, 108, 159, 157, 97, 14, 16, 54, 23, 33, 117, 126, 199, 86, 66, 25, 150, 53, 156, 33, 31, 29, 35, 90, 178, 187, 49, 190, 162, 238, 107, 174, 50, 133, 14, 39, 204, 138, 208, 26, 227, 230, 195, 123, 242, 114, 212, 253, 245, 83, 118, 202, 222, 54, 134, 56, 115, 101, 75 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 7, 2, 36, 802, DateTimeKind.Local).AddTicks(215));
        }
    }
}
