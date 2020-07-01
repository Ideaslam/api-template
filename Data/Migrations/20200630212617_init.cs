using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "appResources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    AddUserId = table.Column<int>(nullable: false),
                    ModifyUserId = table.Column<int>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    ValueAr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    AddUserId = table.Column<int>(nullable: false),
                    ModifyUserId = table.Column<int>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    AddUserId = table.Column<int>(nullable: false),
                    ModifyUserId = table.Column<int>(nullable: false),
                    RowStatus = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    SignImage = table.Column<string>(nullable: true),
                    PortraitImage = table.Column<string>(nullable: true),
                    PosterImage = table.Column<string>(nullable: true),
                    BackgroundImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appResources");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
