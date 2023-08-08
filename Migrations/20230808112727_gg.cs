using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    public partial class gg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Make",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MakeId",
                table: "Products",
                column: "MakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Makes_MakeId",
                table: "Products",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Makes_MakeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MakeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Make",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
