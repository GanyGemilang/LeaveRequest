using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveRequest.Migrations
{
    public partial class addModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserNIK",
                table: "TB_M_Request",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Request_UserNIK",
                table: "TB_M_Request",
                column: "UserNIK");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Request_TB_M_User_UserNIK",
                table: "TB_M_Request",
                column: "UserNIK",
                principalTable: "TB_M_User",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Request_TB_M_User_UserNIK",
                table: "TB_M_Request");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Request_UserNIK",
                table: "TB_M_Request");

            migrationBuilder.DropColumn(
                name: "UserNIK",
                table: "TB_M_Request");
        }
    }
}
