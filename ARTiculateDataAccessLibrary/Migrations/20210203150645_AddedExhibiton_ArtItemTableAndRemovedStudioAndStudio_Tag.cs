using Microsoft.EntityFrameworkCore.Migrations;

namespace ARTiculateDataAccessLibrary.Migrations
{
    public partial class AddedExhibiton_ArtItemTableAndRemovedStudioAndStudio_Tag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Studio_Tags");

            migrationBuilder.DropTable(
                name: "Studio");

            migrationBuilder.AddColumn<int>(
                name: "Exhibition_ArtItemArtItemId",
                table: "Exhibitions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exhibition_ArtItemExhibitionId",
                table: "Exhibitions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exhibition_ArtItemArtItemId",
                table: "ArtItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exhibition_ArtItemExhibitionId",
                table: "ArtItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Exhibition_ArtItems",
                columns: table => new
                {
                    ExhibitionId = table.Column<int>(nullable: false),
                    ArtItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibition_ArtItems", x => new { x.ExhibitionId, x.ArtItemId });
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtItems_Exhibition_ArtItems_Exhibition_ArtItemExhibitionId_Exhibition_ArtItemArtItemId",
                table: "ArtItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Exhibitions_Exhibition_ArtItems_Exhibition_ArtItemExhibitionId_Exhibition_ArtItemArtItemId",
                table: "Exhibitions");

            migrationBuilder.DropTable(
                name: "Exhibition_ArtItems");

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

            migrationBuilder.CreateTable(
                name: "Studio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    Open = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Studio_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Studio_Tags",
                columns: table => new
                {
                    StudioId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studio_Tags", x => new { x.StudioId, x.TagId });
                    table.ForeignKey(
                        name: "FK_Studio_Tags_Studio_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Studio_Tags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Studio_ArtistId",
                table: "Studio",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Studio_Tags_TagId",
                table: "Studio_Tags",
                column: "TagId");
        }
    }
}
