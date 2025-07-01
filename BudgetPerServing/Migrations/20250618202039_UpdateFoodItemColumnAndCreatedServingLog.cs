using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetPerServing.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFoodItemColumnAndCreatedServingLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "FoodItems",
                newName: "TotalPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "FoodItems",
                newName: "Price");
        }
    }
}
