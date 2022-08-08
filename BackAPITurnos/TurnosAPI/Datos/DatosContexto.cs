using Microsoft.EntityFrameworkCore;

namespace TurnosAPI.Datos
{
    public class DatosContexto : DbContext
    {
        public DatosContexto(DbContextOptions<DatosContexto> options) : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<TipoServicio> TipoServicio { get; set; }

        public DbSet<ServicioCliente> ServicioCliente { get; set; }
       
    }
}
