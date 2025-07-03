using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetPerServing.Migrations
{
    /// <inheritdoc />
    public partial class datetimeupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "ServingLogs",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "FdcId",
                table: "ServingLogs",
                type: "character varying(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FdcId",
                table: "ServingLogs");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "ServingLogs",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
