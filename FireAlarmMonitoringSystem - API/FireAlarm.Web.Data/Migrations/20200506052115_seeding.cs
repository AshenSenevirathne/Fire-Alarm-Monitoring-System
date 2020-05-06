using Microsoft.EntityFrameworkCore.Migrations;

namespace FireAlarm.Web.Data.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SensorDetails",
                columns: new[] { "sensorId", "coLevel", "floorNo", "roomNo", "sensorName", "sensorRemark", "sensorStatus", "smokeLevel" },
                values: new object[,]
                {
                    { 1, 0, "2", "1", "Sensor One", null, "A", 0 },
                    { 2, 0, "1", "8", "Sensor Two", null, "A", 0 },
                    { 3, 0, "3", "3", "Sensor Three", null, "A", 0 },
                    { 4, 0, "6", "1", "Sensor Four", null, "A", 0 },
                    { 5, 0, "5", "2", "Sensor Five", null, "A", 0 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "roleId", "roleDescription" },
                values: new object[,]
                {
                    { 1, "SDUSER" },
                    { 2, "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "userEmail", "userMobileNo", "userName", "userPassword", "userRoleId" },
                values: new object[] { 2, "dimuthuc2@gmail.com", "0757123456", "Dimuthu Abesighe", "abc123", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "userEmail", "userMobileNo", "userName", "userPassword", "userRoleId" },
                values: new object[] { 1, "kusalpriyanka782@gmail.com", "0777123456", "Kusal Priyanka", "abc123", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SensorDetails",
                keyColumn: "sensorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SensorDetails",
                keyColumn: "sensorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SensorDetails",
                keyColumn: "sensorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SensorDetails",
                keyColumn: "sensorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SensorDetails",
                keyColumn: "sensorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "roleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "roleId",
                keyValue: 2);
        }
    }
}
