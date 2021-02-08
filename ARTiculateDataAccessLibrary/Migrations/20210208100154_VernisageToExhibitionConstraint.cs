using Microsoft.EntityFrameworkCore.Migrations;

namespace ARTiculateDataAccessLibrary.Migrations
{
    public partial class VernisageToExhibitionConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExhibitionId",
                table: "Vernisages",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vernisages_ExhibitionId",
                table: "Vernisages",
                column: "ExhibitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vernisages_Exhibitions_ExhibitionId",
                table: "Vernisages",
                column: "ExhibitionId",
                principalTable: "Exhibitions",
                principalColumn: "Id");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vernisages_Exhibitions_ExhibitionId",
                table: "Vernisages");

            migrationBuilder.DropIndex(
                name: "IX_Vernisages_ExhibitionId",
                table: "Vernisages");

            migrationBuilder.DropColumn(
                name: "ExhibitionId",
                table: "Vernisages");
        }
    }
}
