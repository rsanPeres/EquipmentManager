using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquipmentManager.Infrastructure.Migrations
{
    public partial class mgt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipment_Model",
                columns: table => new
                {
                    Id_EquipmentModel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment_Model", x => x.Id_EquipmentModel);
                });

            migrationBuilder.CreateTable(
                name: "Equipment_State",
                columns: table => new
                {
                    Id_EquipmentState = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "varchar(50)", nullable: false),
                    EquipmentColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment_State", x => x.Id_EquipmentState);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id_User = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id_User);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id_Equipment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    EquipmentModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id_Equipment);
                    table.ForeignKey(
                        name: "FK_Equipment_Equipment_Model_EquipmentModelId",
                        column: x => x.EquipmentModelId,
                        principalTable: "Equipment_Model",
                        principalColumn: "Id_EquipmentModel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment_Model_State_Hourly_Earning",
                columns: table => new
                {
                    EquipmentModelId = table.Column<int>(type: "int", nullable: false),
                    EquipmentStateId = table.Column<int>(type: "int", nullable: false),
                    EarnedValueByHourState = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id_EquipmentModelStateHourlyEarning", x => new { x.EquipmentStateId, x.EquipmentModelId });
                    table.ForeignKey(
                        name: "FK_Equipment_Model_State_Hourly_Earning_Equipment_Model_EquipmentModelId",
                        column: x => x.EquipmentModelId,
                        principalTable: "Equipment_Model",
                        principalColumn: "Id_EquipmentModel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipment_Model_State_Hourly_Earning_Equipment_State_EquipmentStateId",
                        column: x => x.EquipmentStateId,
                        principalTable: "Equipment_State",
                        principalColumn: "Id_EquipmentState",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment_Position_History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRegisteredPosition = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id_EquipmentPositionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_Position_History_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id_Equipment",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment_State_History",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportedStatusStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    EquipmentStateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id_EquipmentStateHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_State_History_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id_Equipment",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipment_State_History_Equipment_State_EquipmentStateId",
                        column: x => x.EquipmentStateId,
                        principalTable: "Equipment_State",
                        principalColumn: "Id_EquipmentState",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipmentModelId",
                table: "Equipment",
                column: "EquipmentModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_Model_State_Hourly_Earning_EquipmentModelId",
                table: "Equipment_Model_State_Hourly_Earning",
                column: "EquipmentModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_Position_History_EquipmentId",
                table: "Equipment_Position_History",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_State_History_EquipmentId",
                table: "Equipment_State_History",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_State_History_EquipmentStateId",
                table: "Equipment_State_History",
                column: "EquipmentStateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipment_Model_State_Hourly_Earning");

            migrationBuilder.DropTable(
                name: "Equipment_Position_History");

            migrationBuilder.DropTable(
                name: "Equipment_State_History");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Equipment_State");

            migrationBuilder.DropTable(
                name: "Equipment_Model");
        }
    }
}
