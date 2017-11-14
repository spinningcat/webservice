using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NWSolution.Migrations
{
    public partial class nwsolution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Problem");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "user_detailinfo");

            migrationBuilder.DropTable(
                name: "problem_type");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.CreateTable(
                name: "nw",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longtitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deviceosversion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    network = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    problem_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    problem_note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    problem_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    report_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_devicetype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_deviceversion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nw", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nw");

            migrationBuilder.CreateTable(
                name: "problem_type",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    problem_type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_problem_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    network = table.Column<string>(nullable: true),
                    report_date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Latitude = table.Column<string>(nullable: true),
                    Longtitude = table.Column<string>(nullable: true),
                    user_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Problem",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    problem_date = table.Column<string>(nullable: true),
                    problem_note = table.Column<string>(nullable: true),
                    ptypeid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problem", x => x.id);
                    table.ForeignKey(
                        name: "FK_Problem_problem_type_ptypeid",
                        column: x => x.ptypeid,
                        principalTable: "problem_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_detailinfo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Userid = table.Column<int>(nullable: true),
                    deviceosversion = table.Column<string>(nullable: true),
                    user_devicetype = table.Column<string>(nullable: true),
                    user_deviceversion = table.Column<string>(nullable: true),
                    user_email = table.Column<string>(nullable: true),
                    user_phonenumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_detailinfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_detailinfo_user_Userid",
                        column: x => x.Userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Problem_ptypeid",
                table: "Problem",
                column: "ptypeid");

            migrationBuilder.CreateIndex(
                name: "IX_user_detailinfo_Userid",
                table: "user_detailinfo",
                column: "Userid");
        }
    }
}
