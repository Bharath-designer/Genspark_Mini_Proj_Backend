using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class RatingAddeddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalRating",
                table: "EventCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalRating",
                table: "EventCategories");

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
    }
}
