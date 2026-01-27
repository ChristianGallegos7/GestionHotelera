using GestionHotelera.Dominio.DTOs;
using GestionHotelera.Dominio.Entidades;
using GestionHotelera.Dominio.Mappers;
using GestionHotelera.Negocio.Interfaz;
using GestionHotelera.Repositorios.Interfaz;
namespace GestionHotelera.Negocio.Dominio
{
    public class ClienteNegocioImpl : IClienteNegocio
    {

        private readonly IClienteRepository _repository;

        public ClienteNegocioImpl(IClienteRepository repository)
        {
            _repository = repository;
        }


        public async Task<ClienteDto> Actualizar(ClienteDto clienteDto)
        {
           var cliente = clienteDto.ToEntity();
            
            cliente.FechaUltimaModificacion = DateTime.UtcNow;

            var clienteActualizado = await _repository.Actualizar(cliente);

            return clienteActualizado.ToDto();

        }

        public async Task<ClienteDto> Crear(ClienteDto clienteDto)
        {
            var cliente = clienteDto.ToEntity();
            cliente.FechaRegistro = DateTime.UtcNow;
            var clienteCreado = await _repository.Crear(cliente);
            return clienteCreado.ToDto();
        }

        public async Task<ClienteDto?> ObtenerPorId(int id)
        {
            return (await _repository.ObtenerPorId(id))?.ToDto();
        }
    }
}
