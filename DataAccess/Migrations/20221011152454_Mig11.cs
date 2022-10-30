using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Mig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "Users",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 1,
                column: "imageUrl",
                value: "https://i0.wp.com/www.thewhitetree.org/wp-content/uploads/2015/11/Thorin.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 2,
                column: "imageUrl",
                value: "https://cdn.yeniakit.com.tr/images/news/625/cate-blanchett-b2b56d.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "Users");
        }
    }
}
