using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace H12C2.Data.Migrations
{
    public partial class USerDetailsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAd",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserSoyad",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAd",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserSoyad",
                table: "AspNetUsers");
        }
    }
}
