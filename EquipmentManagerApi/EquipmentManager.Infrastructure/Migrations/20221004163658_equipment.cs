using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquipmentManager.Infrastructure.Migrations
{
    public partial class equipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Name_Equipment",
                table: "Equipment_State",
                newName: "Name_EquipmentState");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Equipment_State",
                newName: "EquipmentColor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name_EquipmentState",
                table: "Equipment_State",
                newName: "Name_Equipment");

            migrationBuilder.RenameColumn(
                name: "EquipmentColor",
                table: "Equipment_State",
                newName: "Color");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
