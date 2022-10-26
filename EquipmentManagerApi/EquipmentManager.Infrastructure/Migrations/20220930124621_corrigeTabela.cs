using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquipmentManager.Infrastructure.Migrations
{
    public partial class corrigeTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "User");
        }
    }
}
