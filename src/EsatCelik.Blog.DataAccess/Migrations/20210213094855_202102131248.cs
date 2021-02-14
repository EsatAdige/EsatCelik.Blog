using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EsatCelik.Blog.DataAccess.Migrations
{
    public partial class _202102131248 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 2, 12, 21, 33, 24, 346, DateTimeKind.Local).AddTicks(3914));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertDate",
                value: new DateTime(2021, 2, 12, 21, 33, 24, 346, DateTimeKind.Local).AddTicks(4397));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertDate",
                value: new DateTime(2021, 2, 12, 21, 33, 24, 346, DateTimeKind.Local).AddTicks(4400));
        }
    }
}
