# Fase 1
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app

EXPOSE 80
EXPOSE 8080
EXPOSE 8081

ENV ASPNETCORE_URLS=http://+:8080

# Fase 2

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY ["GestionHotelera.Api.csproj", "."]
COPY ["DOMAIN/GestionHotelera.Dominio.DTOs/GestionHotelera.Dominio.DTOs.csproj","DOMAIN/GestionHotelera.Dominio.DTOs/"]

COPY ["DOMAIN/GestionHotelera.Dominio.Entidades/GestionHotelera.Dominio.Entidades.csproj","DOMAIN/GestionHotelera.Dominio.Entidades/"]

COPY ["INFRAESTRUCTURA/GestionHotelera.Infraestructura.Datos/GestionHotelera.Infraestructura.Datos.csproj","INFRAESTRUCTURA/GestionHotelera.Infraestructura.Datos/"]


RUN dotnet restore "./GestionHotelera.Api.csproj"

COPY . .

WORKDIR "/src/."

RUN dotnet build "./GestionHotelera.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GestionHotelera.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GestionHotelera.Api.dll"]