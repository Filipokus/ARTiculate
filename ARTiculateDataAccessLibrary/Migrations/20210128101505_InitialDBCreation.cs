using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARTiculateDataAccessLibrary.Migrations
{
    public partial class InitialDBCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Phonenumber = table.Column<string>(nullable: true),
                    Emailadress = table.Column<string>(nullable: true),
                    ProfilePicture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exhibitions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Open = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vernisages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Open = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vernisages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(nullable: false),
                    Picture = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Width = table.Column<string>(nullable: true),
                    Depth = table.Column<string>(nullable: true),
                    Open = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtItems_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Link",
                columns: table => new
                {
                    ArtistId = table.Column<int>(nullable: false),
                    Instagram = table.Column<string>(nullable: true),
                    Pinterest = table.Column<string>(nullable: true),
                    Patreon = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    FlickR = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Optional = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.ArtistId);
                    table.ForeignKey(
                        name: "FK_Link_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Studio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(nullable: false),
                    Open = table.Column<bool>(nullable: false)
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
                name: "Artist_Exhibitions",
                columns: table => new
                {
                    ArtistId = table.Column<int>(nullable: false),
                    ExhibitionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist_Exhibitions", x => new { x.ArtistId, x.ExhibitionId });
                    table.ForeignKey(
                        name: "FK_Artist_Exhibitions_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artist_Exhibitions_Exhibitions_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Artist_Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false),
                    ArtistId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist_Tags", x => new { x.ArtistId, x.TagId });
                    table.ForeignKey(
                        name: "FK_Artist_Tags_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artist_Tags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exhibition_Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false),
                    ExhibitionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exhibition_Tags", x => new { x.ExhibitionId, x.TagId });
                    table.ForeignKey(
                        name: "FK_Exhibition_Tags_Exhibitions_ExhibitionId",
                        column: x => x.ExhibitionId,
                        principalTable: "Exhibitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exhibition_Tags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Artist_Vernisages",
                columns: table => new
                {
                    ArtistId = table.Column<int>(nullable: false),
                    VernisageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist_Vernisages", x => new { x.ArtistId, x.VernisageId });
                    table.ForeignKey(
                        name: "FK_Artist_Vernisages_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artist_Vernisages_Vernisages_VernisageId",
                        column: x => x.VernisageId,
                        principalTable: "Vernisages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vernisage_Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false),
                    VernisageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vernisage_Tags", x => new { x.VernisageId, x.TagId });
                    table.ForeignKey(
                        name: "FK_Vernisage_Tags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vernisage_Tags_Vernisages_VernisageId",
                        column: x => x.VernisageId,
                        principalTable: "Vernisages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtItem_Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false),
                    ArtItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtItem_Tags", x => new { x.ArtItemId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ArtItem_Tags_ArtItems_ArtItemId",
                        column: x => x.ArtItemId,
                        principalTable: "ArtItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtItem_Tags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Studio_Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false),
                    StudioId = table.Column<int>(nullable: false)
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
                name: "IX_Artist_Exhibitions_ExhibitionId",
                table: "Artist_Exhibitions",
                column: "ExhibitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_Tags_TagId",
                table: "Artist_Tags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_Vernisages_VernisageId",
                table: "Artist_Vernisages",
                column: "VernisageId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtItem_Tags_TagId",
                table: "ArtItem_Tags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtItems_ArtistId",
                table: "ArtItems",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Exhibition_Tags_TagId",
                table: "Exhibition_Tags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Studio_ArtistId",
                table: "Studio",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Studio_Tags_TagId",
                table: "Studio_Tags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Vernisage_Tags_TagId",
                table: "Vernisage_Tags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artist_Exhibitions");

            migrationBuilder.DropTable(
                name: "Artist_Tags");

            migrationBuilder.DropTable(
                name: "Artist_Vernisages");

            migrationBuilder.DropTable(
                name: "ArtItem_Tags");

            migrationBuilder.DropTable(
                name: "Exhibition_Tags");

            migrationBuilder.DropTable(
                name: "Link");

            migrationBuilder.DropTable(
                name: "Studio_Tags");

            migrationBuilder.DropTable(
                name: "Vernisage_Tags");

            migrationBuilder.DropTable(
                name: "ArtItems");

            migrationBuilder.DropTable(
                name: "Exhibitions");

            migrationBuilder.DropTable(
                name: "Studio");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Vernisages");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
