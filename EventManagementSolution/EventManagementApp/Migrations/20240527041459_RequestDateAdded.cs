using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class RequestDateAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "QuotationRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "UserCredentialId",
                keyValue: 1,
                columns: new[] { "HashKey", "HashedPassword" },
                values: new object[] { new byte[] { 152, 59, 230, 154, 128, 163, 7, 114, 190, 92, 234, 251, 160, 54, 183, 15, 134, 71, 228, 117, 66, 213, 15, 238, 100, 226, 114, 146, 170, 82, 4, 215, 166, 15, 205, 236, 72, 24, 145, 36, 247, 201, 249, 5, 254, 214, 85, 206, 41, 208, 98, 108, 7, 250, 166, 233, 206, 162, 122, 118, 41, 247, 8, 178, 107, 154, 112, 90, 197, 165, 62, 39, 59, 164, 6, 34, 102, 87, 161, 17, 220, 108, 2, 16, 73, 13, 131, 95, 139, 9, 9, 190, 216, 227, 78, 28, 245, 28, 169, 72, 61, 189, 166, 114, 92, 143, 126, 175, 253, 235, 1, 133, 228, 179, 179, 132, 220, 26, 80, 247, 129, 191, 214, 17, 187, 89, 44, 45 }, new byte[] { 31, 193, 193, 230, 229, 129, 247, 201, 151, 88, 66, 181, 137, 125, 67, 206, 31, 160, 222, 128, 226, 225, 95, 41, 237, 197, 91, 228, 250, 208, 155, 85, 238, 32, 70, 209, 210, 67, 215, 97, 71, 248, 162, 48, 231, 53, 91, 215, 140, 92, 161, 17, 118, 41, 3, 214, 113, 227, 207, 145, 67, 53, 212, 20 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 9, 44, 58, 457, DateTimeKind.Local).AddTicks(5933));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "QuotationRequests");

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "UserCredentialId",
                keyValue: 1,
                columns: new[] { "HashKey", "HashedPassword" },
                values: new object[] { new byte[] { 89, 216, 17, 46, 214, 105, 82, 8, 41, 213, 228, 212, 3, 251, 223, 217, 198, 29, 66, 64, 210, 246, 145, 226, 171, 164, 41, 197, 12, 82, 6, 104, 197, 80, 249, 6, 132, 213, 185, 199, 255, 123, 127, 233, 33, 7, 181, 59, 118, 23, 236, 52, 121, 86, 251, 44, 44, 23, 32, 65, 141, 173, 139, 17, 85, 163, 84, 155, 187, 21, 198, 64, 159, 249, 197, 5, 222, 144, 226, 46, 5, 170, 105, 12, 209, 161, 239, 241, 203, 173, 207, 214, 228, 166, 32, 255, 180, 214, 47, 202, 215, 21, 109, 23, 223, 80, 61, 122, 167, 120, 182, 104, 94, 160, 157, 164, 108, 250, 73, 133, 150, 116, 203, 50, 151, 27, 245, 204 }, new byte[] { 114, 67, 96, 144, 142, 116, 167, 39, 16, 183, 94, 248, 185, 5, 99, 44, 10, 73, 25, 226, 67, 194, 167, 156, 211, 156, 157, 161, 113, 229, 234, 13, 245, 253, 217, 144, 33, 133, 202, 128, 84, 159, 79, 176, 128, 51, 2, 140, 88, 58, 153, 245, 36, 153, 70, 36, 95, 109, 44, 163, 209, 175, 103, 82 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 27, 6, 46, 27, 759, DateTimeKind.Local).AddTicks(8420));
        }
    }
}
