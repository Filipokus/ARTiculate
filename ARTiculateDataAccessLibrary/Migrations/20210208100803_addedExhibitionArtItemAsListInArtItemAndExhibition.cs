using Microsoft.EntityFrameworkCore.Migrations;

namespace ARTiculateDataAccessLibrary.Migrations
{
    public partial class addedExhibitionArtItemAsListInArtItemAndExhibition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtItems_Exhibition_ArtItems_Exhibition_ArtItemExhibitionId_Exhibition_ArtItemArtItemId",
                table: "ArtItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Exhibitions_Exhibition_ArtItems_Exhibition_ArtItemExhibitionId_Exhibition_ArtItemArtItemId",
                table: "Exhibitions");

            migrationBuilder.DropIndex(
                name: "IX_Exhibitions_Exhibition_ArtItemExhibitionId_Exhibition_ArtItemArtItemId",
                table: "Exhibitions");

            migrationBuilder.DropIndex(
                name: "IX_ArtItems_Exhibition_ArtItemExhibitionId_Exhibition_ArtItemArtItemId",
                table: "ArtItems");

            migrationBuilder.DropColumn(
                name: "Exhibition_ArtItemArtItemId",
                table: "Exhibitions");

            migrationBuilder.DropColumn(
                name: "Exhibition_ArtItemExhibitionId",
                table: "Exhibitions");

            migrationBuilder.DropColumn(
                name: "Exhibition_ArtItemArtItemId",
                table: "ArtItems");

            migrationBuilder.DropColumn(
                name: "Exhibition_ArtItemExhibitionId",
                table: "ArtItems");

            migrationBuilder.AddColumn<int>(
                name: "ArtItemId",
                table: "Artist_Exhibitions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exhibition_ArtItems_ArtItemId",
                table: "Exhibition_ArtItems",
                column: "ArtItemId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Exhibition_ArtItems_ArtItems_ArtItemId",
                table: "Exhibition_ArtItems",
                column: "ArtItemId",
                principalTable: "ArtItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exhibition_ArtItems_Exhibitions_ExhibitionId",
                table: "Exhibition_ArtItems",
                column: "ExhibitionId",
                principalTable: "Exhibitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Exhibitions_ArtItems_ArtItemId",
                table: "Artist_Exhibitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Exhibition_ArtItems_ArtItems_ArtItemId",
                table: "Exhibition_ArtItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Exhibition_ArtItems_Exhibitions_ExhibitionId",
                table: "Exhibition_ArtItems");

            migrationBuilder.DropIndex(
                name: "IX_Exhibition_ArtItems_ArtItemId",
                table: "Exhibition_ArtItems");

            migrationBuilder.DropIndex(
                name: "IX_Artist_Exhibitions_ArtItemId",
                table: "Artist_Exhibitions");

            migrationBuilder.DropColumn(
                name: "ArtItemId",
                table: "Artist_Exhibitions");

            migrationBuilder.AddColumn<int>(
                name: "Exhibition_ArtItemArtItemId",
                table: "Exhibitions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exhibition_ArtItemExhibitionId",
                table: "Exhibitions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exhibition_ArtItemArtItemId",
                table: "ArtItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exhibition_ArtItemExhibitionId",
                table: "ArtItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exhibitions_Exhibition_ArtItemExhibitionId_Exhibition_ArtItemArtItemId",
                table: "Exhibitions",
                columns: new[] { "Exhibition_ArtItemExhibitionId", "Exhibition_ArtItemArtItemId" });

            migrationBuilder.CreateIndex(
                name: "IX_ArtItems_Exhibition_ArtItemExhibitionId_Exhibition_ArtItemArtItemId",
                table: "ArtItems",
                columns: new[] { "Exhibition_ArtItemExhibitionId", "Exhibition_ArtItemArtItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArtItems_Exhibition_ArtItems_Exhibition_ArtItemExhibitionId_Exhibition_ArtItemArtItemId",
                table: "ArtItems",
                columns: new[] { "Exhibition_ArtItemExhibitionId", "Exhibition_ArtItemArtItemId" },
                principalTable: "Exhibition_ArtItems",
                principalColumns: new[] { "ExhibitionId", "ArtItemId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exhibitions_Exhibition_ArtItems_Exhibition_ArtItemExhibitionId_Exhibition_ArtItemArtItemId",
                table: "Exhibitions",
                columns: new[] { "Exhibition_ArtItemExhibitionId", "Exhibition_ArtItemArtItemId" },
                principalTable: "Exhibition_ArtItems",
                principalColumns: new[] { "ExhibitionId", "ArtItemId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
