using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class refundAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Refunds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Refunds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TransactionId",
                table: "Refunds",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "UserCredentialId",
                keyValue: 1,
                columns: new[] { "HashKey", "HashedPassword" },
                values: new object[] { new byte[] { 187, 82, 19, 222, 147, 58, 33, 193, 221, 89, 61, 39, 157, 97, 45, 135, 244, 67, 251, 162, 62, 249, 200, 74, 87, 218, 7, 19, 20, 182, 121, 177, 30, 207, 185, 217, 22, 225, 27, 105, 135, 87, 83, 113, 107, 109, 99, 97, 153, 70, 42, 0, 46, 95, 246, 168, 201, 112, 142, 230, 49, 41, 245, 35, 86, 198, 210, 255, 15, 133, 92, 74, 28, 215, 165, 233, 120, 156, 150, 72, 238, 13, 9, 129, 188, 91, 234, 190, 167, 165, 65, 187, 5, 92, 219, 121, 194, 126, 106, 224, 240, 63, 255, 167, 70, 18, 173, 199, 0, 90, 191, 50, 189, 175, 149, 216, 132, 58, 187, 161, 120, 15, 76, 141, 93, 55, 248, 128 }, new byte[] { 69, 250, 147, 73, 245, 135, 39, 173, 156, 94, 251, 127, 158, 59, 150, 154, 1, 229, 104, 5, 42, 153, 79, 137, 145, 98, 81, 54, 234, 134, 197, 155, 61, 220, 251, 33, 0, 15, 60, 228, 26, 171, 27, 54, 248, 0, 129, 133, 107, 151, 70, 36, 69, 220, 49, 79, 200, 84, 205, 94, 147, 156, 15, 125 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 30, 13, 28, 21, 76, DateTimeKind.Local).AddTicks(4286));

            migrationBuilder.CreateIndex(
                name: "IX_Refunds_TransactionId",
                table: "Refunds",
                column: "TransactionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Refunds_Transactions_TransactionId",
                table: "Refunds",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Refunds_Transactions_TransactionId",
                table: "Refunds");

            migrationBuilder.DropIndex(
                name: "IX_Refunds_TransactionId",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Refunds");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Refunds");

            migrationBuilder.UpdateData(
                table: "UserCredentials",
                keyColumn: "UserCredentialId",
                keyValue: 1,
                columns: new[] { "HashKey", "HashedPassword" },
                values: new object[] { new byte[] { 220, 34, 91, 64, 190, 183, 116, 58, 73, 76, 160, 169, 219, 74, 219, 185, 155, 212, 207, 22, 100, 19, 75, 251, 103, 168, 75, 228, 137, 243, 33, 36, 155, 52, 148, 22, 255, 176, 8, 141, 75, 157, 17, 203, 233, 129, 9, 62, 85, 122, 242, 160, 143, 16, 144, 198, 74, 83, 65, 224, 107, 33, 162, 110, 211, 43, 138, 126, 199, 241, 164, 199, 20, 230, 15, 129, 44, 140, 2, 109, 159, 229, 31, 193, 210, 88, 220, 25, 39, 234, 148, 246, 46, 93, 79, 66, 59, 0, 90, 169, 165, 213, 80, 121, 159, 162, 199, 235, 116, 148, 92, 65, 193, 226, 18, 160, 198, 57, 124, 164, 19, 66, 33, 183, 165, 220, 119, 19 }, new byte[] { 239, 13, 48, 188, 146, 37, 159, 21, 2, 103, 162, 147, 43, 143, 4, 221, 123, 238, 58, 140, 216, 143, 41, 29, 38, 226, 140, 89, 2, 150, 151, 197, 67, 244, 138, 166, 151, 102, 36, 2, 131, 17, 140, 212, 169, 74, 18, 80, 111, 78, 179, 172, 242, 235, 241, 40, 195, 122, 105, 164, 244, 190, 33, 11 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 30, 9, 34, 27, 95, DateTimeKind.Local).AddTicks(666));
        }
    }
}
