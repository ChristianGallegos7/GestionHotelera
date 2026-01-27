using GestionHotelera.Dominio.DTOs;
using GestionHotelera.Dominio.Entidades;

namespace GestionHotelera.Dominio.Mappers
{
    public static class ClienteMapper
    {
        public static Cliente ToEntity(this ClienteDto dto) => new Cliente
        { 
            Id = dto.Id,
            ClaveHash = dto.ClaveHash,
            CorreoElectronico = dto.CorreoElectronico,
            EmailVerificado = dto.EmailVerificado,
            EstaActivo = dto.EstaActivo,
            FechaNacimiento = dto.FechaNacimiento,
            FechaRegistro = dto.FechaRegistro,
            FechaUltimaModificacion = dto.FechaUltimaModificacion,
            NumeroDocumento = dto.NumeroDocumento,
            PrimerApellido = dto.PrimerApellido,
            PrimerNombre = dto.PrimerNombre,
            Reservas = new List<Reserva>(),
            SegundoApellido = dto.SegundoApellido,
            SegundoNombre = dto.SegundoNombre,
            Telefono = dto.Telefono,
            TipoDocumento = Enum.Parse<TipoDocumento>(dto.TipoDocumento),
            TokenVerificacionEmail = dto.TokenVerificacionEmail
        };  

        public static ClienteDto ToDto(this Cliente entity) => new ClienteDto
        {
            Id =  entity.Id,
            ClaveHash = entity.ClaveHash,
            CorreoElectronico = entity.CorreoElectronico,
            EmailVerificado = entity.EmailVerificado,
            EstaActivo = entity.EstaActivo,
            FechaNacimiento = entity.FechaNacimiento,
            FechaRegistro = entity.FechaRegistro,
            FechaUltimaModificacion = entity.FechaUltimaModificacion,
            NumeroDocumento = entity.NumeroDocumento,
            PrimerApellido = entity.PrimerApellido,
            PrimerNombre = entity.PrimerNombre,
            SegundoApellido = entity.SegundoApellido,
            SegundoNombre = entity.SegundoNombre,
            Telefono = entity.Telefono,
            TipoDocumento = entity.TipoDocumento.ToString(),
            TokenVerificacionEmail = entity.TokenVerificacionEmail
        };
    }
}
