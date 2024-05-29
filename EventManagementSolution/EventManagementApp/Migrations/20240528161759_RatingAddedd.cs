using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class RatingAddedd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfRatings",
                table: "EventCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "UserCredentialId",
                keyValue: 1,
                columns: new[] { "HashKey", "HashedPassword" },
                values: new object[] { new byte[] { 45, 181, 20, 174, 189, 152, 140, 41, 68, 221, 7, 49, 45, 175, 73, 245, 250, 116, 143, 177, 44, 179, 149, 162, 14, 248, 13, 53, 241, 102, 164, 163, 32, 158, 133, 203, 174, 180, 74, 87, 12, 86, 41, 71, 159, 221, 157, 137, 16, 81, 33, 87, 81, 61, 237, 193, 218, 150, 179, 49, 233, 86, 1, 254, 118, 50, 13, 28, 41, 179, 198, 66, 107, 208, 61, 157, 156, 140, 146, 2, 101, 85, 216, 63, 50, 231, 237, 2, 94, 119, 248, 158, 148, 135, 120, 10, 190, 57, 205, 39, 37, 205, 203, 99, 54, 77, 39, 70, 173, 236, 56, 72, 131, 127, 97, 60, 66, 160, 77, 114, 121, 11, 180, 194, 250, 171, 128, 252 }, new byte[] { 135, 41, 134, 137, 85, 101, 184, 217, 17, 144, 21, 217, 232, 241, 200, 170, 62, 207, 216, 10, 163, 81, 16, 168, 173, 113, 132, 10, 143, 24, 66, 187, 183, 80, 144, 233, 86, 245, 93, 73, 67, 76, 143, 2, 161, 48, 65, 114, 145, 251, 128, 63, 4, 87, 97, 195, 126, 122, 55, 156, 229, 232, 178, 171 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 21, 47, 58, 716, DateTimeKind.Local).AddTicks(2544));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRatings",
                table: "EventCategories");

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
    }
}
