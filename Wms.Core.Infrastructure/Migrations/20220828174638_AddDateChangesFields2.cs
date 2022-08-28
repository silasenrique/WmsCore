using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wms.Core.Infrastructure.Migrations
{
    public partial class AddDateChangesFields2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreationDate",
                table: "ProductPackaging",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LastChangeDate",
                table: "ProductPackaging",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreationDate",
                table: "ProductControl",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LastChangeDate",
                table: "ProductControl",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreationDate",
                table: "Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LastChangeDate",
                table: "Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductPackaging");

            migrationBuilder.DropColumn(
                name: "LastChangeDate",
                table: "ProductPackaging");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductControl");

            migrationBuilder.DropColumn(
                name: "LastChangeDate",
                table: "ProductControl");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "LastChangeDate",
                table: "Product");
        }
    }
}
