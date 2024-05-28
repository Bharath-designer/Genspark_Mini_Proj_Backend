using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class EventUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuotationRequestId",
                table: "ScheduledEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledEvents_QuotationRequestId",
                table: "ScheduledEvents",
                column: "QuotationRequestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledEvents_QuotationRequests_QuotationRequestId",
                table: "ScheduledEvents",
                column: "QuotationRequestId",
                principalTable: "QuotationRequests",
                principalColumn: "QuotationRequestId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledEvents_QuotationRequests_QuotationRequestId",
                table: "ScheduledEvents");

            migrationBuilder.DropIndex(
                name: "IX_ScheduledEvents_QuotationRequestId",
                table: "ScheduledEvents");

            migrationBuilder.DropColumn(
                name: "QuotationRequestId",
                table: "ScheduledEvents");

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "UserCredentialId",
                keyValue: 1,
                columns: new[] { "HashKey", "HashedPassword" },
                values: new object[] { new byte[] { 38, 15, 209, 59, 177, 150, 165, 54, 138, 114, 22, 239, 216, 136, 219, 15, 41, 179, 140, 121, 174, 253, 52, 40, 213, 191, 186, 133, 35, 156, 162, 142, 81, 92, 181, 32, 220, 20, 90, 39, 121, 138, 186, 217, 53, 97, 96, 193, 26, 37, 177, 168, 69, 42, 242, 67, 222, 6, 148, 159, 112, 180, 187, 116, 71, 178, 70, 202, 171, 194, 67, 56, 162, 252, 71, 71, 59, 51, 184, 190, 252, 111, 83, 87, 239, 242, 140, 47, 22, 105, 27, 183, 34, 71, 6, 70, 9, 12, 88, 220, 253, 90, 127, 37, 161, 72, 82, 104, 22, 52, 210, 176, 123, 244, 71, 221, 179, 40, 196, 101, 162, 57, 66, 128, 246, 192, 86, 123 }, new byte[] { 132, 172, 138, 107, 65, 221, 207, 33, 98, 143, 240, 199, 245, 60, 39, 198, 23, 20, 44, 134, 197, 113, 180, 6, 171, 11, 232, 37, 141, 48, 80, 93, 159, 180, 45, 118, 0, 200, 112, 40, 202, 222, 252, 122, 101, 97, 9, 228, 181, 182, 191, 103, 94, 37, 164, 142, 76, 99, 110, 22, 145, 111, 222, 4 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 28, 7, 30, 37, 899, DateTimeKind.Local).AddTicks(938));
        }
    }
}
