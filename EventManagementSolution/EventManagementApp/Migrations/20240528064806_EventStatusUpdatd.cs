using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class EventStatusUpdatd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "EventCategories",
                newName: "IsActive");

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "UserCredentialId",
                keyValue: 1,
                columns: new[] { "HashKey", "HashedPassword" },
                values: new object[] { new byte[] { 160, 19, 183, 211, 59, 103, 98, 48, 124, 136, 214, 190, 116, 89, 216, 243, 222, 172, 68, 215, 15, 81, 109, 18, 136, 200, 10, 22, 55, 3, 197, 65, 204, 120, 131, 148, 255, 206, 147, 17, 7, 172, 246, 113, 28, 165, 148, 162, 255, 35, 113, 239, 165, 141, 59, 9, 51, 161, 228, 234, 133, 124, 4, 134, 156, 49, 242, 158, 157, 19, 224, 10, 35, 222, 151, 59, 151, 233, 251, 222, 116, 127, 29, 83, 251, 87, 45, 184, 120, 220, 96, 34, 223, 227, 11, 88, 166, 245, 11, 101, 46, 158, 37, 31, 139, 154, 207, 42, 93, 140, 63, 118, 93, 199, 97, 220, 134, 181, 246, 193, 53, 223, 98, 88, 7, 14, 62, 153 }, new byte[] { 53, 191, 140, 131, 156, 129, 49, 64, 163, 29, 242, 35, 128, 56, 242, 26, 91, 202, 43, 102, 168, 127, 41, 196, 146, 60, 28, 179, 41, 68, 145, 34, 50, 56, 30, 189, 22, 77, 202, 57, 170, 175, 244, 43, 179, 236, 40, 174, 91, 0, 13, 111, 128, 93, 234, 114, 210, 70, 65, 107, 84, 140, 246, 88 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 12, 18, 5, 561, DateTimeKind.Local).AddTicks(7025));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "EventCategories",
                newName: "isActive");

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
    }
}
