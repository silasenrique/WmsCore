using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Wms.Core.Infrastructure.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DistributionCenter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Document = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<long>(type: "bigint", nullable: false),
                    LastChangeDate = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributionCenter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Document = table.Column<string>(type: "text", nullable: true),
                    TypeDoc = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                    table.UniqueConstraint("AK_Owner_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Document = table.Column<string>(type: "text", nullable: true),
                    TypeDoc = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.Id);
                    table.UniqueConstraint("AK_Provider_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Shipping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Document = table.Column<string>(type: "text", nullable: true),
                    TypeDoc = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitizerType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MaximumWeight = table.Column<float>(type: "real", nullable: false),
                    WeightUnit = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    HeightUnit = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    WidthUnit = table.Column<int>(type: "integer", nullable: false),
                    Length = table.Column<float>(type: "real", nullable: false),
                    LengthUnit = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitizerType", x => x.Id);
                    table.UniqueConstraint("AK_UnitizerType_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    OwnerCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.UniqueConstraint("AK_Product_OwnerCode_Code", x => new { x.OwnerCode, x.Code });
                    table.ForeignKey(
                        name: "FK_Product_Owner_OwnerCode",
                        column: x => x.OwnerCode,
                        principalTable: "Owner",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    ControlType = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    WeightUnit = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    HeightUnit = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    WidthUnit = table.Column<int>(type: "integer", nullable: false),
                    Length = table.Column<float>(type: "real", nullable: false),
                    LengthUnit = table.Column<int>(type: "integer", nullable: false),
                    Cd = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAddress", x => x.Id);
                    table.UniqueConstraint("AK_TypeAddress_Cd_Code", x => new { x.Cd, x.Code });
                    table.ForeignKey(
                        name: "FK_TypeAddress_Provider_Cd",
                        column: x => x.Cd,
                        principalTable: "Provider",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Deposit = table.Column<string>(type: "text", nullable: false),
                    Area = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    FirstComponent = table.Column<string>(type: "text", nullable: true),
                    SecondComponent = table.Column<string>(type: "text", nullable: true),
                    ThirdComponent = table.Column<string>(type: "text", nullable: true),
                    FourthComponent = table.Column<string>(type: "text", nullable: true),
                    FifthComponent = table.Column<string>(type: "text", nullable: true),
                    SixthComponent = table.Column<string>(type: "text", nullable: true),
                    AddressFormat = table.Column<string>(type: "text", nullable: true),
                    Dock = table.Column<bool>(type: "boolean", nullable: false),
                    SingleProduct = table.Column<bool>(type: "boolean", nullable: false),
                    SingleBatch = table.Column<bool>(type: "boolean", nullable: false),
                    FixedPicking = table.Column<bool>(type: "boolean", nullable: false),
                    DynamicReplacement = table.Column<bool>(type: "boolean", nullable: false),
                    MinimumAndMaximumReplacement = table.Column<bool>(type: "boolean", nullable: false),
                    Cd = table.Column<string>(type: "text", nullable: false),
                    TypeAddressCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.Id);
                    table.UniqueConstraint("AK_Zone_Cd_Deposit_Area", x => new { x.Cd, x.Deposit, x.Area });
                    table.ForeignKey(
                        name: "FK_Zone_Provider_Cd",
                        column: x => x.Cd,
                        principalTable: "Provider",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPackaging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BarCode = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    MaximumWeight = table.Column<float>(type: "real", nullable: false),
                    WeightUnit = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    HeightUnit = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    WidthUnit = table.Column<int>(type: "integer", nullable: false),
                    Length = table.Column<float>(type: "real", nullable: false),
                    LengthUnit = table.Column<int>(type: "integer", nullable: false),
                    Cd = table.Column<string>(type: "text", nullable: false),
                    OwnerCode = table.Column<string>(type: "text", nullable: false),
                    ProductCode = table.Column<string>(type: "text", nullable: false),
                    UnitizerType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPackaging", x => x.Id);
                    table.UniqueConstraint("AK_ProductPackaging_Cd_OwnerCode_ProductCode_UnitizerType", x => new { x.Cd, x.OwnerCode, x.ProductCode, x.UnitizerType });
                    table.ForeignKey(
                        name: "FK_ProductPackaging_Product_OwnerCode_ProductCode",
                        columns: x => new { x.OwnerCode, x.ProductCode },
                        principalTable: "Product",
                        principalColumns: new[] { "OwnerCode", "Code" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPackaging_Provider_Cd",
                        column: x => x.Cd,
                        principalTable: "Provider",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPackaging_UnitizerType_UnitizerType",
                        column: x => x.UnitizerType,
                        principalTable: "UnitizerType",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OccupationStatus = table.Column<int>(type: "integer", nullable: false),
                    OccupancyPercentage = table.Column<int>(type: "integer", nullable: false),
                    BarCode = table.Column<string>(type: "text", nullable: true),
                    FirstComponent = table.Column<string>(type: "text", nullable: true),
                    SecondComponent = table.Column<string>(type: "text", nullable: true),
                    ThirdComponent = table.Column<string>(type: "text", nullable: true),
                    FourthComponent = table.Column<string>(type: "text", nullable: true),
                    FifthComponent = table.Column<string>(type: "text", nullable: true),
                    SixthComponent = table.Column<string>(type: "text", nullable: true),
                    SingleProduct = table.Column<bool>(type: "boolean", nullable: false),
                    SingleBatch = table.Column<bool>(type: "boolean", nullable: false),
                    FixedPicking = table.Column<bool>(type: "boolean", nullable: false),
                    MinimumAmount = table.Column<float>(type: "real", nullable: false),
                    MaximumAmount = table.Column<float>(type: "real", nullable: false),
                    OwnerCode = table.Column<string>(type: "text", nullable: true),
                    ProductCode = table.Column<string>(type: "text", nullable: true),
                    TypeAddress = table.Column<string>(type: "text", nullable: true),
                    Cd = table.Column<string>(type: "text", nullable: false),
                    Deposit = table.Column<string>(type: "text", nullable: false),
                    Area = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAddresses", x => x.Id);
                    table.UniqueConstraint("AK_StockAddresses_Cd_Deposit_Area_Address", x => new { x.Cd, x.Deposit, x.Area, x.Address });
                    table.ForeignKey(
                        name: "FK_StockAddresses_Owner_OwnerCode",
                        column: x => x.OwnerCode,
                        principalTable: "Owner",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_StockAddresses_Product_OwnerCode_ProductCode",
                        columns: x => new { x.OwnerCode, x.ProductCode },
                        principalTable: "Product",
                        principalColumns: new[] { "OwnerCode", "Code" });
                    table.ForeignKey(
                        name: "FK_StockAddresses_Provider_Cd",
                        column: x => x.Cd,
                        principalTable: "Provider",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockAddresses_TypeAddress_Cd_TypeAddress",
                        columns: x => new { x.Cd, x.TypeAddress },
                        principalTable: "TypeAddress",
                        principalColumns: new[] { "Cd", "Code" });
                    table.ForeignKey(
                        name: "FK_StockAddresses_Zone_Cd_Deposit_Area",
                        columns: x => new { x.Cd, x.Deposit, x.Area },
                        principalTable: "Zone",
                        principalColumns: new[] { "Cd", "Deposit", "Area" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductControl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Lot = table.Column<bool>(type: "boolean", nullable: false),
                    ExpirationDate = table.Column<bool>(type: "boolean", nullable: false),
                    ProductionDate = table.Column<bool>(type: "boolean", nullable: false),
                    Cd = table.Column<string>(type: "text", nullable: true),
                    DriveUnit = table.Column<string>(type: "text", nullable: true),
                    OwnerCode = table.Column<string>(type: "text", nullable: true),
                    ProductCode = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductControl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductControl_Product_OwnerCode_ProductCode",
                        columns: x => new { x.OwnerCode, x.ProductCode },
                        principalTable: "Product",
                        principalColumns: new[] { "OwnerCode", "Code" });
                    table.ForeignKey(
                        name: "FK_ProductControl_ProductPackaging_Cd_OwnerCode_ProductCode_Dr~",
                        columns: x => new { x.Cd, x.OwnerCode, x.ProductCode, x.DriveUnit },
                        principalTable: "ProductPackaging",
                        principalColumns: new[] { "Cd", "OwnerCode", "ProductCode", "UnitizerType" });
                    table.ForeignKey(
                        name: "FK_ProductControl_Provider_Cd",
                        column: x => x.Cd,
                        principalTable: "Provider",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "Unitizer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NrUnitizer = table.Column<int>(type: "integer", nullable: false),
                    InMotion = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UnitizerType = table.Column<string>(type: "text", nullable: true),
                    Cd = table.Column<string>(type: "text", nullable: false),
                    Deposit = table.Column<string>(type: "text", nullable: true),
                    Area = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unitizer", x => x.Id);
                    table.UniqueConstraint("AK_Unitizer_Cd_NrUnitizer", x => new { x.Cd, x.NrUnitizer });
                    table.ForeignKey(
                        name: "FK_Unitizer_Provider_Cd",
                        column: x => x.Cd,
                        principalTable: "Provider",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Unitizer_StockAddresses_Cd_Deposit_Area_Address",
                        columns: x => new { x.Cd, x.Deposit, x.Area, x.Address },
                        principalTable: "StockAddresses",
                        principalColumns: new[] { "Cd", "Deposit", "Area", "Address" });
                    table.ForeignKey(
                        name: "FK_Unitizer_UnitizerType_UnitizerType",
                        column: x => x.UnitizerType,
                        principalTable: "UnitizerType",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Lot = table.Column<string>(type: "text", nullable: true),
                    ExpirationDate = table.Column<string>(type: "text", nullable: true),
                    ProductionDate = table.Column<string>(type: "text", nullable: true),
                    Blocked = table.Column<bool>(type: "boolean", nullable: false),
                    InMotion = table.Column<bool>(type: "boolean", nullable: false),
                    BlockingReason = table.Column<int>(type: "integer", nullable: false),
                    AvailableQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    ReservedQuantity = table.Column<decimal>(type: "numeric", nullable: false),
                    QuantityInCirculation = table.Column<decimal>(type: "numeric", nullable: false),
                    OwnerCode = table.Column<string>(type: "text", nullable: true),
                    ProductCode = table.Column<string>(type: "text", nullable: true),
                    NrUnitizer = table.Column<int>(type: "integer", nullable: false),
                    Cd = table.Column<string>(type: "text", nullable: true),
                    Deposit = table.Column<string>(type: "text", nullable: true),
                    Area = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Owner_OwnerCode",
                        column: x => x.OwnerCode,
                        principalTable: "Owner",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Stock_Product_OwnerCode_ProductCode",
                        columns: x => new { x.OwnerCode, x.ProductCode },
                        principalTable: "Product",
                        principalColumns: new[] { "OwnerCode", "Code" });
                    table.ForeignKey(
                        name: "FK_Stock_Provider_Cd",
                        column: x => x.Cd,
                        principalTable: "Provider",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Stock_StockAddresses_Cd_Deposit_Area_Address",
                        columns: x => new { x.Cd, x.Deposit, x.Area, x.Address },
                        principalTable: "StockAddresses",
                        principalColumns: new[] { "Cd", "Deposit", "Area", "Address" });
                    table.ForeignKey(
                        name: "FK_Stock_Unitizer_Cd_NrUnitizer",
                        columns: x => new { x.Cd, x.NrUnitizer },
                        principalTable: "Unitizer",
                        principalColumns: new[] { "Cd", "NrUnitizer" });
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Owner_Code",
                table: "Owner",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owner_Document",
                table: "Owner",
                column: "Document",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_OwnerCode_Code",
                table: "Product",
                columns: new[] { "OwnerCode", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductControl_Cd_OwnerCode_ProductCode",
                table: "ProductControl",
                columns: new[] { "Cd", "OwnerCode", "ProductCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductControl_Cd_OwnerCode_ProductCode_DriveUnit",
                table: "ProductControl",
                columns: new[] { "Cd", "OwnerCode", "ProductCode", "DriveUnit" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductControl_OwnerCode_ProductCode",
                table: "ProductControl",
                columns: new[] { "OwnerCode", "ProductCode" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPackaging_Cd_BarCode",
                table: "ProductPackaging",
                columns: new[] { "Cd", "BarCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductPackaging_Cd_OwnerCode_ProductCode_UnitizerType",
                table: "ProductPackaging",
                columns: new[] { "Cd", "OwnerCode", "ProductCode", "UnitizerType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductPackaging_OwnerCode_ProductCode",
                table: "ProductPackaging",
                columns: new[] { "OwnerCode", "ProductCode" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPackaging_UnitizerType",
                table: "ProductPackaging",
                column: "UnitizerType");

            migrationBuilder.CreateIndex(
                name: "IX_Provider_Code",
                table: "Provider",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Provider_Document",
                table: "Provider",
                column: "Document",
                unique: true);

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
                name: "IX_Stock_Cd_Deposit_Area_Address",
                table: "Stock",
                columns: new[] { "Cd", "Deposit", "Area", "Address" });

            migrationBuilder.CreateIndex(
                name: "IX_Stock_Cd_NrUnitizer",
                table: "Stock",
                columns: new[] { "Cd", "NrUnitizer" });

            migrationBuilder.CreateIndex(
                name: "IX_Stock_Cd_OwnerCode_ProductCode_Deposit_Area_Address_NrUniti~",
                table: "Stock",
                columns: new[] { "Cd", "OwnerCode", "ProductCode", "Deposit", "Area", "Address", "NrUnitizer", "Lot", "ProductionDate", "ExpirationDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stock_OwnerCode_ProductCode",
                table: "Stock",
                columns: new[] { "OwnerCode", "ProductCode" });

            migrationBuilder.CreateIndex(
                name: "IX_StockAddresses_Cd_BarCode",
                table: "StockAddresses",
                columns: new[] { "Cd", "BarCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockAddresses_Cd_Deposit_Area_Address",
                table: "StockAddresses",
                columns: new[] { "Cd", "Deposit", "Area", "Address" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockAddresses_Cd_TypeAddress",
                table: "StockAddresses",
                columns: new[] { "Cd", "TypeAddress" });

            migrationBuilder.CreateIndex(
                name: "IX_StockAddresses_OwnerCode_ProductCode",
                table: "StockAddresses",
                columns: new[] { "OwnerCode", "ProductCode" });

            migrationBuilder.CreateIndex(
                name: "IX_TypeAddress_Cd_Code",
                table: "TypeAddress",
                columns: new[] { "Cd", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unitizer_Cd_Deposit_Area_Address",
                table: "Unitizer",
                columns: new[] { "Cd", "Deposit", "Area", "Address" });

            migrationBuilder.CreateIndex(
                name: "IX_Unitizer_Cd_NrUnitizer_UnitizerType",
                table: "Unitizer",
                columns: new[] { "Cd", "NrUnitizer", "UnitizerType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unitizer_UnitizerType",
                table: "Unitizer",
                column: "UnitizerType");

            migrationBuilder.CreateIndex(
                name: "IX_Zone_Cd_Deposit_Area",
                table: "Zone",
                columns: new[] { "Cd", "Deposit", "Area" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistributionCenter");

            migrationBuilder.DropTable(
                name: "ProductControl");

            migrationBuilder.DropTable(
                name: "Shipping");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "ProductPackaging");

            migrationBuilder.DropTable(
                name: "Unitizer");

            migrationBuilder.DropTable(
                name: "StockAddresses");

            migrationBuilder.DropTable(
                name: "UnitizerType");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "TypeAddress");

            migrationBuilder.DropTable(
                name: "Zone");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "Provider");
        }
    }
}
