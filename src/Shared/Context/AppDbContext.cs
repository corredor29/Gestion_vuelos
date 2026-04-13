using Microsoft.EntityFrameworkCore;
using GestionVuelos.Modules.Paises.Domain.Aggregate;
using GestionVuelos.Modules.Ciudades.Domain.Aggregate;
using GestionVuelos.Modules.TipoDocumento.Domain.Aggregate;
using GestionVuelos.Modules.Roles.Domain.Aggregate;
using GestionVuelos.Modules.Aerolineas.Domain.Aggregate;
using GestionVuelos.Modules.Aeropuertos.Domain.Aggregate;
using GestionVuelos.Modules.Clientes.Domain.Aggregate;
using GestionVuelos.Modules.DominioEmail.Domain.Aggregate;
using GestionVuelos.Modules.CodigoTelefono.Domain.Aggregate;
using GestionVuelos.Modules.ClienteEmails.Domain.Aggregate;
using GestionVuelos.Modules.ClienteTelefonos.Domain.Aggregate;
using GestionVuelos.Modules.EstadoVuelo.Domain.Aggregate;
using GestionVuelos.Modules.Vuelos.Domain.Aggregate;
using GestionVuelos.Modules.AsientosVuelo.Domain.Aggregate;
using GestionVuelos.Modules.Pasajero.Domain.Aggregate;
using GestionVuelos.Modules.ReservaPasajero.Domain.Aggregate;
using GestionVuelos.Modules.EstadoTiquete.Domain.Aggregate;
using GestionVuelos.Modules.Tiquete.Domain.Aggregate;
using GestionVuelos.Modules.EstadoPago.Domain.Aggregate;
using GestionVuelos.Modules.TipoMedioPago.Domain.Aggregate;
using GestionVuelos.Modules.TipoTarjeta.Domain.Aggregate;
using GestionVuelos.Modules.EmisorTarjeta.Domain.Aggregate;
using GestionVuelos.Modules.MetodoPago.Domain.Aggregate;
using GestionVuelos.Modules.Pago.Domain.Aggregate;
using GestionVuelos.Modules.Usuario.Domain.Aggregate;
using GestionVuelos.Modules.UsuarioRol.Domain.Aggregate;


namespace GestionVuelos.Shared.Context;

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