using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace H92C.Migrations
{
    public partial class SayfaSayisiEkleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KitapSayfasi",
                table: "Kitaplar",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KitapSayfasi",
                table: "Kitaplar");
        }
    }
}
