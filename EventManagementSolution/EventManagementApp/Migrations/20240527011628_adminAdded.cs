using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class adminAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "FullName", "PhoneNumber" },
                values: new object[] { 1, new DateTime(2024, 5, 27, 6, 46, 27, 759, DateTimeKind.Local).AddTicks(8420), "admin@bookmyevent.in", "Book My Event", "97343792398" });

            migrationBuilder.InsertData(
                table: "UserCredentials",
                columns: new[] { "UserCredentialId", "HashKey", "HashedPassword", "Role", "UserId" },
                values: new object[] { 1, new byte[] { 89, 216, 17, 46, 214, 105, 82, 8, 41, 213, 228, 212, 3, 251, 223, 217, 198, 29, 66, 64, 210, 246, 145, 226, 171, 164, 41, 197, 12, 82, 6, 104, 197, 80, 249, 6, 132, 213, 185, 199, 255, 123, 127, 233, 33, 7, 181, 59, 118, 23, 236, 52, 121, 86, 251, 44, 44, 23, 32, 65, 141, 173, 139, 17, 85, 163, 84, 155, 187, 21, 198, 64, 159, 249, 197, 5, 222, 144, 226, 46, 5, 170, 105, 12, 209, 161, 239, 241, 203, 173, 207, 214, 228, 166, 32, 255, 180, 214, 47, 202, 215, 21, 109, 23, 223, 80, 61, 122, 167, 120, 182, 104, 94, 160, 157, 164, 108, 250, 73, 133, 150, 116, 203, 50, 151, 27, 245, 204 }, new byte[] { 114, 67, 96, 144, 142, 116, 167, 39, 16, 183, 94, 248, 185, 5, 99, 44, 10, 73, 25, 226, 67, 194, 167, 156, 211, 156, 157, 161, 113, 229, 234, 13, 245, 253, 217, 144, 33, 133, 202, 128, 84, 159, 79, 176, 128, 51, 2, 140, 88, 58, 153, 245, 36, 153, 70, 36, 95, 109, 44, 163, 209, 175, 103, 82 }, "Admin", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserCredentials",
                keyColumn: "UserCredentialId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
