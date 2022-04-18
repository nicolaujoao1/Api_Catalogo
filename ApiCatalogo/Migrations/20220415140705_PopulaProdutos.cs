using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    public partial class PopulaProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)"+
                "VALUES('Medicamento 1','Usar para saude',1450.00,'img.png',12,now(),1)");
            migrationBuilder.Sql("INSERT INTO produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
                "VALUES('Medicamento 2','Usar para saude',1200.00,'img.png',12,now(),1)");
            migrationBuilder.Sql("INSERT INTO produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
                "VALUES('Medicamento 3','Usar para saude',1300.00,'img.png',12,now(),2)");
            migrationBuilder.Sql("INSERT INTO produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
                "VALUES('Medicamento 4','Usar para saude',1300.00,'img.png',12,now(),3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM produtos");
        }
    }
}
