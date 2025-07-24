using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BudgetPerServing.Migrations
{
    /// <inheritdoc />
    public partial class update_database_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "TotalServings",
                table: "FoodItems");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FoodItems",
                newName: "ShortDescription");

            migrationBuilder.AddColumn<int>(
                name: "FdcId",
                table: "ServingLogs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AllHighlightFields",
                table: "FoodItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BrandName",
                table: "FoodItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BrandOwner",
                table: "FoodItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataSource",
                table: "FoodItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataType",
                table: "FoodItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FoodItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FdcId",
                table: "FoodItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FoodCategory",
                table: "FoodItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GtinUpc",
                table: "FoodItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HouseholdServingFullText",
                table: "FoodItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "FoodItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MarketCountry",
                table: "FoodItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedDate",
                table: "FoodItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PackageWeight",
                table: "FoodItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "FoodItems",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PublishedDate",
                table: "FoodItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "FoodItems",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ServingSize",
                table: "FoodItems",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ServingSizeUnit",
                table: "FoodItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "FoodItems",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<List<string>>(
                name: "TradeChannels",
                table: "FoodItems",
                type: "text[]",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "FoodNutrient",
                columns: table => new
                {
                    FoodNutrientId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NutrientId = table.Column<int>(type: "integer", nullable: false),
                    NutrientName = table.Column<string>(type: "text", nullable: false),
                    NutrientNumber = table.Column<string>(type: "text", nullable: false),
                    UnitName = table.Column<string>(type: "text", nullable: false),
                    DerivationCode = table.Column<string>(type: "text", nullable: false),
                    DerivationDescription = table.Column<string>(type: "text", nullable: false),
                    DerivationId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false),
                    FoodNutrientSourceId = table.Column<int>(type: "integer", nullable: false),
                    FoodNutrientSourceCode = table.Column<string>(type: "text", nullable: false),
                    FoodNutrientSourceDescription = table.Column<string>(type: "text", nullable: false),
                    Rank = table.Column<int>(type: "integer", nullable: false),
                    IndentLevel = table.Column<int>(type: "integer", nullable: false),
                    PercentDailyValue = table.Column<int>(type: "integer", nullable: true),
                    FoodItemId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodNutrient", x => x.FoodNutrientId);
                    table.ForeignKey(
                        name: "FK_FoodNutrient_FoodItems_FoodItemId",
                        column: x => x.FoodItemId,
                        principalTable: "FoodItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Suite = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_StoreId",
                table: "FoodItems",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodNutrient_FoodItemId",
                table: "FoodNutrient",
                column: "FoodItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_Stores_StoreId",
                table: "FoodItems",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_Stores_StoreId",
                table: "FoodItems");

            migrationBuilder.DropTable(
                name: "FoodNutrient");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_FoodItems_StoreId",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "FdcId",
                table: "ServingLogs");

            migrationBuilder.DropColumn(
                name: "AllHighlightFields",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "BrandName",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "BrandOwner",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "DataSource",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "DataType",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "FdcId",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "FoodCategory",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "GtinUpc",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "HouseholdServingFullText",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "MarketCountry",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "PackageWeight",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "PublishedDate",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "ServingSize",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "ServingSizeUnit",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "TradeChannels",
                table: "FoodItems");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "FoodItems",
                newName: "Name");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "FoodItems",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalServings",
                table: "FoodItems",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
