using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValidacoesAPI.Data.DataContext;
using ValidacoesAPI.Models;

namespace ValidacoesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet ]        
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            var cli = await _context.Clientes.AsNoTracking().ToListAsync();
            if (cli is null)
            {
                return NotFound("Cliente não encontrados !");
            }
            return Ok(cli);
        }
                    
        [HttpGet("{id}", Name = "ObterCliente")] 
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var cli = await _context.Clientes.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (cli is null)
            {
                return NotFound("O Cliente de Código " + id + " não foi encontrado !");
            }
            return Ok(cli);
        }

        [HttpPost]
        public ActionResult Post(Cliente cliente)
        {
            if (cliente is null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                // Log the error or return it in the response
                return BadRequest("Tentativa de registro Inválida !");
            }

            return Ok(cliente);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest("Tentativa de registro Inválida !");
            }

            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var cli = _context.Clientes.FirstOrDefault(c => c.Id == id);

            if (cli is null)
            {
                return NotFound("Cliente de código " + id + " não foi localizado!");
            }
            _context.Clientes.Remove(cli);
            _context.SaveChanges();
            return Ok(cli);
        }
    }
}
