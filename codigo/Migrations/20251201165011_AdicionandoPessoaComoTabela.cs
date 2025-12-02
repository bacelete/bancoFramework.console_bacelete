using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codigo.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoPessoaComoTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cpf",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "nome",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Cliente",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cpf = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PessoaId",
                table: "Cliente",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Pessoa_PessoaId",
                table: "Cliente",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Pessoa_id",
                table: "Cliente",
                column: "id",
                principalTable: "Pessoa",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pessoa_PessoaId",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pessoa_id",
                table: "Cliente");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_PessoaId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Cliente",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "cpf",
                table: "Cliente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "nome",
                table: "Cliente",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
