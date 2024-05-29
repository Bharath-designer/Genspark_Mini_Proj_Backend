using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class RatingAdded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "TotalRating",
                table: "EventCategories",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "UserCredentialId",
                keyValue: 1,
                columns: new[] { "HashKey", "HashedPassword" },
                values: new object[] { new byte[] { 149, 146, 223, 155, 178, 208, 164, 249, 32, 99, 64, 178, 99, 139, 93, 144, 78, 200, 65, 145, 59, 205, 210, 155, 11, 195, 230, 174, 188, 48, 44, 38, 2, 87, 1, 172, 172, 68, 49, 125, 100, 116, 12, 115, 55, 237, 219, 134, 41, 94, 37, 85, 1, 54, 247, 248, 90, 72, 249, 75, 243, 117, 26, 155, 74, 188, 227, 88, 127, 72, 238, 32, 101, 117, 142, 69, 122, 220, 238, 155, 91, 187, 194, 130, 52, 193, 190, 120, 14, 233, 20, 22, 111, 69, 108, 135, 150, 177, 145, 227, 168, 182, 225, 158, 100, 246, 143, 19, 185, 157, 73, 61, 64, 28, 236, 73, 84, 165, 243, 0, 128, 199, 33, 135, 111, 136, 3, 110 }, new byte[] { 183, 83, 90, 128, 24, 25, 89, 167, 139, 1, 214, 242, 17, 221, 177, 56, 82, 154, 172, 138, 47, 128, 229, 228, 253, 16, 230, 47, 54, 60, 220, 44, 38, 46, 100, 208, 240, 27, 191, 126, 142, 38, 154, 201, 158, 54, 136, 175, 107, 99, 26, 123, 21, 26, 16, 16, 213, 191, 173, 113, 56, 249, 138, 201 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 21, 51, 32, 299, DateTimeKind.Local).AddTicks(9367));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalRating",
                table: "EventCategories",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "UserCredentialId",
                keyValue: 1,
                columns: new[] { "HashKey", "HashedPassword" },
                values: new object[] { new byte[] { 71, 120, 45, 47, 255, 222, 116, 94, 255, 35, 159, 58, 155, 207, 95, 58, 161, 216, 227, 184, 210, 9, 61, 114, 226, 48, 104, 248, 12, 218, 142, 102, 9, 230, 169, 65, 217, 39, 142, 105, 117, 216, 178, 113, 121, 125, 83, 42, 42, 41, 108, 137, 80, 228, 38, 78, 195, 96, 236, 191, 115, 144, 80, 118, 115, 116, 51, 206, 20, 140, 251, 201, 29, 95, 140, 166, 50, 129, 59, 8, 254, 147, 63, 214, 39, 210, 181, 52, 216, 0, 59, 189, 221, 48, 12, 48, 9, 235, 44, 48, 251, 159, 124, 96, 14, 120, 42, 104, 181, 59, 169, 113, 23, 240, 91, 205, 46, 49, 65, 213, 228, 148, 130, 219, 45, 9, 69, 118 }, new byte[] { 14, 171, 174, 71, 33, 209, 59, 236, 47, 137, 251, 136, 221, 127, 188, 92, 197, 133, 4, 28, 16, 62, 72, 72, 111, 242, 141, 192, 235, 207, 27, 92, 93, 124, 35, 154, 116, 146, 225, 121, 153, 8, 213, 61, 177, 83, 52, 43, 204, 215, 208, 243, 216, 206, 181, 231, 107, 155, 78, 132, 160, 242, 67, 235 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 21, 49, 40, 277, DateTimeKind.Local).AddTicks(8244));
        }
    }
}
