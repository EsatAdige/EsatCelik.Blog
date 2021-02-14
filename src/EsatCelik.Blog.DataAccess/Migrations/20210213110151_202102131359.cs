using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EsatCelik.Blog.DataAccess.Migrations
{
    public partial class _202102131359 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogAddress",
                table: "Articles",
                newName: "ArticleAddress");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArticleAddress",
                table: "Articles",
                newName: "BlogAddress");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 2, 13, 12, 48, 55, 114, DateTimeKind.Local).AddTicks(5556));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertDate",
                value: new DateTime(2021, 2, 13, 12, 48, 55, 114, DateTimeKind.Local).AddTicks(5999));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertDate",
                value: new DateTime(2021, 2, 13, 12, 48, 55, 114, DateTimeKind.Local).AddTicks(6001));
        }
    }
}
