using Microsoft.EntityFrameworkCore.Migrations;

namespace ARTiculateDataAccessLibrary.Migrations
{
    public partial class AddedPosterInVernisageAndMadLinkRequied : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Exhibitions_ArtItems_ArtItemId",
                table: "Artist_Exhibitions");

            migrationBuilder.DropIndex(
                name: "IX_Artist_Exhibitions_ArtItemId",
                table: "Artist_Exhibitions");

            migrationBuilder.DropColumn(
                name: "ArtItemId",
                table: "Artist_Exhibitions");

            migrationBuilder.AlterColumn<string>(
                name: "LiveLink",
                table: "Vernisages",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Poster",
                table: "Vernisages",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Poster",
                table: "Vernisages");

            migrationBuilder.AlterColumn<string>(
                name: "LiveLink",
                table: "Vernisages",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<int>(
                name: "ArtItemId",
                table: "Artist_Exhibitions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artist_Exhibitions_ArtItemId",
                table: "Artist_Exhibitions",
                column: "ArtItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Exhibitions_ArtItems_ArtItemId",
                table: "Artist_Exhibitions",
                column: "ArtItemId",
                principalTable: "ArtItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
