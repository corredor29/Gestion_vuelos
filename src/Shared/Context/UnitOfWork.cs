using System;
using System.Threading.Tasks;
using Gestion_vuelos.Shared.Contracts;

// Importamos las implementaciones de los repositorios

namespace Gestion_vuelos.Shared.Context;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    // Campos privados para Lazy Loading
    private IPaisRepository _paises;
    private ICiudadRepository _ciudades;
    private ITipoDocumentoRepository _tiposDocumento;
    private IRolRepository _roles;
    private IAerolineaRepository _aerolineas;
    private IAeropuertoRepository _aeropuertos;
    private IClienteRepository _clientes;
    private IClienteEmailRepository _clientesEmails;
    private IClienteTelefonoRepository _clientesTelefonos;
    private IVueloRepository _vuelos;
    private IAsientoVueloRepository _asientosVuelo;
    private IEstadoVueloRepository _estadosVuelo;
    private IReservaRepository _reservas;
    private IPasajeroRepository _pasajeros;
    private IReservaPasajeroRepository _reservasPasajeros;
    private ITiqueteRepository _tiquetes;
    private IPagoRepository _pagos;
    private IMetodoPagoRepository _metodosPago;
    private IUsuarioRepository _usuarios;
    private IUsuarioRolRepository _usuariosRoles;

    public UnitOfWork(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    // --- Implementación de Propiedades ---

    public IPaisRepository Paises => _paises ??= new PaisRepository(_context);
    public ICiudadRepository Ciudades => _ciudades ??= new CiudadRepository(_context);
    public ITipoDocumentoRepository TiposDocumento => _tiposDocumento ??= new TipoDocumentoRepository(_context);
    public IRolRepository Roles => _roles ??= new RolRepository(_context);

    public IAerolineaRepository Aerolineas => _aerolineas ??= new AerolineaRepository(_context);
    public IAeropuertoRepository Aeropuertos => _aeropuertos ??= new AeropuertoRepository(_context);

    public IClienteRepository Clientes => _clientes ??= new ClienteRepository(_context);
    public IClienteEmailRepository ClientesEmails => _clientesEmails ??= new ClienteEmailRepository(_context);
    public IClienteTelefonoRepository ClientesTelefonos => _clientesTelefonos ??= new ClienteTelefonoRepository(_context);

    public IVueloRepository Vuelos => _vuelos ??= new VueloRepository(_context);
    public IAsientoVueloRepository AsientosVuelo => _asientosVuelo ??= new AsientoVueloRepository(_context);
    public IEstadoVueloRepository EstadosVuelo => _estadosVuelo ??= new EstadoVueloRepository(_context);

    public IReservaRepository Reservas => _reservas ??= new ReservaRepository(_context);
    public IPasajeroRepository Pasajeros => _pasajeros ??= new PasajeroRepository(_context);
    public IReservaPasajeroRepository ReservasPasajeros => _reservasPasajeros ??= new ReservaPasajeroRepository(_context);

    public ITiqueteRepository Tiquetes => _tiquetes ??= new TiqueteRepository(_context);

    public IPagoRepository Pagos => _pagos ??= new PagoRepository(_context);
    public IMetodoPagoRepository MetodosPago => _metodosPago ??= new MetodoPagoRepository(_context);

    public IUsuarioRepository Usuarios => _usuarios ??= new UsuarioRepository(_context);
    public IUsuarioRolRepository UsuariosRoles => _usuariosRoles ??= new UsuarioRolRepository(_context);

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}