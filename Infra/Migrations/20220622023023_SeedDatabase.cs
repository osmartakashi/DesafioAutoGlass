using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    CodigoFornecedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.CodigoFornecedor);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    CodigoProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Situacao = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DataFabricacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodigoFornecedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.CodigoProduto);
                    table.ForeignKey(
                        name: "FK_Produtos_Fornecedor_CodigoFornecedor",
                        column: x => x.CodigoFornecedor,
                        principalTable: "Fornecedor",
                        principalColumn: "CodigoFornecedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Fornecedor",
                columns: new[] { "CodigoFornecedor", "Cnpj", "Descricao" },
                values: new object[] { 1, "08.223.587/0001-00", "AutoGlass" });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CodigoFornecedor",
                table: "Produtos",
                column: "CodigoFornecedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Fornecedor");
        }
    }
}
