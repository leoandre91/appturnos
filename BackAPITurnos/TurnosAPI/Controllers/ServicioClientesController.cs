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
    public class ServicioClientesController : ControllerBase
    {
        private readonly DatosContexto _context;

        public ServicioClientesController(DatosContexto context)
        {
            _context = context;
        }

        [HttpPut]
        [Route("api/[controller]/PutServicioClienteEstado/{id}")]
        public IActionResult PutServicioClienteEstado(int id, ServicioCliente servicioCliente)
        {

            var query = (from a in _context.ServicioCliente
                         where a.Id == id
                         select a).FirstOrDefault();

            if (query == null)
            {
                return NotFound();
            }

            query.EstadoTruno = servicioCliente.EstadoTruno;

            _context.SaveChanges();

            var jSon = JsonConvert.SerializeObject(query);

            return Ok(jSon);
        }

        [HttpPut]
        [Route("api/[controller]/PutServicioClienteComentario/{id}")]

        public IActionResult PutServicioClienteComentario (int id, ServicioCliente servicioCliente)
        {
            var query = (from d in _context.ServicioCliente
                         where d.Id == id
                         select d).FirstOrDefault();

            if (query == null)
            {
                return NotFound();
            }

            query.Comentarios = servicioCliente.Comentarios;
            query.EstadoTruno = servicioCliente.EstadoTruno;

            _context.SaveChanges();

            return Ok();
        }

        // GET: api/ServicioClientes
        [HttpGet]
        [Route("api/[controller]/GetServicioCliente")]
        public async Task<ActionResult<IEnumerable<ServicioCliente>>> GetServicioCliente()
        {
          if (_context.ServicioCliente == null)
          {
              return NotFound();
          }
            return await _context.ServicioCliente.ToListAsync();
        }

        // GET: api/ServicioClientes/5
        [HttpGet]
        [Route("api/[controller]/GetServicioCliente/{id}")]
        public async Task<ActionResult<ServicioCliente>> GetServicioCliente(int id)
        {
          if (_context.ServicioCliente == null)
          {
              return NotFound();
          }
            var servicioCliente = await _context.ServicioCliente.FindAsync(id);

            if (servicioCliente == null)
            {
                return NotFound();
            }

            return servicioCliente;
        }

        // PUT: api/ServicioClientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("api/[controller]/PutServicioCliente/{id}")]
        public async Task<IActionResult> PutServicioCliente(int id, ServicioCliente servicioCliente)
        {
            if (id != servicioCliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(servicioCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioClienteExists(id))
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

        // POST: api/ServicioClientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("api/[controller]/PostServicioCliente")]
        public async Task<ActionResult<ServicioCliente>> PostServicioCliente(ServicioCliente servicioCliente)
        {
          if (_context.ServicioCliente == null)
          {
              return Problem("Entity set 'DatosContexto.ServicioCliente'  is null.");
          }
            _context.ServicioCliente.Add(servicioCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicioCliente", new { id = servicioCliente.Id }, servicioCliente);
        }

        // DELETE: api/ServicioClientes/5
        [HttpDelete]
        [Route("api/[controller]/DeleteServicioCliente/{id}")]
        public async Task<IActionResult> DeleteServicioCliente(int id)
        {
            if (_context.ServicioCliente == null)
            {
                return NotFound();
            }
            var servicioCliente = await _context.ServicioCliente.FindAsync(id);
            if (servicioCliente == null)
            {
                return NotFound();
            }

            _context.ServicioCliente.Remove(servicioCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicioClienteExists(int id)
        {
            return (_context.ServicioCliente?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
