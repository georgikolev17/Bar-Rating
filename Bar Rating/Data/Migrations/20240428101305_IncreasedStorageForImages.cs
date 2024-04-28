using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bar_Rating.Data.Migrations
{
    public partial class IncreasedStorageForImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "BarImage",
                table: "Bars",
                type: "varbinary(max)",
                maxLength: 2097152,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(2048)",
                oldMaxLength: 2048);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "BarImage",
                table: "Bars",
                type: "varbinary(2048)",
                maxLength: 2048,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldMaxLength: 2097152);
        }
    }
}
