using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaVirtual.API.Migrations
{
    public partial class EstruturaProjeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "MinhaSequencia",
                startValue: 1000L);

            migrationBuilder.CreateTable(
                name: "marcas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(1000)", nullable: false),
                    removido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tipo_produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(1000)", nullable: false),
                    removido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR MinhaSequencia"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ValorDesconto = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Imagem = table.Column<string>(type: "varchar(250)", nullable: false),
                    removido = table.Column<bool>(type: "bit", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    TipoDesconto = table.Column<int>(type: "int", nullable: false),
                    TipoProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MarcaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_produtos_marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_produtos_tipo_produto_TipoProdutoId",
                        column: x => x.TipoProdutoId,
                        principalTable: "tipo_produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "imagens_produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(1000)", nullable: false),
                    removido = table.Column<bool>(type: "bit", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagens_produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_imagens_produtos_produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_imagens_produtos_ProdutoId",
                table: "imagens_produtos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_MarcaId",
                table: "produtos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_TipoProdutoId",
                table: "produtos",
                column: "TipoProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imagens_produtos");

            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "marcas");

            migrationBuilder.DropTable(
                name: "tipo_produto");

            migrationBuilder.DropSequence(
                name: "MinhaSequencia");
        }
    }
}
