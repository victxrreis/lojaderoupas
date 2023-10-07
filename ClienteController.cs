using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using LojaDeRoupas.Models;
using LojaDeRoupas.Data;
using System.Threading.Tasks;

namespace LojaDeRoupas.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class ClienteController : ControllerBase
   {
      private LojaDeRoupasDbContext _context;

      public ClienteController(LojaDeRoupasDbContext context)
      {
         _context = context;
      }

      [HttpGet]
      [Route("listar")]
      public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
      {
         if (_context is null)
            return NotFound();

         var clientes = await _context.Cliente.ToListAsync();
         return Ok(clientes);
      }

      [HttpPost]
      [Route("cadastrar")]
      public async Task<ActionResult<Cliente>> Cadastrar(Cliente cliente)
      {
         if (_context is null)
            return NotFound();

         await _context.AddAsync(cliente);
         await _context.SaveChangesAsync();

         return Created("", cliente);
      }

      [HttpPut]
      [Route("alterar")]
      public async Task<ActionResult> Alterar(Cliente cliente)
      {
         if (_context is null)
            return NotFound();

         var clienteTemp = await _context.Cliente.FindAsync(cliente.Id);
         if (clienteTemp is null)
            return NotFound();

         clienteTemp.ClienteNome = cliente.ClienteNome;
         clienteTemp.ClienteEndereco = cliente.ClienteEndereco;
         clienteTemp.ClienteEmail = cliente.ClienteEmail;

         await _context.SaveChangesAsync();

         return Ok();
      }

      [HttpPatch]
      [Route("mudar/endereco/{id}")]
      public async Task<ActionResult> MudarEndereco(int id, string clienteEndereco)
      {
         if (_context is null)
            return NotFound();

         var clienteTemp = await _context.Cliente.FindAsync(id);
         if (clienteTemp is null)
            return NotFound();

         clienteTemp.ClienteEndereco = clienteEndereco;
         await _context.SaveChangesAsync();

         return Ok();
      }

      [HttpPatch]
      [Route("mudar/{id}")]
      public async Task<ActionResult> MudarEmail(int id, string clienteEmail)
      {
         if (_context is null)
            return NotFound();

         var clienteTemp = await _context.Cliente.FindAsync(id);
         if (clienteTemp is null)
            return NotFound();

         clienteTemp.ClienteEmail = clienteEmail;
         await _context.SaveChangesAsync();

         return Ok();
      }

      [HttpDelete]
      [Route("excluir/{id}")]
      public async Task<ActionResult> Excluir(int id)
      {
         if (_context is null)
            return NotFound();

         var clienteTemp = await _context.Cliente.FindAsync(id);
         if (clienteTemp is null)
            return NotFound();

         _context.Remove(clienteTemp);
         await _context.SaveChangesAsync();

         return Ok();
      }
   }
}