using Microsoft.EntityFrameworkCore;
using Gestion_vuelos.src.Modules.Paises.infrastructure.Entity;
using Gestion_vuelos.src.Modules.Ciudades.infrastructure.Entity;
using Gestion_vuelos.src.Modules.TipoDocumento.infrastructure.Entity;
using Gestion_vuelos.src.Modules.Roles.infrastructure.Entity;
using Gestion_vuelos.src.Modules.Aerolineas.infrastructure.Entity;
using Gestion_vuelos.src.Modules.Aeropuertos.infrastructure.Entity;
using Gestion_vuelos.src.Modules.Clientes.infrastructure.Entity;
using Gestion_vuelos.src.Modules.DominioEmail.infrastructure.Entity;
using Gestion_vuelos.src.Modules.CodigoTelefono.infrastructure.Entity;
using Gestion_vuelos.src.Modules.ClienteEmails.infrastructure.Entity;
using Gestion_vuelos.src.Modules.ClienteTelefonos.infrastructure.Entity;
using Gestion_vuelos.src.Modules.EstadoVuelo.infrastructure.Entity;
using Gestion_vuelos.src.Modules.Vuelos.infrastructure.Entity;
using Gestion_vuelos.src.Modules.AsientosVuelo.infrastructure.Entity;
using Gestion_vuelos.src.Modules.Pasajero.infrastructure.Entity;
using Gestion_vuelos.src.Modules.ReservaPasajero.infrastructure.Entity;
using Gestion_vuelos.src.Modules.EstadoTiquete.infrastructure.Entity;
using Gestion_vuelos.src.Modules.Tiquete.infrastructure.Entity;
using Gestion_vuelos.src.Modules.EstadoPago.infrastructure.Entity;
using Gestion_vuelos.src.Modules.TipoMedioPago.infrastructure.Entity;
using Gestion_vuelos.src.Modules.TipoTarjeta.infrastructure.Entity;
using Gestion_vuelos.src.Modules.EmisorTarjeta.infrastructure.Entity;
using Gestion_vuelos.src.Modules.MetodoPago.infrastructure.Entity;
using Gestion_vuelos.src.Modules.Pago.infrastructure.Entity;
using Gestion_vuelos.src.Modules.Usuario.infrastructure.Entity;
using Gestion_vuelos.src.Modules.UsuarioRol.infrastructure.Entity;                   
using Gestion_vuelos.src.Modules.DominioEmail.infrastructure.Entity;
using Gestion_vuelos.src.Modules.CodigoTelefono.infrastructure.Entity;
using Gestion_vuelos.src.Modules.ClienteEmails.infrastructure.Entity;
using Gestion_vuelos.src.Modules.ClienteTelefonos.infrastructure.Entity;
using Gestion_vuelos.src.Modules.EstadoVuelo.infrastructure.Entity;
using Gestion_vuelos.src.Modules.Vuelos.infrastructure.Entity;
using Gestion_vuelos.src.Modules.AsientosVuelo.infrastructure.Entity;
using Gestion_vuelos.src.Modules.Pasajero.infrastructure.Entity;
using Gestion_vuelos.src.Modules.ReservaPasajero.infrastructure.Entity;
using Gestion_vuelos.src.Modules.EstadoTiquete.infrastructure.Entity;
using Gestion_vuelos.src.Modules.Tiquete.infrastructure.Entity;
using Gestion_vuelos.src.Modules.EstadoPago.infrastructure.Entity;
using Gestion_vuelos.src.Modules.TipoMedioPago.infrastructure.Entity;
using Gestion_vuelos.src.Modules.TipoTarjeta.infrastructure.Entity;
using Gestion_vuelos.src.Modules.EmisorTarjeta.infrastructure.Entity;
using Gestion_vuelos.src.Modules.MetodoPago.infrastructure.Entity;
using Gestion_vuelos.src.Modules.Pago.infrastructure.Entity;
using Gestion_vuelos.src.Modules.Usuario.infrastructure.Entity;
using Gestion_vuelos.src.Modules.UsuarioRol.infrastructure.Entity;


namespace Gestion_vuelos.Shared.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

/*    // 1. Geografía y Maestros
    public DbSet<Pais> Paises { get; set; }
    public DbSet<Ciudad> Ciudades { get; set; }
    public DbSet<TipoDocumento> TiposDocumento { get; set; }
    public DbSet<Rol> Roles { get; set; }

    // 2. Aeronáutica
    public DbSet<Aerolinea> Aerolineas { get; set; }
    public DbSet<Aeropuerto> Aeropuertos { get; set; }

    // 3. Clientes y Contacto
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<DominioEmail> DominiosEmail { get; set; }
    public DbSet<CodigoTelefono> CodigosTelefono { get; set; }
    public DbSet<ClienteEmail> ClientesEmails { get; set; }
    public DbSet<ClienteTelefono> ClientesTelefonos { get; set; }

    // 4. Vuelos y Asientos
    public DbSet<EstadoVuelo> EstadosVuelo { get; set; }
    public DbSet<Vuelo> Vuelos { get; set; }
    public DbSet<AsientoVuelo> AsientosVuelo { get; set; }

    // 5. Pasajeros y Reservas
    public DbSet<Pasajero> Pasajeros { get; set; }
    public DbSet<EstadoReserva> EstadosReserva { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<ReservaPasajero> ReservasPasajeros { get; set; }

    // 6. Tiquetes
    public DbSet<EstadoTiquete> EstadosTiquete { get; set; }
    public DbSet<Tiquete> Tiquetes { get; set; }

    // 7. Pagos y Finanzas
    public DbSet<EstadoPago> EstadosPago { get; set; }
    public DbSet<TipoMedioPago> TiposMedioPago { get; set; }
    public DbSet<TipoTarjeta> TiposTarjeta { get; set; }
    public DbSet<EmisorTarjeta> EmisoresTarjeta { get; set; }
    public DbSet<MetodoPago> MetodosPago { get; set; }
    public DbSet<Pago> Pagos { get; set; }

    // 8. Usuarios
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<UsuarioRol> UsuariosRoles { get; set; }*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Aplica todas las configuraciones de la carpeta infrastructure/Entity
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}