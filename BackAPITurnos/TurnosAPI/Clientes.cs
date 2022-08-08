namespace TurnosAPI
{
    public class Clientes
    {
        public int Id { get; set; }

        public string NombreCliente { get; set; } = String.Empty;

        public string ApellidosCliente { get; set; } = String.Empty;

        public int EdadCliente { get; set; }

        public string SexoCliente { get; set; } = string.Empty;

        public string TipoIdentificacionCliente { get; set; } = String.Empty; 

        public int NoIdentificacionCliente { get; set; }

        public string DepartamentoCliente { get; set; } = String.Empty;

        public string CiudadCliente { get; set; } = String.Empty;

        public string BarrioCliente { get; set; } = String.Empty;

        public string DireccionCliente { get; set; } = String.Empty;

    }
}
