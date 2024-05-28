using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Notification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");
        }
    }
}
