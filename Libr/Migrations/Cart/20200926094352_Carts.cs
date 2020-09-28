using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Libr.Migrations.Cart
{
    public partial class Carts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(nullable: true),
                    NameBook = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    priceBook = table.Column<float>(nullable: false),
                    FullPrice = table.Column<float>(nullable: false),
                    count = table.Column<int>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: true),
                    Librariant = table.Column<string>(nullable: true),
                    Issued = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
