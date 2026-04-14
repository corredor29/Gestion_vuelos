using Gestion_vuelos.src.Modules.Airports.Domain.Aggregate;
using Gestion_vuelos.src.Modules.Airports.Domain.ValueObject;

namespace Gestion_vuelos.src.Modules.Airports.Domain.Repositories;

public interface IAirportRepository
{
    Task<Airport?> GetByIdAsync(AirportId id, CancellationToken cancellationToken = default);
    Task<Airport?> GetByIataCodeAsync(AirportIataCode iataCode, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Airport>> GetAllAsync(CancellationToken cancellationToken = default);

    Task AddAsync(Airport airport, CancellationToken cancellationToken = default);
    Task UpdateAsync(Airport airport, CancellationToken cancellationToken = default);
    Task DeleteAsync(Airport airport, CancellationToken cancellationToken = default);
}