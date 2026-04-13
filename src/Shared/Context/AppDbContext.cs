using Microsoft.EntityFrameworkCore;
using GestionVuelos.Models.Paises.Domain.Aggregate;
using GestionVuelos.Models.Ciudades.Domain.Aggregate;
using GestionVuelos.Models.TipoDocumento.Domain.Aggregate;
using GestionVuelos.Models.Roles.Domain.Aggregate;
using GestionVuelos.Models.Aerolineas.Domain.Aggregate;
using GestionVuelos.Models.Aeropuertos.Domain.Aggregate;
using GestionVuelos.Models.Clientes.Domain.Aggregate;
using GestionVuelos.Models.DominioEmail.Domain.Aggregate;
using GestionVuelos.Models.CodigoTelefono.Domain.Aggregate;
using GestionVuelos.Models.ClienteEmails.Domain.Aggregate;
using GestionVuelos.Models.ClienteTelefonos.Domain.Aggregate;
using GestionVuelos.Models.EstadoVuelo.Domain.Aggregate;
using GestionVuelos.Models.Vuelos.Domain.Aggregate;
using GestionVuelos.Models.AsientosVuelo.Domain.Aggregate;
using GestionVuelos.Models.Pasajero.Domain.Aggregate;
using GestionVuelos.Models.ReservaPasajero.Domain.Aggregate;
using GestionVuelos.Models.EstadoTiquete.Domain.Aggregate;
using GestionVuelos.Models.Tiquete.Domain.Aggregate;
using GestionVuelos.Models.EstadoPago.Domain.Aggregate;
using GestionVuelos.Models.TipoMedioPago.Domain.Aggregate;
using GestionVuelos.Models.TipoTarjeta.Domain.Aggregate;
using GestionVuelos.Models.EmisorTarjeta.Domain.Aggregate;
using GestionVuelos.Models.MetodoPago.Domain.Aggregate;
using GestionVuelos.Models.Pago.Domain.Aggregate;
using GestionVuelos.Models.Usuario.Domain.Aggregate;
using GestionVuelos.Models.UsuarioRol.Domain.Aggregate;


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