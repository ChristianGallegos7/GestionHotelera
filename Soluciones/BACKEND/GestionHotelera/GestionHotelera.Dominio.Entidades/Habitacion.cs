using GestionHotelera.Dominio.Entidades;

public class Habitacion
{
    public int Id { get; set; }
    public string Numero { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public decimal PrecioPorNoche { get; set; }
    public bool Disponible { get; set; }

    // Información adicional recomendada
    public int CapacidadMaxima { get; set; } = 2;
    public string? Descripcion { get; set; }
    public string? Amenidades { get; set; } // JSON con amenidades

    // Relación con Reservas
    public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}