using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LojaDeRoupas.Models;
using LojaDeRoupas.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaDeRoupas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private LojaDeRoupasDbContext _context;

        public ProdutoController(LojaDeRoupasDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Produto>>> Listar()
        {
            if (_context.Produto is null)
                return NotFound();
            return await _context.Produto.ToListAsync();
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult<Produto>> Cadastrar(Produto produto)
        {
            if (_context is null) return NotFound();
            await _context.AddAsync(produto);
            await _context.SaveChangesAsync();
            return Created("", produto);
        }

        [HttpPut]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Produto produto)
        {
            if (_context is null) return NotFound();
            if (_context.Produto is null) return NotFound();
            var produtoTemp = await _context.Produto.FindAsync(produto.Id);
            if (produtoTemp is null) return NotFound();
            _context.Entry(produtoTemp).CurrentValues.SetValues(produto);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch]
        [Route("mudar/{id}/nome")]
        public async Task<ActionResult> MudarNome(int id, [FromBody] string produtoNome)
        {
            if (_context is null) return NotFound();
            if (_context.Produto is null) return NotFound();
            var produtoTemp = await _context.Produto.FindAsync(id);
            if (produtoTemp is null) return NotFound();
            produtoTemp.ProdutoNome = produtoNome;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch]
        [Route("mudar/{id}/descricao")]
        public async Task<ActionResult> MudarDescricao(int id, [FromBody] string produtoDescricao)
        {
            if (_context is null) return NotFound();
            if (_context.Produto is null) return NotFound();
            var produtoTemp = await _context.Produto.FindAsync(id);
            if (produtoTemp is null) return NotFound();
            produtoTemp.ProdutoDesc = produtoDescricao;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch]
        [Route("mudar/{id}/preco")]
        public async Task<ActionResult> MudarPreco(int id, [FromBody] double produtoPreco)
        {
            if (_context is null) return NotFound();
            if (_context.Produto is null) return NotFound();
            var produtoTemp = await _context.Produto.FindAsync(id);
            if (produtoTemp is null) return NotFound();
            produtoTemp.ProdutoPreco = produtoPreco;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch]
        [Route("mudar/{id}/categoria")]
        public async Task<ActionResult> MudarCategoria(int id, [FromBody] string produtoCategoria)
        {
            if (_context is null) return NotFound();
            if (_context.Produto is null) return NotFound();
            var produtoTemp = await _context.Produto.FindAsync(id);
            if (produtoTemp is null) return NotFound();
            produtoTemp.ProdutoCategoria = produtoCategoria;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch]
        [Route("mudar/{id}/quant")]
        public async Task<ActionResult> MudarQuantidade(int id, [FromBody] int produtoQuantidade)
        {
            if (_context is null) return NotFound();
            if (_context.Produto is null) return NotFound();
            var produtoTemp = await _context.Produto.FindAsync(id);
            if (produtoTemp is null) return NotFound();
            produtoTemp.ProdutoQuant = produtoQuantidade;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            if (_context is null) return NotFound();
            if (_context.Produto is null) return NotFound();
            var produtoTemp = await _context.Produto.FindAsync(id);
            if (produtoTemp is null) return NotFound();
            _context.Remove(produtoTemp);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
