using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TurnosAPI.Datos;
using TurnosAPI.Modelo;

namespace TurnosAPI.Controllers
{    
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly DatosContexto _context;

        public TurnoController(DatosContexto context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/[controller]/GetTurno/{IdCliente}")]
        public IActionResult GetTurno(int IdCliente)        
        {
            var list = from g in _context.Clientes
                       where g.Id == IdCliente
                       join servClientes in _context.ServicioCliente on g.Id equals servClientes.ClienteId
                       join tipServicio in _context.TipoServicio on servClientes.TipoServicioId equals tipServicio.Id
                       select new Turno
                       {
                           NoTurno = servClientes.NoTurno,
                           TipoTurno = servClientes.TipoTurno,
                           EstadoTurno = servClientes.EstadoTruno,
                           NombreServicio = tipServicio.NombreServicio
                       };

            list.ToList();

            if (list.Count() == 0)
            {
                return NotFound();
            }

            var jSon = JsonConvert.SerializeObject(list);

            return Ok(jSon);
        }

        [HttpGet]
        [Route("api/[controller]/GetUltimoTurno/{IdTipoServicio}")]
        public IActionResult GetUltimoTurno(int IdTipoServicio)
        {
     
            var max =  (from u in _context.ServicioCliente
                         where u.TipoServicioId == IdTipoServicio
                         orderby u.NoTurno descending
             select new { NoTurno = u.NoTurno }).Take(1);
            

            if (max == null)
            {
                return NotFound();
            }

            var jSon = JsonConvert.SerializeObject(max);

            return Ok(jSon);
        }

        [HttpGet]
        [Route("api/[controller]/GetTurnoServicio/{TipoServicioId}")]
        public IActionResult GetTurnoServicio(int TipoServicioId)
        {
            var list = from g in _context.ServicioCliente
                       where g.TipoServicioId == TipoServicioId
                       join cli in _context.Clientes on g.ClienteId equals cli.Id
                       select new
                       {
                           IdTurno = g.Id,
                           NombreCliente = cli.NombreCliente,
                           ApellidoCliente = cli.ApellidosCliente,
                           TipoIdentificacion = cli.TipoIdentificacionCliente,
                           NoIdentificacion = cli.NoIdentificacionCliente,
                           NoTurno = g.NoTurno,
                           TipoTurno = g.TipoTurno,
                           EstadoTurno = g.EstadoTruno,
                           Comentario = g.Comentarios
                       };

            list.ToList();

            if (list.Count() == 0)
            {
                return NotFound();
            }

            var jSon = JsonConvert.SerializeObject(list);

            return Ok(jSon);
        }
    }
}
