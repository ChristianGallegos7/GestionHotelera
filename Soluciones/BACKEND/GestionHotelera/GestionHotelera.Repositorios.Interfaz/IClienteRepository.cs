using GestionHotelera.Dominio.Entidades;

namespace GestionHotelera.Repositorios.Interfaz
{
    public interface IClienteRepository
    {
        Task<(IEnumerable<Cliente> clientes, int total)> ListarTodosPaginado(int pagina, int registrosPorPagina);

        Task<Cliente?> ObtenerPorId(int id);
        Task<Cliente> Crear(Cliente cliente);

        Task<Cliente> Actualizar(Cliente cliente);
        Task<bool> Eliminar(int id);

        Task<Cliente?> ObtenerPorCorreo(string correoElectronico);
        Task<Cliente?> ObtenerPorDocumento(string numeroDocumento);
        Task<bool> ExisteCorreo(string correoElectronico);

        Task<bool> ExisteDocumento(string numeroDocumento);

        Task<IEnumerable<Cliente>> BuscarPorNombre(string nombre);

        Task<Cliente?> ObtenerConReservas(int idCliente);

        Task<bool> Desactivar();

        Task<bool> Activar();
    }
}
