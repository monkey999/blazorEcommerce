using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class changeImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Striped Logo-Intarsia Cotton Track Jacket", "https://www.mrporter.com/variants/images/30629810019746309/in/w560_q60.jpg", "GUCCI" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Webbing-Trimmed Logo-Print Stretch-Jersey Hooded Jacket", "https://www.mrporter.com/variants/images/1647597301034878/in/w560_q60.jpg", "GUCCI" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Monogrammed Linen-Blend Suit Jacket", "https://www.mrporter.com/variants/images/1647597311499279/in/w560_q60.jpg", "GUCCI" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Pain reliever and fever reducer", "https://media.istockphoto.com/id/458563393/photo/aspirin-bottle-with-tablets-spilling-out.jpg?s=612x612&w=0&k=20&c=MuRtWxOfp_rA2hWvVxAoJEeOcaWFIQ1xqtieh-W5iG8=", "Aspirin" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Nonsteroidal anti-inflammatory drug (NSAID)", "https://m.media-amazon.com/images/I/71byBwaWpuL._AC_UF894,1000_QL80_.jpg", "Ibuprofen" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "Title" },
                values: new object[] { "Antibiotic used to treat bacterial infections", "https://www.mintrxpharmacy.com/on/demandware.static/-/Sites-master-catalog/default/dwec20c7c0/images/products/amoxicillin_capsule_500.jpg", "Amoxicillin" });
        }
    }
}
