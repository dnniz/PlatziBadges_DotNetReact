using Microsoft.EntityFrameworkCore.Migrations;

namespace PlatziBadges.Data.Migrations
{
    public partial class UpdateColumnBadge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Badge",
                table: "Badge");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Badge");

            migrationBuilder.AddColumn<int>(
                name: "BadgeId",
                table: "Badge",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Badge",
                table: "Badge",
                column: "BadgeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Badge",
                table: "Badge");

            migrationBuilder.DropColumn(
                name: "BadgeId",
                table: "Badge");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Badge",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Badge",
                table: "Badge",
                column: "Id");
        }
    }
}
