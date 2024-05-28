using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class Updated_ScheduledEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "ScheduledEvents",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "ScheduledEvents");

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "UserCredentialId",
                keyValue: 1,
                columns: new[] { "HashKey", "HashedPassword" },
                values: new object[] { new byte[] { 2, 92, 155, 230, 38, 52, 135, 249, 136, 117, 150, 153, 251, 254, 154, 255, 213, 25, 82, 219, 93, 232, 240, 0, 124, 121, 143, 15, 55, 35, 121, 212, 3, 16, 87, 230, 185, 21, 27, 53, 86, 162, 16, 118, 93, 23, 155, 13, 0, 205, 78, 44, 149, 39, 35, 228, 167, 177, 6, 124, 144, 70, 231, 175, 161, 205, 253, 28, 230, 175, 88, 50, 17, 50, 210, 201, 141, 133, 117, 186, 84, 234, 34, 75, 213, 233, 21, 148, 88, 69, 85, 107, 165, 98, 237, 230, 14, 49, 122, 185, 253, 9, 218, 197, 152, 53, 221, 80, 248, 94, 82, 234, 167, 98, 29, 22, 64, 95, 15, 184, 216, 2, 126, 153, 21, 55, 174, 142 }, new byte[] { 241, 158, 183, 103, 15, 225, 215, 99, 8, 15, 185, 186, 110, 115, 163, 206, 184, 208, 188, 78, 33, 176, 65, 107, 1, 240, 101, 117, 198, 150, 132, 205, 163, 97, 200, 226, 149, 70, 169, 6, 242, 221, 0, 87, 51, 5, 76, 228, 39, 53, 69, 151, 226, 200, 40, 174, 34, 74, 237, 180, 191, 11, 5, 18 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 12, 47, 3, 555, DateTimeKind.Local).AddTicks(8105));
        }
    }
}
