using GestionHotelera.Dominio.Entidades;

namespace GestionHotelera.Repositorios.Interfaz
{
    public interface ILogErrorRepository
    {
        Task<LogError> Crear(LogError logError);
        Task<IEnumerable<LogError>> ObtenerTodos(int limite = 100);
        Task<IEnumerable<LogError>> ObtenerPorFecha(DateTime fechaInicio, DateTime fechaFin);
        Task<IEnumerable<LogError>> ObtenerPorNivel(NivelSeveridad nivel);
        Task<IEnumerable<LogError>> ObtenerNoResueltos();
        Task<bool> MarcarComoResuelto(int id, string notasResolucion);
        Task<int> ContarErroresPorFecha(DateTime fecha);
        Task<bool> LimpiarErroresAntiguos(int dias = 30);
    }
}
