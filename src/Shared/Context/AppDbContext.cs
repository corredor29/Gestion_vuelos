using Microsoft.EntityFrameworkCore;
using Gestion_vuelos.src.Modules.Paises.infrastructure.Entity;
using Gestion_vuelos.src.Modules.Ciudades.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.TipoDocumento.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.Roles.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.Aerolineas.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.Aeropuertos.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.Clientes.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.DominioEmail.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.CodigoTelefono.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.ClienteEmails.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.ClienteTelefonos.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.EstadoVuelo.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.Vuelos.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.AsientosVuelo.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.Pasajero.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.ReservaPasajero.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.EstadoTiquete.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.Tiquete.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.EstadoPago.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.TipoMedioPago.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.TipoTarjeta.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.EmisorTarjeta.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.MetodoPago.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.Pago.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.Usuario.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.UsuarioRol.Infraestructure.Entity;                   
using Gestion_vuelos.src.Modules.DominioEmail.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.CodigoTelefono.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.ClienteEmails.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.ClienteTelefonos.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.EstadoVuelo.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.Vuelos.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.AsientosVuelo.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.Pasajero.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.ReservaPasajero.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.EstadoTiquete.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.Tiquete.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.EstadoPago.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.TipoMedioPago.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.TipoTarjeta.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.EmisorTarjeta.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.MetodoPago.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.Pago.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.Usuario.Infraestructure.Entity;
using Gestion_vuelos.src.Modules.UsuarioRol.Infraestructure.Entity;


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