using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeaTimeDemo.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addStoreRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "City", "Description", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "台中市北区三民路三段129号", "台中市", "临近一中商圈", "台中一中店", "0987654321" },
                    { 2, "台北市信义区信义路一段9号", "台北市", "临近信义商圈", "台北信义店", "0912345678" },
                    { 3, "高雄市新兴区五福三路13号", "高雄市", "临近新崛江商圈", "高雄五福店", "0912348765" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
