using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WCFServiceHost.Migrations
{
    public partial class FisrtMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    RG = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Data_Expedicao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Orgao_Expedicao = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    UF_Expedicao = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Data_Nascimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Sexo = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Estado_Civil = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Addresss",
                columns: table => new
                {
                    IdAddress = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(nullable: true),
                    Logradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    ClienteRef = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresss", x => x.IdAddress);
                    table.ForeignKey(
                        name: "FK_Addresss_Client_ClienteRef",
                        column: x => x.ClienteRef,
                        principalTable: "Client",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresss_ClienteRef",
                table: "Addresss",
                column: "ClienteRef",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresss");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
