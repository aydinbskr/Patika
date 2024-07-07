using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteManagementSystem.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Apartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Type",
                table: "Apartments",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "Apartments",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_UserId",
                table: "Apartments",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Users_UserId",
                table: "Apartments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Users_UserId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_UserId",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Apartments");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }
    }
}
