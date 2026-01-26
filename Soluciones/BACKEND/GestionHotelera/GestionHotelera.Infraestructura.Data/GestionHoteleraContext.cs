using GestionHotelera.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GestionHotelera.Infraestructura.Data
{
    public class GestionHoteleraContext : DbContext
    {
        public GestionHoteleraContext(DbContextOptions<GestionHoteleraContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Habitacion> Habitaciones { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<LogError> LogError { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.HasOne(e => e.Cliente)
                       .WithMany(c => c.Reservas)
                       .HasForeignKey(e => e.ClienteId)
                       .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Habitacion)
                      .WithMany(h => h.Reservas)
                      .HasForeignKey(e => e.HabitacionId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.PrecioPorNoche).HasPrecision(18, 2);
                entity.Property(e => e.PrecioTotal).HasPrecision(18, 2);
                entity.Property(e => e.MontoFinal).HasPrecision(18, 2);
                entity.Property(e => e.CodigoConfirmacion).IsRequired().HasMaxLength(20);

                entity.HasIndex(e => e.CodigoConfirmacion).IsUnique();
                entity.HasIndex(e => new { e.HabitacionId, e.FechaCheckIn, e.FechaCheckOut });

            });

            modelBuilder.Entity<LogError>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Mensaje).IsRequired().HasMaxLength(500);
                entity.Property(e => e.StackTrace).HasMaxLength(4000);
                entity.Property(e => e.InnerException).HasMaxLength(2000);
                entity.Property(e => e.TipoError).HasMaxLength(200);
                entity.Property(e => e.Controlador).HasMaxLength(100);
                entity.Property(e => e.Accion).HasMaxLength(100);
                entity.Property(e => e.Endpoint).HasMaxLength(500);
                entity.Property(e => e.MetodoHttp).HasMaxLength(10);
                entity.Property(e => e.DireccionIP).HasMaxLength(45); // IPv6

                // Índices para búsqueda rápida
                entity.HasIndex(e => e.FechaHora);
                entity.HasIndex(e => e.Nivel);
                entity.HasIndex(e => e.UsuarioId);
                entity.HasIndex(e => e.Resuelto);
            });

        }
    }
}
