using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagment.Persistance.Migrations
{
    public partial class add_precision_to_price_in_product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "StockProduct",
                type: "decimal(22,4)",
                precision: 22,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "StockProduct",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(22,4)",
                oldPrecision: 22,
                oldScale: 4);
        }
    }
}
