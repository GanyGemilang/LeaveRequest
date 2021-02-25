using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveRequest.Migrations
{
    public partial class addModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "NIK",
                table: "TB_M_Request",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Request_NIK",
                table: "TB_M_Request",
                column: "NIK");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_Request_TB_M_User_NIK",
                table: "TB_M_Request",
                column: "NIK",
                principalTable: "TB_M_User",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_Request_TB_M_User_NIK",
                table: "TB_M_Request");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_Request_NIK",
                table: "TB_M_Request");

            migrationBuilder.AlterColumn<string>(
                name: "NIK",
                table: "TB_M_Request",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserNIK",
                table: "TB_M_Request",
                type: "nvarchar(10)",
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
    }
}
