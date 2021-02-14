using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EsatCelik.Blog.DataAccess.Migrations
{
    public partial class _202102131502 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 2, 13, 15, 2, 55, 624, DateTimeKind.Local).AddTicks(6391));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertDate",
                value: new DateTime(2021, 2, 13, 15, 2, 55, 624, DateTimeKind.Local).AddTicks(6825));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertDate",
                value: new DateTime(2021, 2, 13, 15, 2, 55, 624, DateTimeKind.Local).AddTicks(6827));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertedBy = table.Column<int>(type: "int", nullable: false),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTags",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTags", x => new { x.ArticleId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ArticleTags_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticleTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 2, 13, 14, 1, 51, 325, DateTimeKind.Local).AddTicks(2806));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertDate",
                value: new DateTime(2021, 2, 13, 14, 1, 51, 325, DateTimeKind.Local).AddTicks(3277));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertDate",
                value: new DateTime(2021, 2, 13, 14, 1, 51, 325, DateTimeKind.Local).AddTicks(3280));

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTags_TagId",
                table: "ArticleTags",
                column: "TagId");
        }
    }
}
