using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class RatingAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "EventCategories",
                type: "real",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "UserCredentialId",
                keyValue: 1,
                columns: new[] { "HashKey", "HashedPassword" },
                values: new object[] { new byte[] { 140, 181, 223, 194, 136, 214, 198, 246, 249, 221, 117, 114, 164, 82, 98, 3, 113, 16, 7, 46, 115, 75, 196, 8, 191, 103, 248, 207, 89, 50, 33, 235, 176, 25, 38, 221, 135, 155, 3, 21, 192, 4, 115, 115, 112, 216, 194, 49, 237, 58, 68, 48, 50, 131, 244, 107, 12, 173, 2, 162, 39, 64, 171, 90, 82, 112, 123, 199, 204, 108, 216, 41, 60, 81, 169, 234, 209, 7, 95, 210, 207, 70, 74, 209, 68, 34, 175, 109, 17, 79, 110, 219, 210, 27, 108, 166, 217, 18, 96, 123, 61, 25, 224, 228, 167, 31, 176, 40, 100, 16, 28, 81, 58, 208, 175, 69, 83, 84, 99, 135, 147, 229, 47, 94, 4, 92, 81, 243 }, new byte[] { 221, 165, 8, 203, 27, 206, 211, 100, 176, 139, 8, 116, 78, 94, 104, 171, 104, 56, 86, 108, 102, 189, 116, 229, 236, 206, 168, 70, 114, 116, 249, 23, 101, 228, 235, 94, 76, 91, 87, 100, 178, 117, 25, 138, 6, 105, 12, 191, 130, 34, 179, 161, 6, 73, 106, 119, 193, 68, 89, 70, 181, 129, 93, 142 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 21, 7, 48, 96, DateTimeKind.Local).AddTicks(3020));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "EventCategories");

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "UserCredentialId",
                keyValue: 1,
                columns: new[] { "HashKey", "HashedPassword" },
                values: new object[] { new byte[] { 31, 59, 86, 36, 208, 163, 227, 71, 218, 223, 89, 126, 145, 220, 155, 132, 90, 119, 35, 222, 156, 244, 142, 18, 55, 153, 194, 43, 89, 121, 148, 168, 42, 231, 172, 110, 72, 197, 70, 11, 184, 34, 217, 15, 218, 156, 203, 250, 86, 221, 156, 53, 93, 56, 81, 211, 183, 76, 32, 73, 73, 225, 101, 191, 209, 70, 1, 125, 131, 200, 118, 228, 220, 204, 4, 240, 60, 142, 105, 129, 137, 97, 158, 15, 211, 201, 138, 192, 149, 168, 97, 14, 39, 250, 54, 208, 95, 197, 112, 79, 207, 195, 191, 232, 226, 129, 221, 248, 108, 188, 99, 229, 250, 184, 112, 212, 189, 246, 175, 223, 137, 108, 202, 9, 23, 29, 170, 68 }, new byte[] { 235, 147, 30, 129, 229, 167, 112, 53, 110, 174, 103, 143, 34, 255, 197, 139, 54, 144, 202, 187, 53, 200, 237, 46, 63, 83, 21, 194, 245, 127, 181, 130, 64, 83, 33, 196, 134, 237, 92, 154, 45, 25, 41, 140, 37, 181, 20, 175, 195, 26, 114, 6, 192, 146, 215, 0, 202, 233, 93, 140, 56, 12, 90, 54 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 12, 50, 27, 823, DateTimeKind.Local).AddTicks(4854));
        }
    }
}
