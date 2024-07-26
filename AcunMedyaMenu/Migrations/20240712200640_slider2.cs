using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcunMedyaMenu.Migrations
{
    public partial class slider2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title2",
                table: "Sliders",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title2",
                table: "Sliders");
        }
    }
}
