using GestionHotelera.Dominio.Entidades;
using GestionHotelera.Infraestructura.Data;
using GestionHotelera.Repositorios.Interfaz;
using Microsoft.EntityFrameworkCore;

namespace GestionHotelera.Repositorios.Dominio
{
    public class ClienteRepositoryImpl : IClienteRepository
    {

        private readonly GestionHoteleraContext _context;

        public ClienteRepositoryImpl(GestionHoteleraContext context)
        {
            _context = context;
        }


        public async Task<Cliente> Actualizar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<IEnumerable<Cliente>> BuscarPorNombre(string nombre)
        {
            var cliente = await _context.Clientes
                .Where(c => (c.PrimerNombre + " " + c.SegundoNombre + " " + c.PrimerApellido + " " + c.SegundoApellido).Contains(nombre))
                .ToListAsync();
            return cliente;
        }

        public async Task<bool> CambiarEstado(int id, bool activo)
        {
            try
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

                if (cliente == null)
                {
                    return false;
                }

                if (cliente.EstaActivo == activo)
                {
                    return true;
                }

                cliente.EstaActivo = activo;
                cliente.FechaUltimaModificacion = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al cambiar el estado del cliente", ex);
            }
        }

        public async Task<Cliente> Crear(Cliente cliente)
        {
            var existeEmail = await ExisteCorreo(cliente.CorreoElectronico);

            if (existeEmail)
            {
                throw new Exception("El correo electrónico ya está registrado.");
            }
            var existeDocumento = await ExisteDocumento(cliente.NumeroDocumento);

            if (existeDocumento)
            {
                throw new Exception("El número de documento ya está registrado.");
            }

            cliente.FechaRegistro = DateTime.UtcNow;
            cliente.EstaActivo = true;
            cliente.EmailVerificado = false;

            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();

            return cliente;

        }



        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExisteCorreo(string correoElectronico)
        {
            return _context.Clientes.AnyAsync(c => c.CorreoElectronico == correoElectronico);
            
        }

        public Task<bool> ExisteDocumento(string numeroDocumento)
        {
            return _context.Clientes.AnyAsync(c => c.NumeroDocumento == numeroDocumento);
        }

        public Task<(IEnumerable<Cliente> clientes, int total)> ListarTodosPaginado(int pagina, int registrosPorPagina)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente?> ObtenerConReservas(int idCliente)
        {
            return await _context.Clientes.Include(c => c.Reservas)
                .FirstOrDefaultAsync(c => c.Id == idCliente);
        }

        public async Task<Cliente?> ObtenerPorCorreo(string correoElectronico)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.CorreoElectronico == correoElectronico);
        }

        public async Task<Cliente?> ObtenerPorDocumento(string numeroDocumento)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.NumeroDocumento == numeroDocumento);
        }

        public async Task<Cliente?> ObtenerPorId(int id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
