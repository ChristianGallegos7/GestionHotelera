using GestionHotelera.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GestionHotelera.Infraestructura.Data
{
    public class GestionHoteleraContext : DbContext
    {
        public GestionHoteleraContext(DbContextOptions<GestionHoteleraContext> options) : base(options)
        {

        }

        DbSet<Cliente> Clientes { get; set; }

        DbSet<Habitacion> Habitaciones { get; set; }

        DbSet<Reserva> Reservas { get; set; }

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
        }
    }
}
