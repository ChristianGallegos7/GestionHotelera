namespace GestionHotelera.Dominio.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        
        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }

        public TipoDocumento TipoDocumento { get; set; }

        public string NumeroDocumento { get; set; }

        public string Telefono { get; set; }

        public string CorreoElectronico { get; set; }

        public string ClaveHash { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public DateTime? FechaUltimaModificacion { get; set; }

        public bool EstaActivo { get; set; } = true;

        public DateTime? FechaNacimiento { get; set; }

        public bool EmailVerificado { get; set; } = false;
        public string? TokenVerificacionEmail { get; set; }

        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    }

    public enum TipoDocumento
    {
        CedulaCiudadania = 1,
        CedulaExtranjeria = 2,
        Pasaporte = 3,
        NIT = 4,
        Otro = 99
    }
}
