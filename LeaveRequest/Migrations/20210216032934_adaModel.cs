using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveRequest.Migrations
{
    public partial class adaModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Parameter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Parameter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Request",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerName = table.Column<string>(maxLength: 20, nullable: false),
                    ReasionRequest = table.Column<int>(nullable: false),
                    QuotaLeaveRequest = table.Column<int>(nullable: false),
                    ApprovedManager = table.Column<int>(nullable: false),
                    StartDate = table.Column<string>(nullable: false),
                    EndDate = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: false),
                    UploadProof = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Request", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_User",
                columns: table => new
                {
                    NIK = table.Column<string>(maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 255, nullable: true),
                    Password = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    MarriedStatus = table.Column<int>(nullable: false),
                    ManagerId = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    Phone = table.Column<string>(maxLength: 12, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_User", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_TB_M_User_TB_M_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "TB_M_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Account",
                columns: table => new
                {
                    NIK = table.Column<string>(maxLength: 10, nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Account", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_TB_M_Account_TB_M_User_NIK",
                        column: x => x.NIK,
                        principalTable: "TB_M_User",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_RequestHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmitDate = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    RequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_RequestHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_RequestHistory_TB_M_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "TB_M_Request",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_M_RequestHistory_TB_M_User_UserId",
                        column: x => x.UserId,
                        principalTable: "TB_M_User",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_RequestHistory_RequestId",
                table: "TB_M_RequestHistory",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_RequestHistory_UserId",
                table: "TB_M_RequestHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_User_RoleId",
                table: "TB_M_User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_M_Account");

            migrationBuilder.DropTable(
                name: "TB_M_Parameter");

            migrationBuilder.DropTable(
                name: "TB_M_RequestHistory");

            migrationBuilder.DropTable(
                name: "TB_M_Request");

            migrationBuilder.DropTable(
                name: "TB_M_User");

            migrationBuilder.DropTable(
                name: "TB_M_Role");
        }
    }
}
