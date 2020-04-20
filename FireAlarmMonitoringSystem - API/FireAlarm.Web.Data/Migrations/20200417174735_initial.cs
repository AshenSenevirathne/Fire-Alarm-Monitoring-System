using Microsoft.EntityFrameworkCore.Migrations;

namespace FireAlarm.Web.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SensorDetails",
                columns: table => new
                {
                    sensorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sensorName = table.Column<string>(nullable: true),
                    floorNo = table.Column<string>(nullable: true),
                    roomNo = table.Column<string>(nullable: true),
                    sensorStatus = table.Column<string>(nullable: true),
                    sensorRemark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorDetails", x => x.sensorId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    roleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "SensorState",
                columns: table => new
                {
                    statusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    smokeLevel = table.Column<int>(nullable: false),
                    coLevel = table.Column<int>(nullable: false),
                    sensorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorState", x => x.statusId);
                    table.ForeignKey(
                        name: "FK_SensorState_SensorDetails_sensorId",
                        column: x => x.sensorId,
                        principalTable: "SensorDetails",
                        principalColumn: "sensorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(nullable: true),
                    userPassword = table.Column<string>(nullable: true),
                    userEmail = table.Column<string>(nullable: true),
                    userMobileNo = table.Column<string>(nullable: true),
                    userRoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_userRoleId",
                        column: x => x.userRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "roleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensorState_sensorId",
                table: "SensorState",
                column: "sensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userRoleId",
                table: "Users",
                column: "userRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SensorState");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SensorDetails");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
