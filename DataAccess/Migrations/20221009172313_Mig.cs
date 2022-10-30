using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nickName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    passWord = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    fullName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    eMail = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    gender = table.Column<bool>(type: "bit", nullable: false),
                    birthDate = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    adresId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    adress = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.adresId);
                    table.ForeignKey(
                        name: "FK_Adresses_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentCards",
                columns: table => new
                {
                    paymentCardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentCards", x => x.paymentCardId);
                    table.ForeignKey(
                        name: "FK_PaymentCards_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "birthDate", "eMail", "fullName", "gender", "nickName", "passWord", "phoneNumber" },
                values: new object[] { 1, "30-12-1992", "samet66@gmail.com", "Abdussamet Solak", true, "Samet", "123", "123" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "birthDate", "eMail", "fullName", "gender", "nickName", "passWord", "phoneNumber" },
                values: new object[] { 2, "30-12-1994", "elif@gmail.com", "Elif Solak", false, "Elif", "123", "123" });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "adresId", "adress", "name", "userId" },
                values: new object[,]
                {
                    { 1, "Cemal Sururi Sokak Mecidiyekoy/Sisli/Istanbul", "Ev", 1 },
                    { 2, "Bilmemne Sokak Bostancı/Kadıkoy/Istanbul", "Is", 1 },
                    { 3, "Cemal Sururi Sokak Mecidiyekoy/Sisli/Istanbul", "Ev", 2 }
                });

            migrationBuilder.InsertData(
                table: "PaymentCards",
                columns: new[] { "paymentCardId", "name", "userId" },
                values: new object[,]
                {
                    { 1, "Akbank", 1 },
                    { 2, "Vakıfbank", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_userId",
                table: "Adresses",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentCards_userId",
                table: "PaymentCards",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "PaymentCards");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
