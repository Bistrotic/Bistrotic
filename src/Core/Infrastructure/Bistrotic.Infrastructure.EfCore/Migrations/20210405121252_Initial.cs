using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bistrotic.Infrastructure.EfCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdHash = table.Column<int>(type: "int", nullable: false),
                    CreatedByUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUtcDateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Json = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JsonType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedByUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedUtcDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => new { x.IdHash, x.Id });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
