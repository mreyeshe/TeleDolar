using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Remesa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRemitente = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreBeneficiario = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodigoPaisOrigen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPaisDestino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoMoneda = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remesa", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Remesa_Id",
                table: "Remesa",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Remesa_NombreBeneficiario",
                table: "Remesa",
                column: "NombreBeneficiario");

            migrationBuilder.CreateIndex(
                name: "IX_Remesa_NombreRemitente",
                table: "Remesa",
                column: "NombreRemitente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Remesa");
        }
    }
}
