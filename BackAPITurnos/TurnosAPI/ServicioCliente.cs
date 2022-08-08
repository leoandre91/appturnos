namespace TurnosAPI
{
    public class ServicioCliente
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public int TipoServicioId { get; set; }

        public int NoTurno { get; set; }

        public string TipoTurno { get; set; } = string.Empty;

        public string Comentarios { get; set; } = string.Empty;

        public string EstadoTruno { get; set; } = string.Empty; 

        public Clientes? Cliente { get; set; }

        public TipoServicio? TipoServicio { get; set; }
    }
}
