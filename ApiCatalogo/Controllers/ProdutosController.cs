using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        public readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }
        //Retornar Produtos
        [HttpGet]   
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos.AsNoTracking().ToList();
            if (produtos is null)
                return NotFound("Produto não encontrado..");
            else
                return produtos;    
        }
        //Retornar um Produto especifico{ id }
        [HttpGet("{id:int}",Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id) 
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId== id);
            if (produto is null)
                return NotFound($"Produto no indice {id} não encontrado.");
            return produto;
        }
        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
                return BadRequest();
            else
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
            }
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if (id!=produto.ProdutoId)
                return BadRequest();
            _context.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges(); 
            return Ok(produto);    
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produtos=_context.Produtos.FirstOrDefault(p=>p.ProdutoId == id);
            if (produtos is null)
            {
                return NotFound($"Produto não encontrado no indice {id}...");
            }
            _context.Remove(produtos);
            _context.SaveChanges();
            return Ok(produtos);
        }
    }
}
