using Microsoft.EntityFrameworkCore.Migrations;

namespace YarnShop.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KnittingNeedle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<double>(type: "float", nullable: false),
                    n = table.Column<int>(type: "int", nullable: false),
                    Circular = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnittingNeedle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YarnType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    NeedlesSize = table.Column<double>(type: "float", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YarnType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YarnType_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yarnTypeId = table.Column<int>(type: "int", nullable: true),
                    n = table.Column<int>(type: "int", nullable: false),
                    ToolId = table.Column<int>(type: "int", nullable: true),
                    Pattern = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kit_KnittingNeedle_ToolId",
                        column: x => x.ToolId,
                        principalTable: "KnittingNeedle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kit_YarnType_yarnTypeId",
                        column: x => x.yarnTypeId,
                        principalTable: "YarnType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YarnBundles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YarnTypeId = table.Column<int>(type: "int", nullable: true),
                    n = table.Column<int>(type: "int", nullable: false),
                    PricePercentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YarnBundles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YarnBundles_YarnType_YarnTypeId",
                        column: x => x.YarnTypeId,
                        principalTable: "YarnType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kit_ToolId",
                table: "Kit",
                column: "ToolId");

            migrationBuilder.CreateIndex(
                name: "IX_Kit_yarnTypeId",
                table: "Kit",
                column: "yarnTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_YarnBundles_YarnTypeId",
                table: "YarnBundles",
                column: "YarnTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_YarnType_ColorId",
                table: "YarnType",
                column: "ColorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kit");

            migrationBuilder.DropTable(
                name: "YarnBundles");

            migrationBuilder.DropTable(
                name: "KnittingNeedle");

            migrationBuilder.DropTable(
                name: "YarnType");

            migrationBuilder.DropTable(
                name: "Color");
        }
    }
}
