using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wms.Core.Infrastructure.Migrations
{
    public partial class AddDateChangesFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreationDate",
                table: "Shipping",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LastChangeDate",
                table: "Shipping",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreationDate",
                table: "Provider",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LastChangeDate",
                table: "Provider",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreationDate",
                table: "Owner",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LastChangeDate",
                table: "Owner",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Shipping");

            migrationBuilder.DropColumn(
                name: "LastChangeDate",
                table: "Shipping");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "LastChangeDate",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "LastChangeDate",
                table: "Owner");
        }
    }
}
