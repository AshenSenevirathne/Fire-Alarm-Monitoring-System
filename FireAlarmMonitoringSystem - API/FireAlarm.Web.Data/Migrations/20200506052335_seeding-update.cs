using Microsoft.EntityFrameworkCore.Migrations;

namespace FireAlarm.Web.Data.Migrations
{
    public partial class seedingupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 1,
                column: "userMobileNo",
                value: "+940755628231");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 2,
                column: "userMobileNo",
                value: "+940766944088");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 1,
                column: "userMobileNo",
                value: "0777123456");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 2,
                column: "userMobileNo",
                value: "0757123456");
        }
    }
}
