using Microsoft.EntityFrameworkCore.Migrations;

namespace ARTiculateDataAccessLibrary.Migrations
{
    public partial class UpdateTableVernisageWithLiveLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LiveLink",
                table: "Vernisages",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LiveLink",
                table: "Vernisages");
        }
    }
}
