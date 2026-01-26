using GestionHotelera.Dominio.Entidades;
using GestionHotelera.Infraestructura.Data;
using GestionHotelera.Repositorios.Interfaz;
using Microsoft.EntityFrameworkCore;

namespace GestionHotelera.Repositorios.Dominio
{
    public class LogErrorRepositoryImpl : ILogErrorRepository
    {
        private readonly GestionHoteleraContext _context;

        public LogErrorRepositoryImpl(GestionHoteleraContext context)
        {
            _context = context;
        }

        public async Task<LogError> Crear(LogError logError)
        {
            _context.LogError.Add(logError);
            await _context.SaveChangesAsync();
            return logError;
        }

        public async Task<IEnumerable<LogError>> ObtenerTodos(int limite = 100)
        {
            return await _context.LogError
                .OrderByDescending(l => l.FechaHora)
                .Take(limite)
                .ToListAsync();
        }

        public async Task<IEnumerable<LogError>> ObtenerPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _context.LogError
                .Where(l => l.FechaHora >= fechaInicio && l.FechaHora <= fechaFin)
                .OrderByDescending(l => l.FechaHora)
                .ToListAsync();
        }

        public async Task<IEnumerable<LogError>> ObtenerPorNivel(NivelSeveridad nivel)
        {
            return await _context.LogError
                .Where(l => l.Nivel == nivel)
                .OrderByDescending(l => l.FechaHora)
                .Take(100)
                .ToListAsync();
        }

        public async Task<IEnumerable<LogError>> ObtenerNoResueltos()
        {
            return await _context.LogError
                .Where(l => !l.Resuelto)
                .OrderByDescending(l => l.FechaHora)
                .ToListAsync();
        }

        public async Task<bool> MarcarComoResuelto(int id, string notasResolucion)
        {
            var log = await _context.LogError.FindAsync(id);

            if (log == null)
                return false;

            log.Resuelto = true;
            log.FechaResolucion = DateTime.UtcNow;
            log.NotasResolucion = notasResolucion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> ContarErroresPorFecha(DateTime fecha)
        {
            return await _context.LogError
                .CountAsync(l => l.FechaHora.Date == fecha.Date);
        }

        public async Task<bool> LimpiarErroresAntiguos(int dias = 30)
        {
            var fechaLimite = DateTime.UtcNow.AddDays(-dias);

            var erroresAntiguos = await _context.LogError
                .Where(l => l.FechaHora < fechaLimite && l.Resuelto)
                .ToListAsync();

            _context.LogError.RemoveRange(erroresAntiguos);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
