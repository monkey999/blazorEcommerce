namespace BlazorEcommerce.Server.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category
               {
                   Id = 1,
                   Name = "Jeans",
                   Url = "Jeans"
               },
               new Category
               {
                   Id = 2,
                   Name = "Jackets",
                   Url = "Jackets"
               },
               new Category
               {
                   Id = 3,
                   Name = "Shoes",
                   Url = "Shoes"
               },
               new Category
               {
                   Id = 4,
                   Name = "T-Shirts",
                   Url = "T-Shirts"
               },
               new Category
               {
                   Id = 5,
                   Name = "Dresses",
                   Url = "Dresses"
               },
               new Category
               {
                   Id = 6,
                   Name = "Hats",
                   Url = "Hats"
               },
               new Category
               {
                   Id = 7,
                   Name = "Accessories",
                   Url = "Accessories"
               });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "GUCCI",
                    Description = "Striped Logo-Intarsia Cotton Track Jacket",
                    ImageUrl = "https://www.mrporter.com/variants/images/30629810019746309/in/w560_q60.jpg",
                    Price = 9.99m,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 2,
                    Title = "GUCCI",
                    Description = "Webbing-Trimmed Logo-Print Stretch-Jersey Hooded Jacket",
                    ImageUrl = "https://www.mrporter.com/variants/images/1647597301034878/in/w560_q60.jpg",
                    Price = 7.99m,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 3,
                    Title = "GUCCI",
                    Description = "Monogrammed Linen-Blend Suit Jacket",
                    ImageUrl = "https://www.mrporter.com/variants/images/1647597311499279/in/w560_q60.jpg",
                    Price = 8.99m,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 4,
                    Title = "Levi's Jeans",
                    Description = "Classic Blue Jeans",
                    ImageUrl = "https://denim.ua/image/cache/catalog/files/378194546_muzhskie-dzhinsy-levis-600x800.jpg",
                    Price = 49.99m,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 5,
                    Title = "Nike Running Shoes",
                    Description = "Comfortable Running Shoes",
                    ImageUrl = "https://static.nike.com/a/images/t_PDP_1280_v1/f_auto,q_auto:eco/f655b4fb-35e9-4a63-acf8-c02dfd78cfda/zoom-fly-5-road-running-shoes-lkx7Zp.png",
                    Price = 89.99m,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 6,
                    Title = "Adidas T-Shirt",
                    Description = "Casual Cotton T-Shirt",
                    ImageUrl = "https://brand-centr.com/image/cache/catalog/2031121%20-1-1678366701-1500x1500.jpg",
                    Price = 19.99m,
                    CategoryId = 4
                },
                new Product
                {
                    Id = 7,
                    Title = "Red Dress",
                    Description = "Elegant Red Evening Dress",
                    ImageUrl = "https://media.istockphoto.com/id/1217970889/photo/beautiful-female-red-dress-without-sleeves-isolated-on-white-evening-dress.jpg?s=612x612&w=0&k=20&c=SV4eWKwIY-HsUkrCi6X2jApUBcC5-lKFSd_tKG5Ewcw=",
                    Price = 129.99m,
                    CategoryId = 5
                },
                new Product
                {
                    Id = 8,
                    Title = "Fedora Hat",
                    Description = "Classic Fedora Hat",
                    ImageUrl = "https://m.media-amazon.com/images/I/71EzZPIe+oL._AC_UY1000_.jpg",
                    Price = 39.99m,
                    CategoryId = 6
                },
                new Product
                {
                    Id = 9,
                    Title = "Sunglasses",
                    Description = "Stylish Sunglasses",
                    ImageUrl = "https://assets.oakley.com/is/image/OakleyEYE/888392327031_holbrook_matte-black-prizm-sapphr-irid-polar_main_046.png?impolicy=SEO_4x3",
                    Price = 29.99m,
                    CategoryId = 7
                });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
