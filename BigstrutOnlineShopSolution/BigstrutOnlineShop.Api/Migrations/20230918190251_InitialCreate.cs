using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BigstrutOnlineShop.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Computer" },
                    { 2, "Accessories" },
                    { 3, "Furniture" },
                    { 4, "Shoes" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageURL", "Name", "Price", "Qty" },
                values: new object[,]
                {
                    { 1, 1, "Intel Celeron Processor, 8GB Memory, 64GB eMMC Storage, Fast Charge and HDMI", "/Images/Computer/Computer1.png", "HP Latest Stream 14 - HD Laptop", 280m, 100 },
                    { 2, 1, "HD Touchscreen, Intel Celeron, 4GB DDR4 64GB, eMMC WiFi Webcam Stereo Speakers Bluetooth  ", "/Images/Computer/Computer2.png", "HP Laptop X360 14a Chromebook 14", 399m, 45 },
                    { 3, 1, "13.5 Touch Screen, Thin & Lightweight, Long Battery Life, Fast Intel i5 Processor, 512GB Storage", "/Images/Computer/Computer3.png", "Microsoft Surface Laptop 5 (2022)", 895m, 30 },
                    { 4, 1, "A hp-zbook-fury-17-g7-mobile-workstation, Intel Core i7-10750H Processor. 2.6 GHz ", "/Images/Computer/Computer4.png", "Curology - hp-zbook", 3389m, 60 },
                    { 5, 1, "13.5 Touch Screen, Thin & Lightweight, Long Battery Life, Fast Intel i5 Processor, 512GB Storage ", "/Images/Computer/Computer5.png", "Microsoft Surface Laptop 5 (2022)", 30m, 85 },
                    { 6, 2, "Air Pods - in-ear wireless headphones", "/Images/Accessories/Accessories1.png", "Air Pods", 100m, 120 },
                    { 7, 2, "On-ear Golden Headphones - these headphones are not wireless", "/Images/Accessories/Accessories2.png", "On-ear Golden Headphones", 40m, 200 },
                    { 8, 2, "On-ear Black Headphones - these headphones are not wireless", "/Images/Accessories/Accessories3.png", "On-ear Black Headphones", 40m, 300 },
                    { 9, 2, "Sennheiser Digital Camera - High quality digital camera provided by Sennheiser - includes tripod", "/Images/Accessories/Accessories4.png", "Sennheiser Digital Camera with Tripod", 600m, 20 },
                    { 10, 2, "Canon Digital Camera - High quality digital camera provided by Canon", "/Images/Accessories/Accessories5.png", "Canon Digital Camera", 500m, 15 },
                    { 11, 2, "Gameboy - Provided by Nintendo", "/Images/Accessories/Accessories6.png", "Nintendo Gameboy", 100m, 60 },
                    { 12, 3, "Very comfortable black leather office chair", "/Images/Furniture/Furniture1.png", "Black Leather Office Chair", 50m, 212 },
                    { 13, 3, "Very comfortable pink leather office chair", "/Images/Furniture/Furniture2.png", "Pink Leather Office Chair", 50m, 112 },
                    { 14, 3, "Very comfortable lounge chair", "/Images/Furniture/Furniture3.png", "Lounge Chair", 70m, 90 },
                    { 15, 3, "Very comfortable Silver lounge chair", "/Images/Furniture/Furniture4.png", "Silver Lounge Chair", 120m, 95 },
                    { 16, 3, "White and blue Porcelain Table Lamp", "/Images/Furniture/Furniture6.png", "Porcelain Table Lamp", 15m, 100 },
                    { 17, 3, "Office Table Lamp", "/Images/Furniture/Furniture7.png", "Office Table Lamp", 20m, 73 },
                    { 18, 4, "Comfortable Puma Sneakers in most sizes", "/Images/Shoes/Shoes1.png", "Puma Sneakers", 100m, 50 },
                    { 19, 4, "Colorful trainsers - available in most sizes", "/Images/Shoes/Shoes2.png", "Colorful Trainers", 150m, 60 },
                    { 20, 4, "Blue Nike Trainers - available in most sizes", "/Images/Shoes/Shoes3.png", "Blue Nike Trainers", 200m, 70 },
                    { 21, 4, "Colorful Hummel Trainers - available in most sizes", "/Images/Shoes/Shoes4.png", "Colorful Hummel Trainers", 120m, 120 },
                    { 22, 4, "Red Nike Trainers - available in most sizes", "/Images/Shoes/Shoes5.png", "Red Nike Trainers", 200m, 100 },
                    { 23, 4, "Birkenstock Sandles - available in most sizes", "/Images/Shoes/Shoes6.png", "Birkenstock Sandles", 50m, 150 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[,]
                {
                    { 1, "Bob" },
                    { 2, "Sarah" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
