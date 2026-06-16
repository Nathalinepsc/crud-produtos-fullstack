using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoNsaSenhora.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedToProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Produtos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Produtos");
        }
    }
}
