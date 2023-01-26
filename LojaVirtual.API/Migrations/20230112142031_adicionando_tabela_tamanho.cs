using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ci.Calcados.API.Migrations
{
    public partial class adicionando_tabela_tamanho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TamanhoId",
                table: "produtos",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "tamanhos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(500)", nullable: false),
                    removido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tamanhos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_produtos_TamanhoId",
                table: "produtos",
                column: "TamanhoId");

            migrationBuilder.AddForeignKey(
                name: "FK_produtos_tamanhos_TamanhoId",
                table: "produtos",
                column: "TamanhoId",
                principalTable: "tamanhos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produtos_tamanhos_TamanhoId",
                table: "produtos");

            migrationBuilder.DropTable(
                name: "tamanhos");

            migrationBuilder.DropIndex(
                name: "IX_produtos_TamanhoId",
                table: "produtos");

            migrationBuilder.DropColumn(
                name: "TamanhoId",
                table: "produtos");
        }
    }
}
