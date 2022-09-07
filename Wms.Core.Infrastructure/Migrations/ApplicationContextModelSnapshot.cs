﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Wms.Core.Infrastructure.Context;

#nullable disable

namespace Wms.Core.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Wms.Core.Domain.Entities.Address.StockAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BarCode")
                        .HasColumnType("text");

                    b.Property<string>("Cd")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Deposit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FifthComponent")
                        .HasColumnType("text");

                    b.Property<string>("FirstComponent")
                        .HasColumnType("text");

                    b.Property<bool>("FixedPicking")
                        .HasColumnType("boolean");

                    b.Property<string>("FourthComponent")
                        .HasColumnType("text");

                    b.Property<float>("MaximumAmount")
                        .HasColumnType("real");

                    b.Property<float>("MinimumAmount")
                        .HasColumnType("real");

                    b.Property<int>("OccupancyPercentage")
                        .HasColumnType("integer");

                    b.Property<int>("OccupationStatus")
                        .HasColumnType("integer");

                    b.Property<string>("OwnerCode")
                        .HasColumnType("text");

                    b.Property<string>("ProductCode")
                        .HasColumnType("text");

                    b.Property<string>("SecondComponent")
                        .HasColumnType("text");

                    b.Property<bool>("SingleBatch")
                        .HasColumnType("boolean");

                    b.Property<bool>("SingleProduct")
                        .HasColumnType("boolean");

                    b.Property<string>("SixthComponent")
                        .HasColumnType("text");

                    b.Property<string>("ThirdComponent")
                        .HasColumnType("text");

                    b.Property<string>("TypeAddress")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Cd", "BarCode")
                        .IsUnique();

                    b.HasIndex("Cd", "TypeAddress");

                    b.HasIndex("OwnerCode", "ProductCode");

                    b.HasIndex("Cd", "Deposit", "Area", "Address")
                        .IsUnique();

                    b.ToTable("StockAddresses");
                });

            modelBuilder.Entity("Wms.Core.Domain.Entities.Address.Zone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressFormat")
                        .HasColumnType("text");

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cd")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Deposit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Dock")
                        .HasColumnType("boolean");

                    b.Property<bool>("DynamicReplacement")
                        .HasColumnType("boolean");

                    b.Property<string>("FifthComponent")
                        .HasColumnType("text");

                    b.Property<string>("FirstComponent")
                        .HasColumnType("text");

                    b.Property<bool>("FixedPicking")
                        .HasColumnType("boolean");

                    b.Property<string>("FourthComponent")
                        .HasColumnType("text");

                    b.Property<bool>("MinimumAndMaximumReplacement")
                        .HasColumnType("boolean");

                    b.Property<string>("SecondComponent")
                        .HasColumnType("text");

                    b.Property<bool>("SingleBatch")
                        .HasColumnType("boolean");

                    b.Property<bool>("SingleProduct")
                        .HasColumnType("boolean");

                    b.Property<string>("SixthComponent")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("ThirdComponent")
                        .HasColumnType("text");

                    b.Property<string>("TypeAddressCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Cd", "Deposit", "Area")
                        .IsUnique();

                    b.ToTable("Zone");
                });

            modelBuilder.Entity("Wms.Core.Domain.Entities.Entity.DistributionCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<long>("CreationDate")
                        .HasColumnType("bigint");

                    b.Property<string>("Document")
                        .HasColumnType("text");

                    b.Property<long>("LastChangeDate")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Document")
                        .IsUnique();

                    b.ToTable("DistributionCenter");
                });

            modelBuilder.Entity("Wms.Core.Domain.Entities.Entity.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("CreationDate")
                        .HasColumnType("bigint");

                    b.Property<string>("Document")
                        .HasColumnType("text");

                    b.Property<long>("LastChangeDate")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("TypeDoc")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Document")
                        .IsUnique();

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("Wms.Core.Domain.Entities.Entity.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("CreationDate")
                        .HasColumnType("bigint");

                    b.Property<string>("Document")
                        .HasColumnType("text");

                    b.Property<long>("LastChangeDate")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("TypeDoc")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Document")
                        .IsUnique();

                    b.ToTable("Provider");
                });

            modelBuilder.Entity("Wms.Core.Domain.Entities.Entity.Shipping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<long>("CreationDate")
                        .HasColumnType("bigint");

                    b.Property<string>("Document")
                        .HasColumnType("text");

                    b.Property<long>("LastChangeDate")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("TypeDoc")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Document")
                        .IsUnique();

                    b.ToTable("Shipping");
                });

            modelBuilder.Entity("Wms.Core.Domain.Entities.Inventory.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Area")
                        .HasColumnType("text");

                    b.Property<decimal>("AvailableQuantity")
                        .HasColumnType("numeric");

                    b.Property<bool>("Blocked")
                        .HasColumnType("boolean");

                    b.Property<int>("BlockingReason")
                        .HasColumnType("integer");

                    b.Property<string>("Cd")
                        .HasColumnType("text");

                    b.Property<string>("Deposit")
                        .HasColumnType("text");

                    b.Property<string>("ExpirationDate")
                        .HasColumnType("text");

                    b.Property<bool>("InMotion")
                        .HasColumnType("boolean");

                    b.Property<string>("Lot")
                        .HasColumnType("text");

                    b.Property<int>("NrUnitizer")
                        .HasColumnType("integer");

                    b.Property<string>("OwnerCode")
                        .HasColumnType("text");

                    b.Property<string>("ProductCode")
                        .HasColumnType("text");

                    b.Property<string>("ProductionDate")
                        .HasColumnType("text");

                    b.Property<decimal>("QuantityInCirculation")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ReservedQuantity")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("Cd", "NrUnitizer");

                    b.HasIndex("OwnerCode", "ProductCode");

                    b.HasIndex("Cd", "Deposit", "Area", "Address");

                    b.HasIndex("Cd", "OwnerCode", "ProductCode", "Deposit", "Area", "Address", "NrUnitizer", "Lot", "ProductionDate", "ExpirationDate")
                        .IsUnique();

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("Wms.Core.Domain.Entities.Product.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("CreationDate")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<long>("LastChangeDate")
                        .HasColumnType("bigint");

                    b.Property<string>("OwnerCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerCode", "Code")
                        .IsUnique();

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Wms.Core.Domain.Entities.Product.ProductControl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cd")
                        .HasColumnType("text");

                    b.Property<long>("CreationDate")
                        .HasColumnType("bigint");

                    b.Property<string>("DriveUnit")
                        .HasColumnType("text");

                    b.Property<bool>("ExpirationDate")
                        .HasColumnType("boolean");

                    b.Property<long>("LastChangeDate")
                        .HasColumnType("bigint");

                    b.Property<bool>("Lot")
                        .HasColumnType("boolean");

                    b.Property<string>("OwnerCode")
                        .HasColumnType("text");

                    b.Property<string>("ProductCode")
                        .HasColumnType("text");

                    b.Property<bool>("ProductionDate")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("OwnerCode", "ProductCode");

                    b.HasIndex("Cd", "OwnerCode", "ProductCode")
                        .IsUnique();

                    b.HasIndex("Cd", "OwnerCode", "ProductCode", "DriveUnit");

                    b.ToTable("ProductControl");
                });

            modelBuilder.Entity("Wms.Core.Domain.Entities.Product.ProductPackaging", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BarCode")
                        .HasColumnType("text");

                    b.Property<string>("Cd")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("CreationDate")
                        .HasColumnType("bigint");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<int>("HeightUnit")
                        .HasColumnType("integer");

                    b.Property<long>("LastChangeDate")
                        .HasColumnType("bigint");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<int>("LengthUnit")
                        .HasColumnType("integer");

                    b.Property<float>("MaximumWeight")
                        .HasColumnType("real");

                    b.Property<string>("OwnerCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<string>("UnitizerType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WeightUnit")
                        .HasColumnType("integer");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.Property<int>("WidthUnit")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UnitizerType");

                    b.HasIndex("Cd", "BarCode")
                        .IsUnique();

                    b.HasIndex("OwnerCode", "ProductCode");

                    b.HasIndex("Cd", "OwnerCode", "ProductCode", "UnitizerType")
                        .IsUnique();

                    b.ToTable("ProductPackaging");
                });

            modelBuilder.Entity("Wms.Core.Domain.Entities.Unitizer.Unitizer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Area")
                        .HasColumnType("text");

                    b.Property<string>("Cd")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Deposit")
                        .HasColumnType("text");

                    b.Property<bool>("InMotion")
                        .HasColumnType("boolean");

                    b.Property<int>("NrUnitizer")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("UnitizerType")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UnitizerType");

                    b.HasIndex("Cd", "NrUnitizer", "UnitizerType")
                        .IsUnique();

                    b.HasIndex("Cd", "Deposit", "Area", "Address");

                    b.ToTable("Unitizer");
                });

            modelBuilder.Entity("Wms.Core.Domain.Entities.Unitizer.UnitizerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("CreationDate")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<string>("HeightUnit")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar");

                    b.Property<long>("LastChangeDate")
                        .HasColumnType("bigint");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<string>("LengthUnit")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar");

                    b.Property<float>("MaximumWeight")
                        .HasColumnType("real");

                    b.Property<string>("WeightUnit")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.Property<string>("WidthUnit")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("UnitizerType");
                });

            modelBuilder.Entity("Wms.Core.Domain.Entities.Warehouse.TypeAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cd")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ControlType")
                        .HasColumnType("integer");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<int>("HeightUnit")
                        .HasColumnType("integer");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<int>("LengthUnit")
                        .HasColumnType("integer");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.Property<int>("WeightUnit")
                        .HasColumnType("integer");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.Property<int>("WidthUnit")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Cd", "Code")
                        .IsUnique();

                    b.ToTable("TypeAddress");
                });

            modelBuilder.Entity("Wms.Core.Domain.Entities.Address.StockAddress", b =>
                {
                    b.HasOne("Wms.Core.Domain.Entities.Entity.Provider", null)
                        .WithMany()
                        .HasForeignKey("Cd")
                        .HasPrincipalKey("Code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wms.Core.Domain.Entities.Entity.Owner", null)
                        .WithMany()
                        .HasForeignKey("OwnerCode")
                        .HasPrincipalKey("Code");

                    b.HasOne("Wms.Core.Domain.Entities.Warehouse.TypeAddress", null)
                        .WithMany()
                        .HasForeignKey("Cd", "TypeAddress")
                        .HasPrincipalKey("Cd", "Code");

                    b.HasOne("Wms.Core.Domain.Entities.Product.Product", null)
                        .WithMany()
                        .HasForeignKey("OwnerCode", "ProductCode")
                        .HasPrincipalKey("OwnerCode", "Code");

                    b.HasOne("Wms.Core.Domain.Entities.Address.Zone", null)
                        .WithMany()
                        .HasForeignKey("Cd", "Deposit", "Area")
                        .HasPrincipalKey("Cd", "Deposit", "Area")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wms.Core.Domain.Entities.Address.Zone", b =>
                {
                    b.HasOne("Wms.Core.Domain.Entities.Entity.Provider", null)
                        .WithMany()
                        .HasForeignKey("Cd")
                        .HasPrincipalKey("Code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wms.Core.Domain.Entities.Inventory.Inventory", b =>
                {
                    b.HasOne("Wms.Core.Domain.Entities.Entity.Provider", null)
                        .WithMany()
                        .HasForeignKey("Cd")
                        .HasPrincipalKey("Code");

                    b.HasOne("Wms.Core.Domain.Entities.Entity.Owner", null)
                        .WithMany()
                        .HasForeignKey("OwnerCode")
                        .HasPrincipalKey("Code");

                    b.HasOne("Wms.Core.Domain.Entities.Unitizer.Unitizer", null)
                        .WithMany()
                        .HasForeignKey("Cd", "NrUnitizer")
                        .HasPrincipalKey("Cd", "NrUnitizer");

                    b.HasOne("Wms.Core.Domain.Entities.Product.Product", null)
                        .WithMany()
                        .HasForeignKey("OwnerCode", "ProductCode")
                        .HasPrincipalKey("OwnerCode", "Code");

                    b.HasOne("Wms.Core.Domain.Entities.Address.StockAddress", null)
                        .WithMany()
                        .HasForeignKey("Cd", "Deposit", "Area", "Address")
                        .HasPrincipalKey("Cd", "Deposit", "Area", "Address");
                });

            modelBuilder.Entity("Wms.Core.Domain.Entities.Product.Product", b =>
                {
                    b.HasOne("Wms.Core.Domain.Entities.Entity.Owner", null)
                        .WithMany()
                        .HasForeignKey("OwnerCode")
                        .HasPrincipalKey("Code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wms.Core.Domain.Entities.Product.ProductControl", b =>
                {
                    b.HasOne("Wms.Core.Domain.Entities.Entity.Provider", null)
                        .WithMany()
                        .HasForeignKey("Cd")
                        .HasPrincipalKey("Code");

                    b.HasOne("Wms.Core.Domain.Entities.Product.Product", null)
                        .WithMany()
                        .HasForeignKey("OwnerCode", "ProductCode")
                        .HasPrincipalKey("OwnerCode", "Code");

                    b.HasOne("Wms.Core.Domain.Entities.Product.ProductPackaging", null)
                        .WithMany()
                        .HasForeignKey("Cd", "OwnerCode", "ProductCode", "DriveUnit")
                        .HasPrincipalKey("Cd", "OwnerCode", "ProductCode", "UnitizerType");
                });

            modelBuilder.Entity("Wms.Core.Domain.Entities.Product.ProductPackaging", b =>
                {
                    b.HasOne("Wms.Core.Domain.Entities.Entity.Provider", null)
                        .WithMany()
                        .HasForeignKey("Cd")
                        .HasPrincipalKey("Code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wms.Core.Domain.Entities.Unitizer.UnitizerType", null)
                        .WithMany()
                        .HasForeignKey("UnitizerType")
                        .HasPrincipalKey("Code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wms.Core.Domain.Entities.Product.Product", null)
                        .WithMany()
                        .HasForeignKey("OwnerCode", "ProductCode")
                        .HasPrincipalKey("OwnerCode", "Code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wms.Core.Domain.Entities.Unitizer.Unitizer", b =>
                {
                    b.HasOne("Wms.Core.Domain.Entities.Entity.Provider", null)
                        .WithMany()
                        .HasForeignKey("Cd")
                        .HasPrincipalKey("Code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wms.Core.Domain.Entities.Unitizer.UnitizerType", null)
                        .WithMany()
                        .HasForeignKey("UnitizerType")
                        .HasPrincipalKey("Code");

                    b.HasOne("Wms.Core.Domain.Entities.Address.StockAddress", null)
                        .WithMany()
                        .HasForeignKey("Cd", "Deposit", "Area", "Address")
                        .HasPrincipalKey("Cd", "Deposit", "Area", "Address");
                });

            modelBuilder.Entity("Wms.Core.Domain.Entities.Warehouse.TypeAddress", b =>
                {
                    b.HasOne("Wms.Core.Domain.Entities.Entity.Provider", null)
                        .WithMany()
                        .HasForeignKey("Cd")
                        .HasPrincipalKey("Code")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
