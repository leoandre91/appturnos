using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TurnosAPI;
using TurnosAPI.Datos;

namespace TurnosAPI.Controllers
{    
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly DatosContexto _context;

        public ClientesController(DatosContexto context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        [Route("api/[controller]/GetClientes")]
        public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
        {
          if (_context.Clientes == null)
          {
              return NotFound();
          }
            return await _context.Clientes.ToListAsync();
        }

        //Obtener cliente por cedula
        [HttpGet]
        [Route("api/[controller]/GetClientesCe/{NoIdentificacionCliente}")]
        public IActionResult GetClientesCe(int NoIdentificacionCliente)
        {
           
            var clientes = _context.Clientes.Where(x => x.NoIdentificacionCliente == NoIdentificacionCliente).FirstOrDefault();

            if (clientes == null)
            {
                return NotFound();
            }

            var jSon = JsonConvert.SerializeObject(clientes);

            return Ok(jSon);
        }

        // GET: api/Clientes/5
        [HttpGet]
        [Route("api/[controller]/GetClientes/{id}")]
        public async Task<ActionResult<Clientes>> GetClientes(int id)
        {
          if (_context.Clientes == null)
          {
              return NotFound();
          }
            var clientes = await _context.Clientes.FindAsync(id);

            if (clientes == null)
            {
                return NotFound();
            }

            return clientes;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("api/[controller]/PutClientes/{id}")]
        public async Task<IActionResult> PutClientes(int id, Clientes clientes)
        {
            if (id != clientes.Id)
            {
                return BadRequest();
            }

            _context.Entry(clientes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("api/[controller]/PostClientes")]
        public async Task<ActionResult<Clientes>> PostClientes(Clientes clientes)
        {
          if (_context.Clientes == null)
          {
              return Problem("Entity set 'DatosContexto.Clientes'  is null.");
          }
            _context.Clientes.Add(clientes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientes", new { id = clientes.Id }, clientes);
        }

        // DELETE: api/Clientes/5
        [HttpDelete]
        [Route("api/[controller]/DeleteClientes/{id}")]
        public async Task<IActionResult> DeleteClientes(int id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientesExists(int id)
        {
            return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
