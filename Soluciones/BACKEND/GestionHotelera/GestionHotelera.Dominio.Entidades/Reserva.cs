namespace GestionHotelera.Dominio.Entidades
{
    public class Reserva
    {
        public int Id { get; set; }

        // Relaciones (Foreign Keys)
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public int HabitacionId { get; set; }
        public Habitacion Habitacion { get; set; } = null!;

        // Fechas de la reserva
        public DateTime FechaCheckIn { get; set; }
        public DateTime FechaCheckOut { get; set; }
        public int NumeroNoches { get; set; } // Calculado: CheckOut - CheckIn

        // Información financiera
        public decimal PrecioPorNoche { get; set; } // Guardado al momento de reservar
        public decimal PrecioTotal { get; set; } // NumeroNoches * PrecioPorNoche
        public decimal? Descuento { get; set; } // Opcional
        public decimal MontoFinal { get; set; } // PrecioTotal - Descuento

        // Estado de la reserva
        public EstadoReserva Estado { get; set; } = EstadoReserva.Pendiente;

        // Huéspedes
        public int NumeroHuespedes { get; set; } = 1;
        public int NumeroAdultos { get; set; } = 1;
        public int NumeroNinos { get; set; } = 0;

        // Notas y solicitudes especiales
        public string? NotasEspeciales { get; set; }
        public string? SolicitudesEspeciales { get; set; } // Cama extra, cuna, etc.

        // Auditoría
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaCancelacion { get; set; }
        public string? MotivoCancelacion { get; set; }

        // Check-in/Check-out real (puede diferir de las fechas reservadas)
        public DateTime? FechaCheckInReal { get; set; }
        public DateTime? FechaCheckOutReal { get; set; }

        // Código de confirmación
        public string CodigoConfirmacion { get; set; } = string.Empty;
    }

    public enum EstadoReserva
    {
        Pendiente = 1,        // Reserva creada, esperando confirmación/pago
        Confirmada = 2,       // Reserva confirmada y pagada
        CheckInRealizado = 3, // Cliente ya hizo check-in
        CheckOutRealizado = 4,// Cliente ya hizo check-out
        Cancelada = 5,        // Cancelada por cliente o hotel
        NoShow = 6,           // Cliente no se presentó
        Completada = 7        // Estancia completada exitosamente
    }
}