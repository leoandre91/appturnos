using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurnosAPI;
using TurnosAPI.Datos;

namespace TurnosAPI.Controllers
{    
    [ApiController]
    public class TipoServiciosController : ControllerBase
    {
        private readonly DatosContexto _context;

        public TipoServiciosController(DatosContexto context)
        {
            _context = context;
        }

        // GET: api/TipoServicios
        [HttpGet]
        [Route("api/[controller]/GetTipoServicio")]
        public async Task<ActionResult<IEnumerable<TipoServicio>>> GetTipoServicio()
        {
          if (_context.TipoServicio == null)
          {
              return NotFound();
          }
            return await _context.TipoServicio.ToListAsync();
        }

        // GET: api/TipoServicios/5
        [HttpGet]
        [Route("api/[controller]/GetTipoServicio/{id}")]
        public async Task<ActionResult<TipoServicio>> GetTipoServicio(int id)
        {
          if (_context.TipoServicio == null)
          {
              return NotFound();
          }
            var tipoServicio = await _context.TipoServicio.FindAsync(id);

            if (tipoServicio == null)
            {
                return NotFound();
            }

            return tipoServicio;
        }

        // PUT: api/TipoServicios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("api/[controller]/PutTipoServicio/{id}")]        
        public async Task<IActionResult> PutTipoServicio(int id, TipoServicio tipoServicio)
        {
            if (id != tipoServicio.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoServicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoServicioExists(id))
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

        // POST: api/TipoServicios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("api/[controller]/PostTipoServicio")]
        public async Task<ActionResult<TipoServicio>> PostTipoServicio(TipoServicio tipoServicio)
        {
          if (_context.TipoServicio == null)
          {
              return Problem("Entity set 'DatosContexto.TipoServicio'  is null.");
          }
            _context.TipoServicio.Add(tipoServicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoServicio", new { id = tipoServicio.Id }, tipoServicio);
        }

        // DELETE: api/TipoServicios/5
        [HttpDelete]
        [Route("api/[controller]/DeleteTipoServicio/{id}")]
        public async Task<IActionResult> DeleteTipoServicio(int id)
        {
            if (_context.TipoServicio == null)
            {
                return NotFound();
            }
            var tipoServicio = await _context.TipoServicio.FindAsync(id);
            if (tipoServicio == null)
            {
                return NotFound();
            }

            _context.TipoServicio.Remove(tipoServicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoServicioExists(int id)
        {
            return (_context.TipoServicio?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
