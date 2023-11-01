using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorEcommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class ProductSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Pain reliever and fever reducer", "https://media.istockphoto.com/id/458563393/photo/aspirin-bottle-with-tablets-spilling-out.jpg?s=612x612&w=0&k=20&c=MuRtWxOfp_rA2hWvVxAoJEeOcaWFIQ1xqtieh-W5iG8=", 9.99m, "Aspirin" },
                    { 2, "Nonsteroidal anti-inflammatory drug (NSAID)", "https://m.media-amazon.com/images/I/71byBwaWpuL._AC_UF894,1000_QL80_.jpg", 7.99m, "Ibuprofen" },
                    { 3, "Antibiotic used to treat bacterial infections", "https://www.mintrxpharmacy.com/on/demandware.static/-/Sites-master-catalog/default/dwec20c7c0/images/products/amoxicillin_capsule_500.jpg", 8.99m, "Amoxicillin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
