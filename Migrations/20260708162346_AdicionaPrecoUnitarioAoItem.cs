using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Produtos.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaPrecoUnitarioAoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Pedidos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoUnitario",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "PrecoUnitario",
                table: "Items");
        }
    }
}
