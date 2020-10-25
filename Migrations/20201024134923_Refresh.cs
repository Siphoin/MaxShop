using Microsoft.EntityFrameworkCore.Migrations;

namespace MaxShop.Migrations
{
    public partial class Refresh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(nullable: false),
                    Avaliable = table.Column<bool>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    ShortDecription = table.Column<string>(nullable: true),
                    LongDecription = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IsFavorite = table.Column<bool>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phone_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopPhoneItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phoneId = table.Column<int>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    ShopCartId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopPhoneItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopPhoneItem_Phone_phoneId",
                        column: x => x.phoneId,
                        principalTable: "Phone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phone_CategoryID",
                table: "Phone",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ShopPhoneItem_phoneId",
                table: "ShopPhoneItem",
                column: "phoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopPhoneItem");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
