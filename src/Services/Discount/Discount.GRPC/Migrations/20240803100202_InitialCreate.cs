using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Discount.GRPC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "Amount", "Description", "ProductName" },
                values: new object[] { new Guid("66a5c31d-fd19-49d9-bfb4-fdf9afcd0a11"), 2000m, "Iphonediscount", "Iphone 17" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: new Guid("66a5c31d-fd19-49d9-bfb4-fdf9afcd0a11"));
        }
    }
}
