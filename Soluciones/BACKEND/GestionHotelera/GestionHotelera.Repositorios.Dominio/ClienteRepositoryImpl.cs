using GestionHotelera.Dominio.Entidades;
using GestionHotelera.Repositorios.Interfaz;

namespace GestionHotelera.Repositorios.Dominio
{
    public class ClienteRepositoryImpl : IClienteRepository
    {


        public Task<bool> Activar()
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> Actualizar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> BuscarPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> Crear(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Desactivar()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExisteCorreo(string correoElectronico)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExisteDocumento(string numeroDocumento)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<Cliente> clientes, int total)> ListarTodosPaginado(int pagina, int registrosPorPagina)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente?> ObtenerConReservas(int idCliente)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente?> ObtenerPorCorreo(string correoElectronico)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente?> ObtenerPorDocumento(string numeroDocumento)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente?> ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
