using System;
using System.Threading.Tasks;
// Importamos los namespaces de las interfaces de repositorios
using Gestion_vuelos.src.Modules.Paises.Domain.Interfaces;
using Gestion_vuelos.src.Modules.Ciudades.Domain.Interfaces;
using Gestion_vuelos.src.Modules.Aerolineas.Domain.Interfaces;
using Gestion_vuelos.src.Modules.Aeropuertos.Domain.Interfaces;
using Gestion_vuelos.src.Modules.Clientes.Domain.Interfaces;
using Gestion_vuelos.src.Modules.Vuelos.Domain.Interfaces;
using Gestion_vuelos.src.Modules.Reservas.Domain.Interfaces;
using Gestion_vuelos.src.Modules.Pagos.Domain.Interfaces;
using Gestion_vuelos.src.Modules.Usuarios.Domain.Interfaces;

namespace Gestion_vuelos.Shared.Contracts;

public interface IUnitOfWork : IDisposable
{
    // --- 1. Maestros y Geografía ---
    IPaisRepository Paises { get; }
    ICiudadRepository Ciudades { get; }
    ITipoDocumentoRepository TiposDocumento { get; }
    IRolRepository Roles { get; }

    // --- 2. Aeronáutica ---
    IAerolineaRepository Aerolineas { get; }
    IAeropuertoRepository Aeropuertos { get; }

    // --- 3. Clientes y Contacto ---
    IClienteRepository Clientes { get; }
    IClienteEmailRepository ClientesEmails { get; }
    IClienteTelefonoRepository ClientesTelefonos { get; }

    // --- 4. Vuelos ---
    IVueloRepository Vuelos { get; }
    IAsientoVueloRepository AsientosVuelo { get; }
    IEstadoVueloRepository EstadosVuelo { get; }

    // --- 5. Reservas y Pasajeros ---
    IReservaRepository Reservas { get; }
    IPasajeroRepository Pasajeros { get; }
    IReservaPasajeroRepository ReservasPasajeros { get; }

    // --- 6. Tiquetes ---
    ITiqueteRepository Tiquetes { get; }

    // --- 7. Pagos y Finanzas ---
    IPagoRepository Pagos { get; }
    IMetodoPagoRepository MetodosPago { get; }

    // --- 8. Seguridad ---
    IUsuarioRepository Usuarios { get; }
    IUsuarioRolRepository UsuariosRoles { get; }

    /// <summary>
    /// Guarda todos los cambios realizados en el contexto de la base de datos 
    /// dentro de una única transacción.
    /// </summary>
    Task<int> SaveAsync();
}