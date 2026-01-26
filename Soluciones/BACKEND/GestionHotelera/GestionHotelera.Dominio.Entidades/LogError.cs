namespace GestionHotelera.Dominio.Entidades
{
    public class LogError
    {
        public int Id { get; set; }

        // Información del error
        public string Mensaje { get; set; } = string.Empty;
        public string? StackTrace { get; set; }
        public string? InnerException { get; set; }
        public string TipoError { get; set; } = string.Empty; // Exception type

        // Contexto
        public string? Controlador { get; set; }
        public string? Accion { get; set; }
        public string? Endpoint { get; set; }
        public string? MetodoHttp { get; set; } // GET, POST, PUT, DELETE

        // Usuario y request
        public int? UsuarioId { get; set; }
        public string? UsuarioEmail { get; set; }
        public string? DireccionIP { get; set; }
        public string? UserAgent { get; set; }

        // Datos adicionales
        public string? RequestBody { get; set; } // JSON del request
        public string? QueryString { get; set; }

        // Severidad
        public NivelSeveridad Nivel { get; set; } = NivelSeveridad.Error;

        // Timestamp
        public DateTime FechaHora { get; set; } = DateTime.UtcNow;

        // Estado
        public bool Resuelto { get; set; } = false;
        public DateTime? FechaResolucion { get; set; }
        public string? NotasResolucion { get; set; }
    }

    public enum NivelSeveridad
    {
        Debug = 0,
        Info = 1,
        Warning = 2,
        Error = 3,
        Critical = 4,
        Fatal = 5
    }
}