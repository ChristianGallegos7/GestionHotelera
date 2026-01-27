using GestionHotelera.Dominio.DTOs;

namespace GestionHotelera.Negocio.Interfaz
{
    public interface IClienteNegocio
    {
        Task<ClienteDto?> ObtenerPorId(int id);
        Task<ClienteDto> Crear(ClienteDto clienteDto);
        Task<ClienteDto> Actualizar(ClienteDto clienteDto);
    }
}
