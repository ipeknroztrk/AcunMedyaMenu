using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcunMedyaMenu.Migrations
{
    public partial class migstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE \"Bookings\" ALTER COLUMN \"Status\" TYPE boolean USING \"Status\"::boolean;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Bookings",
                type: "text",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);
        }
    }
}
