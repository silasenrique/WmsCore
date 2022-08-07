using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wms.Core.Infrastructure.Migrations
{
    public partial class AddDateTimeFilds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductControl_DistributionCenter_Cd",
                table: "ProductControl");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPackaging_DistributionCenter_Cd",
                table: "ProductPackaging");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_DistributionCenter_Cd",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_StockAddresses_DistributionCenter_Cd",
                table: "StockAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeAddress_DistributionCenter_Cd",
                table: "TypeAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Unitizer_DistributionCenter_Cd",
                table: "Unitizer");

            migrationBuilder.DropForeignKey(
                name: "FK_Zone_DistributionCenter_Cd",
                table: "Zone");

            migrationBuilder.DropIndex(
                name: "IX_Shipping_Code",
                table: "Shipping");

            migrationBuilder.DropIndex(
                name: "IX_Shipping_Document",
                table: "Shipping");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_DistributionCenter_Code",
                table: "DistributionCenter");

            migrationBuilder.DropIndex(
                name: "IX_DistributionCenter_Code",
                table: "DistributionCenter");

            migrationBuilder.DropIndex(
                name: "IX_DistributionCenter_Document",
                table: "DistributionCenter");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Shipping",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "Shipping",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Shipping",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Provider",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "Provider",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Provider",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Owner",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "Owner",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "DistributionCenter",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastChangeDate",
                table: "DistributionCenter",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DistributionCenter",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Provider_Code",
                table: "Provider",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductControl_Provider_Cd",
                table: "ProductControl",
                column: "Cd",
                principalTable: "Provider",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPackaging_Provider_Cd",
                table: "ProductPackaging",
                column: "Cd",
                principalTable: "Provider",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Provider_Cd",
                table: "Stock",
                column: "Cd",
                principalTable: "Provider",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_StockAddresses_Provider_Cd",
                table: "StockAddresses",
                column: "Cd",
                principalTable: "Provider",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeAddress_Provider_Cd",
                table: "TypeAddress",
                column: "Cd",
                principalTable: "Provider",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Unitizer_Provider_Cd",
                table: "Unitizer",
                column: "Cd",
                principalTable: "Provider",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zone_Provider_Cd",
                table: "Zone",
                column: "Cd",
                principalTable: "Provider",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductControl_Provider_Cd",
                table: "ProductControl");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPackaging_Provider_Cd",
                table: "ProductPackaging");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Provider_Cd",
                table: "Stock");

            migrationBuilder.DropForeignKey(
                name: "FK_StockAddresses_Provider_Cd",
                table: "StockAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeAddress_Provider_Cd",
                table: "TypeAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Unitizer_Provider_Cd",
                table: "Unitizer");

            migrationBuilder.DropForeignKey(
                name: "FK_Zone_Provider_Cd",
                table: "Zone");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Provider_Code",
                table: "Provider");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "DistributionCenter");

            migrationBuilder.DropColumn(
                name: "LastChangeDate",
                table: "DistributionCenter");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DistributionCenter");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Shipping",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "Shipping",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Shipping",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Provider",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "Provider",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Provider",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Owner",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "Owner",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_DistributionCenter_Code",
                table: "DistributionCenter",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Shipping_Code",
                table: "Shipping",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shipping_Document",
                table: "Shipping",
                column: "Document",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DistributionCenter_Code",
                table: "DistributionCenter",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DistributionCenter_Document",
                table: "DistributionCenter",
                column: "Document",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductControl_DistributionCenter_Cd",
                table: "ProductControl",
                column: "Cd",
                principalTable: "DistributionCenter",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPackaging_DistributionCenter_Cd",
                table: "ProductPackaging",
                column: "Cd",
                principalTable: "DistributionCenter",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_DistributionCenter_Cd",
                table: "Stock",
                column: "Cd",
                principalTable: "DistributionCenter",
                principalColumn: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_StockAddresses_DistributionCenter_Cd",
                table: "StockAddresses",
                column: "Cd",
                principalTable: "DistributionCenter",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeAddress_DistributionCenter_Cd",
                table: "TypeAddress",
                column: "Cd",
                principalTable: "DistributionCenter",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Unitizer_DistributionCenter_Cd",
                table: "Unitizer",
                column: "Cd",
                principalTable: "DistributionCenter",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zone_DistributionCenter_Cd",
                table: "Zone",
                column: "Cd",
                principalTable: "DistributionCenter",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
