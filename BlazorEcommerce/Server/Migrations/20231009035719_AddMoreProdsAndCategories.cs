using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorEcommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreProdsAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 4, "T-Shirts", "T-Shirts" },
                    { 5, "Dresses", "Dresses" },
                    { 6, "Hats", "Hats" },
                    { 7, "Accessories", "Accessories" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 4, 1, "Classic Blue Jeans", "https://denim.ua/image/cache/catalog/files/378194546_muzhskie-dzhinsy-levis-600x800.jpg", 49.99m, "Levi's Jeans" },
                    { 5, 3, "Comfortable Running Shoes", "https://static.nike.com/a/images/t_PDP_1280_v1/f_auto,q_auto:eco/f655b4fb-35e9-4a63-acf8-c02dfd78cfda/zoom-fly-5-road-running-shoes-lkx7Zp.png", 89.99m, "Nike Running Shoes" },
                    { 6, 4, "Casual Cotton T-Shirt", "https://brand-centr.com/image/cache/catalog/2031121%20-1-1678366701-1500x1500.jpg", 19.99m, "Adidas T-Shirt" },
                    { 7, 5, "Elegant Red Evening Dress", "https://media.istockphoto.com/id/1217970889/photo/beautiful-female-red-dress-without-sleeves-isolated-on-white-evening-dress.jpg?s=612x612&w=0&k=20&c=SV4eWKwIY-HsUkrCi6X2jApUBcC5-lKFSd_tKG5Ewcw=", 129.99m, "Red Dress" },
                    { 8, 6, "Classic Fedora Hat", "https://m.media-amazon.com/images/I/71EzZPIe+oL._AC_UY1000_.jpg", 39.99m, "Fedora Hat" },
                    { 9, 7, "Stylish Sunglasses", "https://assets.oakley.com/is/image/OakleyEYE/888392327031_holbrook_matte-black-prizm-sapphr-irid-polar_main_046.png?impolicy=SEO_4x3", 29.99m, "Sunglasses" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
