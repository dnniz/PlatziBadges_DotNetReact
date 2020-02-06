using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlatziBadges.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Badge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlagActivo = table.Column<bool>(nullable: false),
                    FlagEliminado = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<string>(maxLength: 120, nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: true),
                    ModificadoPor = table.Column<string>(maxLength: 120, nullable: true),
                    FechaModificacion = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    JobTitle = table.Column<string>(maxLength: 100, nullable: true),
                    Twitter = table.Column<string>(maxLength: 50, nullable: true),
                    AvatarUrl = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badge", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Badge");
        }
    }
}
