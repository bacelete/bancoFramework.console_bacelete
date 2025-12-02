using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace codigo.Migrations
{
    /// <inheritdoc />
    public partial class RenomeandoForeignKeyCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pessoa_PessoaId",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_PessoaId",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "id_pessoa",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_id_pessoa",
                table: "Cliente",
                column: "id_pessoa");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Pessoa_id_pessoa",
                table: "Cliente",
                column: "id_pessoa",
                principalTable: "Pessoa",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Pessoa_id_pessoa",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_id_pessoa",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "id_pessoa",
                table: "Cliente");

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
        }
    }
}
