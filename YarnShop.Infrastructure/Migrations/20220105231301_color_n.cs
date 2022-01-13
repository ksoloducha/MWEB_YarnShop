using Microsoft.EntityFrameworkCore.Migrations;

namespace YarnShop.Infrastructure.Migrations
{
    public partial class color_n : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "n",
                table: "Color",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "n",
                table: "Color");
        }
    }
}
