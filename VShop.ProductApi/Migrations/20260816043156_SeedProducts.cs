using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products(Name, Price, Description, Stock, ImageURL, CategoryId) " +
                    "VALUES ('Caderno', 7.55, 'Caderno', 10, 'caderno1.jpg', 1)");

            mb.Sql("INSERT INTO Products(Name, Price, Description, Stock, ImageURL, CategoryId) " +
                   "VALUES ('Lápis', 3.55, 'Lápis Preto', 20, 'lapis1.jpg', 1)");

            mb.Sql("INSERT INTO Products(Name, Price, Description, Stock, ImageURL, CategoryId) " +
                   "VALUES ('Clips', 5.34, 'Clips para papel', 50, 'clips1.jpg', 2)");  
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE from Products");
        }
    }
}
