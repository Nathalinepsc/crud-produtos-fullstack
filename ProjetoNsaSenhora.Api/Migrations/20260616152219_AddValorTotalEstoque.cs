using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoNsaSenhora.Migrations
{
    /// <inheritdoc />
    public partial class AddValorTotalEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotalEstoque",
                table: "Produtos",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorTotalEstoque",
                table: "Produtos");
        }
    }
}
