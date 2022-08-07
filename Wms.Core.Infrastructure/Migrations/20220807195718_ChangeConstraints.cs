using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wms.Core.Infrastructure.Migrations
{
    public partial class ChangeConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Shipping_Code",
                table: "Shipping");

            migrationBuilder.DropIndex(
                name: "IX_Shipping_Document",
                table: "Shipping");

            migrationBuilder.DropIndex(
                name: "IX_DistributionCenter_Code",
                table: "DistributionCenter");

            migrationBuilder.DropIndex(
                name: "IX_DistributionCenter_Document",
                table: "DistributionCenter");
        }
    }
}
