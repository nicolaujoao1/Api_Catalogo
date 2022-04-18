using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        public readonly AppDbContext _context;
        public CategoriasController(AppDbContext contex) { _context = contex; } 
        [HttpGet]   
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            try
            {
                var categorias=_context.Categorias.AsNoTracking().ToList();
                return categorias is null ? NotFound("Categoria Inexistentes...") : categorias;
            }catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oucorreu um erro ao acessar o servidor...");    
            }
           
        }
        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriaProdutos()
        {
            var categoria = _context.Categorias.Include(p=>p.Produtos).Where(c=>
            c.CategoriaId<=5).ToList();
            if (categoria is null)
            {
                return NotFound("Categorias não encontrados...");
            }
            return categoria;
        }
        [HttpGet("{id:int}",Name ="ObterCategoria")]
        public ActionResult<Categoria>Get(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
            if (categoria is null)
                return NotFound($"Categoria com indice {id} inexistente...");
            return categoria;  
        }
        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null)
                return BadRequest();
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterCategoria",new {id=categoria.CategoriaId},categoria); 
        }
        [HttpPut("{id:int}")]
        public ActionResult<Categoria> Put(int id,Categoria categoria)
        {
            if (id != categoria.CategoriaId)
                BadRequest("Verique o seu ID");
            _context.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Ok(categoria);
        }
        [HttpDelete("{id:int}")]
        public ActionResult<Categoria>Delete(int id)
        {
            var categoria=_context.Categorias.FirstOrDefault(p=>p.CategoriaId==id);
            if (categoria is null)
                return NotFound($"Categoria não encontrado no índice {id}..");
            _context.Remove(categoria);
            _context.SaveChanges();
            return Ok(categoria);   

        }
    }
}
