using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication2.Migrations
{
    public partial class somechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dashboard",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    table.PrimaryKey("PK_Dashboard", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dashboard");
        }
    }
}
