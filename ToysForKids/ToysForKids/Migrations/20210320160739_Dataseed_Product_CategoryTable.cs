using Microsoft.EntityFrameworkCore.Migrations;

namespace ToysForKids.Migrations
{
    public partial class Dataseed_Product_CategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Tank" },
                    { 2, "Car" },
                    { 3, "Aircraft" },
                    { 4, "Destroyer" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "FileAvatarName", "ProductName", "QuantityPerUnit", "UnitInStock", "UnitOnOrder", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, "USA-World War 1", "M1917.jpg", "M1917", 20L, 20L, 0L, 120000L },
                    { 2, 1, "USA-World War 1", "M1918.jpg", "M1918", 20L, 20L, 0L, 150000L },
                    { 3, 2, "Made in China", "RADCLO_RC_Car.jpg", "RADCLO RC Car 2.4Ghz 1/20", 20L, 20L, 0L, 120000L },
                    { 4, 3, "USA", "Airforce 1.jpg", "Airforce 1", 20L, 20L, 0L, 220000L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);
        }
    }
}
