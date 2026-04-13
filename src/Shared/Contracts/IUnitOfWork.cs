using System;
using System.Threading.Tasks;
// Importamos los namespaces de las interfaces de repositorios
using GestionVuelos.Modules.Paises.Domain.Interfaces;
using GestionVuelos.Modules.Ciudades.Domain.Interfaces;
using GestionVuelos.Modules.Aerolineas.Domain.Interfaces;
using GestionVuelos.Modules.Aeropuertos.Domain.Interfaces;
using GestionVuelos.Modules.Clientes.Domain.Interfaces;
using GestionVuelos.Modules.Vuelos.Domain.Interfaces;
using GestionVuelos.Modules.Reservas.Domain.Interfaces;
using GestionVuelos.Modules.Pagos.Domain.Interfaces;
using GestionVuelos.Modules.Usuarios.Domain.Interfaces;

namespace GestionVuelos.Shared.Contracts;

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