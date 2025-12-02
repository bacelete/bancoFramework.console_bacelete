using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codigo.Migrations
{
    /// <inheritdoc />
    public partial class OneTablePerHierachy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pessoa",
                type: "varchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<float>(
                name: "saldo",
                table: "Pessoa",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "saldo",
                table: "Pessoa");
        }
    }
}
