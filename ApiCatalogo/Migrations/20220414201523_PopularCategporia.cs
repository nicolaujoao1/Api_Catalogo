using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    public partial class PopularCategporia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO categorias(Nome,ImagemUrl)values('Injectavel','imgagem1.jgp')");
            migrationBuilder.Sql("INSERT INTO categorias(Nome,ImagemUrl)values('Liquido-creme','imgagem2.jgp')");
            migrationBuilder.Sql("INSERT INTO categorias(Nome,ImagemUrl)values('Teste 1','imgagem3.jgp')");
            migrationBuilder.Sql("INSERT INTO categorias(Nome,ImagemUrl)values('Teste 2','imgagem4.jgp')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM categorias");
        }
    }
}
