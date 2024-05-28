using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class EventStatusUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "EventCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "UserCredentialId",
                keyValue: 1,
                columns: new[] { "HashKey", "HashedPassword" },
                values: new object[] { new byte[] { 185, 244, 168, 243, 162, 141, 59, 183, 7, 158, 233, 130, 61, 26, 215, 33, 172, 115, 76, 165, 116, 154, 87, 113, 50, 15, 222, 82, 207, 213, 165, 68, 128, 202, 82, 173, 39, 219, 172, 41, 134, 181, 50, 48, 26, 207, 253, 48, 0, 131, 239, 84, 214, 114, 125, 159, 150, 136, 30, 14, 162, 121, 207, 152, 186, 230, 247, 126, 200, 51, 134, 100, 23, 180, 149, 84, 73, 124, 13, 69, 167, 254, 77, 24, 176, 60, 52, 254, 53, 236, 141, 133, 102, 234, 26, 34, 30, 152, 138, 164, 121, 153, 240, 206, 181, 1, 94, 162, 116, 55, 187, 26, 232, 8, 166, 204, 127, 112, 14, 111, 227, 4, 179, 236, 67, 88, 246, 113 }, new byte[] { 55, 214, 159, 120, 168, 13, 128, 47, 136, 13, 0, 217, 203, 137, 177, 42, 27, 218, 153, 119, 43, 98, 24, 134, 17, 233, 79, 46, 172, 252, 225, 62, 200, 210, 189, 100, 146, 143, 193, 201, 79, 247, 156, 189, 122, 0, 239, 41, 89, 89, 54, 168, 186, 113, 237, 147, 253, 153, 66, 85, 133, 226, 195, 70 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 12, 17, 25, 110, DateTimeKind.Local).AddTicks(8672));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "EventCategories");

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "UserCredentialId",
                keyValue: 1,
                columns: new[] { "HashKey", "HashedPassword" },
                values: new object[] { new byte[] { 32, 161, 113, 77, 101, 207, 227, 251, 185, 20, 248, 64, 33, 83, 218, 108, 168, 19, 1, 136, 38, 124, 238, 32, 160, 108, 243, 98, 178, 13, 19, 72, 83, 199, 12, 146, 26, 98, 229, 86, 71, 31, 17, 103, 175, 184, 166, 0, 44, 36, 23, 121, 53, 245, 252, 146, 245, 207, 159, 28, 19, 243, 141, 68, 249, 171, 123, 16, 89, 199, 183, 187, 71, 131, 231, 45, 34, 184, 15, 133, 206, 103, 150, 141, 46, 177, 123, 157, 6, 32, 222, 63, 229, 241, 83, 223, 97, 90, 232, 157, 187, 131, 164, 110, 45, 197, 117, 137, 135, 80, 49, 114, 137, 47, 230, 251, 36, 212, 201, 74, 119, 175, 64, 127, 131, 117, 157, 31 }, new byte[] { 173, 119, 2, 231, 73, 80, 111, 238, 143, 98, 134, 117, 103, 154, 1, 173, 99, 182, 247, 243, 237, 70, 248, 95, 210, 129, 122, 99, 199, 52, 224, 176, 127, 145, 50, 10, 6, 175, 99, 70, 172, 241, 40, 176, 62, 14, 122, 131, 237, 150, 24, 184, 115, 117, 63, 30, 67, 52, 139, 17, 178, 228, 118, 79 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 10, 56, 6, 735, DateTimeKind.Local).AddTicks(392));
        }
    }
}
