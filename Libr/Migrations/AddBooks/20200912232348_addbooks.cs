using Microsoft.EntityFrameworkCore.Migrations;

namespace Libr.Migrations.AddBooks
{
    public partial class addbooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    count = table.Column<int>(nullable: false),
                    PhotoPath = table.Column<string>(nullable: true),
                    genres = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
